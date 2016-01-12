using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe.Entities
{
  public class StripeDisputeEvidence
  {
    [JsonProperty("access_activity_log")]
    public string AccessActivityLog { get; set; }

    [JsonProperty("billing_address")]
    public string BillingAddress { get; set; }

    #region Expandable CancellationPolicy
    public string CancellationPolicyId { get; set; }

    [JsonIgnore]
    public StripeFileUpload CancellationPolicy { get; set; }

    [JsonProperty("cancellation_policy")]
    internal object InternalCancellationPolicy
    {
      set
      {
        ExpandableProperty<StripeFileUpload>.Map(value, s => CancellationPolicyId = s, o => CancellationPolicy = o);
      }
    }
    #endregion

    [JsonProperty("cancellation_policy_disclosure")]
    public string CancellationPolicyDisclosure { get; set; }

    [JsonProperty("cancellation_rebuttal")]
    public string CancellationRebuttal { get; set; }

    #region Expandable CustomerCommunication
    public string CustomerCommunicationId { get; set; }

    [JsonIgnore]
    public StripeFileUpload CustomerCommunication { get; set; }

    [JsonProperty("customer_communication")]
    internal object InternalCustomerCommunication
    {
      set
      {
        ExpandableProperty<StripeFileUpload>.Map(value, s => CustomerCommunicationId = s, o => CustomerCommunication = o);
      }
    }
    #endregion

    [JsonProperty("customer_email_address")]
    public string CustomerEmailAddress { get; set; }

    [JsonProperty("customer_name")]
    public string CustomerName { get; set; }

    [JsonProperty("customer_purchase_ip")]
    public string CustomerPurchaseIp { get; set; }

    #region Expandable CustomerSignature
    public string CustomerSignatureId { get; set; }

    [JsonIgnore]
    public StripeFileUpload CustomerSignature { get; set; }

    [JsonProperty("customer_signature")]
    internal object InternalCustomerSignature
    {
      set
      {
        ExpandableProperty<StripeFileUpload>.Map(value, s => CustomerSignatureId = s, o => CustomerSignature = o);
      }
    }
    #endregion

    #region Expandable DuplicateChargeDocumentation
    public string DuplicateChargeDocumentationId { get; set; }

    [JsonIgnore]
    public StripeFileUpload DuplicateChargeDocumentation { get; set; }

    [JsonProperty("duplicate_charge_documentation")]
    internal object InternalDuplicateChargeDocumentation
    {
      set
      {
        ExpandableProperty<StripeFileUpload>.Map(value, s => DuplicateChargeDocumentationId = s, o => DuplicateChargeDocumentation = o);
      }
    }
    #endregion

    [JsonProperty("duplicate_charge_explanation")]
    public string DuplicateChargeExplanation { get; set; }

    [JsonProperty("duplicate_charge_id")]
    public string DuplicateChargeId { get; set; }

    [JsonProperty("product_description")]
    public string ProductDescription { get; set; }

    #region Expandable RefundPolicy
    public string RefundPolicyId { get; set; }

    [JsonIgnore]
    public StripeFileUpload RefundPolicy { get; set; }

    [JsonProperty("refund_policy")]
    internal object InternalRefundPolicy
    {
      set
      {
        ExpandableProperty<StripeFileUpload>.Map(value, s => RefundPolicyId = s, o => RefundPolicy = o);
      }
    }
    #endregion

    #region Expandable Receipt
    public string ReceiptId { get; set; }

    [JsonIgnore]
    public StripeFileUpload Receipt { get; set; }

    [JsonProperty("receipt")]
    internal object InternalReceipt
    {
      set
      {
        ExpandableProperty<StripeFileUpload>.Map(value, s => ReceiptId = s, o => Receipt = o);
      }
    }
    #endregion

    [JsonProperty("refund_policy_disclosure")]
    public string RefundPolicyDisclosure { get; set; }

    [JsonProperty("refund_refusal_explanation")]
    public string RefundRefusalExplanation { get; set; }

    [JsonProperty("service_date")]
    public string ServiceDate { get; set; }

    #region Expandable ServiceDocumentation
    public string ServiceDocumentationId { get; set; }

    [JsonIgnore]
    public StripeFileUpload ServiceDocumentation { get; set; }

    [JsonProperty("service_documentation")]
    internal object InternalServiceDocumentation
    {
      set
      {
        ExpandableProperty<StripeFileUpload>.Map(value, s => ServiceDocumentationId = s, o => ServiceDocumentation = o);
      }
    }
    #endregion

    [JsonProperty("shipping_address")]
    public string ShippingAddress { get; set; }

    [JsonProperty("shipping_carrier")]
    public string ShippingCarrier { get; set; }

    [JsonProperty("shipping_date")]
    public string ShippingDate { get; set; }

    #region Expandable ShippingDocumentation
    public string ShippingDocumentationId { get; set; }

    [JsonIgnore]
    public StripeFileUpload ShippingDocumentation { get; set; }

    [JsonProperty("shipping_documentation")]
    internal object InternalShippingDocumentation
    {
      set
      {
        ExpandableProperty<StripeFileUpload>.Map(value, s => ShippingDocumentationId = s, o => ShippingDocumentation = o);
      }
    }
    #endregion

    [JsonProperty("shipping_tracking_number")]
    public string ShippingTrackingNumber { get; set; }

    #region Expandable UncategorizedFile
    public string UncategorizedFileId { get; set; }

    [JsonIgnore]
    public StripeFileUpload UncategorizedFile { get; set; }

    [JsonProperty("uncategorized_file")]
    internal object InternalUncategorizedFile
    {
      set
      {
        ExpandableProperty<StripeFileUpload>.Map(value, s => UncategorizedFileId = s, o => UncategorizedFile = o);
      }
    }
    #endregion

    [JsonProperty("uncategorized_text")]
    public string UncategorizedText { get; set; }
  }
}