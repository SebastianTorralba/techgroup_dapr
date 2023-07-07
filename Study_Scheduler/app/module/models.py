from uuid import uuid4
from sqlalchemy import Column, ForeignKey, String, func
from sqlalchemy.orm import relationship, class_mapper
from app import db

class Module(db.Model):
    __tablename__ = 'Module'

    id = Column(String, primary_key=True, default=lambda: str(uuid4()))
    createdAt = db.Column(db.DateTime(timezone=True), default=func.now())
    updatedAt = db.Column(db.DateTime(timezone=True), default=func.now(), onupdate=func.now())
    status = Column(String, nullable=False)
    courseId = Column(String, ForeignKey('Course.id'), nullable=False)
    subjectId = Column(String, ForeignKey('Subject.id'), nullable=False)
    academyId = Column(String, ForeignKey('Academy.id'), nullable=False)
    userId = Column(String, ForeignKey('User.id'), nullable=False)

    academy = relationship('Academy', backref='academy_modules')
    subject = relationship('Subject', backref='subject_modules')
    course = relationship('Course', backref='course_modules')
    user = relationship('User', backref='user_modules')
    

    def to_dict(self):
        return {c.key: getattr(self, c.key) for c in class_mapper(self.__class__).columns if c.key not in ['courseId', 'subjectId', 'academyId', 'userId']}


