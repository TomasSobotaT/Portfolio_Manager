using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using PortfolioManager.Chat.Interfaces;

namespace PortfolioManager.Chat.Managers
{
	/// <summary>
	/// Communication with OPENAI API
	/// </summary>
	public class OpenAIChatManager :IOpenAIChatManager
	{
		private const string ApiKey = ApiOptions.ChatGptApiKey;
		private const string OrgId = ApiOptions.ChatGptOrgId;
		private string answerOptions = ApiOptions.answerOptions;

		private List<ChatMessage> messages = new();


		public OpenAIChatManager() => this.messages.Add(new ChatMessage(ChatMessageRole.System, answerOptions));

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
			{ 
		messages.RemoveAt(1);
                messages.RemoveAt(2);

            }


            return answer;

}

}
}
