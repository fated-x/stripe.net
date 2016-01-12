using System.Collections.Generic;

namespace Stripe
{
  public class StripeDisputeService : StripeService
  {
    public StripeDisputeService(string apiKey = null) : base(apiKey) { }

    public bool ExpandCharge { get; set; }
    public bool ExpandBalanceTransaction { get; set; }
    public bool ExpandEvidence_CancellationPolicy { get; set; }
    public bool ExpandEvidence_CustomerCommunication { get; set; }
    public bool ExpandEvidence_DuplicateChargeDocumentation { get; set; }
    public bool ExpandEvidence_CustomerSignature { get; set; }
    public bool ExpandEvidence_Receipt { get; set; }
    public bool ExpandEvidence_RefundPolicy { get; set; }
    public bool ExpandEvidence_ServiceDocumentation { get; set; }
    public bool ExpandEvidence_ShippingDocumentation { get; set; }
    public bool ExpandEvidence_UncategorizedFile { get; set; }

    public virtual IEnumerable<StripeDispute> List(StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = Urls.Disputes;
      url = this.ApplyAllParameters(null, url, true);

      var response = Requestor.GetString(url, requestOptions);

      return Mapper<StripeDispute>.MapCollectionFromJson(response);
    }

    public virtual StripeDispute Update(string disputeId, StripeDisputeUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = $"{Urls.Disputes}/{disputeId}";
      url = this.ApplyAllParameters(updateOptions, url, false);

      var response = Requestor.PostString(url, requestOptions);

      return Mapper<StripeDispute>.MapFromJson(response);
    }

    public virtual StripeDispute Close(string disputeId, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);

      var url = $"{Urls.Disputes}/{disputeId}/close";
      url = this.ApplyAllParameters(null, url, false);

      var response = Requestor.PostString(url, requestOptions);

      return Mapper<StripeDispute>.MapFromJson(response);
    }
  }
}