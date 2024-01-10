using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace soruCevapPortali.Models
{
    public class Cevaplar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int QuestionId { get; set; }
        public Sorular? Sorular { get; set; }
    }

}
