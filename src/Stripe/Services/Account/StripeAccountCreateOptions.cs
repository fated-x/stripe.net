using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Services;

namespace Stripe
{
  public class StripeAccountCreateOptions
  {
    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("managed")]
    public bool? Managed { get; set; }

    [JsonProperty("business_logo")]
    public string BusinessLogo { get; set; }

    [JsonProperty("business_name")]
    public string BusinessName { get; set; }

    [JsonProperty("business_primary_color")]
    public string BusinessPrimaryColor { get; set; }

    [JsonProperty("business_url")]
    public string BusinessUrl { get; set; }

    [JsonProperty("debit_negative_balances")]
    public bool? DebitNegativeBalances { get; set; }

    [JsonProperty("decline_charge_on")]
    public Dictionary<string, bool> DeclineChargeOn { get; set; }

    [JsonProperty("default_currency")]
    public string DefaultCurrency { get; set; }

    [JsonProperty("external_account")]
    public StripeExternalAccountOptions ExternalAccount { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, string> Metadata { get; set; }

    [JsonProperty("product_description")]
    public string ProductDescription { get; set; }

    [JsonProperty("statement_descriptor")]
    public string StatementDescriptor { get; set; }

    [JsonProperty("support_email")]
    public string SupportEmail { get; set; }

    [JsonProperty("support_phone")]
    public string SupportPhone { get; set; }

    [JsonProperty("support_url")]
    public string SupportUrl { get; set; }

    [JsonProperty("tos_acceptance")]
    public StripeTosAcceptanceOptions ToSAcceptance { get; set; }

    [JsonProperty("external_account[transfer_schedule]")]
    public StripeTransferScheduleOptions TransferSchedule { get; set; }

    // TODO: LegalEntity ("legal_entity")
  }
}