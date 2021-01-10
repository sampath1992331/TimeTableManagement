using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public interface IResponse
    {
        Response GenerateResponseMessage(string successErrorString, string SuccessErrorCode, string Description, object data);
    }
}
