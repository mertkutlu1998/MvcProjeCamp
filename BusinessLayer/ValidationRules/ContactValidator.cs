using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu Boş Geçemezsiniz.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Kısmını Boş Geçemezsiniz.");
            RuleFor(x => x.UserName).MaximumLength(3).WithMessage("Şütfen en az 3 karakter girişi yapınız.");
        }
    }
}
