using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareFundamentalsToolkit.RecursiveFunctions
{
    public class Indexer
    {
        private readonly string directory;

        public delegate void OutFile(OutFileItem file);
        public event OutFile OnOutFile;

        public delegate void OutIndexer(string directory);
        public event OutIndexer OnOutIndexer;

        public Indexer(string directory)
        {
            this.directory = directory;
        }


        public void Index()
        {
            try
            {
                var subDirectories = Directory.GetDirectories(directory);
                foreach (var subDirectory in subDirectories)
                {
                    OnOutIndexer(subDirectory);
                }

                foreach (var file in Directory.GetFiles(directory))
                {
                    try
                    {
                        var fileBytes = File.ReadAllBytes(file);

                        using SHA256 sHA256 = SHA256.Create();
                        var hash = sHA256.ComputeHash(fileBytes);

                        OutFileItem outFileItem = new()
                        {
                            Path = file,
                            Hash = Convert.ToBase64String(hash)
                        };
                        OnOutFile(outFileItem);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.ToString());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
