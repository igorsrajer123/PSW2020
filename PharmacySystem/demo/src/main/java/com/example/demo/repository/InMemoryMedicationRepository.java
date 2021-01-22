package com.example.demo.repository;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import org.springframework.stereotype.Repository;

import com.example.demo.model.Medication;


@Repository
public class InMemoryMedicationRepository implements MedicationRepository{

	private List<Medication> medications = new ArrayList<Medication>();
	
	@Override
	public Collection<Medication> findAll() {
		medications.add(new Medication(1, "Bromazepam", 152));
		medications.add(new Medication(2, "Rivotril", 333));
		medications.add(new Medication(3, "Toxicilin", 69));
		medications.add(new Medication(4, "Fervex", 1023));
		return this.medications;
	}

}
