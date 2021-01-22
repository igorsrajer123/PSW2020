package com.example.demo.service;

import java.util.Collection;

import com.example.demo.model.Medication;


public interface MedicationService {

	Collection<Medication> findAll();
}
