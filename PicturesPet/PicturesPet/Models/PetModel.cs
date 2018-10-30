using Newtonsoft.Json;
using System.Collections.Generic;

namespace PicturesPet.Models
{
    public class PetModel : BaseModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("breeds")]
        public List<Breed> Breeds { get; set; }

        public class Breed
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }

    }
}
