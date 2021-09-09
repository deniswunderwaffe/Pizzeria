using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzeria.Core.HelperClasses
{
    public static class PizzaHelper
    {
        public enum PizzaTypes
        {
            American,
            Italian,
            Japanese
        }

        public static IEnumerable<string> GetTypes()
        {
            return Enum.GetNames(typeof(PizzaTypes)).ToList();
        }
    }
}