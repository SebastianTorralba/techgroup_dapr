# Use Node.js v14
FROM node:14

# Set the working directory in the Docker container
WORKDIR /app

# Copy package.json and package-lock.json (if available)
COPY . .

# Install Node.js dependencies
RUN npm install

# This will ensure the environment variables are available when running Prisma
CMD ["/bin/bash", "-c", "npm run migrate"]
