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
            match = re.search(r'column (\w+)\.', str(e))
            column_name = match.group(1) if match else 'unknown'
            message = f'Error: column "{column_name}" does not exist'
            return jsonify({'message': message}), 500
    return wrapper
