using Newtonsoft.Json;

namespace Stripe
{
  public class StripeAccountUpdateOptions
  {
    [JsonProperty("external_account")]
    public StripeExternalAccountOptions ExternalAccount { get; set; }
  }
}
