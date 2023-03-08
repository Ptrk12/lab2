using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            QuizItem quizItem1 = new QuizItem(1, "Correct planet ?", new List<string>() { "ziemia", "jowisz", "mars" }, "pluton");
            QuizItem quizItem2 = new QuizItem(2, "Correct animal ?", new List<string>() { "pies", "kot", "mysz" }, "karaluch");
            QuizItem quizItem3 = new QuizItem(3, "Correct color ?", new List<string>() { "czarny", "żółty", "ciapek" }, "biały");

            List<QuizItem> list = new List<QuizItem>() { quizItem1, quizItem2, quizItem3 };

            Quiz quiz = new Quiz(1,list,"tytuł");

            quizItemRepo.Add(quizItem1);
            quizItemRepo.Add(quizItem2);
            quizItemRepo.Add(quizItem3);

            quizRepo.Add(quiz);
        }
    }
}