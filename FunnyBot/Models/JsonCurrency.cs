using Newtonsoft.Json;

namespace FunnyBot.Models
{
    public class JsonCurrency
    {
        [JsonProperty("r030")]
        public int r030 { get; set; }

        [JsonProperty("txt")]
        public string txt { get; set; }

        [JsonProperty("rate")]
        public double rate { get; set; }

        [JsonProperty("cc")]
        public string cc { get; set; }

        [JsonProperty("exchangedate")]
        public string exchangedate { get; set; }
    }
}
