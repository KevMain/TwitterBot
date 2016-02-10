namespace CompatibleSoftware.BLL.Repositories
{
    public interface ITwitterRepository
    {
        void SendTweet(string username, string message);
    }
}