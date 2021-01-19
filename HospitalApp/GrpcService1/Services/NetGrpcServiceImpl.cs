﻿using System;
using System.Threading.Tasks;
using Grpc.Core;
using HospitalApp.Protos;

namespace HospitalApp
{
    public class NetGrpcServiceImpl : NetGrpcService.NetGrpcServiceBase
    {
        public override Task<MessageResponseProto> transfer(MessageProto request, ServerCallContext context)
        {
            Console.WriteLine(request.Message + " from spring; random int: " + request.RandomInteger.ToString());
            MessageResponseProto response = new MessageResponseProto();
            response.Response = "NET GRPC RESPONSE " + Guid.NewGuid().ToString();
            response.Status = "STATUS OK";
            return Task.FromResult(response);
        }
    }
}
