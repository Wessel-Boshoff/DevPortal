using System.Net.Sockets;
using System.Net;
using System.Text;

IPAddress ipAddress = IPAddress.Loopback;
IPEndPoint ipEndPoint = new(ipAddress, 11_000);

using Socket listener = new(
    ipEndPoint.AddressFamily,
    SocketType.Stream,
    ProtocolType.Tcp);

listener.Bind(ipEndPoint);
listener.Listen(100);

Console.WriteLine($"Server listening on {ipEndPoint}");

using Socket handler = await listener.AcceptAsync();
Console.WriteLine($"Connection accepted from {handler.RemoteEndPoint}");

while (true)
{
    var buffer = new byte[1024];
    var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
    if (received == 0)
    {
        await handler.DisconnectAsync(true);
        continue;
    }

    var message = Encoding.UTF8.GetString(buffer, 0, received);
    Console.WriteLine($"Client: {message}");

    await handler.SendAsync(buffer);
}


