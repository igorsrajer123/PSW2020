package com.example.demo.service;

import java.util.Collection;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.model.Medication;
import com.example.demo.repository.InMemoryMedicationRepository;


@Service
public class MedicationServiceImpl implements MedicationService{

	@Autowired
	private InMemoryMedicationRepository medicationRepository;
	
	@Override
	public Collection<Medication> findAll() {
		Collection<Medication> meds = medicationRepository.findAll();
		return meds;
	}
}
