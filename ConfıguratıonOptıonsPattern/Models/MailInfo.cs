namespace ConfıguratıonOptıonsPattern.Models
{
	public class MailInfo
	{
        public string Host { get; set; }
        public string Port { get; set; }
        public EmailInfos EmailInfo { get; set; }


      
    }
	public class EmailInfos
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
