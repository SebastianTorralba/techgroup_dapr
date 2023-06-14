from uuid import uuid4
from sqlalchemy import Column, DateTime, ForeignKey, Integer, String, func, text
from sqlalchemy.orm import relationship
from app import db

class Module(db.Model):
    __tablename__ = 'Module'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False, server_default=func.now())
    status = Column(String, nullable=False)
    courseId = Column(String, ForeignKey('Course.id'), nullable=False)
    subjectId = Column(String, ForeignKey('Subject.id'), nullable=False)
    academyId = Column(String, ForeignKey('Academy.id'), nullable=False)

    studyPlanDetails = relationship('StudyPlanDetail', backref='module')
