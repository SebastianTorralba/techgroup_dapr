
from flask import request, jsonify, current_app
from functools import wraps
import jwt
from app.user.models import User

def token_required(f):
    @wraps(f)
    def decorated(*args, **kwargs):
        token = None

        if 'x-access-token' in request.headers:
            token = request.headers['x-access-token']
            print(token, 'token')

        if not token:
            return jsonify({'message': 'Token is missing!'}), 401

        try: 
            data = jwt.decode(token, current_app.config['SECRET_KEY'], algorithms=['HS256'])
            print(data, 'data')
            current_user = User.query.filter_by(id=data['id']).first()
            print(current_user, 'current_user')
        except Exception as e:
            print(str(e))
            return jsonify({'message': 'Token is invalid!'}), 401

        return f(current_user, *args, **kwargs)

    return decorated
