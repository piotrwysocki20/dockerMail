namespace DockerTraining.Web.Infrastructure
{
    public class SmtpServerSettings
    {
        public string ServerAddress { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
