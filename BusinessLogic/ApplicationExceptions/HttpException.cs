using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApplicationExceptions
{

	[Serializable]
	public class HttpException : ApplicationException
	{
        public HttpStatusCode StatusCode { get; }
        public HttpException() 
		{
			StatusCode = HttpStatusCode.InternalServerError;
		}
		public HttpException(string message, HttpStatusCode status = HttpStatusCode.InternalServerError) : base(message) 
		{
			StatusCode = status;
		}
		public HttpException(string message, HttpStatusCode status, Exception inner) : base(message, inner) 
		{
            StatusCode = status;
        }
		protected HttpException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
