using System.ComponentModel.DataAnnotations;

namespace CrazyMusicians.Models
{
    public class MusicianDto
    {
        // İsim alanı zorunludur, boş bırakılamaz.
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "İsim en fazla 50 karakter olabilir.")]
        public string Name { get; set; }

        // Meslek alanı zorunludur, boş bırakılamaz.
        [Required(ErrorMessage = "Meslek alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Meslek en fazla 50 karakter olabilir.")]
        public string Profession { get; set; }

        // Eğlenceli özellik alanı isteğe bağlıdır, ancak maksimum 200 karakter olabilir.
        [MaxLength(200, ErrorMessage = "Eğlenceli özellik en fazla 200 karakter olabilir.")]
        public string FunFact { get; set; }
    }
}
