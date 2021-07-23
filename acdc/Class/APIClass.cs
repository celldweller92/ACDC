using ACDC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ACDC.Class
{
    public class APIClass
    {
        public static string BaseURL()
        {
            var connection = string.Format("http://192.168.210.166/API/");
            return connection;
        }
        public string InsertUser(UserAccount acc)
        {
            var val = string.Empty;

            try
            {
                Uri uri = new Uri(string.Format(BaseURL() + "AddUser"));
                string jsonData = JsonConvert.SerializeObject(acc);
                string response = string.Empty;
                using (var client = new WebClient())
                {
                    client.Headers.Add("content-type", "application/json");
                    response = Encoding.ASCII.GetString(client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(jsonData)));
                }
                return response;
            }
            catch (Exception)
            {
                val = "Error 404";
            }
            return val;
        }
        public string AccountCredential(Login acc)
        {
            var val = string.Empty;
            try
            {
                Uri uri = new Uri(string.Format(BaseURL() + "UserCredential"));
                string jsonData = JsonConvert.SerializeObject(acc);
                string response = string.Empty;
                using (var client = new WebClient())
               {
                    client.Headers.Add("content-type", "application/json");
                    response = Encoding.ASCII.GetString(client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(jsonData)));
                }
                return response;
            }
            catch (Exception)
            {
                val = "Error 404";
            }
            return val;
        }
    }
}
