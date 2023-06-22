# Study Scheduler

Study Scheduler is a simple Flask application for managing study schedules. It uses SQLAlchemy for ORM and a PostgreSQL database for persistent storage. The application and database are deployed using Docker containers, providing a consistent environment that is easy to set up and run.

## Prerequisites

- Docker installed on your system
- Python 3.7+

## Setup for local development

1. Setup and activate virtual environment

   ```
   python3 -m venv myenv
   source myenv/bin/activate
   ```

2. Install dependencies

   ```
   pip install -r requirements.txt
   ```

3. Run the application

   ```
   python run.py
   ```

## How to run the application with Docker

1. Clone the repository:

   ```
   git clone https://github.com/SebastianTorralba/techgroup_dapr.git
   cd Study_Scheduler
   ```

2. Build and run the Docker containers:

   ```
   docker-compose up
   ```

3. The application will be available at `localhost:5000`.

## Application structure

- `main.py` - The main Python file that contains Flask application code.
- `Dockerfile` - Dockerfile for building the application Docker image.
- `docker-compose.yml` - Docker Compose file for running the application and database containers.
- `requirements.txt` - Required Python packages.
