using VideoGames.Models;

namespace VideoGames
{
    public interface IVideoGameService
    {
        Task AddVideoGameAsync(VideoGame videoGame);
        Task DeleteVideoGameAsync(int id);
        Task<VideoGame> GetVideoGameByIdAsync(int id);
        Task<List<VideoGame>> GetVideoGamesAsync();
        Task UpdateVideoGameAsync(VideoGame newGame, int id);
    }
}