from flask import Blueprint, request, jsonify
from app import db
from sqlalchemy.orm import joinedload
from .models import Module

module = Blueprint('module', __name__)

# CREATE
@module.route('/module', methods=['POST'])
def create_module():
    data = request.get_json()

    new_module = Module(
        userId=data['userId'],
        status=data['status'],
        courseId=data['courseId'],
        subjectId=data['subjectId'],
        academyId=data['academyId']
    )

    db.session.add(new_module)
    db.session.commit()

    return jsonify({"message": "Module created"}), 201

# LIST
@module.route('/module', methods=['GET'])
def get_modules():
    modules = Module.query.options(joinedload(Module.academy),joinedload(Module.subject), joinedload(Module.course)).filter(Module.status == 'active').all()
    
    output = []
    for module in modules:
        module_dict = module.to_dict()
        module_dict['academy'] = module.academy.to_dict()
        module_dict['subject'] = module.subject.to_dict()
        module_dict['course'] = module.course.to_dict()
        output.append(module_dict)
    
    return jsonify({'modules': output})

# GET
@module.route('/module/<id>', methods=['GET'])
def get_module(id):
    module = Module.query.filter_by(id=id, status='active').first()
    if module:
        module_dict = module.to_dict()
        module_dict['academy'] = module.academy.to_dict()
        module_dict['subject'] = module.subject.to_dict()
        module_dict['course'] = module.course.to_dict()
        return jsonify({'module': module_dict}), 200
    else:
        return jsonify({"message": "Module not found"}), 404

# UPDATE
@module.route('/module/<id>', methods=['PUT'])
def update_module(id):
    data = request.get_json()
    module = Module.query.get(id)
    if module:
        module.userId = data.get('userId', module.userId)
        module.status = data.get('status', module.status)
        module.courseId = data.get('courseId', module.courseId)
        module.subjectId = data.get('subjectId', module.subjectId)
        module.academyId = data.get('academyId', module.academyId)
        db.session.commit()
        return jsonify({"message": "Module updated"}), 200
    else:
        return jsonify({"message": "Module not found"}), 404

# DELETE (SET TO INACTIVE)
@module.route('/module/<id>', methods=['DELETE'])
def set_module_inactive(id):
    module = Module.query.get(id)
    if module:
        module.status = "inactive"
        db.session.commit()
        return jsonify({"message": "Module set to inactive"}), 200
    else:
        return jsonify({"message": "Module not found"}), 404
