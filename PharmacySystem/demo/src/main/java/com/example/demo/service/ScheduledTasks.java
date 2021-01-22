package com.example.demo.service;

import java.util.UUID;

import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

import io.grpc.netty.shaded.io.netty.util.internal.ThreadLocalRandom;

import net.devh.boot.grpc.client.inject.GrpcClient;
import rs.ac.uns.ftn.grpc.MessageProto;
import rs.ac.uns.ftn.grpc.MessageResponseProto;
import rs.ac.uns.ftn.grpc.NetGrpcServiceGrpc.NetGrpcServiceBlockingStub;
/*
@Component
public class ScheduledTasks {

	@GrpcClient("netgrpcserver")
	private NetGrpcServiceBlockingStub stub;
	
	@Scheduled(fixedRate = 3000)
	public void sendMessageToServer() {
		MessageProto message = MessageProto.newBuilder().setMessage("Random message from Java Client: " +
					UUID.randomUUID().toString()).setRandomInteger(ThreadLocalRandom.current().nextInt(1, 101)).build();
					
		final MessageResponseProto response = this.stub.transfer(message);
		System.out.println("Response: " + response.getResponse() + "; " + response.getStatus());
	}
}*/
