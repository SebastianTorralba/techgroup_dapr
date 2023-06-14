from datetime import datetime
from app import db

class StudyPlan(db.Model):
    __tablename__ = 'StudyPlan'

    id = db.Column(db.String, primary_key=True, default='cuid()')
    userId = db.Column(db.String, nullable=False)
    createdAt = db.Column(db.DateTime, default=datetime.utcnow)
    updatedAt = db.Column(db.DateTime, onupdate=datetime.utcnow)
    status = db.Column(db.String, nullable=False)
    courseId = db.Column(db.String, db.ForeignKey('course.id'))

    # Relationship
    details = db.relationship('StudyPlanDetail', backref='plan')

class StudyPlanDetail(db.Model):
    __tablename__ = 'StudyPlanDetail'

    id = db.Column(db.String, primary_key=True, default='cuid()')
    userId = db.Column(db.String, nullable=False)
    createdAt = db.Column(db.DateTime, default=datetime.utcnow)
    updatedAt = db.Column(db.DateTime, onupdate=datetime.utcnow)
    status = db.Column(db.String, nullable=False)
    orderNo = db.Column(db.String, nullable=False)
    moduleId = db.Column(db.String, db.ForeignKey('module.id'))
    planId = db.Column(db.String, db.ForeignKey('StudyPlan.id'))
