using ApiCrudClient.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace ApiCrudClient.Api
{
    public class APIGateway
    {
        private string url = "https://localhost:7265/api/Customer";
        private HttpClient httpClient = new HttpClient();

        public List<Customer> ListCustomer()
        {
            List<Customer> customers = new List<Customer>();
            if(url.Trim().Substring(0,5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var datacol = JsonConvert.DeserializeObject<List<Customer>>(result);
                    if (datacol != null)
                        customers = datacol;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the Api Endpoint, Error Info" + result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the Api Endpoint, Error Info" + ex.Message);
            }
            finally { }
            return customers;

        }

      //create
      public Customer CreateCustomer(Customer customer)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = JsonConvert.SerializeObject(customer);

            try
            {
               HttpResponseMessage response = httpClient.PostAsync(url,new StringContent(json,Encoding.UTF8,"application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Customer>(result);
                    if(data != null)
                        customer = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the Api Endpoint, Error Info" + result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the Api Endpoint, Error Info" + ex.Message);
            }
            finally { }
            return customer;

        }

        //get one customer

        public Customer GetCustomer(int id)
        {
            Customer customer= new Customer();
            url = url + "/" + id;
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<Customer> (result);
                    if (data != null)
                    customer = data;
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the Api Endpoint, Error Info" + result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the Api Endpoint, Error Info" + ex.Message);
            }
            finally { }

            return customer;
        }

        //update 
        public void UpdateCustomer(Customer customer)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            int id = customer.Id;

            url = url + "/" + id;
            string json = JsonConvert.SerializeObject(customer);
            try
            {
                HttpResponseMessage response = httpClient.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the Api Endpoint, Error Info" + result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the Api Endpoint, Error Info" + ex.Message);
            }
            finally { }

            return;

        }

        //Delete

        public void DeleteCustomer(int id)
        {
            if (url.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            url = url + "/" + id;
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                if(!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the Api Endpoint, Error Info" + result);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error Occured at the Api Endpoint, Error Info" + ex.Message);
            }
            finally { }

            return;
        }







    }
}
