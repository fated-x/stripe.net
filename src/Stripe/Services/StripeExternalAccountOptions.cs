using Newtonsoft.Json;

namespace Stripe
{
  public class StripeExternalAccountOptions
  {
    [JsonProperty("external_account")]
    public string TokenId { get; set; }

    [JsonProperty("external_account[object]")]
    public string Object { get; set; }

    [JsonProperty("external_account[account_number]")]
    public string AccountId { get; set; }

    [JsonProperty("external_account[country]")]
    public string Country { get; set; }

    [JsonProperty("external_account[currency]")]
    public string Currency { get; set; }

    [JsonProperty("external_account[account_holder_type]")]
    public string AccountHolderType { get; set; }

    [JsonProperty("external_account[name]")]
    public string Name { get; set; }

    [JsonProperty("external_account[routing_number]")]
    public string RoutingNumber { get; set; }
  }
}