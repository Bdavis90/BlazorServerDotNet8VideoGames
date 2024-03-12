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

        public async Task<List<VideoGame>> GetVideoGamesAsync()
        {
            return await _dataContext?.VideoGames?.ToListAsync();
        }

        public async Task<VideoGame> GetVideoGameByIdAsync(int id)
        {
            return await _dataContext.VideoGames.FindAsync(id);
        }

        public async Task AddVideoGameAsync(VideoGame videoGame)
        {

            _dataContext?.VideoGames?.Add(videoGame);
            await _dataContext?.SaveChangesAsync();

        }

        public async Task DeleteVideoGameAsync(int id)
        {
            var game = await _dataContext.VideoGames.FindAsync(id);
            if (game != null)
            {
                _dataContext.VideoGames.Remove(game);
                await _dataContext.SaveChangesAsync();
            }
        }

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
