import os


class Config(object):
    SECRET_KEY = os.environ.get('SECRET_KEY') or 'rolling-stones'

    # Database configuration
    SQLALCHEMY_DATABASE_URI = os.environ.get('DATABASE_URL') or \
        'postgresql://postgres:postgres@localhost:5432/academy_scheduler'
    SQLALCHEMY_TRACK_MODIFICATIONS = False  # turn off tracking for SQLAlchemy

    # Server configuration
    SERVER_NAME = os.environ.get('SERVER_NAME') or 'localhost:8002'
    DEBUG = os.environ.get('DEBUG') or True  # Enable debug mode
