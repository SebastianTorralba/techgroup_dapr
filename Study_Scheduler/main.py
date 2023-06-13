from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from sqlalchemy.exc import OperationalError
from sqlalchemy import text

app = Flask(__name__)
app.config[
    "SQLALCHEMY_DATABASE_URI"
] = "postgresql://postgres:postgres@localhost:5432/academy_scheduler"
db = SQLAlchemy(app)


@app.route("/")
def hello_world():
    try:
        # Get a connection and execute a simple query to check the connection
        with db.engine.connect() as connection:
            result = connection.execute(text("SELECT 1"))
        print("Database is connected successfully!")
    except Exception as e:
        print(f"Error occurred while connecting to the database: {str(e)}")
    return "Hello, World!"


if __name__ == "__main__":
    # Run the application
    app.run(host="0.0.0.0", port=5000, debug=True)
