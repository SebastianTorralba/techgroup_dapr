package com.incluit.techgroups.calendar;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.incluit.techgroups.calendar.domain.data.Module;
import com.incluit.techgroups.calendar.domain.data.Module.Academy;
import com.incluit.techgroups.calendar.domain.data.Module.Teacher;

import io.dapr.client.DaprClient;
import io.dapr.client.DaprClientBuilder;
import io.dapr.client.domain.State;
import reactor.core.publisher.Mono;

@SpringBootTest
class CalendarApplicationTests {

	@Test
	void contextLoads() {
	}

	@Test
	void Test_Dapr_StateStore() {
		DaprClient client = new DaprClientBuilder().build();
		client.waitForSidecar(10000);
		client.saveState("modules", "1", "Prueba").block();
		State<String> value = client.getState("modules", "1", String.class).block();
		assertEquals("Prueba", value.getValue());

	}

	@Test
	void module_create() {
		Module module = new Module(1, 2, new Module.Course(1, "A", new Academy(1, "Academy", "Desc")),
				new Module.Subject(1, "Subject", new Teacher(1, "Teacher")));
		assertEquals(1, module.id());
		assertEquals(2, module.Duration());
		System.out.println(module);
		ObjectMapper mapper = new ObjectMapper();
		try {
			String json = mapper.writeValueAsString(module);
			System.out.println(json);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	@Test
	void module_create_from_json() {
		String json = "{\"id\":1,\"Duration\":2,\"course\":{\"id\":1,\"section\":\"A\",\"academy\":{\"id\":1,\"name\":\"Academy\",\"description\":\"Desc\"}},\"subject\":{\"id\":1,\"name\":\"Subject\",\"teacher\":{\"id\":1,\"name\":\"Teacher\"}}}";
		ObjectMapper mapper = new ObjectMapper();
		try {
			Module module = mapper.readValue(json, Module.class);
			System.out.println(module);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
