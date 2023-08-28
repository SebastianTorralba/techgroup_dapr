import { Elysia, t } from 'elysia';

import { getFromDaprState, saveToDaprState } from '../utils/dapr';

export const dapr = (app: Elysia) =>
  app.group('/dapr', (app) =>
    app
      .post(
        '/state',
        async ({ body }) => {
          const results = await Promise.all(
            body.map(async (item: { key: string; value: string }) => {
              return await saveToDaprState(item.key, item.value);
            })
          );

          const allSuccess = results.every((success) => success);
          return {
            success: allSuccess,
            message: allSuccess
              ? 'All states saved successfully'
              : 'Failed to save some states'
          };
        },
        {
          body: t.Array(
            t.Object({
              key: t.String(),
              value: t.String()
            })
          )
        }
      )
      .get('/state/:key', async ({ params }) => {
        const { key } = params;
        const value = await getFromDaprState(key);
        return {
          success: value !== null,
          data: value,
          message:
            value !== null
              ? 'State fetched successfully'
              : 'Failed to fetch state'
        };
      })
      .get('/port', async () => {
        const daprPort = Bun.env.DAPR_HTTP_PORT;
        return {
          success: true,
          data: {
            daprPort
          },
          message: 'Dapr port fetched successfully'
        };
      })
  );
