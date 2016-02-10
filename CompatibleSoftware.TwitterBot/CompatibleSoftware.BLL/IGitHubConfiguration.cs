namespace CompatibleSoftware.BLL
{
    public interface IGitHubConfiguration
    {
        string Token { get; }
        string AppName { get; }
        string UserName { get; }
    }
}
