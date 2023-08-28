from flask import Blueprint, request, jsonify
from app import db
from app.handler.error import handle_errors
from .models import StudyPlan, StudyPlanDetail
from datetime import datetime
from sqlalchemy.orm import joinedload

study_plan = Blueprint('study_plan', __name__)

# CREATE
@study_plan.route('/study-plan', methods=['POST'])
@handle_errors
def create_study_plan():
    data = request.get_json()

    new_plan = StudyPlan(
        userId=data['userId'],
        status=data['status'],
        courseId=data['courseId'],
        createdAt=datetime.utcnow(),
        updatedAt=datetime.utcnow()
    )

    db.session.add(new_plan)
    db.session.flush()  # Flush to get id of the new_plan

    details = data.get('details', [])

    for detail in details:
        new_detail = StudyPlanDetail(
            userId=detail['userId'],
            status=detail['status'],
            orderNo=detail['orderNo'],
            moduleId=detail['moduleId'],
            planId=new_plan.id,  # Use the new_plan id as foreign key
            createdAt=datetime.utcnow(),
            updatedAt=datetime.utcnow()
        )
        db.session.add(new_detail)

    db.session.commit()

    return jsonify({"message": "StudyPlan created", "id": new_plan.id}), 201

# LIST
@study_plan.route('/study-plan', methods=['GET'])
@handle_errors
def get_study_plans():
    study_plans = StudyPlan.query.options(joinedload(StudyPlan.course), joinedload(StudyPlan.user)).filter(StudyPlan.status == 'active').all()

    if not study_plans:
        return jsonify({'message': 'Study plans not found'}), 404
    
    output = []
    for study_plan in study_plans:
        study_plan_dict = study_plan.to_dict()
        study_plan_dict['course'] = study_plan.course.to_dict()
        study_plan_dict['user'] = study_plan.user.to_dict()
        output.append(study_plan_dict)
    
    return jsonify({'study_plans': output})

# GET
@study_plan.route('/study-plan/<id>', methods=['GET'])
@handle_errors
def get_study_plan( id):
    study_plan = StudyPlan.query.filter_by(id=id, status='active').first()
    
    if study_plan:
        study_plan_dict = study_plan.to_dict()
        study_plan_dict['course'] = study_plan.course.to_dict()
        study_plan_dict['user'] = study_plan.user.to_dict()
        return jsonify({'study_plan': study_plan_dict}), 200
    else:
        return jsonify({"message": "Study plan not found"}), 404

# UPDATE
@study_plan.route('/study-plan/<id>', methods=['PUT'])
@handle_errors
def update_study_plan( id):
    data = request.get_json()
    study_plan = StudyPlan.query.get(id)
    if study_plan:
        study_plan.userId = data.get('userId', study_plan.userId)
        study_plan.status = data.get('status', study_plan.status)
        study_plan.courseId = data.get('courseId', study_plan.courseId)
        db.session.commit()
        return jsonify({"message": "StudyPlan updated"}), 200
    else:
        return jsonify({"message": "StudyPlan not found"}), 404

# DELETE
@study_plan.route('/study-plan/<id>', methods=['DELETE'])
@handle_errors
def delete_study_plan( id):
    study_plan = StudyPlan.query.get(id)
    if study_plan:
        db.session.delete(study_plan)
        db.session.commit()
        return jsonify({"message": "StudyPlan deleted"}), 200
    else:
        return jsonify({"message": "StudyPlan not found"}), 404
