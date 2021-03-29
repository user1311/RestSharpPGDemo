using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpLib.Models
{
    public class Data
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class Users
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public IList<Data> data { get; set; }
        public Support support { get; set; }
    }

    public class SingleUser
    {
        public Data data { get; set; }
        public Support support { get; set; }
    }

}
