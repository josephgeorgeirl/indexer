using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indexer.Core
{
    public class Indexer
    {
        //INDEX COLLECTION
        public static Dictionary<string, List<string>> IndexStore { get; set; }

        public static string BinaryFilePath { get; set; }
        public List<string> SelectedFolders { get; set; }
        public int TotalFiles { get; set; }
        public static List<string> WordList { get; set; }
        private static Object thisLock = new Object();
        public Indexer(List<string> folders)
        {
            SelectedFolders = folders;
        }
        static Indexer()
        {
            //to store serialized index collection object
            BinaryFilePath = ConfigurationManager.AppSettings.Get("BinaryFileLocation") + @"\IndexStore.bin";
        }

         public void CreateIndex(List<string> folders)
        {
            //create index from text files within selected folders
            //this method will extract all text contents and split it stores in dictionary object along with filename and position

            SelectedFolders = folders;
            IndexStore = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            WordList = new List<string>();
            string blackListItems = ConfigurationManager.AppSettings.Get("BlackListItems");
            string charactersToRemove = ConfigurationManager.AppSettings.Get("InvalidCharactersToRemove");
            try
            {
                lock (thisLock)
                {
                    foreach (string folder in SelectedFolders)
                    {
                        
                        foreach (string file in Directory.GetFiles(folder, "*.txt"))
                            
                        {
                            WaitForFile(file);
                            using (StreamReader sr = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                            {
                                var lineCount = 0;
                                while (!sr.EndOfStream)
                                {
                                    lineCount++;
                                    var line = sr.ReadLine();
                                    if (!string.IsNullOrEmpty(line) && line[0] != '\0')
                                    {
                                        //remove invalid characters from index (eg. fullstop)
                                        if (charactersToRemove.Trim().Length>0)
                                        {
                                            foreach (string character in charactersToRemove.Trim().Split('|'))
                                            {
                                                line=line.Replace(character, "");
                                            }
                                        }
                                        var lineWords = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                        AddToIndexStore(lineWords, file, lineCount, blackListItems);
                                    }
                                }
                            }

                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
           
        }

        public static void WaitForFile(string fileName)
        {
            int i = 0;

            while (true)
            {
                try
                {
                    using (Stream stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                    {
                        if (stream != null)
                        {
                            break;
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    //System.Diagnostics.Trace.WriteLine(string.Format("Output file {0} not yet ready ({1})", fileName, ex.Message));
                }
                catch (IOException ex)
                {
                }
                catch (UnauthorizedAccessException ex)
                {
                }
                Thread.Sleep(500);
                i++;

                if (i >= 20)
                    break; //avoid infinite loop
            }
        }

        private void AddToIndexStore(List<string> words, string document, int lineNumber, string blackListItems)
        {
            try
            {
                
                lock (thisLock)
                {
                    foreach (var word in words)
                    {
                        string inputWord = word;

                        //remove null characters from words
                        inputWord = inputWord.Trim().Replace("\0", string.Empty);

                        //Check blacklist items and single letter words
                        if (!blackListItems.Split(',').Contains(inputWord) && inputWord.Length > 1)
                        {

                            if (IndexStore.ContainsKey(inputWord))
                            {

                                IndexStore[inputWord].Add(document + "|" + lineNumber.ToString());
                            }
                            else
                            {
                                WordList.Add(inputWord);
                                IndexStore.Add(inputWord, new List<string> { document + "|" + lineNumber.ToString() });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
            
        }

        public static void SerializeIndex()
        {

            try
            {
                lock (thisLock)
                {
                    FileInfo fi = new FileInfo(BinaryFilePath);
                    if (!fi.Directory.Exists)
                    {
                        System.IO.Directory.CreateDirectory(fi.DirectoryName);
                    }
                    using (Stream fileStream = new FileStream(BinaryFilePath, FileMode.OpenOrCreate))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(fileStream, IndexStore);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
            }
        }

        public static void DeserializeIndex()
        {
            try
            {
                if (File.Exists(BinaryFilePath))
                {
                    using (Stream fileStream = new FileStream(BinaryFilePath, FileMode.Open))
                    {
                        BinaryFormatter binFormatter = new BinaryFormatter();
                        var indx = binFormatter.Deserialize(fileStream) as Dictionary<string, List<string>>;
                        IndexStore = indx;
                        if(WordList==null && IndexStore!=null)
                        {
                            WordList = IndexStore.Keys.ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
            
        }

    }
}
