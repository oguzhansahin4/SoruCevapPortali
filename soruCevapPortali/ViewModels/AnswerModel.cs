using soruCevapPortali.Models;

namespace soruCevapPortali.ViewModels
{
    public class AnswerModel
    {
        public int? AnswerId { get; set; }
        public string Content { get; set; }
        public string? QuestionTitle { get; set; }
        public string? QuestionContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public int QuestionId { get; set; }
    }
}
