
using SoftwareFundamentalsToolkit.ChatBot.Core;

bool alive = true;

var brainPath = Path.Combine(Environment.CurrentDirectory, "brain.json");
Bot bot = new(brainPath);
bot.OnClose += Bot_OnClose;

void Bot_OnClose()
{
    alive = false;
}

while (alive)
{
    bot.Talk(Console.ReadLine() ?? "");

}


