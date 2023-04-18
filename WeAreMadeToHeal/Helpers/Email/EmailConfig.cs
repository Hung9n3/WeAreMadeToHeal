namespace WeAreMadeToHeal.Helpers.Email
{
    public class EmailConfig
    {
        public string EmailHost { get; set; }
        public string EmailUsername { get; set; }
        public string AppPassword { get; set; }
        public int Port { get; set; }

        public EmailConfig(IConfiguration configuration)
        {
            this.EmailHost = configuration["EmailConfig:EmailHost"];
            this.EmailUsername = configuration["EmailConfig:EmailUsername"];
            this.AppPassword = configuration["EmailConfig:AppPassword"];
            this.Port = int.Parse(configuration["EmailConfig:Port"]);
        }

    }
}
