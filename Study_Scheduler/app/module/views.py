from flask import Blueprint, request, jsonify
from app import db
from sqlalchemy.orm import joinedload
from app.handler.error import handle_errors
from .models import Module

module = Blueprint('module', __name__)

# CREATE
@module.route('/module', methods=['POST'])
@handle_errors
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
@handle_errors
def get_modules():
    modules = Module.query.options(joinedload(Module.academy), joinedload(Module.subject), joinedload(Module.course), joinedload(Module.user)).filter(Module.status == 'active').all()

    if not modules:
        return jsonify({'message': 'Module not found'}), 404

    output = []
    errors = []
    for module in modules:
        module_dict = module.to_dict()
        related_objs = {'academy': module.academy, 'subject': module.subject, 'course': module.course, 'user': module.user}
        for obj_name, related_obj in related_objs.items():
            try:
                module_dict[obj_name] = convert_to_dict(related_obj, obj_name)
            except ValueError as e:
                errors.append(f'Error for module id {module.id}: {str(e)}')

        output.append(module_dict)

    if errors:
        return jsonify({'modules': output, 'errors': errors}), 200
    else:
        return jsonify({'modules': output}), 200

# GET
@module.route('/module/<id>', methods=['GET'])
@handle_errors
def get_module( id):
    module = Module.query.filter_by(id=id, status='active').first()
    
    if module:
        module_dict = module.to_dict()
        module_dict['academy'] = module.academy.to_dict()
        module_dict['subject'] = module.subject.to_dict()
        module_dict['course'] = module.course.to_dict()
        module_dict['user'] = module.user.to_dict()
        return jsonify({'module': module_dict}), 200
    else:
        return jsonify({"message": "Module not found"}), 404

# UPDATE
@module.route('/module/<id>', methods=['PUT'])
@handle_errors
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
@handle_errors
def set_module_inactive( id):
    module = Module.query.get(id)
    if module:
        module.status = "inactive"
        db.session.commit()
        return jsonify({"message": "Module set to inactive"}), 200
    else:
        return jsonify({"message": "Module not found"}), 404

# UTILS
def convert_to_dict(obj, obj_name):
    if obj:
        return obj.to_dict()
    else:
        raise ValueError(f'{obj_name} not found')
