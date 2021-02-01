using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Favohit.WebApi.Models
{
    public class Music
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public int Duration { get; set; }

        [JsonIgnore]
        public Album Album { get; set; }
    }
}
