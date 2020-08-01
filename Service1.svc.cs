using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace hw3phase2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Forecast(string zip)
        {
            List<Int16> temp = new List<Int16>();
            double temp1;
            string url = @"http://api.openweathermap.org/data/2.5/forecast?zip=" + zip + ",us&appid=" + "e553bceb8640b1b4474c13bd30c41df1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();

            weatherapi weatherObject = JsonConvert.DeserializeObject<weatherapi>(responsereader);
            
            for(int i=0; i <5; i++)
            {
                 temp1 = weatherObject.list[i].main.temp;
                double k = ((temp1 - 273.15) * 9 / 5) + 32;
              temp.Add(Convert.ToInt16(k));

            }
            string end = temp[0] + "$" + temp[1] + "$" + temp[2] + "$" + temp[3] + "$" + temp[4];
            return end;
        }
    }
    public class Sys
    {
        public string pod { get; set; }

    }
    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }

    }
    public class Cloud{
        public int all { get; set; }
        }
    public class weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }

    }
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min {get; set;}
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int sea_lvel { get; set; }
        public int grnd_level { get; set; }
        public  int humidity { get; set; }
        public double temp_kf { get; set; }
    }
    public class list
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<weather> weather { get; set; }
        public Cloud clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }

        


    }
    public class weatherapi

    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<list> list { get; set; }

    }
}
