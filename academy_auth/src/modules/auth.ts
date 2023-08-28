import { Elysia, t } from 'elysia';

import { prisma } from '../libs/prisma';
import { saveToDaprState } from '../utils/dapr';

export const auth = (app: Elysia) =>
  app.group('/auth', (app) =>
    app
      .post(
        '/signup',
        async ({ body, set }) => {
          try {
            const { email, firstname, lastname, password, birthdate, status } =
              body;

            const emailExists = await prisma.user.findUnique({
              where: {
                email
              },
              select: {
                id: true
              }
            });

            if (emailExists) {
              set.status = 400;
              return {
                success: false,
                data: null,
                message: 'Email address already in use.'
              };
            }

            const usernameExists = await prisma.user.findUnique({
              where: {
                email
              },
              select: {
                id: true
              }
            });

            if (usernameExists) {
              set.status = 400;
              return {
                success: false,
                data: null,
                message: 'Someone already taken this username.'
              };
            }

            const hash = await Bun.password.hash(password, 'bcrypt');

            const newUser = await prisma.user.create({
              data: {
                email,
                firstname,
                lastname,
                birthdate,
                hash,
                status
              }
            });

            return {
              success: true,
              message: 'Account created',
              data: {
                user: newUser
              }
            };
          } catch (error) {
            console.log('🚀 -> error:', error);
          }
        },
        {
          body: t.Object({
            email: t.String(),
            password: t.String(),
            firstname: t.String(),
            lastname: t.String(),
            birthdate: t.String(),
            status: t.String()
          })
        }
      )
      .post(
        '/login',
        async ({ body, set, jwt, setCookie }) => {
          const { email, password } = body;
          const user = await prisma.user.findFirst({
            where: {
              email
            },
            select: {
              id: true,
              hash: true
            }
          });

          if (!user) {
            set.status = 400;
            return {
              success: false,
              data: null,
              message: 'Invalid credentials'
            };
          }

          const match = await Bun.password.verify(password, user.hash);
          if (!match) {
            set.status = 400;
            return {
              success: false,
              data: null,
              message: 'Invalid credentials'
            };
          }

          const accessToken = await jwt.sign({
            userId: user.id
          });

          await saveToDaprState(`user_${user.id}_token`, accessToken);

          setCookie('access_token', accessToken, {
            maxAge: 15 * 6000,
            path: '/'
          });

          return {
            success: true,
            data: { accessToken, stateStoreTokenKey: `user_${user.id}_token` },
            message: 'Account login successfully'
          };
        },
        {
          body: t.Object({
            email: t.String(),
            password: t.String()
          })
        }
      )
      .get('/profile', async ({ headers, jwt, set }) => {
        try {
          const authHeader = headers['authorization'];
          if (!authHeader || !authHeader.startsWith('Bearer ')) {
            set.status = 401;
            return {
              success: false,
              data: null,
              message: 'Authorization header is missing or invalid'
            };
          }

          const accessToken = authHeader.split(' ')[1];
          const decoded = await jwt.verify(accessToken);
          const userId = decoded.userId;

          const user = await prisma.user.findUnique({
            where: {
              id: userId
            },
            select: {
              id: true,
              email: true,
              firstname: true,
              lastname: true,
              birthdate: true,
              status: true
            }
          });

          if (!user) {
            set.status = 404;
            return {
              success: false,
              data: null,
              message: 'User not found'
            };
          }

          return {
            success: true,
            data: {
              user
            },
            message: 'User profile fetched successfully'
          };
        } catch (error) {
          console.log('🚀 -> error:', error);
          set.status = 401;
          return {
            success: false,
            data: null,
            message: 'Invalid token or authorization error'
          };
        }
      })
  );
