using System.Collections.Generic;

namespace Client.Models
{

    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }

    //public class ReportResponse
    //{
    //    public long StatusCode { get; set; }
    //    public string StatusDescription { get; set; }
    //    public Data Data { get; set; }
    //}

    public class Data
    {
        public string FileContents { get; set; }
        public string ContentType { get; set; }
        public string FileDownloadName { get; set; }
        public object LastModified { get; set; }
        public object EntityTag { get; set; }
        public bool EnableRangeProcessing { get; set; }
    }

    public partial class ReportResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
        public Data Data { get; set; }
    }
}
