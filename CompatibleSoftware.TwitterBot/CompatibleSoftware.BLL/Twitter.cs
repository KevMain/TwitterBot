using System.Configuration;
using TweetSharp;

namespace CompatibleSoftware.BLL
{
    public class Twitter
    {
        private readonly TwitterService _twitterService;
        
        public Twitter()
        {
            var consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            var token = ConfigurationManager.AppSettings["Token"];
            var tokenSecret = ConfigurationManager.AppSettings["TokenSecret"];

            _twitterService = new TwitterService(consumerKey, consumerSecret);
            _twitterService.AuthenticateWith(token, tokenSecret);
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
