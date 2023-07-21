from uuid import uuid4
from sqlalchemy import Column, DateTime, ForeignKey, Integer, String, UniqueConstraint
from sqlalchemy.orm import relationship, class_mapper
from app import db

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