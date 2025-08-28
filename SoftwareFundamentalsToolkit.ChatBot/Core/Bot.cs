using Newtonsoft.Json;
using SoftwareFundamentalsToolkit.ChatBot.Models;
using SoftwareFundamentalsToolkit.ChatBot.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareFundamentalsToolkit.ChatBot.Core
{
    internal class Bot : IDisposable
    {
        private readonly Output output;

        internal delegate void BotMessageHandler(string message);
        internal event BotMessageHandler? OnConsoleMessage;


        internal delegate void BotCloseHandler();
        internal event BotCloseHandler? OnClose;

        private readonly string _brainPath = "";
        private const string Greeting = "Welcome to ChatBot how can I help you today.";

        private List<MemoryNode> MemoryNodes { get; set; }

        internal Bot(string brainPath)
        {
            _brainPath = brainPath;
            output = new Output(this);
            Init();
        }

        internal void Talk(string message)
        {
            switch (message)
            {
                case "*save*":
                    SaveMemories();
                    break;
                case "*exit*":
                    SaveMemories();
                    Dispose();
                    break;
                default:
                    ProcessPrompt(message);
                    break;
            }
        }

        private void ProcessPrompt(string message)
        {
            if (message.Contains("=="))
            {
                var split = message.Split("==");
                if (!MemoryNodes.Any(c => c.Value == split[0]))
                {
                    MemoryNodes.Add(new MemoryNode() { Value = split[0], Associations = new List<Association>() { new Association() { Value = split[1] } } });
                    OnConsoleMessage($"I have learned a new memory that {split[0]} is equal to {split[1]}");
                    return;
                }
                else
                {
                    var memory = MemoryNodes.Single(c => c.Value == split[0]);
                    if (!memory.Associations.Any(c => c.Value == split[1]))
                    {
                        memory.Associations.Add(new Association() { Value = split[1] });
                        OnConsoleMessage($"I have learned a new memory that {split[0]} is equal to {split[1]}");
                        return;
                    }
                    else
                    {
                        var association = memory.Associations.Single(c => c.Value == split[1]);
                        association.Assure();
                        OnConsoleMessage($"I have re reinforced my memory with {split[0]} as an association of {split[1]}");
                        return;
                    }
                }
            }
            else 
            {
                if (!MemoryNodes.Any(c => c.Value == message))
                {
                    OnConsoleMessage($"I don't know what {message} means please type {message}==the meaning");
                    return;
                }

                var memoryNode = MemoryNodes.Single(c => c.Value == message);
                OnConsoleMessage(memoryNode.GetMostAssured(message));
            }
        }

        private void Init()
        {
            LoadMemories();
            CompleteInit();
        }

        private void CompleteInit()
        {
            OnConsoleMessage(Text.Instructions);
            OnConsoleMessage(Text.Separator);
            OnConsoleMessage(Text.PromptSave);
            OnConsoleMessage(Text.PromptExit);
            OnConsoleMessage(Text.Separator);
            OnConsoleMessage(Greeting);
            OnConsoleMessage(Text.Separator);
        }

        private void LoadMemories()
        {
            if (File.Exists(_brainPath))
            {
                MemoryNodes = JsonConvert.DeserializeObject<List<MemoryNode>>(File.ReadAllText(_brainPath)) ?? [];
                OnConsoleMessage($"Loaded {MemoryNodes.Count} memories from {_brainPath}");
            }
            else
            {
                OnConsoleMessage($"No memory file, will create one after exit");
            }


        }

        private void SaveMemories()
        {
            File.WriteAllText(_brainPath, JsonConvert.SerializeObject(MemoryNodes));
            OnConsoleMessage($"Saved {MemoryNodes.Count} memories to {_brainPath}");
        }

        public void Dispose()
        {
            OnClose();
        }
    };
}
