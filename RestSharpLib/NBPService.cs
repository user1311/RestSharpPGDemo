using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharpLib.Models;
using RestSharpLib.Models.NBP;
using System.Collections.Generic;

namespace RestSharpLib
{
    public class NBPService
    {
        /// <summary>
        /// http://api.nbp.pl/en.html Open API from National Bank of Poland :D Feel free to check it out
        /// </summary>

        private const string BaseUrl = "http://api.nbp.pl/";
        public RestClient client { get; set; }

        public NBPService()
        {
            client = new RestClient(BaseUrl);
            client.UseXml();
        }

        public IRestResponse<CenaZlota> GetCenaZlota()
        {
            //Create request
            var request = new RestRequest("/api/cenyzlota", Method.GET,DataFormat.Xml);

            //Execute request and return response
            var response = client.Get<CenaZlota>(request);
            return response;
        }

        public IRestResponse<List<CenaZlota>> GetGoldPricesInTimeRange(string startDate,string endDate)
        {
            //Create GET request with id parameter
            var request = new RestRequest("/api/cenyzlota/"+startDate+"/"+endDate,Method.GET,DataFormat.Xml);

            var response = client.Get<List<CenaZlota>>(request);
            return client.Deserialize<List<CenaZlota>>(response);
        }

        public IRestResponse<ExchangeRatesSeries> GetCurrentExchangeRates(string currency)
        {
            //Create GET request with id parameter
            var request = new RestRequest("/api/exchangerates/rates/a/" + currency, Method.GET, DataFormat.Xml);

            var response = client.Get<ExchangeRatesSeries>(request);
            return response;
        }
    }
}
