namespace CompatibleSoftware.BLL.Services
{
    public interface ITwitterService
    {
        void SendTweetToUser(string username, string message);
    }
}