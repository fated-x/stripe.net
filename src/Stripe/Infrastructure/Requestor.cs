using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Stripe
{
  internal static class Requestor
  {
    public static string GetString(string url, StripeRequestOptions requestOptions)
    {
      var wr = GetWebRequest(url, "GET", requestOptions);

      return ExecuteWebRequest(wr);
    }

    public static string PostString(string url, StripeRequestOptions requestOptions)
    {
      var wr = GetWebRequest(url, "POST", requestOptions);

      return ExecuteWebRequest(wr);
    }

    public static string PostMultipart(string url, StripeRequestOptions requestOptions, Dictionary<string, object> postParameters)
    {
      var wr = GetWebRequest(url, "POST", requestOptions, false, postParameters);

      return ExecuteWebRequest(wr);
    }

    public static string Delete(string url, StripeRequestOptions requestOptions)
    {
      var wr = GetWebRequest(url, "DELETE", requestOptions);

      return ExecuteWebRequest(wr);
    }

    public static string PostStringBearer(string url, StripeRequestOptions requestOptions)
    {
      var wr = GetWebRequest(url, "POST", requestOptions, true);

      return ExecuteWebRequest(wr);
    }

    internal static WebRequest GetWebRequest(string url, string method, StripeRequestOptions requestOptions, bool useBearer = false, Dictionary<string, object> postParameters = null)
    {
      requestOptions.ApiKey = requestOptions.ApiKey ?? StripeConfiguration.GetApiKey();

      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

      var request = (HttpWebRequest)WebRequest.Create(url);
      request.Method = method;

      request.Headers.Add("Authorization", !useBearer ? GetAuthorizationHeaderValue(requestOptions.ApiKey) : GetAuthorizationHeaderValueBearer(requestOptions.ApiKey));

      request.Headers.Add("Stripe-Version", StripeConfiguration.ApiVersion);

      if (requestOptions.StripeConnectAccountId != null)
        request.Headers.Add("Stripe-Account", requestOptions.StripeConnectAccountId);

      if (requestOptions.IdempotencyKey != null)
        request.Headers.Add("Idempotency-Key", requestOptions.IdempotencyKey);

      request.ContentType = "application/x-www-form-urlencoded";
      request.UserAgent = "Stripe.net (https://github.com/jaymedavis/stripe.net)";

      if (postParameters != null)
      {
        string formDataBoundary = $"----------{Guid.NewGuid():N}";
        request.ContentType = "multipart/form-data; boundary=" + formDataBoundary;

        var formData = GetMultipartFormData(postParameters, formDataBoundary);
        request.ContentLength = formData.Length;

        // Send the form data to the request.
        using (var requestStream = request.GetRequestStream())
        {
          requestStream.Write(formData, 0, formData.Length);
          requestStream.Close();
        }
      }

      return request;
    }

    private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
    {
      var encoding = Encoding.UTF8;
      Stream formDataStream = new MemoryStream();
      var needsCLRF = false;

      foreach (var param in postParameters)
      {
        // Add a CRLF to allow multiple parameters to be added.
        // Skip it on the first parameter, add it to subsequent parameters.
        if (needsCLRF)
          formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

        needsCLRF = true;

        if (param.Value is FileParameter)
        {
          var fileToUpload = (FileParameter)param.Value;

          // Add just the first part of this param, since we will write the file data directly to the Stream.
          string header = $"--{boundary}\r\nContent-Disposition: form-data; name=\"{param.Key}\"; filename=\"{fileToUpload.FileName ?? param.Key}\";\r\nContent-Type: {fileToUpload.ContentType ?? "application/octet-stream"}\r\n\r\n";

          formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

          // Write the file data directly to the Stream, rather than serializing it to a string.
          formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
        }
        else
        {
          var postData = $"--{boundary}\r\nContent-Disposition: form-data; name=\"{param.Key}\"\r\n\r\n{param.Value}";
          formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
        }
      }

      // Add the end of the request.  Start with a newline
      string footer = "\r\n--" + boundary + "--\r\n";
      formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

      // Dump the Stream into a byte[].
      formDataStream.Position = 0;
      byte[] formData = new byte[formDataStream.Length];
      formDataStream.Read(formData, 0, formData.Length);
      formDataStream.Close();

      return formData;
    }

    private static string GetAuthorizationHeaderValue(string apiKey)
    {
      var token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:"));
      return $"Basic {token}";
    }

    private static string GetAuthorizationHeaderValueBearer(string apiKey)
    {
      return $"Bearer {apiKey}";
    }

    private static string ExecuteWebRequest(WebRequest webRequest)
    {
      try
      {
        using (var response = webRequest.GetResponse())
        {
          return ReadStream(response.GetResponseStream());
        }
      }
      catch (WebException webException)
      {
        if (webException.Response != null)
        {
          var statusCode = ((HttpWebResponse)webException.Response).StatusCode;

          var stripeError = new StripeError();

          if (webRequest.RequestUri.ToString().Contains("oauth"))
            stripeError = Mapper<StripeError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()));
          else
            stripeError = Mapper<StripeError>.MapFromJson(ReadStream(webException.Response.GetResponseStream()), "error");

          throw new StripeException(statusCode, stripeError, stripeError.Message);
        }

        throw;
      }
    }

    private static string ReadStream(Stream stream)
    {
      using (var reader = new StreamReader(stream, Encoding.UTF8))
      {
        return reader.ReadToEnd();
      }
    }
  }
}