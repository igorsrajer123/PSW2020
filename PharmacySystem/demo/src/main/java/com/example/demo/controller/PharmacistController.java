package com.example.demo.controller;

import java.util.Collection;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.demo.model.Pharmacist;
import com.example.demo.service.PharmacistService;

@RestController
@RequestMapping("/api/")
public class PharmacistController {

	@Autowired
	private PharmacistService pharmacistService;
	
	@GetMapping(value = "/pharmacists", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Collection<Pharmacist>> getMedications() {
		Collection<Pharmacist> meds = pharmacistService.findAll();
		return new ResponseEntity<Collection<Pharmacist>>(meds, HttpStatus.OK);
	}
}
