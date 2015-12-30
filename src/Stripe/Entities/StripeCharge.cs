using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
  public class StripeCharge : StripeObject
  {
    [JsonProperty("id")]
    public string ChargeID { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("amount")]
    public int AmountInCents { get; set; }

    [JsonProperty("amount_refunded")]
    public int AmountRefundedInCents { get; set; }

    #region Expandable ApplicationFee
    public string ApplicationFeeId { get; set; }

    [JsonIgnore]
    public StripeApplicationFee ApplicationFee { get; set; }

    [JsonProperty("application_fee")]
    internal object InternalApplicationFee
    {
      set
      {
        ExpandableProperty<StripeApplicationFee>.Map(value, s => ApplicationFeeId = s, o => ApplicationFee = o);
      }
    }
    #endregion

    #region Expandable Balance Transaction
    public string BalanceTransactionId { get; set; }

    [JsonIgnore]
    public StripeBalanceTransaction BalanceTransaction { get; set; }

    [JsonProperty("balance_transaction")]
    internal object InternalBalanceTransaction
    {
      set
      {
        ExpandableProperty<StripeBalanceTransaction>.Map(value, s => BalanceTransactionId = s, o => BalanceTransaction = o);
      }
    }
    #endregion

    [JsonProperty("captured")]
    public bool? Captured { get; set; }

    [JsonProperty("created")]
    [JsonConverter(typeof(StripeDateTimeConverter))]
    public DateTime Created { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; }

    #region Expandable Customer
    public string CustomerId { get; set; }

    [JsonIgnore]
    public StripeCustomer Customer { get; set; }

    [JsonProperty("customer")]
    internal object InternalCustomer
    {
      set
      {
        ExpandableProperty<StripeCustomer>.Map(value, s => CustomerId = s, o => Customer = o);
      }
    }
    #endregion

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("destination")]
    public string Destination { get; set; }

    [JsonProperty("dispute")]
    public StripeDispute Dispute { get; set; }

    [JsonProperty("failure_code")]
    public string FailureCode { get; set; }

    [JsonProperty("failure_message")]
    public string FailureMessage { get; set; }

    [JsonProperty("fraud_details")]
    public Dictionary<string, string> FraudDetails { get; set; }

    #region Expandable Invoice
    public string InvoiceId { get; set; }

    [JsonIgnore]
    public StripeInvoice Invoice { get; set; }

    [JsonProperty("invoice")]
    internal object InternalInvoice
    {
      set
      {
        ExpandableProperty<StripeInvoice>.Map(value, s => InvoiceId = s, o => Invoice = o);
      }
    }
    #endregion

    [JsonProperty("livemode")]
    public bool LiveMode { get; set; }

    [JsonProperty("metadata")]
    public Dictionary<string, string> Metadata { get; set; }

    [JsonProperty("paid")]
    public bool Paid { get; set; }

    [JsonProperty("receipt_email")]
    public string ReceiptEmail { get; set; }

    [JsonProperty("receipt_number")]
    public string ReceiptNumber { get; set; }

    [JsonProperty("refunded")]
    public bool Refunded { get; set; }

    [JsonProperty("refunds")]
    public StripeList<StripeRefund> Refunds { get; set; }

    [JsonProperty("shipping")]
    public Dictionary<string, string> Shipping { get; set; }

    [JsonProperty("source")]
    public StripeCard Source { get; set; }

    [JsonProperty("statement_descriptor")]
    public string StatementDescriptor { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    // Destination (destination)

    // Transfer (transfer)
  }
}