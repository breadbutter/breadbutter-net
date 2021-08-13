using ServiceStack;
using System;
using System.Collections.Generic;
using System.Net;

namespace BreadButter
{
    public class BreadButterException : Exception
    {
        public HttpStatusCode httpStatusCode { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }


        internal BreadButterException(HttpStatusCode httpStatusCode, string errorCode, string errorMessage,
            Exception innerException) : base(errorMessage, innerException)
        {
            this.httpStatusCode = httpStatusCode;
            this.errorCode = errorCode;
            this.errorMessage = errorMessage;


        }

        internal static BreadButterException GetException(WebServiceException ex)
        {
            var genericBaseResponse = ServiceStack.Text.JsonSerializer.DeserializeFromString<System.Dynamic.ExpandoObject>(ex.ResponseBody);


            string errorCode = null;
            string errorMessage = null;

            var baseResponseDict = genericBaseResponse as IDictionary<string, object>;
            if (baseResponseDict.ContainsKey("error"))
            {
                var errorDict = baseResponseDict["error"] as IDictionary<string, object>;

                if (errorDict.ContainsKey("code"))
                {
                    errorCode = (string)errorDict["code"];
                }

                if (errorDict.ContainsKey("message"))
                {
                    errorMessage = (string)errorDict["message"];
                }
            }


            return new BreadButterException((HttpStatusCode)ex.StatusCode, errorCode, errorMessage, ex);
        }

    }
}
