using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareFundamentalsToolkit.ChatBot.Models
{
    public class Association
    {
        public int Assurance { get; set; }
        public string Value { get; set; } = "";

        internal void Assure()
        {
            Assurance++;
        }
    }
}
