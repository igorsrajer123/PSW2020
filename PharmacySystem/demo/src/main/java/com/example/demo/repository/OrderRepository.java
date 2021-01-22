package com.example.demo.repository;

import java.util.Collection;

import com.example.demo.model.Order;

public interface OrderRepository {

	Collection<Order> findAll();
	
	Order create(Order order);
	
	Order findOne(int id);
	
	Order setUsed(int id);
}
