using TweetSharp;

namespace CompatibleSoftware.BLL.Repositories
{
    public class TwitterRepository : ITwitterRepository
    {
        private readonly TweetSharp.TwitterService _twitterService;

        public TwitterRepository(string consumerKey, string consumerSecret, string token, string tokenSecret)
        {
            _twitterService = new TweetSharp.TwitterService(consumerKey, consumerSecret);
            _twitterService.AuthenticateWith(token, tokenSecret);
        }

        public void SendTweet(string username, string message)
        {
            _twitterService.SendTweet(
                new SendTweetOptions
                {
                    Status = $"@{username} {message}"
                });
        }
    }
}
