![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![License](https://img.shields.io/badge/license-MIT-green)
![Groq](https://img.shields.io/badge/API-Groq-orange)
![Stars](https://img.shields.io/github/stars/LEATERNx/CSharpGroqChatbotTemplate)

## 🎥 Demo

![Demo](demo.gif)

# 🤖 C# Groq ChatBot Template

A simple and fast console chatbot application using Groq API.

## ✨ Features

- ⚡ **Free and Fast**: Lightning-fast responses with Groq API
- 🧠 **Llama 3.3 70B Model**: Powerful open-source AI model
- 💬 **Chat History**: Conversations are automatically saved
- 🎨 **Colorful Console**: Readable and user-friendly interface
- 📝 **Log System**: All conversations saved to `chat_log.txt`
- ⏰ **Built-in Commands**: Time, date, and help commands

## 📋 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Groq API Key](https://console.groq.com/) (Free)

## 🚀 Installation

### 1. Clone the Repository
```bash
git clone https://github.com/LEATERNx/CSharpGroqChatbotTemplate.git
cd CSharpGroqChatbotTemplate
```

### 2. Get API Key
1. Go to [console.groq.com](https://console.groq.com/)
2. Create a free account
3. Navigate to **API Keys** → **Create API Key**
4. Copy your API key

### 3. Add Your API Key
Open `Program.cs` and edit line 12:
```csharp
string apiKey = "paste_your_api_key_here"; // Edit this line
```

### 4. Run the Application
```bash
dotnet run
```

## 💻 Usage

```
Welcome to ChatBot! Type 'exit' to quit. Type /help to see commands.

You: Hello!
Bot: Hello! How can I assist you today?

You: /help
Bot: Available commands:
  /help - Shows this help menu
  saat - Shows current time
  tarih - Shows current date
  exit - Exit the bot
```

## 🎮 Commands

| Command | Description |
|---------|-------------|
| `/help` | Display help menu |
| `saat` | Show current time (Turkish: "saat" = time) |
| `tarih` | Show current date (Turkish: "tarih" = date) |
| `exit` | Exit the program |

## 📁 File Structure

```
CSharpGroqChatbotTemplate/
├── Program.cs                      # Main code
├── chat_log.txt                    # Chat history (auto-generated)
└── CSharpGroqChatbotTemplate.csproj # Project file
```

## ⚙️ Customization

### Use Different Model
Edit line 13 in `Program.cs`:
```csharp
string model = "llama-3.3-70b-versatile";  // Default (Recommended)
// string model = "llama-3.1-8b-instant";  // Faster
// string model = "mixtral-8x7b-32768";    // Longer context window
```

### Change Colors
Modify `Console.ForegroundColor` values:
- `ConsoleColor.Green` → User messages
- `ConsoleColor.Blue` → Bot responses
- `ConsoleColor.Red` → Errors
- `ConsoleColor.Yellow` → Help messages

### Add Custom Commands
Add new commands in the `Main` method:
```csharp
else if (userInput.ToLower() == "yourcommand")
{
    Console.WriteLine("Bot: Your custom response\n");
    continue;
}
```

## 🐛 Troubleshooting

### "Unauthorized" Error
- Check your API key
- Make sure the key is active
- Verify there are no extra spaces

### "Model decommissioned" Error
- Check current models: [Groq Models](https://console.groq.com/docs/models)
- Update the model name in `Program.cs`

### "Rate limit exceeded"
- Free tier: 30 requests/minute
- Wait a few seconds and try again
- Consider upgrading for higher limits

### Chat History Not Saving
- Ensure write permissions in the project directory
- Check if `chat_log.txt` exists after first message
- Verify the file path is correct

## 🔒 Security Notes

**IMPORTANT**: Never commit your API key to GitHub!

✅ Good:
```csharp
string apiKey = "WRITE_YOUR_OWN_GROQ_API_KEY_HERE";
```

❌ Bad:
```csharp
string apiKey = "gsk_actual_api_key_12345"; // Never do this!
```

For production use, consider using environment variables:
```csharp
string apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
```

## 📝 License

MIT License - See [LICENSE](LICENSE) file for details.

## 🤝 Contributing

Contributions are welcome! Here's how:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Ideas for Contributions
- Add more built-in commands
- Implement conversation context management
- Add multi-language support
- Create a GUI version
- Add voice input/output
- Implement conversation export to different formats

## 🌟 Acknowledgments

- [Groq](https://groq.com/) for providing fast inference API
- [Meta AI](https://ai.meta.com/) for the Llama model
- The open-source community

## 💡 Support

- **Issues**: Found a bug? [Open an issue](https://github.com/YOUR_USERNAME/CSharpGroqChatbotTemplate/issues)
- **Discussions**: Have questions? [Start a discussion](https://github.com/YOUR_USERNAME/CSharpGroqChatbotTemplate/discussions)
- **Pull Requests**: Want to contribute? PRs are welcome!

## 📚 Additional Resources

- [Groq Documentation](https://console.groq.com/docs)
- [.NET Documentation](https://docs.microsoft.com/dotnet/)
- [C# Programming Guide](https://docs.microsoft.com/dotnet/csharp/)

## 📊 Stats

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![License](https://img.shields.io/badge/license-MIT-green)
![Groq](https://img.shields.io/badge/API-Groq-orange)
![Language](https://img.shields.io/badge/language-C%23-239120)

---

⭐ If you find this project useful, please consider giving it a star!

**Made with ❤️ by [Your Name]**
