using System.Net;

namespace Pizzeria.Core.Exceptions
{
    public class EmptyOrderCollectionBodyException:ApiException
    {
        public EmptyOrderCollectionBodyException(HttpStatusCode statusCode, string message) : base(statusCode, message)
        {
        }
    }
}