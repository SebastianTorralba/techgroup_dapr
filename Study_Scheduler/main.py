from flask import Flask
from flask_sqlalchemy import SQLAlchemy

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'postgresql://postgres:postgres@db:5432/postgres'
db = SQLAlchemy(app)

# Define a route for the default URL, which loads the hello world message
@app.route('/')
def hello_world():
    return 'Hello, World!'

# Main driver function
if __name__ == '__main__':
    # Run the application
    app.run(debug=True)
