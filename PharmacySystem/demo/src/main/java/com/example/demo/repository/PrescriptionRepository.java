package com.example.demo.repository;

import java.util.Collection;

import com.example.demo.model.Prescription;

public interface PrescriptionRepository {
	
	Collection<Prescription> findAll();
	
	Prescription create(Prescription prescription);
	
	Prescription findOne(int id);
	
	Prescription setUsed(int id);
}
