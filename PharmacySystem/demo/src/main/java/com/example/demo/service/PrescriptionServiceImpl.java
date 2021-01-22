package com.example.demo.service;

import java.util.Collection;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.model.Prescription;
import com.example.demo.repository.InMemoryPrescriptionRepository;

@Service
public class PrescriptionServiceImpl implements PrescriptionService{

	@Autowired
	InMemoryPrescriptionRepository prescriptionRepository;
	
	@Override
	public Collection<Prescription> findAll() {
		Collection<Prescription> prescriptions = prescriptionRepository.findAll();
		return prescriptions;
	}

	@Override
	public Prescription create(Prescription prescription) throws Exception {
		Prescription myPrescription = prescriptionRepository.create(prescription);
		return myPrescription;
	}

	@Override
	public Prescription findOne(int id) {
		return prescriptionRepository.findOne(id);
	}
	
	@Override
	public Prescription setUsed(int id) {
		return prescriptionRepository.setUsed(id);
	}

}
