package com.example.demo.model;

import java.util.List;

public class Order {
 
	private int id;
	private List<String> medications;
	private boolean used;
	private boolean urgent;
	
	public Order(int id, List<String> medications, boolean used, boolean urgent) {
		super();
		this.id = id;
		this.medications = medications;
		this.used = used;
		this.urgent = urgent;
	}
	
	public int getId() {
		return id;
	}
	
	public void setId(int id) {
		this.id = id;
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

	public boolean isUrgent() {
		return urgent;
	}

	public void setUrgent(boolean urgent) {
		this.urgent = urgent;
	}
	
	
}
