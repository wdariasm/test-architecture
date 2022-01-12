using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace TicketManagement.Application.Exceptions
{
    public class ValidationException: ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
        }
    }
}
