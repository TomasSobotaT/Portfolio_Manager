using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using PortfolioManager.Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManager.Chat.Managers
{
	public class OpenAIChatManager :IOpenAIChatManager
	{
		private const string ApiKey = "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";
		private const string OrgId = "org-MuAnU5yTZJCiNb31UImRIpMJ";
		private string options = "Odpovídej ve vážném stylu finančnicví, investování a bankovnictví.Odpověd maximálně 250 znaků.Vždy vykej a odpovídej v českém jazyce.";
		private List<ChatMessage> messages = new();


		public OpenAIChatManager() => this.messages.Add(new ChatMessage(ChatMessageRole.System, options));

		public async Task<string> GenerateAnswerAsync(string question)
		{ 

		messages.Add(new ChatMessage(ChatMessageRole.User, question));	

		var ai = new OpenAIAPI(new APIAuthentication(ApiKey, OrgId));

		ChatRequest request = new ChatRequest();
		request.user = "PortfolioManager_User";
		request.Model = Model.ChatGPTTurbo;
		request.Messages = messages;
		request.Temperature = 0.7;
		request.MaxTokens = 350;


		var response = await ai.Chat.CreateChatCompletionAsync(request);

		string answer = response.Choices.FirstOrDefault().Message.Content;

		messages.Add(response.Choices.FirstOrDefault().Message);


	if (messages.Count > 7)
		messages.RemoveAt(1);
		

	return answer;

}

}
}
