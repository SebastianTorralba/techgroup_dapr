from flask import Blueprint, request, jsonify
from app import db
from .models import User, UserCourse
from datetime import datetime
from sqlalchemy.orm import joinedload

user = Blueprint('user', __name__)

#Create
@user.route('/user', methods=['POST'])
def create_user():
    data = request.get_json()
    new_user = User(
        firstname = data['firstname']
        lastname = data['lastname']
        email = data['email']
        password = data['password']
        photo = data['photo']
        cellphone = data['cellphone']
        birthdate = data['date']
        status = data['status']
    )

    db.session.add(new_user)
    db.session.commit()

    return jsonify({"message": "User created"}), 201

#GET ALL
@user.route('/user', methods = ['GET'])
def get_users():
    users = User.query.filter(User.status == 'active').all()
    return jsonify([user.to_dict() for user in users]), 200

#GET BY ID
@user.route('/user/<id>', methods = ['GET'])
def get_users(id):
    user = User.query.filter_by(id=id, status='active')
    if not user:
        return jsonify({'message': "User not found"}), 404
    return jsonify(user.to_dict()), 200

#UPDATE
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

    db.session.commit()
        return jsonify({'message': 'User updated succesfully'}), 200


#DELETE
@user.route('/user', methods = ['DELETE'])
def delete_user(id):
    user = User.query.get(id)
    if user:
        user.status = 'inactive'
        db.session.commit()
        return jsonify({'message': "User set to inactive"}), 200
    else:
        return jsonify({'message': "User not found"}), 404