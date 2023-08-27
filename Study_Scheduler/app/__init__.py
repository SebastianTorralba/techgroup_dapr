from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from config import Config

db = SQLAlchemy()

def create_app(config_class=Config):
    app = Flask(__name__)
    app.config.from_object(config_class)

    db.init_app(app)

    from app.study_plan.views import study_plan
    app.register_blueprint(study_plan)
    
    from app.module.views import module
    app.register_blueprint(module)
    
    return app
