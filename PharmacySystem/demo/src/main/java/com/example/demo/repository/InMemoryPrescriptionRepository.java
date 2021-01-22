package com.example.demo.repository;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import org.springframework.stereotype.Repository;

import com.example.demo.model.Prescription;

@Repository
public class InMemoryPrescriptionRepository implements PrescriptionRepository{

	private List<Prescription> prescriptions = new ArrayList<Prescription>();
	private List<String> meds = new ArrayList<String>();

	@Override
	public Collection<Prescription> findAll() {	
		establishRepository();
		return this.prescriptions;
	}

	@Override
	public Prescription create(Prescription prescription) {
		if(prescription == null)
			return null;
		
		prescriptions.add(prescription);
		return prescription;			
	}

	@Override
	public Prescription findOne(int id) {
		establishRepository();
		
		for(Prescription p : prescriptions)
			if(p.getId() == id)
				return p;
		
		return null;
	}
	
	@Override
	public Prescription setUsed(int id) {
		for(Prescription p : prescriptions)
			if(p.getId() == id) {
				p.setUsed(true);
				return p;
			}
		
		return null;
	}
	
	private void establishRepository() {
		if(prescriptions.isEmpty()) {
			meds.add("Rivotril(1)");
			prescriptions.add(new Prescription(1, "Pera Peric", meds, false));
		}
	}
	
}
