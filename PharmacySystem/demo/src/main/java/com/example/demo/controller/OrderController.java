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

import com.example.demo.model.Order;
import com.example.demo.service.OrderService;

@CrossOrigin(origins="*")
@RestController
@RequestMapping("/api/")
public class OrderController {

	@Autowired
	private OrderService orderService;
	
	@GetMapping(value = "/orders", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Collection<Order>> getOrders() {
		Collection<Order> meds = orderService.findAll();
		return new ResponseEntity<Collection<Order>>(meds, HttpStatus.OK);
	}
	
	@PostMapping(value = "/createOrder", consumes = MediaType.APPLICATION_JSON_VALUE, produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Order> createOrder(@RequestBody Order order) throws Exception {
		Order savedOrder = orderService.create(order);
		return new ResponseEntity<Order>(savedOrder, HttpStatus.CREATED);
	}
	
	@GetMapping(value = "/getOrder/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Order> findOne(@PathVariable("id") int id){
		Order order = orderService.findOne(id);
		
		if(order == null)
			return new ResponseEntity<Order>(HttpStatus.NOT_FOUND);
		
		return new ResponseEntity<Order>(order, HttpStatus.OK);
	}
	
	@PutMapping(value = "/setOrderUsed/{id}", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Order> setUsed(@PathVariable("id") int id){
		Order order = orderService.setUsed(id);
		
		if(order == null)
			return new ResponseEntity<Order>(HttpStatus.NOT_FOUND);
		
		return new ResponseEntity<Order>(order, HttpStatus.OK);
	}	
}
