using SoftwareFundamentalsToolkit.RecursiveFunctions;
using System.Collections.Concurrent;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Please enter directory to index");
string directory = Console.ReadLine() ?? "";
ConcurrentQueue<OutFileItem> indexedFiles = new();


Timer tmr = new(TimerTick, null,0, 1000);

List<Task<Indexer>> indexers = [];

Indexer indexer = new (directory);
indexer.OnOutIndexer += Indexer_OnOutIndexer;
indexer.OnOutFile += Indexer_OnOutFile;
indexer.Index();

void Indexer_OnOutFile(OutFileItem file)
{
    indexedFiles.Enqueue(file);
}

void Indexer_OnOutIndexer(string directory)
{
    Indexer indexer = new(directory);
    indexer.OnOutIndexer += Indexer_OnOutIndexer;
    indexer.OnOutFile += Indexer_OnOutFile;
    indexer.Index();
    indexers.Add(Task.Run(() => indexer));
}

void TimerTick(object? state)
{
    while (indexedFiles.Count > 0)
    {
        if (!indexedFiles.TryDequeue(out OutFileItem? outFile))
        {
            Console.WriteLine("Unable to dequeue");
        }
        Console.WriteLine($"{outFile.Hash} : {outFile.Path}");
    }
}


Task.WaitAll([.. indexers]);
Console.ReadKey();

