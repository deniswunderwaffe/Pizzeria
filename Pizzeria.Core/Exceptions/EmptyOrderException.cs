using System.Net;

namespace Pizzeria.Core.Exceptions
{
    public class EmptyOrderException:ApiException
    {
        public EmptyOrderException(HttpStatusCode statusCode, string message) : base(statusCode, message)
        {
        }
    }
}