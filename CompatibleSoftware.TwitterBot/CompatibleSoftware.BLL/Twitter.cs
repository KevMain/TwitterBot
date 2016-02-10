using System.Configuration;
using TweetSharp;

namespace CompatibleSoftware.BLL
{
    public class Twitter : ITwitter
    {
        private readonly TwitterService _twitterService;
        
        public Twitter()
        {
            var consumerKey = ConfigurationManager.AppSettings["Twitter.ConsumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["Twitter.ConsumerSecret"];
            var token = ConfigurationManager.AppSettings["Twitter.Token"];
            var tokenSecret = ConfigurationManager.AppSettings["Twitter.TokenSecret"];

            _twitterService = new TwitterService(consumerKey, consumerSecret);
            _twitterService.AuthenticateWith(token, tokenSecret);
        }
        
        public void SendTweetToUser(string message)
        {
            var twitterUserName = ConfigurationManager.AppSettings["Twitter.UserName"];

            _twitterService.SendTweet(
                new SendTweetOptions
                {
                    Status = $"@{twitterUserName} {message}"
                });
        }
    }
}
