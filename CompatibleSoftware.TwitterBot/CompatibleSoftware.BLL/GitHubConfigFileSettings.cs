using System.Configuration;

namespace CompatibleSoftware.BLL
{
    public class GitHubConfigFileSettings : IGitHubConfiguration
    {
        public string Token { get; }
        public string AppName { get; }
        public string UserName { get; }

        public GitHubConfigFileSettings()
        {
            Token = ConfigurationManager.AppSettings["GitHub.Token"];
            AppName = ConfigurationManager.AppSettings["GitHub.AppName"];
            UserName = ConfigurationManager.AppSettings["GitHub.User"];
        }
    }
}
