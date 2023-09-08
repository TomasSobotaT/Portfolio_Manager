using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Chat.Interfaces
{
	public interface IOpenAIChatManager
	{
		Task<string> GenerateAnswerAsync(string question);
	}
}
