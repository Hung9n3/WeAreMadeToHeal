using Microsoft.Extensions.Configuration;
using System.Text;

namespace WeAreMadeToHeal.Helpers.Auth
{
    public class AppSettings
    {
        public string? SecretKey { get; set; }
        public int ExpiredDay { get; set; }

        public AppSettings(IConfiguration configuration)
        {
            this.SecretKey = Encoding.UTF8.GetBytes(configuration["AppSettings:SecretKey"]).ToString();
            this.ExpiredDay = int.Parse(configuration["AppSettings:ExpiredDay"]);

        }
    }
}
