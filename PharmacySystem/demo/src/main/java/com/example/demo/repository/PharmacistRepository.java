package com.example.demo.repository;

import java.util.Collection;

import com.example.demo.model.Pharmacist;

public interface PharmacistRepository {

	Collection<Pharmacist> findAll();
}
