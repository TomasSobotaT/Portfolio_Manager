using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PortfolioManager.Chat.Interfaces;
using PortfolioManager.Chat.Managers;

namespace PortfolioManager.Controllers
{

	public class ChatController : Controller
	{

		private IOpenAIChatManager manager;
		public ChatController(IOpenAIChatManager manager) 
		{
			this.manager = manager;
		}	

		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public async Task<string> GetAnswer([FromBody] string question) {

			string answer = await manager.GenerateAnswerAsync(question);
			return answer;
		}




	
	}
}
