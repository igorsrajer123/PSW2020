package com.example.demo.controller;

import java.util.Collection;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.demo.model.Prescription;
import com.example.demo.service.PrescriptionService;


@CrossOrigin(origins="*")
@RestController
@RequestMapping("/api/")
public class PrescriptionController {

	@Autowired
	private PrescriptionService prescriptionService;
	
	@GetMapping(value = "/prescriptions", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Collection<Prescription>> getMedications() {
		Collection<Prescription> meds = prescriptionService.findAll();
		return new ResponseEntity<Collection<Prescription>>(meds, HttpStatus.OK);
	}
	
	@PostMapping(value = "/createPrescription", consumes = MediaType.APPLICATION_JSON_VALUE, produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Prescription> createGreeting(@RequestBody Prescription prescription) throws Exception {
		Prescription savedGreeting = prescriptionService.create(prescription);
		return new ResponseEntity<Prescription>(savedGreeting, HttpStatus.CREATED);
	}
	
	@GetMapping(value = "/getPrescription/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Prescription> findOne(@PathVariable("id") int id){
		Prescription prescription = prescriptionService.findOne(id);
		
		if(prescription == null)
			return new ResponseEntity<Prescription>(HttpStatus.NOT_FOUND);
		
		return new ResponseEntity<Prescription>(prescription, HttpStatus.OK);
	}
	
	@PutMapping(value = "/setPrescriptionUsed/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Prescription> setUsed(@PathVariable("id") int id){
		Prescription prescription = prescriptionService.setUsed(id);
		
		if(prescription == null)
			return new ResponseEntity<Prescription>(HttpStatus.NOT_FOUND);
		
		return new ResponseEntity<Prescription>(prescription, HttpStatus.OK);
	}	
}
