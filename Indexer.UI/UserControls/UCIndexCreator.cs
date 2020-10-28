using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Indexer.Core;

namespace Indexer.UI.UserControls
{
    public partial class UCIndexCreator : UserControl
    {
        public UCIndexCreator()
        {
            InitializeComponent();
        }
        public FileWatcher TheWatcher { get; set; }
        private void UCIndexCreator_Load(object sender, EventArgs e)
        {
            LoadTreeView();

            TheWatcher = new FileWatcher();
            //Apply previous treeview state (expand and checked)
            TreeViewState tvState = TreeViewExtensions.DeserializeTreeViewState();
            if (tvState != null)
            {
                treeViewFolders.BeginUpdate();

                // Once it is populated, we need to restore expanded nodes
                treeViewFolders.Nodes.SetExpansionState(tvState.ExpandedList);
                treeViewFolders.Nodes.SetCheckedState(tvState.CheckedList);

                //Integrate filewatcher to get notification on file modifications based on previous folder selection

                TheWatcher.RefreshWatchers();
                TheWatcher.OnFileChange += Fw_OnFileChange;
                TheWatcher.ConfigureFileWatcher(tvState.CheckedList);

                treeViewFolders.EndUpdate();
            }
            GetCheckedNodes(treeViewFolders.Nodes);
        }

        private void LoadTreeView()
        {

            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
               
                //Only consider fixed disks.
                if (di.DriveType ==DriveType.Fixed)
                {
                    TreeNode node = new TreeNode(drive.Substring(0, 1), 0, 0);
                    node.Tag = drive;

                    if (di.IsReady == true)
                        node.Nodes.Add("...");

                    treeViewFolders.Nodes.Add(node);
                }
            }
        }
        private void treeViewFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());
                    
                    foreach (string dir in dirs)
                    {
                       
                        DirectoryInfo di = new DirectoryInfo(dir);

                        //skip hidden directories
                        if (!di.Attributes.HasFlag(FileAttributes.Hidden))
                        {
                            TreeNode node = new TreeNode(di.Name, 1, 1);

                            try
                            {
                                //keep the directory's full path in the tag for use later
                                node.Tag = dir;
                                
                                //if the directory has sub directories add the place holder
                                if (di.GetDirectories().Count() > 0)
                                    node.Nodes.Add(null, "...", 1, 1);
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                Logger.Log(ex);
                            }
                            catch (Exception ex)
                            {
                                Logger.Log(ex);
                            }
                            finally
                            {
                                e.Node.Nodes.Add(node);
                            }
                        }
                    }
                }
            }
        }

        private List<string> selectedFolders=new List<string>();
        //recursive function to get selected folders
        private void GetCheckedNodes(TreeNodeCollection nodes)
        {
            foreach (System.Windows.Forms.TreeNode aNode in nodes)
            {
                if (aNode.Checked && aNode.Tag!=null && aNode.Tag.ToString()!="")
                    selectedFolders.Add(aNode.Tag.ToString());

                if (aNode.Nodes.Count != 0)
                    GetCheckedNodes(aNode.Nodes);
            }

        }

        private void btnCreateIndex_Click(object sender, EventArgs e)
        {
            selectedFolders.Clear();
            GetCheckedNodes(treeViewFolders.Nodes);

            if(selectedFolders.Count<=0)
            {
                MessageBox.Show("No folders selected !");
                return;
            }
            //keep treeview state
            TreeViewState obj = new TreeViewState();
            obj.ExpandedList = treeViewFolders.Nodes.GetExpansionState();
            obj.CheckedList = treeViewFolders.Nodes.GetCheckedState();
            TreeViewExtensions.SerializeTreeViewState(obj);

           

            //Integrate filewatcher to get notification on file modifications.
            TheWatcher.RefreshWatchers();
            TheWatcher.OnFileChange += Fw_OnFileChange;
            TheWatcher.ConfigureFileWatcher(selectedFolders);

            CreateIndex();

            //MessageBox.Show("Index Creation Completed");
        }
        private void CreateIndex()
        {
            Application.UseWaitCursor = true;
            Indexer.Core.Indexer objIndexer = new Indexer.Core.Indexer(selectedFolders);
            objIndexer.CreateIndex(selectedFolders);
            Indexer.Core.Indexer.SerializeIndex();

            Application.UseWaitCursor = false;
            
        }

        private void Fw_OnFileChange(object sender, object e)
        {
            CreateIndex();
        }

        private void ObjIndexer_OnProgress(object sender, object e)
        {

            
        }
    }
}
