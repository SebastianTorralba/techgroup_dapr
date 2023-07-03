package com.incluit.techgroups.calendar;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import com.incluit.techgroups.calendar.domain.data.Module.Academy;
import com.incluit.techgroups.calendar.domain.data.Module.Course;
import com.incluit.techgroups.calendar.domain.data.Module.Subject;
import com.incluit.techgroups.calendar.domain.data.Module.Teacher;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.incluit.techgroups.calendar.domain.data.Module;
import io.dapr.client.DaprClient;
import io.dapr.client.DaprClientBuilder;
import io.dapr.client.domain.State;

@SpringBootApplication
public class CalendarApplication {

	public static void main(String[] args) {
		Logger logger = LoggerFactory.getLogger(CalendarApplication.class);
		logger.info("Starting  TECHGROUP CalendarApplication...");
		SpringApplication.run(CalendarApplication.class, args);
		DaprClient client = new DaprClientBuilder().build();
		System.out.println("Waiting for Dapr sidecar ...");
		client.waitForSidecar(10000).block();
		System.out.println("Dapr sidecar is ready.");

		client.saveState("modules", "Test", "Prueba TechGroup").block();
		State<String> value = client.getState("modules", "Test", String.class).block();
		System.out.println("State value: " + value.getValue());

		Module module = new Module(1, 2, new Course(1, "A", new Academy(1, "Academy", "Desc")),
				new Subject(1, "Subject", new Teacher(1, "Teacher")));
		ObjectMapper mapper = new ObjectMapper();
		try {
			String json = mapper.writeValueAsString(module);
			client.saveState("modules", module.id().toString(), json).block();
		} catch (Exception e) {
			e.printStackTrace();
		}
		State<String> json = client.getState("modules", "1", String.class).block();

		try {
			Module moduleJson = mapper.readValue(json.getValue(), Module.class);
			System.out.println(module);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
