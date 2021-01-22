package com.example.demo.controller;

import java.util.Collection;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.demo.model.Medication;
import com.example.demo.service.MedicationService;


@RestController
@RequestMapping("/api/")
public class MedicationController {

	@Autowired
	private MedicationService medicationService;
	
	@GetMapping(value = "/medications", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Collection<Medication>> getMedications() {
		Collection<Medication> meds = medicationService.findAll();
		return new ResponseEntity<Collection<Medication>>(meds, HttpStatus.OK);
	}
}
