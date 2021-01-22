package com.example.demo.repository;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import org.springframework.stereotype.Repository;

import com.example.demo.model.Pharmacist;

@Repository
public class InMemoryPharmacistRepository implements PharmacistRepository{

	private List<Pharmacist> pharmacists = new ArrayList<Pharmacist>();

	@Override
	public Collection<Pharmacist> findAll() {
		pharmacists.add(new Pharmacist(1, "pharma", "pharma"));
		return this.pharmacists;
	}
	
}
