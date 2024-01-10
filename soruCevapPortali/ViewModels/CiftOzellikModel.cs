using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace soruCevapPortali.ViewModels
{
    public class CiftOzellikModel
    {
        public List<QuestionModel> Questions { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
