namespace CompatibleSoftware.BLL.Configuration
{
    public interface IGitHubConfiguration
    {
        string Token { get; }
        string AppName { get; }
        string UserName { get; }
    }
}
