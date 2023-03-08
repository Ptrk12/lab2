using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using Infrastructure.Memory;
using Infrastructure.Memory.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();

builder.Services.AddSingleton(typeof(IGenericRepository<Quiz,int>), typeof(MemoryGenericRepository<Quiz, int>));
builder.Services.AddSingleton(typeof(IGenericRepository<QuizItem,int>), typeof(MemoryGenericRepository<QuizItem, int>));
builder.Services.AddSingleton(typeof(IGenericRepository<QuizItemUserAnswer,string>), typeof(MemoryGenericRepository<QuizItemUserAnswer, string>));
builder.Services.AddScoped<IQuizUserService, QuizUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.Seed();
app.Run();