package com.example.demo.service;

import java.util.Collection;

import com.example.demo.model.Prescription;

public interface PrescriptionService {
	
	Collection<Prescription> findAll();
	
	Prescription create(Prescription prescription) throws Exception;
	
	Prescription findOne(int id);
	
	Prescription setUsed(int id);
}
