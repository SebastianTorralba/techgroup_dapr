BEGIN TRY

BEGIN TRAN;

-- CreateTable
CREATE TABLE [dbo].[Academy] (
    [id] NVARCHAR(1000) NOT NULL,
    [userId] NVARCHAR(1000) NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [Academy_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    [name] NVARCHAR(1000) NOT NULL,
    [description] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [Academy_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[Classroom] (
    [id] NVARCHAR(1000) NOT NULL,
    [userId] NVARCHAR(1000) NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [Classroom_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    [number] NVARCHAR(1000) NOT NULL,
    [capacity] INT NOT NULL,
    [academyId] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [Classroom_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[Course] (
    [id] NVARCHAR(1000) NOT NULL,
    [userId] NVARCHAR(1000) NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [Course_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    [section] NVARCHAR(1000) NOT NULL,
    [academyId] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [Course_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[Module] (
    [id] NVARCHAR(1000) NOT NULL,
    [userId] NVARCHAR(1000) NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [Module_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    [courseId] NVARCHAR(1000) NOT NULL,
    [subjectId] NVARCHAR(1000) NOT NULL,
    [academyId] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [Module_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[StudyPlan] (
    [id] NVARCHAR(1000) NOT NULL,
    [userId] NVARCHAR(1000) NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [StudyPlan_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    [courseId] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [StudyPlan_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[StudyPlanDetail] (
    [id] NVARCHAR(1000) NOT NULL,
    [userId] NVARCHAR(1000) NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [StudyPlanDetail_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    [orderNo] NVARCHAR(1000) NOT NULL,
    [moduleId] NVARCHAR(1000) NOT NULL,
    [planId] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [StudyPlanDetail_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[Subject] (
    [id] NVARCHAR(1000) NOT NULL,
    [userId] NVARCHAR(1000) NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [Subject_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    [name] NVARCHAR(1000) NOT NULL,
    [teacherId] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [Subject_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[Teacher] (
    [id] NVARCHAR(1000) NOT NULL,
    [userId] NVARCHAR(1000) NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [Teacher_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    [name] NVARCHAR(1000) NOT NULL,
    [lastName] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [Teacher_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[User] (
    [id] NVARCHAR(1000) NOT NULL,
    [firstname] VARCHAR(100) NOT NULL,
    [lastname] VARCHAR(100) NOT NULL,
    [email] VARCHAR(320) NOT NULL,
    [password] VARCHAR(255) NOT NULL,
    [photo] VARCHAR(500),
    [cellphone] VARCHAR(20),
    [birthdate] DATETIME2 NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [User_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [User_pkey] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [user_email_unique] UNIQUE NONCLUSTERED ([email])
);

-- CreateTable
CREATE TABLE [dbo].[UserCourse] (
    [id] NVARCHAR(1000) NOT NULL,
    [createdAt] DATETIME2 NOT NULL CONSTRAINT [UserCourse_createdAt_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedAt] DATETIME2 NOT NULL,
    [status] NVARCHAR(1000) NOT NULL,
    [userId] NVARCHAR(1000) NOT NULL,
    [courseId] NVARCHAR(1000) NOT NULL,
    CONSTRAINT [UserCourse_pkey] PRIMARY KEY CLUSTERED ([id]),
    CONSTRAINT [UserCourse_userId_courseId_key] UNIQUE NONCLUSTERED ([userId],[courseId])
);

-- AddForeignKey
ALTER TABLE [dbo].[Academy] ADD CONSTRAINT [Academy_userId_fkey] FOREIGN KEY ([userId]) REFERENCES [dbo].[User]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Classroom] ADD CONSTRAINT [Classroom_academyId_fkey] FOREIGN KEY ([academyId]) REFERENCES [dbo].[Academy]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Classroom] ADD CONSTRAINT [Classroom_userId_fkey] FOREIGN KEY ([userId]) REFERENCES [dbo].[User]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Course] ADD CONSTRAINT [Course_academyId_fkey] FOREIGN KEY ([academyId]) REFERENCES [dbo].[Academy]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Course] ADD CONSTRAINT [Course_userId_fkey] FOREIGN KEY ([userId]) REFERENCES [dbo].[User]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Module] ADD CONSTRAINT [Module_courseId_fkey] FOREIGN KEY ([courseId]) REFERENCES [dbo].[Course]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Module] ADD CONSTRAINT [Module_subjectId_fkey] FOREIGN KEY ([subjectId]) REFERENCES [dbo].[Subject]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Module] ADD CONSTRAINT [Module_academyId_fkey] FOREIGN KEY ([academyId]) REFERENCES [dbo].[Academy]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Module] ADD CONSTRAINT [Module_userId_fkey] FOREIGN KEY ([userId]) REFERENCES [dbo].[User]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[StudyPlan] ADD CONSTRAINT [StudyPlan_courseId_fkey] FOREIGN KEY ([courseId]) REFERENCES [dbo].[Course]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[StudyPlan] ADD CONSTRAINT [StudyPlan_userId_fkey] FOREIGN KEY ([userId]) REFERENCES [dbo].[User]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[StudyPlanDetail] ADD CONSTRAINT [StudyPlanDetail_moduleId_fkey] FOREIGN KEY ([moduleId]) REFERENCES [dbo].[Module]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[StudyPlanDetail] ADD CONSTRAINT [StudyPlanDetail_planId_fkey] FOREIGN KEY ([planId]) REFERENCES [dbo].[StudyPlan]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[StudyPlanDetail] ADD CONSTRAINT [StudyPlanDetail_userId_fkey] FOREIGN KEY ([userId]) REFERENCES [dbo].[User]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Subject] ADD CONSTRAINT [Subject_teacherId_fkey] FOREIGN KEY ([teacherId]) REFERENCES [dbo].[Teacher]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Subject] ADD CONSTRAINT [Subject_userId_fkey] FOREIGN KEY ([userId]) REFERENCES [dbo].[User]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Teacher] ADD CONSTRAINT [Teacher_userId_fkey] FOREIGN KEY ([userId]) REFERENCES [dbo].[User]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[UserCourse] ADD CONSTRAINT [UserCourse_userId_fkey] FOREIGN KEY ([userId]) REFERENCES [dbo].[User]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[UserCourse] ADD CONSTRAINT [UserCourse_courseId_fkey] FOREIGN KEY ([courseId]) REFERENCES [dbo].[Course]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

COMMIT TRAN;

END TRY
BEGIN CATCH

IF @@TRANCOUNT > 0
BEGIN
    ROLLBACK TRAN;
END;
THROW

END CATCH
