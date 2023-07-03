from flask import Blueprint, request, jsonify
from app import db
from .models import StudyPlan, StudyPlanDetail
from datetime import datetime

study_plan = Blueprint('study_plan', __name__)

# LIST
@study_plan.route('/study-plan', methods=['GET'])
def get_study_plans():
    print('Study plan:', StudyPlan)
    study_plans = StudyPlan.query.all()
    return jsonify({'study_plan': [plan.to_dict() for plan in study_plans]})

# CREATE
@study_plan.route('/study-plan', methods=['POST'])
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
            planId=new_plan.id,  # use the new_plan id as foreign key
            createdAt=datetime.utcnow(),
            updatedAt=datetime.utcnow()
        )
        db.session.add(new_detail)

    db.session.commit()

    return jsonify({"message": "StudyPlan created", "id": new_plan.id}), 201

# GET
@study_plan.route('/study-plan/<id>', methods=['GET'])
def get_study_plan(id):
    study_plan = StudyPlan.query.get(id)
    if study_plan:
        return jsonify({'study_plan': study_plan.to_dict()})
    else:
        return jsonify({"message": "StudyPlan not found"}), 404

# UPDATE
@study_plan.route('/study-plan/<id>', methods=['PUT'])
def update_study_plan(id):
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
def delete_study_plan(id):
    study_plan = StudyPlan.query.get(id)
    if study_plan:
        db.session.delete(study_plan)
        db.session.commit()
        return jsonify({"message": "StudyPlan deleted"}), 200
    else:
        return jsonify({"message": "StudyPlan not found"}), 404
