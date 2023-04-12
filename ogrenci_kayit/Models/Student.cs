using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ogrenci_kayit.Models
{
    public class Student
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int StudentID { get; set; }

        [Required(ErrorMessage="İsim zorunlu alandır!")]
        [DisplayName("İsim")]
        public string? StudentName { get; set; }

        [Required(ErrorMessage = "Soyisim zorunlu alandır!")]
        [DisplayName("Soyisim")]
        public string? StudentSurname { get; set; }

        [DisplayName("Bölüm")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Yaş zorunlu alandır!")]
        [DisplayName("Yaş")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Öğrenci numarası zorunlu alandır!")]
        [DisplayName("Öğrenci Numarası")]
        public int StudentNumber { get; set; }
    }
}
