using System;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Services
{
    public class PromotionalCodeService : IPromotionalCodeService
    {
        private readonly IRepository<PromotionalCode> _repository;

        public PromotionalCodeService(IRepository<PromotionalCode> repository)
        {
            _repository = repository;
        }

        public PromotionalCodeResponse ValidateCode(string codeToValidate)
        {
            var resultOfValidation = _repository.FirstOrDefault(x => x.Code == codeToValidate);
            var response = new PromotionalCodeResponse();
            if (resultOfValidation == null) return response;
            if (!resultOfValidation.IsActive.GetValueOrDefault()) return response;
            if (resultOfValidation.ExpirationDate < DateTime.Now || resultOfValidation.MaximumUses < 0)
            {
                resultOfValidation.IsActive = false;
                _repository.SaveAll();
                return response;
            }

            resultOfValidation.MaximumUses = resultOfValidation.MaximumUses - 1;

            response.Discount = resultOfValidation.Discount;
            response.Name = resultOfValidation.Name;
            response.Id = resultOfValidation.Id;
            response.IsValid = true;

            return response;
        }

        public void AddPromotionalCode(PromotionalCode promotionalCode)
        {
            _repository.Add(promotionalCode);
            _repository.SaveAll();
        }

        public PromotionalCode GetPromotionalCodeById(int id)
        {
            var promotionalCode = _repository.GetById(id);
            return promotionalCode;
        }
    }
}