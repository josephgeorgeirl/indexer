using Indexer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace URLExtraction.Core
{
    public class HTMLExtract
    {
        public delegate void ExtractEventHanlder(object sender, object e);
        public event ExtractEventHanlder OnExtracted;
        WebBrowser browserObject;

        public string URL { get; set; }

        public HTMLExtract(string url)
        {
            this.URL = url;
        }

        public void ExtractHTMLContent()
        {
            try
            {
                browserObject = new System.Windows.Forms.WebBrowser();

                //Hook the document completed event so we know when a page is completely loaded up
                browserObject.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browserObject_DocumentCompleted);
                //suppress javascript error during navigation
                browserObject.ScriptErrorsSuppressed = true;
                
                //Navigate to URL
                browserObject.Navigate(URL);
            }
            catch (Exception ex)
            {

               // throw;
            }
           
        }

        private void browserObject_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                //skip iframe load events
                if (e.Url.AbsolutePath == this.browserObject.Url.AbsolutePath)
                {
                    HtmlElementCollection aCol = ((WebBrowser)sender).Document.GetElementsByTagName("a");
                    HtmlElementCollection titleCol = ((WebBrowser)sender).Document.GetElementsByTagName("title");
                    HtmlElementCollection scriptCol = ((WebBrowser)sender).Document.GetElementsByTagName("script");

                    List<HTMLContent> htmlCol = new List<HTMLContent>();
                    int id = 1;
                    foreach (HtmlElement item in titleCol)
                    {
                        htmlCol.Add(new HTMLContent { ID = id, Content = item.OuterHtml, ContentType = "Title" });
                        id++;
                    }

                    foreach (HtmlElement item in aCol)
                    {
                        htmlCol.Add(new HTMLContent { ID = id, Content = item.OuterHtml, ContentType = "Anchor" });
                        id++;
                    }

                    foreach (HtmlElement item in scriptCol)
                    {
                        htmlCol.Add(new HTMLContent { ID = id, Content = item.OuterHtml, ContentType = "Script" });
                        id++;
                    }

                    if (this.OnExtracted != null)
                    {
                        OnExtracted(this, htmlCol);
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
