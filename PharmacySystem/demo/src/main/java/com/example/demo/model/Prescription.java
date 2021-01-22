package com.example.demo.model;

import java.util.List;

public class Prescription {

	private int id;
	private String patientName;
	private List<String> medications;
	private boolean used;
	
	public Prescription(int id, String patientName, List<String> medications, boolean used) {
		super();
		this.id = id;
		this.patientName = patientName;
		this.medications = medications;
		this.used = used;
	}
	
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
	}
	
	public String getPatientName() {
		return patientName;
	}
	
	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}
	
	public List<String> getMedications() {
		return medications;
	}
	
	public void setMedications(List<String> medications) {
		this.medications = medications;
	}
	
	public boolean isUsed() {
		return used;
	}
	
	public void setUsed(boolean used) {
		this.used = used;
	}
}
