package com.example.demo.repository;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import org.springframework.stereotype.Repository;

import com.example.demo.model.Order;

@Repository
public class InMemoryOrderRepository implements OrderRepository{

	private List<Order> orders = new ArrayList<Order>();
	private List<String> meds = new ArrayList<String>();

	@Override
	public Collection<Order> findAll() {
		establishRepository();
		return this.orders;
	}

	@Override
	public Order create(Order order) {
		if(order == null)
			return null;
		
		orders.add(order);
		return order;
	}

	@Override
	public Order findOne(int id) {
		establishRepository();
		
		for(Order o : orders)
			if(o.getId() == id)
				return o;
		
		return null;
	}

	@Override
	public Order setUsed(int id) {
		for(Order o : orders)
			if(o.getId() == id) {
				o.setUsed(true);
				return o;
			}
		
		return null;
	}
	
	private void establishRepository() {
		if(orders.isEmpty()) {
			meds.add("Rivotril(150)");
			orders.add(new Order(1, meds, false, true));
		}
	}

}
