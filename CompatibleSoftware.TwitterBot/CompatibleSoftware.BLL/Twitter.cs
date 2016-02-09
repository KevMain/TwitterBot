using TweetSharp;

namespace CompatibleSoftware.BLL
{
    public class Twitter
    {
        private readonly TwitterService _twitterService;

        public Twitter()
        {
            _twitterService = new TwitterService("ConsumerKey", "SecretKey");
            Authenticate();
        }

        private void Authenticate()
        {
            var uri = _twitterService.GetAuthorizationUri(_twitterService.GetRequestToken());
        }


        public void SendTweet(string message)
        {
            _twitterService.SendTweet(new SendTweetOptions());
        }
    }
}
