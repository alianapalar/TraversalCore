﻿using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUsValidationRules
{
    public class SendContactUsValidator:AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidator()
        {
            RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
            RuleFor(y => y.Subject).MinimumLength(5).WithMessage("Konu alanına en az 5 karakter veri girişi yapmalısınız.");
            RuleFor(y => y.Subject).MaximumLength(100).WithMessage("Konu alanına en fazla 100 karakter veri girişi yapmalısınız.");
            RuleFor(y => y.Mail).MinimumLength(5).WithMessage("Mail alanına en az 5 karakter veri girişi yapmalısınız.");
            RuleFor(y => y.Mail).MaximumLength(100).WithMessage("Mail alanına en fazla 100 karakter veri girişi yapmalısınız.");
        }
    }
}