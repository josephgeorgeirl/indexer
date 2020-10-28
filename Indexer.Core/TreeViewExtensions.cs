using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indexer.Core
{
    public static class TreeViewExtensions
    {

        //to keep treeview expansion/checked state even after closing application.

        public static List<string> GetExpansionState(this TreeNodeCollection nodes)
        {
            List<string> result = new List<string>();
            try
            {
                result= nodes.Descendants()
                       .Where(n => n.IsExpanded)
                       .Select(n => n.FullPath)
                       .ToList();
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
            return result;

        }
        public static List<string> GetCheckedState(this TreeNodeCollection nodes)
        {
            List<string> result = new List<string>();
            try
            {
                result= nodes.Descendants()
                       .Where(n => n.Checked)
                       .Select(n => n.Tag.ToString())
                       .ToList();
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }

            return result;
         
        }

        public static void SetExpansionState(this TreeNodeCollection nodes, List<string> savedExpansionState)
        {
            try
            {
                foreach (var node in nodes.Descendants()
                                     .Where(n => savedExpansionState.Contains(n.FullPath)))
                {
                    node.Expand();
                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
           
        }

        public static void SetCheckedState(this TreeNodeCollection nodes, List<string> savedCheckedState)
        {
            try
            {
                foreach (var node in nodes.Descendants())
                                      //.Where(n => savedCheckedState.Contains(n.Tag.ToString())))
                {
                    if(node.Tag!=null && savedCheckedState.Contains(node.Tag.ToString()))
                    {
                        node.Checked = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
            
        }

        public static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
        {
            foreach (var node in c.OfType<TreeNode>())
            {
                yield return node;

                foreach (var child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }

        public static void SerializeTreeViewState(object treeViewState)
        {
            string filePath = ConfigurationManager.AppSettings.Get("TreeviewStateFileLocation") + @"\TreeviewState.bin";
            try
            {
                FileInfo fi = new FileInfo(filePath);
                if (!fi.Directory.Exists)
                {
                    System.IO.Directory.CreateDirectory(fi.DirectoryName);
                }
                using (Stream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, treeViewState);
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }

        public static TreeViewState DeserializeTreeViewState()
        {
            string stateFilePath= ConfigurationManager.AppSettings.Get("TreeviewStateFileLocation") + @"\TreeviewState.bin";

            try
            {
                if (File.Exists(stateFilePath))
                {
                    TreeViewState state = new TreeViewState();
                    using (Stream fileStream = new FileStream(stateFilePath, FileMode.Open))
                    {
                        BinaryFormatter binFormatter = new BinaryFormatter();
                        state = binFormatter.Deserialize(fileStream) as TreeViewState;
                    }
                    return state;
                }
                
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }

            return null;

        }
    }

    [Serializable]
    public class TreeViewState
    {
        public  List<string> ExpandedList { get; set; }
        public  List<string> CheckedList { get; set; }
    }

}
