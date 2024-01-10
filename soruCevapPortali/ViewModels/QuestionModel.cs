using soruCevapPortali.Models;

namespace soruCevapPortali.ViewModels
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
