using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartyWrapper.Service.WebHelper
{
    public interface IWebRequest 
    {
        IRespone SendRequest(IRequest request);
        IResponse<T> SendRequest<T>(IRequest request);
    }
}
