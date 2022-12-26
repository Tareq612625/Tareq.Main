using System.Net.Http;
using System.Net;
using System.Text.Json;

namespace Tareq.Utility.Web
{
    public static class TareqUtility
    {
        public static IpInfoClass GetRemoteIPAddress()
        {
            HttpClient client = new HttpClient();
            var result = client.GetStringAsync("https://api.db-ip.com/v2/free/self").Result;
            var ip = JsonSerializer.Deserialize<IpInfoClass>(result.ToString());

            if (ip.ipAddress == "")
            {
                return (new IpInfoClass());
            }
            else
            {
                return JsonSerializer.Deserialize<IpInfoClass>(result.ToString());

            }
        }

    }
}