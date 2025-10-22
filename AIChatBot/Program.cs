using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static readonly HttpClient httpClient = new HttpClient();
    private static readonly List<string> chatHistory = new List<string>(); // Chat History
    private static readonly string logPath = "chat_log.txt";

    static async Task Main(string[] args)
    {
        string apiKey = "WRITE_YOUR_OWN_GROQ_API_KEY_HERE"; // Write your API key here
        string model = "llama-3.3-70b-versatile";

        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        Console.WriteLine("ChatBot'a hoş geldin! Çıkmak için 'exit' yaz. /help için komutları gör.\n");

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green; // Colorful "You:"
            Console.Write("Sen: ");
            Console.ResetColor();
            string userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput)) continue;
            if (userInput.ToLower() == "exit") break;

            // Komutları kontrol et
            if (userInput.ToLower() == "/help")
            {
                ShowHelp();
                continue;
            }
            else if (userInput.ToLower() == "saat")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Bot: Şu anki saat: {DateTime.Now:HH:mm}\n");
                Console.ResetColor();
                continue;
            }
            else if (userInput.ToLower() == "tarih")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Bot: Şu anki tarih: {DateTime.Now:dd/MM/yyyy}\n");
                Console.ResetColor();
                continue;
            }

            // Add to chat history
            chatHistory.Add($"User: {userInput}");
            var messages = chatHistory.Select(m => new { role = m.Contains("User:") ? "user" : "assistant", content = m.Replace("User: ", "").Replace("Bot: ", "") });

            try
            {
                var requestBody = new
                {
                    model = model,
                    messages = messages
                };

                var content = new StringContent(
                    JsonSerializer.Serialize(requestBody),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await httpClient.PostAsync(
                    "https://api.groq.com/openai/v1/chat/completions",
                    content
                );

                var responseString = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // error color
                    Console.WriteLine($"API Hatası: {response.StatusCode} - {response.ReasonPhrase}");
                    Console.WriteLine($"Yanıt: {responseString}\n");
                    Console.ResetColor();
                    continue;
                }

                using JsonDocument doc = JsonDocument.Parse(responseString);
                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("choices", out JsonElement choices) &&
                    choices.GetArrayLength() > 0)
                {
                    JsonElement firstChoice = choices[0];
                    if (firstChoice.TryGetProperty("message", out JsonElement message) &&
                        message.TryGetProperty("content", out JsonElement contentElement))
                    {
                        string botReply = contentElement.GetString();
                        Console.ForegroundColor = ConsoleColor.Blue; // Bot color
                        Console.WriteLine($"Bot: {botReply}\n");
                        Console.ResetColor();
                        chatHistory.Add($"Bot: {botReply}");
                        // Save the chat to the log
                        File.AppendAllText(logPath, $"Sen: {userInput}\nBot: {botReply}\n\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Hata: {ex.Message}\n");
                Console.ResetColor();
            }
        }
    }

    // help command
    static void ShowHelp()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Bot: Kullanılabilir komutlar:");
        Console.WriteLine("  /help - Bu yardım menüsünü gösterir");
        Console.WriteLine("  saat - Şu anki saati gösterir");
        Console.WriteLine("  tarih - Şu anki tarihi gösterir");
        Console.WriteLine("  exit - Bot'tan çık");
        Console.WriteLine("Herhangi bir şey yazarak sohbet edebilirsin!\n");
        Console.ResetColor();
    }
}