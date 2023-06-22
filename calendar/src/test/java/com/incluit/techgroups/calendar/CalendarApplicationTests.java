package com.incluit.techgroups.calendar;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

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
}
