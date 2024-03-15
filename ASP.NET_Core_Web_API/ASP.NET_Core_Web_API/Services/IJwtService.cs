namespace ASP.NET_Core_Web_API.Services
{
    public interface IJwtService
    {
        string Authentication(string username, string password);
    }
}
