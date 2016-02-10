using TweetSharp;

namespace CompatibleSoftware.BLL
{
    public class Twitter
    {
        private readonly TwitterService _twitterService;
        
        public Twitter()
        {
            _twitterService = new TwitterService("", "");
            _twitterService.AuthenticateWith("", "");
        }
        
        public void SendTweetToUser(string username, string message)
        {
            _twitterService.SendTweet(
                new SendTweetOptions
                {
                    Status = $"@{username} {message}"
                });
        }
    }
}
