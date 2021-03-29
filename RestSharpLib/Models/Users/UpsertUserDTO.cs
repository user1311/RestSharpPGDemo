using System;
using System.Collections.Generic;
using System.Text;

namespace RestSharpLib.Models
{
    // Insert/Update = UPSERT
    public class UpsertUserDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string job { get; set; }
        public DateTime createdAt { get; set; }
    }
}
