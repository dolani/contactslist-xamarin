using ContactsList.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsList.Validator
{
    public class ContactValidator : AbstractValidator<ContactInfo>
    {
        public ContactValidator()
        {
            RuleFor(c => c.Name).Must(n => ValidateStringEmpty(n)).WithMessage("Contact name should not be empty.");
            RuleFor(c => c.MobileNumber).NotNull().InclusiveBetween("11", "13");
            RuleFor(c => c.Age).Must(a => ValidateStringEmpty(a)).WithMessage("Contact Age should not be empty.");
            RuleFor(c => c.Gender).Must(g => ValidateStringEmpty(g)).WithMessage("Contact Gender should not be empty.");
            RuleFor(c => c.DOB).Must(d => ValidateStringEmpty(d.ToString())).WithMessage("Contact DOB should not be empty.");
            RuleFor(c => c.Address).Must(a => ValidateStringEmpty(a)).WithMessage("Contact Adress should not be empty.");
        }

        bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }
    }
}
