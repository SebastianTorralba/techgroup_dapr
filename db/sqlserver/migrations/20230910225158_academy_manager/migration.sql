BEGIN TRY

BEGIN TRAN;

-- CreateTable
CREATE TABLE [dbo].[Academy] (
    [id] INT NOT NULL IDENTITY(1,1),
    [createdDate] DATETIME2 NOT NULL CONSTRAINT [Academy_createdDate_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedDate] DATETIME2 NOT NULL CONSTRAINT [Academy_updatedDate_df] DEFAULT CURRENT_TIMESTAMP,
    [enabled] BIT NOT NULL,
    [name] NVARCHAR(1000) NOT NULL,
    [description] NVARCHAR(1000) NOT NULL CONSTRAINT [Academy_description_df] DEFAULT '',
    CONSTRAINT [Academy_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[Classroom] (
    [id] INT NOT NULL IDENTITY(1,1),
    [createdDate] DATETIME2 NOT NULL CONSTRAINT [Classroom_createdDate_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedDate] DATETIME2 NOT NULL CONSTRAINT [Classroom_updatedDate_df] DEFAULT CURRENT_TIMESTAMP,
    [enabled] BIT NOT NULL,
    [number] INT NOT NULL,
    [capacity] INT,
    [academyId] INT NOT NULL,
    CONSTRAINT [Classroom_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[Course] (
    [id] INT NOT NULL IDENTITY(1,1),
    [createdDate] DATETIME2 NOT NULL CONSTRAINT [Course_createdDate_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedDate] DATETIME2 NOT NULL CONSTRAINT [Course_updatedDate_df] DEFAULT CURRENT_TIMESTAMP,
    [enabled] BIT NOT NULL,
    [section] NVARCHAR(1000) NOT NULL,
    [academyId] INT NOT NULL,
    [classroomId] INT NOT NULL,
    CONSTRAINT [Course_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[Subject] (
    [id] INT NOT NULL IDENTITY(1,1),
    [createdDate] DATETIME2 NOT NULL CONSTRAINT [Subject_createdDate_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedDate] DATETIME2 NOT NULL CONSTRAINT [Subject_updatedDate_df] DEFAULT CURRENT_TIMESTAMP,
    [enabled] BIT NOT NULL,
    [name] NVARCHAR(1000) NOT NULL,
    [teacherId] INT NOT NULL,
    [academyId] INT NOT NULL,
    [courseId] INT NOT NULL,
    CONSTRAINT [Subject_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- CreateTable
CREATE TABLE [dbo].[Teacher] (
    [id] INT NOT NULL IDENTITY(1,1),
    [createdDate] DATETIME2 NOT NULL CONSTRAINT [Teacher_createdDate_df] DEFAULT CURRENT_TIMESTAMP,
    [updatedDate] DATETIME2 NOT NULL CONSTRAINT [Teacher_updatedDate_df] DEFAULT CURRENT_TIMESTAMP,
    [enabled] BIT NOT NULL,
    [firstname] NVARCHAR(1000) NOT NULL,
    [lastname] NVARCHAR(1000) NOT NULL,
    [academyId] INT NOT NULL,
    CONSTRAINT [Teacher_pkey] PRIMARY KEY CLUSTERED ([id])
);

-- AddForeignKey
ALTER TABLE [dbo].[Classroom] ADD CONSTRAINT [Classroom_academyId_fkey] FOREIGN KEY ([academyId]) REFERENCES [dbo].[Academy]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Course] ADD CONSTRAINT [Course_academyId_fkey] FOREIGN KEY ([academyId]) REFERENCES [dbo].[Academy]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Course] ADD CONSTRAINT [Course_classroomId_fkey] FOREIGN KEY ([classroomId]) REFERENCES [dbo].[Classroom]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Subject] ADD CONSTRAINT [Subject_teacherId_fkey] FOREIGN KEY ([teacherId]) REFERENCES [dbo].[Teacher]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Subject] ADD CONSTRAINT [Subject_academyId_fkey] FOREIGN KEY ([academyId]) REFERENCES [dbo].[Academy]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Subject] ADD CONSTRAINT [Subject_courseId_fkey] FOREIGN KEY ([courseId]) REFERENCES [dbo].[Course]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

-- AddForeignKey
ALTER TABLE [dbo].[Teacher] ADD CONSTRAINT [Teacher_academyId_fkey] FOREIGN KEY ([academyId]) REFERENCES [dbo].[Academy]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

COMMIT TRAN;

END TRY
BEGIN CATCH

IF @@TRANCOUNT > 0
BEGIN
    ROLLBACK TRAN;
END;
THROW

END CATCH
