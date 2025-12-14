namespace TODO.Services
{
    public interface ISessionManagerService
    {
        public void Add(string key, object obj, HttpContext context);
        T Get<T>(string v, HttpContext httpContext);
    }
}
