import Elysia from 'elysia';

import { cookie } from '@elysiajs/cookie';
import { jwt } from '@elysiajs/jwt';
import swagger from '@elysiajs/swagger';

import { auth } from './modules';

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
  )
  .listen(8003);
console.log(
  `🦊 Elysia is running at ${app.server?.hostname}:${app.server?.port}`
);
