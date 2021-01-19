using Grpc.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using HospitalApp.Protos;
using System.Net.Http;
using Grpc.Net.Client;

namespace HospitalApp
{
    public class ClientScheduledService : IHostedService
    {
        private System.Timers.Timer timer;
        private GrpcChannel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public ClientScheduledService() { }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var httpClient = new HttpClient(httpHandler);

            try
            {
                channel = GrpcChannel.ForAddress("https://localhost:8787", new GrpcChannelOptions() { HttpClient = httpClient });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(SendMessage);
            timer.Interval = 10000; // number in miliseconds  
            timer.Enabled = true;
            return Task.CompletedTask;
        }

        private async void SendMessage(object source, ElapsedEventArgs e)
        {
            try
            {
                MessageResponseProto response = await client.communicateAsync(new MessageProto() { Message = "Random message from asp.net client: " + Guid.NewGuid().ToString(), RandomInteger = new Random().Next(1, 101) });
                Console.WriteLine(response.Response + " is response; status: " + response.Status);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            channel?.ShutdownAsync();
            timer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
