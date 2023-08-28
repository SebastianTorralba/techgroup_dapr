import Elysia from 'elysia';

import { cookie } from '@elysiajs/cookie';
import { jwt } from '@elysiajs/jwt';
import swagger from '@elysiajs/swagger';

import { auth } from './modules/auth';
import { dapr } from './modules/dapr';

const app = new Elysia()
  .use(swagger())
  .group('/api', (app) =>
    app
      .use(
        jwt({
          name: 'jwt',
          secret: Bun.env.JWT_SECRET!
        })
      )
      .use(cookie())
      .use(auth)
      .use(dapr)
  )
  .listen(8003);

console.log('🌎', `${app.server?.hostname}:${app.server?.port}`);
console.log('🔑', 'mode:', Bun.env.BUN_ENV);
