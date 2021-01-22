package com.example.demo.service;

import java.util.Collection;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.model.Pharmacist;
import com.example.demo.repository.InMemoryPharmacistRepository;

@Service
public class PharmacistServiceImpl implements PharmacistService{

	@Autowired
	private InMemoryPharmacistRepository pharmacistRepository;
	
	@Override
	public Collection<Pharmacist> findAll() {
		Collection<Pharmacist> pharmas = pharmacistRepository.findAll();
		return pharmas;
	}
}
