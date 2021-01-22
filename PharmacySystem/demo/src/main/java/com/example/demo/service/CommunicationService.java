package com.example.demo.service;

import io.grpc.netty.shaded.io.netty.handler.ssl.util.SelfSignedCertificate;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import rs.ac.uns.ftn.grpc.MessageProto;
import rs.ac.uns.ftn.grpc.MessageResponseProto;
import rs.ac.uns.ftn.grpc.SpringGrpcServiceGrpc.SpringGrpcServiceImplBase;

import java.util.UUID;

import javax.net.ssl.HttpsURLConnection;
import javax.net.ssl.SSLContext;


@GrpcService
public class CommunicationService extends SpringGrpcServiceImplBase{

	@Override
	public void communicate(MessageProto request, StreamObserver<MessageResponseProto> responseObserver) {
		System.out.println("Message: " + request.getMessage() + "; randomInteger: " + request.getRandomInteger());
		
		try {
			SSLContext ctx = SSLContext.getInstance("TLSv1.2");
	        ctx.init(null, null, null);
	        SSLContext.setDefault(ctx);
	        HttpsURLConnection.setDefaultSSLSocketFactory(ctx.getSocketFactory());
	        
	        MessageResponseProto responseMessage = MessageResponseProto.newBuilder()
					.setResponse("Spring Boot: " + UUID.randomUUID().toString()).setStatus("Status 200").build();
	        responseObserver.onNext(responseMessage);
			responseObserver.onCompleted();
		} catch (Exception e) {
	        	System.out.println(e.getMessage());
		}
	}
}
