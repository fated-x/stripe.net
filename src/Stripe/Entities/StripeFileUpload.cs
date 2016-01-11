using System;
using Newtonsoft.Json;
using Stripe.Infrastructure;

namespace Stripe
{
  public class StripeFileUpload : StripeObject
  {
    [JsonProperty("id")]
    public string FileUploadId { get; set; }

    [JsonProperty("object")]
    public string Object { get; set; }

    [JsonProperty("created")]
    [JsonConverter(typeof(StripeDateTimeConverter))]
    public DateTime Created { get; set; }

    [JsonProperty("purpose")]
    public string Purpose { get; set; }

    [JsonProperty("size")]
    public int Size { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
  }

  public class FileParameter
  {
    public byte[] File { get; set; }

    public string FileName { get; set; }

    public string ContentType { get; set; }

    public FileParameter(byte[] file) : this(file, null) { }

    public FileParameter(byte[] file, string filename) : this(file, filename, null) { }

    public FileParameter(byte[] file, string filename, string contenttype)
    {
      File = file;
      FileName = filename;
      ContentType = contenttype;
    }
  }
}