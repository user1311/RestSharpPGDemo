using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpLib.Models
{
    public class AuthUserDTO
    {
        public int id { get; set; }
        public string token { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
