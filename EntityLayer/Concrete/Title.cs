using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Title  //Diğer sınıflardan erişim sağlamak için public yazdık.
    {
        [Key]
        public int TitleID { get; set; }
        [StringLength(50)]
        public string TitleName { get; set; }
        public DateTime TitleDate { get; set; }
        public bool TitleStatus { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; } //ilişikili olup olmadığını anlamak için category ile bire çok bir ilişki oluşturmak istiyoruz.

        public int WriterID { get; set; } //yazar ve başlık ilişkisi yapıldı. Başlığı hangi yazarın açtığını görmek için
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; } //Title classımız content ile ilişkili olacak
        
    }
}
