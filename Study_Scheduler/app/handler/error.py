from flask import jsonify
from functools import wraps
import re

def handle_errors(f):
    @wraps(f)
    def wrapper(*args, **kwargs):
        try:
            return f(*args, **kwargs)
        except Exception as e:
            print(e)
            message = f'Error: {e}'
            return jsonify({'message': message}), 500
    return wrapper
