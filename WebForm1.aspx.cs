using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hw3phase2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            string zipcode = this.TextBox1.Text;
            /*string url = @"https://localhost:44338/Service1.svc/Forecast" + zipcode;
            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            String[] items = reader.ReadToEnd().Split('$');
    */
        
            hw3phase2.Service1 client = new hw3phase2.Service1();



            String[] items = client.Forecast(zipcode).Split('$');
            
            
            
            
            
            
            
            
            DateTime thisDay = DateTime.Today;

            Label1.Text = thisDay.AddDays(0).ToString("d") + " " + items[0] + " °F";
            Label2.Text = thisDay.AddDays(1).ToString("d") + " " + items[1] + " °F";
            Label3.Text = thisDay.AddDays(2).ToString("d") + " " + items[2] + " °F";
            Label4.Text = thisDay.AddDays(3).ToString("d") + " " + items[3] + " °F";
            Label5.Text = thisDay.AddDays(4).ToString("d") + " " + items[4] + " °F";

            
        

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}