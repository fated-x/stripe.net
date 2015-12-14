using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe.Entities
{
  public class StripeExternalAccount
  {
    [JsonProperty("id")]
    public string ExternalAccountId { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("account")]
    public string Account { get; set; }

    [JsonProperty("bank_name")]
    public string BankName { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("default_for_currency")]
    public bool DefaultForCurrency { get; set; }

    [JsonProperty("fingerprint")]
    public string Fingerprint { get; set; }

    [JsonProperty("last4")]
    public string LastFour { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, string> Metadata { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("routing_number")]
    public string RoutingNumber { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }
  }
}