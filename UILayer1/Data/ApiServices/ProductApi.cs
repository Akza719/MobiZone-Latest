using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UILayer.Models;

namespace UIlayer.Data.ApiServices
{
    public class ProductApi
    {
        
        public static IEnumerable<Product> GetProduct()
        {
            ResponseModel<Product> _responseModel = null;
            using (HttpClient httpclient = new HttpClient())
            {
                _responseModel = null;
                string url = "http://localhost:22887/api/product/";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    _responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseModel<Product>>(response.Result);
                }
                return _responseModel.resultList;
            }
        }
        public static Product GetProduct(int id)
        {
            ResponseModel<Product> _responseModel = null;
            using (HttpClient httpclient = new HttpClient())
            {
                string url = "http://localhost:22887/api/product/" + id;
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.GetAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    _responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseModel<Product>>(response.Result);
                }
                return _responseModel.result;
            }
        }
        public static bool EditProduct(Product product)
        {

            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "http://localhost:22887/api/product/";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> response = httpclient.PutAsync(uri, content);
                
                if (response.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public static bool CreateProduct(Product product)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(product);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "http://localhost:22887/api/product/";
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.PostAsync(uri, content);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
        public static bool DeleteProduct(int id)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(id);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                string url = "http://localhost:22887/api/product/" + id;
                Uri uri = new Uri(url);
                System.Threading.Tasks.Task<HttpResponseMessage> result = httpclient.DeleteAsync(uri);
                if (result.Result.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
