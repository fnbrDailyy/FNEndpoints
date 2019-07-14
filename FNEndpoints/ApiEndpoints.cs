using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNEndpoints
{
    class ApiEndpoints
    {
        public static string GetEndpoint(string url, bool auth, Method method)
        {
            RestClient EndpointClient = new RestClient(url);
            RestRequest EndpointRequest = new RestRequest(method);

            if (auth)
            {
                EndpointRequest.AddHeader("Authorization", "bearer " + getExchangeToken(getAccessCode(getAccessToken(Properties.Settings.Default.EpicEmail, Properties.Settings.Default.EpicPassword))));
            }
            EndpointRequest.AddHeader("Accept-Language", Properties.Settings.Default.Language);


            var response = EndpointClient.Execute(EndpointRequest);
            string content = response.Content;

            return content;
        }
        public static string GetAesKeys()
        {
            if (Properties.Settings.Default.pakPath != "" && Directory.Exists(Properties.Settings.Default.pakPath))
            {
                string mainKey;
                {
                    string aesApi = GetEndpoint("http://benbotfn.tk:8080/api/aes", false, Method.GET);
                    dynamic json = JsonConvert.DeserializeObject(aesApi);
                    mainKey = json.mainKey;
                }
                dynamic additionalKeys;
                {
                    string keychain = GetEndpoint("https://fortnite-public-service-prod11.ol.epicgames.com/fortnite/api/storefront/v2/keychain", true, Method.GET);
                    dynamic json = JsonConvert.DeserializeObject(keychain);
                    MessageBox.Show("" + json);
                }
                return "";
            } else
            {
                return "{ error: \"Your PakPath is wrong, set it in the settings!\" }";
            }
        }
        private static string getAccessToken(string email, string password)
        {
            RestClient getAccessTokenClient = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/token");
            RestRequest getAccessTokenRequest = new RestRequest(Method.POST);

            getAccessTokenRequest.AddParameter("grant_type", "password");
            getAccessTokenRequest.AddParameter("username", email);
            getAccessTokenRequest.AddParameter("password", password);
            getAccessTokenRequest.AddParameter("includePerms", "true");

            getAccessTokenRequest.AddHeader("Authorization", "basic MzQ0NmNkNzI2OTRjNGE0NDg1ZDgxYjc3YWRiYjIxNDE6OTIwOWQ0YTVlMjVhNDU3ZmI5YjA3NDg5ZDMxM2I0MWE=");
            getAccessTokenRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            dynamic response = JsonConvert.DeserializeObject(getAccessTokenClient.Execute(getAccessTokenRequest).Content);
            return response["access_token"];
        }
        private static string getAccessCode(string accessToken)
        {
            RestClient getAccessCodeClient = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/exchange");
            RestRequest getAccessCodeRequest = new RestRequest(Method.GET);

            getAccessCodeRequest.AddHeader("Authorization", "bearer " + accessToken);

            dynamic response = JsonConvert.DeserializeObject(getAccessCodeClient.Execute(getAccessCodeRequest).Content);

            return response.code;
        }
        private static string getExchangeToken(string accessCode)
        {
            RestClient getExchangeTokenClient = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/token");
            RestRequest getExchangeTokenRequest = new RestRequest(Method.POST);

            getExchangeTokenRequest.AddHeader("Authorization", "basic ZWM2ODRiOGM2ODdmNDc5ZmFkZWEzY2IyYWQ4M2Y1YzY6ZTFmMzFjMjExZjI4NDEzMTg2MjYyZDM3YTEzZmM4NGQ=");
            getExchangeTokenRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            getExchangeTokenRequest.AddParameter("grant_type", "exchange_code");
            getExchangeTokenRequest.AddParameter("exchange_code", accessCode);
            getExchangeTokenRequest.AddParameter("includePerms", true);
            getExchangeTokenRequest.AddParameter("token_type", "eg1");

            dynamic response = JsonConvert.DeserializeObject(getExchangeTokenClient.Execute(getExchangeTokenRequest).Content);

            return response["access_token"];
        }
    }
}
