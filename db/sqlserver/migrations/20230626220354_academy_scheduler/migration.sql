/*
  Warnings:

  - You are about to drop the column `userId` on the `User` table. All the data in the column will be lost.
  - The primary key for the `UserCourse` table will be changed. If it partially fails, the table could be left without primary key constraint.
  - A unique constraint covering the columns `[userId,courseId]` on the table `UserCourse` will be added. If there are existing duplicate values, this will fail.
  - The required column `id` was added to the `UserCourse` table with a prisma-level default value. This is not possible if the table is not empty. Please add this column as optional, then populate it before making it required.

*/
BEGIN TRY

BEGIN TRAN;

-- DropForeignKey
ALTER TABLE [dbo].[Classroom] DROP CONSTRAINT [Classroom_academyId_fkey];

-- DropForeignKey
ALTER TABLE [dbo].[Course] DROP CONSTRAINT [Course_academyId_fkey];

-- DropForeignKey
ALTER TABLE [dbo].[Module] DROP CONSTRAINT [Module_subjectId_fkey];

-- DropForeignKey
ALTER TABLE [dbo].[StudyPlan] DROP CONSTRAINT [StudyPlan_courseId_fkey];

-- DropForeignKey
ALTER TABLE [dbo].[StudyPlanDetail] DROP CONSTRAINT [StudyPlanDetail_moduleId_fkey];

-- DropForeignKey
ALTER TABLE [dbo].[StudyPlanDetail] DROP CONSTRAINT [StudyPlanDetail_planId_fkey];

-- DropForeignKey
ALTER TABLE [dbo].[Subject] DROP CONSTRAINT [Subject_teacherId_fkey];

-- DropForeignKey
ALTER TABLE [dbo].[UserCourse] DROP CONSTRAINT [UserCourse_courseId_fkey];

-- DropForeignKey
ALTER TABLE [dbo].[UserCourse] DROP CONSTRAINT [UserCourse_userId_fkey];

-- DropIndex
ALTER TABLE [dbo].[User] DROP CONSTRAINT [User_userId_key];

-- AlterTable
ALTER TABLE [dbo].[User] DROP COLUMN [userId];

-- AlterTable
ALTER TABLE [dbo].[UserCourse] DROP CONSTRAINT [UserCourse_pkey];
ALTER TABLE [dbo].[UserCourse] ADD CONSTRAINT UserCourse_pkey PRIMARY KEY CLUSTERED ([id]);
ALTER TABLE [dbo].[UserCourse] ADD [id] NVARCHAR(1000) NOT NULL;

-- CreateIndex
ALTER TABLE [dbo].[UserCourse] ADD CONSTRAINT [UserCourse_userId_courseId_key] UNIQUE NONCLUSTERED ([userId], [courseId]);

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
ALTER TABLE [dbo].[Module] ADD CONSTRAINT [Module_subjectId_fkey] FOREIGN KEY ([subjectId]) REFERENCES [dbo].[Subject]([id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

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
