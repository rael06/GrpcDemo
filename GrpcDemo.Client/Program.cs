// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using GrpcDemo.Client;

Console.WriteLine("Press enter to connect with server..");
Console.ReadLine();

var chanel = GrpcChannel.ForAddress("http://localhost:5176");

var client = new Greeter.GreeterClient(chanel);

var response = await client.SayHelloAsync(new HelloRequest
{
    Name = "Toto"
});

Console.WriteLine(response.Message);
