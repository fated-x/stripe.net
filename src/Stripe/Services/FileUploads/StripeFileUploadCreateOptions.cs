using Newtonsoft.Json;

namespace Stripe
{ 
  public class StripeFileUploadCreateOptions
  {
    [JsonProperty("file")]
    public string File { get; set; }

    [JsonProperty("purpose")]
    public string Purpose { get; set; }
  }
}