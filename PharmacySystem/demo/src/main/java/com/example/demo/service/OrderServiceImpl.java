package com.example.demo.service;

import java.util.Collection;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.demo.model.Order;
import com.example.demo.repository.InMemoryOrderRepository;

@Service
public class OrderServiceImpl implements OrderService{

	@Autowired
	private InMemoryOrderRepository orderRepository;
	
	@Override
	public Collection<Order> findAll() {
		return orderRepository.findAll();
	}

	@Override
	public Order create(Order order) {
		return orderRepository.create(order);
	}

	@Override
	public Order findOne(int id) {
		return orderRepository.findOne(id);
	}

	@Override
	public Order setUsed(int id) {
		return orderRepository.setUsed(id);
	}
}
