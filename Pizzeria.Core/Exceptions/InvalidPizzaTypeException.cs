using System.Net;

namespace Pizzeria.Core.Exceptions
{
    public class InvalidPizzaTypeException:ApiException
    {
        public InvalidPizzaTypeException(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}