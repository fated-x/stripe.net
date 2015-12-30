using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Entities;

namespace Stripe
{
  public class StripeAccount : StripeObject
  {
    [JsonProperty("id")]
    public string AccountId { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("business_logo")]
    public string BusinessLogo { get; set; }

    [JsonProperty("business_name")]
    public string BusinessName { get; set; }

    [JsonProperty("business_url")]
    public string BusinessUrl { get; set; }

    [JsonProperty("charges_enabled")]
    public bool ChargesEnabled { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("currencies_supported")]
    public string[] CurrenciesSupported { get; set; }

    [JsonProperty("debit_negative_balances")]
    public bool DebitNegativeBalances { get; set; }

    [JsonProperty("decline_charge_on")]
    public Dictionary<string, bool> DeclineChargeOn { get; set; }

    [JsonProperty("default_currency")]
    public string DefaultCurrency { get; set; }

    [JsonProperty("details_submitted")]
    public bool DetailsSubmitted { get; set; }

    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("external_accounts")]
    public StripeList<StripeExternalAccount> ExternalAccounts { get; set; }

    [JsonProperty("managed")]
    public bool Managed { get; set; }

    [JsonProperty("product_description")]
    public string ProductDescription { get; set; }

    [JsonProperty("statement_descriptor")]
    public string StatementDescriptor { get; set; }

    [JsonProperty("support_phone")]
    public string SupportPhone { get; set; }

    [JsonProperty("timezone")]
    public string Timezone { get; set; }

    [JsonProperty("tos_acceptance")]
    public StripeToSAcceptance ToSAcceptance { get; set; }

    [JsonProperty("transfer_schedule")]
    public StripeTransferSchedule TransferSchedule { get; set; }

    [JsonProperty("transfers_enabled")]
    public bool TransfersEnabled { get; set; }

    [JsonProperty("verification")]
    public StripeVerification Verification { get; set; }

    // TODO: LegalEntity ("legal_entity")
  }
}