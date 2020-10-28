using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Indexer.Core
{
    public class SearchIndex
    {

        private string binaryFilePath;
        public string SearchText { get; set; }

        public SearchIndex(string searchText)
        {
            SearchText = searchText;
            binaryFilePath = ConfigurationManager.AppSettings.Get("BinaryFileLocation") + @"\IndexStore.bin";
            
        }

        public List<SearchResult> SearchIndexProcess()
        {
            List<SearchResult> resultList = new List<SearchResult>();

            try
            {
                if (Indexer.IndexStore != null) //During application load or new index creation time, IndexStore will get data
                {
                    List<string> result = new List<string>();

                    if (Indexer.IndexStore.ContainsKey(SearchText))
                    {
                        result = Indexer.IndexStore[SearchText];
                    }

                    int i = 1;
                    foreach (string file in result)
                    {
                        resultList.Add(new SearchResult { ID = i, FileName = file.Split('|')[0], LineNumber = file.Split('|')[1] });
                        i++;
                    }

                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
          
            return resultList;
        }

       
    }
}
