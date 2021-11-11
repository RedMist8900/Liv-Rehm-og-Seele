using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace DataModels
{
    public class Vejr
    {
        public string APIKEY = "ba4b53af244913ed5007be811ef02f86";

        public string City { get; set; }

        public string CurrentURL { get; set; } = "https://api.openweathermap.org/data/2.5/weather?q=København&mode=xml&units=metric&appid=ba4b53af244913ed5007be811ef02f86";

        public XDocument document { get; set; }

        public XDocument Accesss()
        {
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(CurrentURL);
                XDocument xDocument = XDocument.Parse(xmlContent);
                return xDocument;
            }
        }

        string Temperature
        {
            get
            {
                return GetTemperature(document);
            }
        }

        public string GetTemperature(XDocument doc)
        {
            return doc.Descendants("temperature").First().Attribute("value").Value;
        }

        public string GetTemperatureMin(XDocument doc)
        {
            return doc.Descendants("temperature").First().Attribute("min").Value;
        }

        public string GetTemperatureMax(XDocument doc)
        {
            return doc.Descendants("temperature").First().Attribute("max").Value;
        }

        public string GetWindValue(XDocument doc)
        {
            return doc.Descendants("speed").First().Attribute("value").Value;
        }

        public string GetWindName(XDocument doc)
        {
            return doc.Descendants("speed").First().Attribute("name").Value;
        }

        public string GetWindDirection(XDocument doc)
        {
            return doc.Descendants("direction").First().Attribute("value").Value;
        }

        public string GetWindDirectionName(XDocument doc)
        {
            return doc.Descendants("direction").First().Attribute("name").Value;
        }
    }
}
