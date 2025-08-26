using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

IPAddress ipAddress = IPAddress.Loopback; // change to server IP if remote
IPEndPoint ipEndPoint = new(ipAddress, 11_000);

using Socket client = new(
    ipEndPoint.AddressFamily,
    SocketType.Stream,
    ProtocolType.Tcp);

await client.ConnectAsync(ipEndPoint);
Console.WriteLine("Connected to server. Type messages (or 'exit' to quit).");

while (true)
{
    Console.Write("You: ");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    if (input.ToLower() == "exit")
    {
        break;
    }

    var message = input;
    var messageBytes = Encoding.UTF8.GetBytes(message);
    await client.SendAsync(messageBytes, SocketFlags.None);

    var buffer = new byte[1024];
    var received = await client.ReceiveAsync(buffer, SocketFlags.None);
    var response = Encoding.UTF8.GetString(buffer, 0, received);

    Console.WriteLine($"Server response: {response}");
}

client.Shutdown(SocketShutdown.Both);

