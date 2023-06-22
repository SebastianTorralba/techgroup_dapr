FROM mcr.microsoft.com/mssql-tools

# Install Node.js
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash -
RUN apt-get install -y nodejs

# Set working directory
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code
COPY . .

# Copy and grant permissions to the entrypoint script
COPY entrypoint.sh .
RUN chmod +x ./entrypoint.sh

# Start the script
CMD ["/bin/bash", "-c", "./entrypoint.sh"]
