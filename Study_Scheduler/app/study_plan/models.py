from uuid import uuid4
from sqlalchemy import Column, DateTime, ForeignKey, Integer, String, UniqueConstraint
from sqlalchemy.orm import relationship, class_mapper
from app import db

class Academy(db.Model):
    __tablename__ = 'Academy'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    name = Column(String, nullable=False)
    description = Column(String, nullable=False)

    classrooms = relationship('Classroom', backref='academy1')
    courses = relationship('Course', backref='academy2')
    modules = relationship('Module', backref='academy_modules')
    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}


class Classroom(db.Model):
    __tablename__ = 'Classroom'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    number = Column(String, nullable=False)
    capacity = Column(Integer, nullable=False)
    academyId = Column(String, ForeignKey('Academy.id'), nullable=False)
    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}


class Course(db.Model):
    __tablename__ = 'Course'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    section = Column(String, nullable=False)
    academyId = Column(String, ForeignKey('Academy.id'), nullable=False)

    modules = relationship('Module', backref='course')
    studyPlans = relationship('StudyPlan', backref='course')
    userCourses = relationship('UserCourse', backref='course')
    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}


class StudyPlan(db.Model):
    __tablename__ = 'StudyPlan'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    courseId = Column(String, ForeignKey('Course.id'), nullable=False)

    studyPlanDetails = relationship('StudyPlanDetail', backref='studyPlan')

    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}



class StudyPlanDetail(db.Model):
    __tablename__ = 'StudyPlanDetail'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    orderNo = Column(String, nullable=False)
    moduleId = Column(String, ForeignKey('Module.id'), nullable=False)
    planId = Column(String, ForeignKey('StudyPlan.id'), nullable=False)

    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}

class Subject(db.Model):
    __tablename__ = 'Subject'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    userId = Column(String, ForeignKey('user.id'), nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    name = Column(String, nullable=False)
    teacherId = Column(String, ForeignKey('Teacher.id'), nullable=False)

    # teacher = relationship('Teacher', backref='taught_subjects')
    modules = relationship('Module', backref='subject_modules')
    # user = db.relationship('User', backref='owned_subjects')

    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}

class User(db.Model):
    __tablename__ = 'User'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    userCourses = relationship('UserCourse', backref='user')
    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}


class UserCourse(db.Model):
    __tablename__ = 'UserCourse'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    userId = Column(String, ForeignKey('User.id'), nullable=False)
    courseId = Column(String, ForeignKey('Course.id'), nullable=False)

    __table_args__ = (
        UniqueConstraint('userId', 'courseId'),
    )

    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}