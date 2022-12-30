using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() //doğrulama kurallarını contractir metodlarının içine yazacağız.
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçmeyiniz."); //boş olamaz
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçmeyiniz.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 Karakter Girişi Yapınız.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("En fazla 20 Karakter Girişi Yapabilirsiniz.");
        }
    }
}
