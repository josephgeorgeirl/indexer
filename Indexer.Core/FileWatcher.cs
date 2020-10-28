using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Indexer.Core
{
    public class FileWatcher
    {

        public delegate void FileWatcherEventHandler(object sender, object e);
        //event to raise file change notification
        public event FileWatcherEventHandler OnFileChange;

        public List<string> FolderList { get; set; }
        public static List<FileSystemWatcher> Watchers { get; set; }


        //to identify multiple event generating from same file at same time.
        private Dictionary<string, DateTime> _lastFileEvent;
        // Interval in Millisecond
        private int _interval;
        //Timespan created when interval is set
        private TimeSpan _recentTimeSpan;

        public int Interval
        {
            get
            {
                return _interval;
            }
            set
            {
                _interval = value;
                // Set timespan based on the value passed
                _recentTimeSpan = new TimeSpan(0, 0, 0, 0, value);
            }
        }
        public FileWatcher()
        {

            Interval = 500;
            _lastFileEvent = new Dictionary<string, DateTime>();
        }

        public void RefreshWatchers()
        {
            //unsubscribe and dispose old watchers.
            try
            {
                if (Watchers != null)
                {
                    foreach (FileSystemWatcher fsw in Watchers)
                    {
                        fsw.EnableRaisingEvents = false;
                        fsw.Created -= new System.IO.FileSystemEventHandler(fileSystemWatcher_Created);
                        fsw.Changed -= new System.IO.FileSystemEventHandler(fileSystemWatcher_Changed);
                        fsw.Deleted -= new System.IO.FileSystemEventHandler(fileSystemWatcher_Deleted);
                        fsw.Renamed -= new System.IO.RenamedEventHandler(fileSystemWatcher_Renamed);
                        fsw.Dispose();
                    }
                    Watchers.Clear();
                }

               
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }

            Watchers = new List<FileSystemWatcher>();
        }
        public void ConfigureFileWatcher(List<string> folders)
        {
            //enabling file watcher on selected folders.
            try
            {
                if (folders == null) return;

                FolderList = folders;

                foreach (string folder in FolderList)
                {
                    System.IO.FileSystemWatcher fileSystemWatcher = new System.IO.FileSystemWatcher();

                    // Set folder path to watch
                    fileSystemWatcher.Path = folder;

                    // Gets or sets the type of changes to watch for.
                    // In this case we will watch change of filename, last modified time, size and directory name
                    fileSystemWatcher.NotifyFilter = System.IO.NotifyFilters.FileName |
                        System.IO.NotifyFilters.LastWrite |
                        System.IO.NotifyFilters.Size |
                        System.IO.NotifyFilters.DirectoryName;

                    // Event handlers that are watching for specific event
                    fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(fileSystemWatcher_Created);
                    fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(fileSystemWatcher_Changed);
                    fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(fileSystemWatcher_Deleted);
                    fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(fileSystemWatcher_Renamed);

                    // NOTE: If you want to monitor specified files in folder, you can use this filter
                    // fileSystemWatcher.Filter

                    // START watching
                    fileSystemWatcher.EnableRaisingEvents = true;
                    Watchers.Add(fileSystemWatcher);
                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
           

           
        }


        private void fileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            DisplayFileSystemWatcherInfo(e.ChangeType, e.Name);
        }

        private void fileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            DisplayFileSystemWatcherInfo(e.ChangeType, e.Name);
        }

        void fileSystemWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            DisplayFileSystemWatcherInfo(e.ChangeType, e.Name);
        }

        private void fileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            DisplayFileSystemWatcherInfo(e.ChangeType, e.Name, e.OldName);
        }

        // ----------------------------------------------------------------------------------

        private void DisplayFileSystemWatcherInfo(System.IO.WatcherChangeTypes watcherChangeTypes, string name, string oldName = null)
        {
          
                if (this.OnFileChange != null && !HasAnotherFileEventOccuredRecently(name))
                {
                
                OnFileChange(this, name);
            }
            
        }

        private bool HasAnotherFileEventOccuredRecently(string FileName)
        {
            bool retVal = false;

            try
            {
                if (_lastFileEvent.ContainsKey(FileName))
                {
                    // If dictionary contains the filename, check how much time has elapsed
                    // since the last event occured. If the timespan is less that the 
                    // specified interval, set return value to true 
                    // and store current datetime in dictionary for this file
                    DateTime lastEventTime = _lastFileEvent[FileName];
                    DateTime currentTime = DateTime.Now;
                    TimeSpan timeSinceLastEvent = currentTime - lastEventTime;
                    retVal = timeSinceLastEvent < _recentTimeSpan;
                    _lastFileEvent[FileName] = currentTime;
                }
                else
                {
                    // If dictionary does not contain the filename, 
                    // no event has occured in past for this file, so set return value to false
                    // and annd filename alongwith current datetime to the dictionary
                    _lastFileEvent.Add(FileName, DateTime.Now);
                    retVal = false;
                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
                         
            

            return retVal;
        }

    }
}
