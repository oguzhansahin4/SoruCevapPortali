using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soruCevapPortali.Models;
using soruCevapPortali.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace soruCevapPortali.Controllers
{
    public class SoruController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        public SoruController(AppDbContext dbContext, ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var sorular = _dbContext.Questions.ToList();
            return View(sorular);
        }

        public IActionResult soruEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult soruEkle(QuestionModel yeniSoru)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sorular newQuestion = new Sorular
                    {
                        Title = yeniSoru.Title,
                        Content = yeniSoru.Content,
                        CreatedAt = DateTime.Now,
                        UserId = _userManager.GetUserId(User),
                };
                    _dbContext.Questions.Add(newQuestion);
                    _dbContext.SaveChanges();
                    _logger.LogInformation("Veri Tabanı Kaydı Oldu");

                }
                catch
                {
                    _logger.LogInformation("Veri Tabanı Kaydı OlMADI");

                }
            

            }
            else
            {
                _logger.LogInformation("ModelState Çalışmadı");
            }
            return RedirectToAction("soruCevapGorunum");
        }

        private int GetLoggedInUserId()
        {
            return 1;
        }
        public IActionResult sorular()
        {
            var sorular = GetSorular();
            var cevaplar = GetCevaplar();

            var model = new QuestionModel
            {
            };

            return View(model);
        }

        private List<Sorular> GetSorular()
        {
            return new List<Sorular>
        {
            new Sorular { QuestionId = 1, Content = "Soru 1", Title = "Soru 1 içeriği" },
            new Sorular { QuestionId = 2, Content = "Soru 2", Title = "Soru 2 içeriği" }
        };
        }

        private List<Cevaplar> GetCevaplar()
        {
            return new List<Cevaplar>
        {
            new Cevaplar { AnswerId = 1, Content = "Cevap 1 içeriği" },
            new Cevaplar { AnswerId = 2, Content = "Cevap 2 içeriği" }
        };
        }
        public IActionResult soruCevapGorunum()
        {
            var questions = _dbContext.Questions.ToList();
            var answers = _dbContext.Answers.ToList();

            var combinedViewModel = new CiftOzellikModel
            {

                Questions = questions.Select(question => new QuestionModel
                {
                    QuestionId = question.QuestionId,
                    Title = question.Title,
                    Content = question.Content,
                    CreatedAt = DateTime.Now,
                }).ToList(),
                Answers = answers.Select(answer => new AnswerModel
                {
                    AnswerId = answer.AnswerId,
                    Content = answer.Content,
                    CreatedAt = DateTime.Now,
                    QuestionId = answer.QuestionId,
                }).ToList(),
            };
            return View(combinedViewModel); 
        }

        public IActionResult CombinedView()
        {
            

            return View();
        }

        public IActionResult CevapEkle(int id)
        {

            var question = _dbContext.Questions
                .Where(a => a.QuestionId == id)
                .FirstOrDefault();
            var answerModel = new AnswerModel()
            {
                QuestionId = id,
                QuestionTitle = question.Title,
                QuestionContent = question.Content,

            };
            return View(answerModel);
        }

        [HttpPost]
        public IActionResult CevapEkle(AnswerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = _userManager.GetUserId(User);

                    if (userId != null)
                    {
                        var answer = new Cevaplar
                        {
                            QuestionId = model.QuestionId,
                            Content = model.Content,
                            CreatedAt = DateTime.Now,
                            UserId = userId,
                        };

                        _dbContext.Answers.Add(answer);
                        var affectedRows = _dbContext.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation("Cevaplar veritabanına başarıyla kaydedildi.");
                        }
                        else
                        {
                            _logger.LogWarning("Veritabanına kayıt eklenirken bir hata oluştu.");
                        }
                    }
                    else
                    {
                        _logger.LogError("Kullanıcı kimliği alınamadı.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Veritabanına kayıt eklenirken bir hata oluştu: {ex.Message}");
                }
            }
            else
            {
                _logger.LogWarning("Model geçerli değil. Validasyon hatası.");
            }

            return RedirectToAction("soruCevapGorunum");
        }
    }
}
