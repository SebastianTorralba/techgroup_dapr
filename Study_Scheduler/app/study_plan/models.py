from sqlalchemy import Column, DateTime, ForeignKey, Integer, String, func, text
from sqlalchemy.orm import relationship
from app import db

class Academy(db.Model):
    __tablename__ = 'Academy'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False)
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
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    number = Column(String, nullable=False)
    capacity = Column(Integer, nullable=False)
    academyId = Column(String, ForeignKey('Academy.id'), nullable=False)


class Course(db.Model):
    __tablename__ = 'Course'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    section = Column(String, nullable=False)
    academyId = Column(String, ForeignKey('Academy.id'), nullable=False)

    modules = relationship('Module', backref='course')
    studyPlans = relationship('StudyPlan', backref='course')
    userCourses = relationship('UserCourse', backref='course')


class Module(db.Model):
    __tablename__ = 'Module'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    courseId = Column(String, ForeignKey('Course.id'), nullable=False)
    subjectId = Column(String, ForeignKey('Subject.id'), nullable=False)
    academyId = Column(String, ForeignKey('Academy.id'), nullable=False)

    studyPlanDetails = relationship('StudyPlanDetail', backref='module')


class StudyPlan(db.Model):
    __tablename__ = 'StudyPlan'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    courseId = Column(String, ForeignKey('Course.id'), nullable=False)

    studyPlanDetails = relationship('StudyPlanDetail', backref='studyPlan')


class StudyPlanDetail(db.Model):
    __tablename__ = 'StudyPlanDetail'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    orderNo = Column(String, nullable=False)
    moduleId = Column(String, ForeignKey('Module.id'), nullable=False)
    planId = Column(String, ForeignKey('StudyPlan.id'), nullable=False)


class Subject(db.Model):
    __tablename__ = 'Subject'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    name = Column(String, nullable=False)
    teacherId = Column(String, ForeignKey('Teacher.id'), nullable=False)

    modules = relationship('Module', backref='subject')


class Teacher(db.Model):
    __tablename__ = 'Teacher'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
    name = Column(String, nullable=False)
    lastName = Column(String, nullable=False)

    subjects = relationship('Subject', backref='teacher')


class User(db.Model):
    __tablename__ = 'User'

    id = Column(String, primary_key=True)
    userId = Column(String, nullable=False, unique=True)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)

    userCourses = relationship('UserCourse', backref='user')


class UserCourse(db.Model):
    __tablename__ = 'UserCourse'

    userId = Column(String, ForeignKey('User.id'), primary_key=True)
    courseId = Column(String, ForeignKey('Course.id'), primary_key=True)
    createdAt = Column(DateTime, nullable=False, server_default=func.now())
    updatedAt = Column(DateTime, nullable=False)
    status = Column(String, nullable=False)
