using Microsoft.EntityFrameworkCore;
using VideoGames;
using VideoGames.Components;
using VideoGames.Data;
using VideoGames.Models;
using VideoGames.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyDB")));
builder.Services.AddScoped<IVideoGameService, VideoGameService>();
var app = builder.Build();
AddVideoGameData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();


static void AddVideoGameData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<DataContext>();

    db.VideoGames.AddRange(new VideoGame[] {
                new VideoGame { Id = 1, Title = "Cyberpunk 2077", Developer = "CD Projekt Red", ReleaseYear = 2020 },
                new VideoGame { Id = 2, Title = "Elden Ring", Developer = "FromSoftware", ReleaseYear = 2022 },
                new VideoGame { Id = 3, Title = "Red Dead Redemption 2", Developer = "Rockstar", ReleaseYear = 2018 }
                });

    db.SaveChanges();
}
