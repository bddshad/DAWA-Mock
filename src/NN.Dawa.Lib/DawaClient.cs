using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.WebSockets;

namespace Mock.Dawa.Lib
{
    public class DawaClient
    {

        private static HttpClient _client;

        public DawaClient()
        {

            _client = new HttpClient();

            _client.BaseAddress = new Uri("https://dawa.aws.dk/");

        }

        public string GetDataFromDawa(string query)
        {

            var url = $"/autocomplete?q={query}&fuzzy=true";
            var response = _client.GetStringAsync(url).Result;
            var jarray= JArray.Parse(response);
            var vejnavn = jarray.First["forslagstekst"].ToString();

            url = $"/autocomplete?q={vejnavn}%20&fuzzy=true";
            response = _client.GetStringAsync(url).Result;
            jarray = JArray.Parse(response);
            if (jarray.First["type"].ToString() == "vejnavn")
            {
                var random = new Random();
                var randomised = random.Next(0, 6);
                url = $"/autocomplete?q={vejnavn}%20{randomised}&fuzzy=true";
                response = _client.GetStringAsync(url).Result;
                jarray = JArray.Parse(response);
                var addresse = $"{jarray.First["forslagstekst"]};{jarray.First["data"]["postnr"]};{jarray.First["data"]["postnrnavn"]};{jarray.First["data"]["href"]};{jarray.First["data"]["id"]}";

                return addresse;
            }
            else
            {
                var addresse = $"{jarray.First["forslagstekst"]};{jarray.First["data"]["postnr"]};{jarray.First["data"]["postnrnavn"]};{jarray.First["data"]["href"]};{jarray.First["data"]["id"]}";

                return addresse;
            }

        }
    }
}
