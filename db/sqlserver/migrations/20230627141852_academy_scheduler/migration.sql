/*
  Warnings:

  - You are about to drop the column `lastName` on the `Teacher` table. All the data in the column will be lost.
  - You are about to drop the column `name` on the `Teacher` table. All the data in the column will be lost.
  - Added the required column `firstname` to the `Teacher` table without a default value. This is not possible if the table is not empty.
  - Added the required column `lastname` to the `Teacher` table without a default value. This is not possible if the table is not empty.

*/
BEGIN TRY

BEGIN TRAN;

-- AlterTable
ALTER TABLE [dbo].[Teacher] DROP COLUMN [lastName],
[name];
ALTER TABLE [dbo].[Teacher] ADD [firstname] NVARCHAR(1000) NOT NULL,
[lastname] NVARCHAR(1000) NOT NULL;

COMMIT TRAN;

END TRY
BEGIN CATCH

IF @@TRANCOUNT > 0
BEGIN
    ROLLBACK TRAN;
END;
THROW

END CATCH
