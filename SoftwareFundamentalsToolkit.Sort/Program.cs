Console.WriteLine("Please enter the list of characters you need to sort:");
string unsorted = Console.ReadLine() ?? "";
List<char> sorted = [.. unsorted.ToCharArray()];

bool isUnsorted = true;
do
{
    isUnsorted = false;
    for (int i = 0; i < sorted.Count - 1; i++)
    {
        if (sorted[i] > sorted[i + 1])
        {
            // swap
            char temp = sorted[i];
            sorted[i] = sorted[i + 1];
            sorted[i + 1] = temp;
            isUnsorted = true;
        }
    }
}
while (isUnsorted);

Console.WriteLine("Sorted characters:");
Console.WriteLine(new string([.. sorted]));

Console.ReadKey();
