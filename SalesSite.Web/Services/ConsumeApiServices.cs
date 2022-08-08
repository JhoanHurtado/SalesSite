using Newtonsoft.Json;
using SalesSite.Web.Interface;
using SalesSite.Web.Models;
using SalesSite.Web.Utility;
using System.Net;
using System.Net.Http.Headers;

namespace SalesSite.Web.Services
{
    public class ConsumeApiServices<T> : IConsumeApi<T> where T : class
    {

        string url = "";
        public ConsumeApiServices(IConfiguration configuration, string dir)
        {
            url= $"{configuration.GetValue<string>("url_service")}/{dir}";
        }

        public CollectionResult<T> PostApi(T t)
        {
            CollectionResult<T> ts = new CollectionResult<T>();
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = JsonConvert.SerializeObject(t);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return ts;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ts = JsonConvert.DeserializeObject<CollectionResult<T>>(responseBody);
                        }
                    }
                }
                return ts;
            }
            catch (WebException ex)
            {
                throw;
            }

        }

        public CollectionResult<List<T>> GetApi(string parameters = "")
        {
            CollectionResult<List<T>> ts = new CollectionResult<List<T>>();
            url = $"{url}{parameters}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return ts;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ts = JsonConvert.DeserializeObject<CollectionResult<List<T>>>(responseBody);
                        }
                    }
                }
                return ts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public CollectionResult<T> PutApi(T t)
        {
            CollectionResult<T> ts = new CollectionResult<T>();
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = JsonConvert.SerializeObject(t);
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return ts;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ts = JsonConvert.DeserializeObject<CollectionResult<T>>(responseBody);
                        }
                    }
                }
                return ts;
            }
            catch (WebException ex)
            {
                throw;
            }
        }
        public CollectionResult<T> DeleteApi(int id)
        {
            CollectionResult<T> ts = new CollectionResult<T>();
            if (id != 0)  url = $"{url}/{id}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return ts;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ts = JsonConvert.DeserializeObject<CollectionResult<T>>(responseBody);
                        }
                    }
                }
                return ts;
            }
            catch (WebException ex)
            {
                throw;
            }
        }
    }
}
