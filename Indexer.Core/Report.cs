using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Indexer.Core;

namespace Indexer.Core
{
    public class Report
    {
        string xmlFilePath = "";
        public Report()
        {
            xmlFilePath = ConfigurationManager.AppSettings.Get("SearchDataXmlFileLocation") + @"\SearchData.xml";
        }

        public void SaveIndexSearch(string searchText)
        {
            //save last 25 search data.
            try
            {
                FileInfo fi = new FileInfo(xmlFilePath);
                if (!fi.Directory.Exists)
                {
                    System.IO.Directory.CreateDirectory(fi.DirectoryName);
                }

                XDocument xmldoc;
                if (!File.Exists(xmlFilePath))
                {
                    //Populate with data here if necessary, then save to make sure it exists
                    xmldoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                    xmldoc.Add(new XElement("Searches"));
                    xmldoc.Save(xmlFilePath);
                }

                xmldoc = XDocument.Load(xmlFilePath);
                XElement root = xmldoc.Root;


                //only last 25 records need to be saved
                if (xmldoc.Elements("Searches").Elements("Search").Count() >= 25)
                {
                    //Remove  first record.
                    XElement record = xmldoc.Elements("Searches").Elements("Search").FirstOrDefault();
                    record.Remove();
                }

                root.Add(new XElement("Search", new XElement("SearchText", searchText), new XElement("SearchDate", String.Format("{0:g}", DateTime.Now))));

                xmldoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
           
        }
        public List<IndexStatistics> GetIndexStatistics()
        {
            //total number of words indexed, the longest word indexed, the shortest word indexed, 
            //the most frequent word indexed and the least frequent.
            List<IndexStatistics> result = new List<IndexStatistics>();
            try
            {
                if (Indexer.IndexStore != null)
                {
                    var maxKey = Indexer.IndexStore.OrderByDescending(kv => kv.Key.Length).First().Key;
                    var minKey = Indexer.IndexStore.OrderByDescending(kv => kv.Key.Length).Last().Key;
                    var wordCount = Indexer.IndexStore.Count;

                    var mostFrequent = Indexer.IndexStore.Aggregate((l, r) => l.Value.Count > r.Value.Count ? l : r).Key;
                    var leastFrequent = Indexer.IndexStore.Aggregate((l, r) => l.Value.Count < r.Value.Count ? l : r).Key;

                    result.Add(new IndexStatistics { Item = "Total words indexed", Value = wordCount.ToString() });
                    result.Add(new IndexStatistics { Item = "Longest word indexed", Value = maxKey });
                    result.Add(new IndexStatistics { Item = "Shortest word indexed", Value = minKey });
                    result.Add(new IndexStatistics { Item = "Most frequent word indexed", Value = mostFrequent });
                    result.Add(new IndexStatistics { Item = "Least frequent word indexed", Value = leastFrequent });
                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
            
            

            return result;


        }
        public List<SearchResultReport> GetSearchData()
        {
            List<SearchResultReport> collection = new List<SearchResultReport>();

            try
            {
                if (File.Exists(xmlFilePath))
                {
                    XDocument xmldoc = XDocument.Load(xmlFilePath);

                    var items = xmldoc.Descendants("Search").ToList();

                    int id = 1;
                    foreach (XElement childEllement in items)
                    {
                        collection.Add(new SearchResultReport { ID = id, SearchText = childEllement.Element("SearchText").Value, SearchDate = childEllement.Element("SearchDate").Value });
                        id++;
                    }
                }
            }
            catch (Exception ex)
            {

                Logger.Log(ex);
            }
                      
            return collection;
        }
    }
   
    public class IndexStatistics
    {
        public string Item { get; set; }
        public string Value { get; set; }
    }
    public class SearchResultReport
    {
        public int ID { get; set; }
        public string SearchText { get; set; }
        public string SearchDate { get; set; }
    }
}
