# Import the flask module to create an application
from flask import Flask

# Initialize the Flask application
app = Flask(__name__)

# Define a route for the default URL, which loads the hello world message
@app.route('/')
def hello_world():
    return 'Hello, World!'

# Main driver function
if __name__ == '__main__':
    # Run the application
    app.run(debug=True)
