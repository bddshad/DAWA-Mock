using System;

namespace Mock.Dawa.Lib
{
    public class DawaClient
    {
        private string _host;

        public DawaClient(string host)
        {
            _host = host;
        }

        public string GetDataFromDawa(string query)
        {
            return "YES";
        }
    }
}
