using System;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
  public class StripeTosAcceptanceOptions
  {
    public DateTime AgreedToDate { get; set; }

    [JsonProperty("tos_acceptance[date]")]
    internal long? AgreedToDateInternal => AgreedToDate.ConvertDateTimeToEpoch();

    [JsonProperty("tos_acceptance[ip]")]
    public string IpAddress { get; set; }

    [JsonProperty("tos_acceptance[user_agent]")]
    public string UserAgent { get; set; }
  }
}