using System;
using System.Collections.Generic;
using System.Text;

namespace API.Common
{
    public class Envelope<T>
    {
        public bool Success { get; set; }
        public string Response { get; set; }
        public T Data { get; set; }
        public string ExceptionMessage { get; set; }
        public string ErrorType { get; set; }
       
        public Envelope(bool success, string key)
        {
            this.Success = success;
           // Phrases.Get(key, out string responseEn, out string responseAr);
           // this.ResponseAR = responseAr;
           //this.ResponseEN = responseEn;
        }
        public Envelope(bool success, string key, Exception exception) : this(success, key)
        {
            this.ExceptionMessage = exception.Message;
            //if (_logger == null)
            //{
            //    _logger = InjectionResolver.GetKernel<ILogger>("Logger");
            //}
            //_logger.Error(exception);
        }

        public Envelope(bool success, string key, T data) : this(success, key)
        {
            this.Data = data;
        }

    }
}
