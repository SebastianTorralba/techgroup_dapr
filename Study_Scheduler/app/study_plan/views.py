from flask import Blueprint, request, jsonify
from app import db
from .models import StudyPlan

study_plan = Blueprint('study_plan', __name__)

@study_plan.route('/study-plan', methods=['GET'])
def get_study_plans():
    study_plans = StudyPlan.query.all()
    return jsonify({'study_plans': [plan.to_dict() for plan in study_plans]})

from flask import request, jsonify
from app import db
from .models import StudyPlan, StudyPlanDetail

@study_plan.route('/study-plan', methods=['POST'])
def create_study_plan():
    data = request.get_json()

    new_plan = StudyPlan(
        userId=data['userId'],
        status=data['status'],
        courseId=data['courseId']
    )

    db.session.add(new_plan)
    
    for detail in data['details']:
        new_detail = StudyPlanDetail(
            userId=detail['userId'],
            status=detail['status'],
            orderNo=detail['orderNo'],
            moduleId=detail['moduleId'],
            plan=new_plan  # This links the detail to the new plan
        )
        db.session.add(new_detail)

    db.session.commit()

    return jsonify({"message": "StudyPlan created"}), 201
