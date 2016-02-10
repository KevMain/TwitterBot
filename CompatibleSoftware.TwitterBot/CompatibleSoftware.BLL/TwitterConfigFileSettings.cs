using System.Configuration;

namespace CompatibleSoftware.BLL
{
    public class TwitterConfigFileSettings : ITwitterConfiguration
    {
        public string ConsumerKey { get; }
        public string ConsumerSecret { get; }
        public string Token { get; }
        public string TokenSecret { get; }
        public string UserName { get; }

        public TwitterConfigFileSettings()
        {
            ConsumerKey = ConfigurationManager.AppSettings["Twitter.ConsumerKey"];
            ConsumerSecret = ConfigurationManager.AppSettings["Twitter.ConsumerSecret"];
            Token = ConfigurationManager.AppSettings["Twitter.Token"];
            TokenSecret = ConfigurationManager.AppSettings["Twitter.TokenSecret"];
            UserName = ConfigurationManager.AppSettings["Twitter.UserName"];
        }
    }
}
