from uuid import uuid4
from sqlalchemy import Column, DateTime, ForeignKey, Integer, String, func, UniqueConstraint
from sqlalchemy.orm import relationship
from app import db

class Academy(db.Model):
    __tablename__ = 'Academy'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False, server_default=func.now(), onupdate=func.now())
    status = Column(String, nullable=False)
    name = Column(String, nullable=False)
    description = Column(String, nullable=False)

    classrooms = relationship('Classroom', backref='academy')
    courses = relationship('Course', backref='academy')
    modules = relationship('Module', backref='academy')


class Classroom(db.Model):
    __tablename__ = 'Classroom'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False, server_default=func.now(), onupdate=func.now())
    status = Column(String, nullable=False)
    number = Column(String, nullable=False)
    capacity = Column(Integer, nullable=False)
    academyId = Column(String, ForeignKey('Academy.id'), nullable=False)


class Course(db.Model):
    __tablename__ = 'Course'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False, server_default=func.now(), onupdate=func.now())
    status = Column(String, nullable=False)
    section = Column(String, nullable=False)
    academyId = Column(String, ForeignKey('Academy.id'), nullable=False)

    modules = relationship('Module', backref='course')
    studyPlans = relationship('StudyPlan', backref='course')
    userCourses = relationship('UserCourse', backref='course')

class User(db.Model):
    __tablename__ = 'User'

    id = Column(String, primary_key=True)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False, server_default=func.now(), onupdate=func.now())
    # Other fields based on your User model

    userCourses = relationship('UserCourse', backref='user')


class UserCourse(db.Model):
    __tablename__ = 'UserCourse'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False, server_default=func.now(), onupdate=func.now())
    status = Column(String, nullable=False)
    userId = Column(String, ForeignKey('User.id'), nullable=False)
    courseId = Column(String, ForeignKey('Course.id'), nullable=False)

    __table_args__ = (
        UniqueConstraint('userId', 'courseId'),
    )

class StudyPlan(db.Model):
    __tablename__ = 'StudyPlan'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False, server_default=func.now(), onupdate=func.now())
    status = Column(String, nullable=False)
    courseId = Column(String, ForeignKey('Course.id'), nullable=False)

    studyPlanDetails = relationship('StudyPlanDetail', backref='studyPlan')



class StudyPlanDetail(db.Model):
    __tablename__ = 'StudyPlanDetail'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False, server_default=func.now(), onupdate=func.now())
    status = Column(String, nullable=False)
    orderNo = Column(String, nullable=False)
    moduleId = Column(String, ForeignKey('Module.id'), nullable=False)
    planId = Column(String, ForeignKey('StudyPlan.id'), nullable=False)
