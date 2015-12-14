using System;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe.Entities
{
  public class StripeToSAcceptance
  {
    [JsonProperty("date")]
    [JsonConverter(typeof(StripeDateTimeConverter))]
    public DateTime AgreedToDate { get; set; }

    [JsonProperty("ip")]
    public string IpAddress { get; set; }

    [JsonProperty("user_agent")]
    public string UserAgent { get; set; }
  }
}