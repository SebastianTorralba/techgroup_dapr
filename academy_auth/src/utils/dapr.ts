export async function saveToDaprState(
  key: string,
  value: string
): Promise<boolean> {
  try {
    const state = [
      {
        key: key,
        value: value
      }
    ];
    console.log(
      `http://localhost:${Bun.env.DAPR_HTTP_PORT}/v1.0/state/statestore`,
      'url es:'
    );

    const res = await fetch(
      `http://localhost:${Bun.env.DAPR_HTTP_PORT}/v1.0/state/statestore`,
      {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(state)
      }
    );

    if (!res.ok) {
      console.error(`Failed to save state: ${res.statusText}`);
      return false;
    }

    return true;
  } catch (error) {
    console.error('An error occurred while saving to Dapr state:', error);
    return false;
  }
}
