using System.Runtime.CompilerServices;

namespace Book_App.Infrastrucrure
{
    public static class UrlExtensions
    {
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
       
    }
}
