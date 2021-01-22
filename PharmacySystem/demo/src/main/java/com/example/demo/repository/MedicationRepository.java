package com.example.demo.repository;

import java.util.Collection;

import com.example.demo.model.Medication;

public interface MedicationRepository {

	Collection<Medication> findAll();
}
