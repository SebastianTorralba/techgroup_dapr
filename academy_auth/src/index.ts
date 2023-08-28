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
  '🌎',
  '\x1b[44m',
  '\x1b[37m',
  'server up on',
  `${app.server?.hostname}:${app.server?.port}`,
  '\x1b[0m'
);
console.log('🔑', '\x1b[45m', '\x1b[37m', 'mode:', Bun.env.BUN_ENV, '\x1b[0m');
