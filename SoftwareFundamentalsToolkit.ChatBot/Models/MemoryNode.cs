using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareFundamentalsToolkit.ChatBot.Models
{
    public class MemoryNode
    {
        public List<Association> Associations { get; set; } = [];
        public string Value { get; set; } = "";
        internal string GetMostAssured(string value) =>
            Associations.OrderByDescending(c => c.Assurance).First().Value;
    }
}
