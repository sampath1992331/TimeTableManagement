using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public class Response : IResponse
    {
        public string ResponseString = string.Empty;
        public string ResponseCode = string.Empty;
        public string Description = string.Empty;
        public object Data { get; set; }

        public Response GenerateResponseMessage(string responseString, string responseCode, string Description, object data)
        {
            this.ResponseString = responseString;
            this.ResponseCode = responseCode;
            this.Description = Description;
            this.Data = data;

            return this;
        }


    }
}
