using Newtonsoft.Json;

namespace Stripe.Services
{
  public class StripeTransferScheduleOptions
  {
    [JsonProperty("transfer_schedule[delay_days]")]
    public int? DelayDays { get; set; }

    [JsonProperty("transfer_schedule[interval]")]
    public string Interval { get; set; }

    [JsonProperty("transfer_schedule[monthly_anchor]")]
    public int? MonthlyAnchor { get; set; }

    [JsonProperty("transfer_schedule[weekly_anchor]")]
    public string WeeklyAnchor { get; set; }
  }
}