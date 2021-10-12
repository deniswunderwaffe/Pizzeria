using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces
{
    public interface IPromotionalCodeService
    {
        PromotionalCodeResponse ValidateCode(string codeToValidate);
        void AddPromotionalCode(PromotionalCode promotionalCode);
        PromotionalCode GetPromotionalCodeById(int id);
    }
}