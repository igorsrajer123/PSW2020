package com.example.demo.service;

import java.util.Collection;

import com.example.demo.model.Order;

public interface OrderService {

	Collection<Order> findAll();
	
	Order create(Order order);
	
	Order findOne(int id);
	
	Order setUsed(int id);
}
