using ConfıguratıonOptıonsPattern.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace ConfıguratıonOptıonsPattern.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		MailInfo _mailInfo;
		private readonly IConfiguration _configuration;

		public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IOptions<MailInfo> options)
		{
			_logger = logger;
			_configuration = configuration;
			_mailInfo = options.Value;  //DI ile ulasabilmek icin  IOptions<MailInfo> nesnesini constructora'a ekledim ve Bu Sekilde IoC ICERISINE VERMIS
			//Oldugum AppSetting.json dosyasi icerisinde tanimladigim MailInfo'nun nesnesine ulasabiliyorum.
		}

		public IActionResult Index()
		{
			//Options Design Pattern ile ulasabiliyorum.
			string port=  _mailInfo.Port;
			string host = _mailInfo.Host;
			string email = _mailInfo.EmailInfo.Email;
			string password = _mailInfo.EmailInfo.Password;




			//string host= _configuration["Mailİnfo:Host"];
			//string port= _configuration["Mailİnfo:Port"];

			MailInfo mailInfo= _configuration.GetSection("Mailİnfo").Get<MailInfo>();


			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
