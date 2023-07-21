from flask import Blueprint, request, jsonify, current_app
from app import db
from app.handler.error_handler import handle_errors
from .models import User, UserCourse
from datetime import datetime
from sqlalchemy.orm import joinedload
from werkzeug.security import generate_password_hash, check_password_hash
import jwt
import datetime


user = Blueprint('user', __name__)

# LOGIN
@user.route('/user/login', methods=['POST'])
def login():
    data = request.get_json()

    email = data.get('email')
    password = data.get('password')

    user = User.query.filter_by(email=email).first()

    if not user or not check_password_hash(user.password, password):
        return jsonify({'message': 'Bad credentials'}), 401

    access_token = jwt.encode({
        'id': user.id,
        'exp': datetime.datetime.utcnow() + datetime.timedelta(hours=24)
    }, current_app.config['SECRET_KEY'])

    return jsonify({'message': "User successfully logged in", 'user': user.to_dict(), 'access_token': access_token})

# CREATE
@user.route('/user', methods=['POST'])
def create_user():
    data = request.get_json()

    hashed_password = generate_password_hash(data['password'], method='sha256')

    new_user = User(
    firstname = data['firstname'],
    lastname = data['lastname'],
    email = data['email'],
    password = hashed_password,
    photo = data['photo'],
    cellphone = data['cellphone'],
    birthdate = data['birthdate'],
    status = data['status'],
    createdAt=datetime.utcnow(),
    updatedAt=datetime.utcnow()
    )

    db.session.add(new_user)
    db.session.commit()

    return jsonify({"message": "User created"}), 201

# LIST
@user.route('/user', methods = ['GET'])
@handle_errors
def get_users():
    users = User.query.filter(User.status == 'active').all()
    return jsonify([user.to_dict() for user in users]), 200

# GET
@user.route('/user/<id>', methods = ['GET'])
@handle_errors
def get_user(id):
    user = User.query.filter_by(id=id, status='active').first()
    if not user:
        return jsonify({'message': "User not found"}), 404
    return jsonify(user.to_dict()), 200

# UPDATE
@user.route('/user/<id>', methods = ['PUT'])
def update_user(id):
    user = User.query.get(id)
    data = request.get_json()

    if not user:
        return jsonify({'message': "User not found"}), 404

    user.firstname = data['firstname']
    user.lastname = data['lastname']
    user.email = data['email']
    user.password = data['password']
    user.photo = data['photo']
    user.cellphone = data['cellphone']
    user.birthdate = data['birthdate']
    user.status = data['status']
    user.updatedAt=datetime.utcnow()

    db.session.commit()
    return jsonify({'message': 'User updated succesfully'}), 200


# DELETE
@user.route('/user', methods = ['DELETE'])
def delete_user(id):
    user = User.query.get(id)
    if user:
        user.status = 'inactive'
        db.session.commit()
        return jsonify({'message': "User set to inactive"}), 200
    else:
        return jsonify({'message': "User not found"}), 404