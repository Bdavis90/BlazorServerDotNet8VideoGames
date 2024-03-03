using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGames.Data;
using VideoGames.Models;

namespace VideoGames.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly DataContext _dataContext;
        public VideoGameService(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<List<VideoGame>> GetVideoGamesAsync()
        {
            return await _dataContext?.VideoGames?.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<VideoGame> GetVideoGameByIdAsync(int id)
        {
            return await _dataContext.VideoGames.FindAsync(id);
        }

        [HttpPost]
        public async Task AddVideoGameAsync(VideoGame videoGame)
        {

            _dataContext?.VideoGames?.Add(videoGame);
            await _dataContext?.SaveChangesAsync();

        }

        [HttpDelete("{id}")]
        public async Task DeleteVideoGameAsync(int id)
        {
            var game = await _dataContext.VideoGames.FindAsync(id);
            if (game != null)
            {
                _dataContext.VideoGames.Remove(game);
            }
        }

        [HttpPut("{id}")]
        public async Task UpdateVideoGameAsync(VideoGame newGame, int id)
        {
            var game = await _dataContext.VideoGames.FindAsync(id);

            if (game != null)
            {
                game.Title = newGame.Title;
                game.Developer = newGame.Developer;
                game.ReleaseYear = newGame.ReleaseYear;

                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
