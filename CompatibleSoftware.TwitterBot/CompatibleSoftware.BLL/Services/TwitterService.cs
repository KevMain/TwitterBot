using CompatibleSoftware.BLL.Repositories;

namespace CompatibleSoftware.BLL.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly ITwitterRepository _twitterRepository;
        
        public TwitterService(ITwitterRepository twitterRepository)
        {
            _twitterRepository = twitterRepository;
        }
        
        public void SendTweetToUser(string username, string message)
        {
            _twitterRepository.SendTweet(username, message);
        }
    }
}
