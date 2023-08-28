# Use a Node.js base image
FROM node:14 as builder

WORKDIR /app

# Install Bun (assuming the Node.js image has curl)
RUN curl https://bun.sh/install | bash

# Copy package.json and lock file, then install dependencies
COPY package.json .
COPY bun.lockb .
RUN /root/.bun/bin/bun install --production

# ? -------------------------
FROM gcr.io/distroless/base

WORKDIR /app

# Copy relevant files from the builder stage
COPY --from=builder /root/.bun/bin/bun bun
COPY --from=builder /app/node_modules node_modules

# Copy your application's files
COPY src src

ENV ENV production
CMD ["./bun", "src/index.ts"]

EXPOSE 8003
