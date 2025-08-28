using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareFundamentalsToolkit.ChatBot.Core
{
    internal class Output
    {

        internal Output(Bot bot)
        {
            bot.OnConsoleMessage += Bot_OnConsoleMessage;
        }

        private void Bot_OnConsoleMessage(string message) =>
            Console.WriteLine(message);


    }
}
