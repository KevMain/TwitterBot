using TweetSharp;

namespace CompatibleSoftware.BLL
{
    public class Twitter : ITwitter
    {
        private readonly TwitterService _twitterService;
        private readonly ITwitterConfiguration _twitterConfiguration;

        public Twitter(ITwitterConfiguration twitterConfiguration)
        {
            _twitterConfiguration = twitterConfiguration;
            _twitterService = new TwitterService(_twitterConfiguration.ConsumerKey, _twitterConfiguration.ConsumerSecret);
            _twitterService.AuthenticateWith(_twitterConfiguration.Token, _twitterConfiguration.TokenSecret);
        }
        
        public void SendTweetToUser(string message)
        {
            _twitterService.SendTweet(
                new SendTweetOptions
                {
                    Status = $"@{_twitterConfiguration.UserName} {message}"
                });
        }
    }
}
