using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content //içerik anlamına gelir.
    {
        [Key] //sınıfların key olması gerekiyor.
        public int ContentID { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }  //içeriğin metni değeri
        public DateTime ContentDate { get; set; }
        //ContentYazar (Bu yazı kim tarafından yazıldı)
        //ContentBaşlık(Bu yazı hangi başlık için yazıldı)
        public bool ContentStatus { get; set; }
        public int TitleID { get; set; }
        public virtual Title Title { get; set; } //başlık ile içeriği ilişkilendirdik.

        public int? WriterID { get; set; } //nunIbiltype
        public virtual Writer Writer { get; set; }
    }
}
