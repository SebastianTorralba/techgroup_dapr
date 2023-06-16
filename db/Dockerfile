# Dockerfile
FROM node:14

WORKDIR /app

COPY . .

RUN npm install
RUN chmod +x runMigrations.sh

CMD [ "./runMigrations.sh" ]
