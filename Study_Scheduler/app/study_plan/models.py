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

    modules = relationship('Module', backref='course_modules')
    study_plan = relationship('Module', backref='course_study_plan')
    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}


class StudyPlan(db.Model):
    __tablename__ = 'StudyPlan'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    userId = Column(String, ForeignKey('User.id'), nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    courseId = Column(String, ForeignKey('Course.id'), nullable=False)

    studyPlanDetails = relationship('StudyPlanDetail', backref='study_plan')
    course = relationship('Course', backref='course_study_plan')
    user = relationship('User', backref='user_study_plan')

    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns if c.key not in ['userId', 'courseId']}

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
    userId = Column(String, ForeignKey('User.id'), nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    name = Column(String, nullable=False)
    teacherId = Column(String, ForeignKey('Teacher.id'), nullable=False)

    modules = relationship('Module', backref='subject_modules')

    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}
    
class User(db.Model):
    __tablename__ = 'User'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    firstname = Column(String(100), nullable=False)
    lastname = Column(String(100), nullable=False)
    email = Column(String(320), unique=True, nullable=False)
    password = Column(String(255), nullable=False)
    photo = Column(String(500), nullable=True)
    cellphone = Column(String(20), nullable=True)
    birthdate = Column(DateTime(timezone=True), nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    userCourses = relationship('UserCourse', backref='user')
    modules = relationship('Module', backref='user_modules')
    study_plan = relationship('Module', backref='user_study_plan')

    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns if c.key not in ['password']}


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
    
class Teacher(db.Model):
    __tablename__ = 'Teacher'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    userId = Column(String, ForeignKey('User.id'), nullable=False)
    createdAt = Column(DateTime, nullable=False)
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    firstname = Column(String, nullable=False)
    lastname = Column(String, nullable=False)
    
    subjects = relationship('Subject', backref='teacher')

    user = relationship('User', backref='teacher_subjects')

    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns}
