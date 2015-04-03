using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacePuls
{
    public interface ISerive
    {
        Task<T> HttpPost<T>(string partUrl, IDictionary<object, object> dictionary) where T : class;
        Task<T> HttpGet<T>(string partUrl, IDictionary<object, object> dictionary) where T : class;
    }

    public interface IHttpMethod
    {
      Task <string>HttpPost(string url, string param);
      Task<string> HttpPost(string url, IDictionary<object, object> param, byte[] fileByte);
      Task<string> HttpGet(string url);
    }
}
