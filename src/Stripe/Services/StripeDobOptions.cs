using Newtonsoft.Json;

namespace Stripe
{
  public class StripeDobOptions
  {
    [JsonProperty("legal_entity[dob][day]")]
    public int Day { get; set; }

    [JsonProperty("legal_entity[dob][month]")]
    public int Month { get; set; }

    [JsonProperty("legal_entity[dob][year]")]
    public int Year { get; set; }
  }
}
