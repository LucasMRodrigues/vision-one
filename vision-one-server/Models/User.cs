using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class User : BaseModel
    {

        public string username { get; set; }
        public string email { get; set; }
        [JsonIgnore]
        public string password { get; set; }
    }
}
