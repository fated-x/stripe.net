using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe
{
  public class StripeDisputeUpdateOptions
  {
    [JsonProperty("evidence")]
    public StripeEvidenceOptions Evidence { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, string> Metadata { get; set; }
  }
}