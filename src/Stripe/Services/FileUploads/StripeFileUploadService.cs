using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace Stripe
{
  public class StripeFileUploadService : StripeService
  {
    public StripeFileUploadService(string apiKey = null) : base(apiKey) { }

    public virtual StripeFileUpload Create(StripeFileUploadCreateOptions createOptions, StripeRequestOptions requestOptions = null)
    {
      requestOptions = SetupRequestOptions(requestOptions);
      var fileName = createOptions.File.Substring(createOptions.File.LastIndexOf(@"\", StringComparison.Ordinal) + 1);

      FileParameter fileParameter = new FileParameter(File.ReadAllBytes(createOptions.File), fileName, "multipart/form-data");
      var postParameters = new Dictionary<string, object>
      {
        { "file", fileParameter },
        { "purpose", createOptions.Purpose }
      };
      var response = Requestor.PostMultipart(Urls.FileUploads, requestOptions, postParameters);

      return Mapper<StripeFileUpload>.MapFromJson(response);
    }
  }
}