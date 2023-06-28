/*
  Warnings:

  - A unique constraint covering the columns `[email]` on the table `User` will be added. If there are existing duplicate values, this will fail.
  - Added the required column `birthdate` to the `User` table without a default value. This is not possible if the table is not empty.
  - Added the required column `email` to the `User` table without a default value. This is not possible if the table is not empty.
  - Added the required column `firstname` to the `User` table without a default value. This is not possible if the table is not empty.
  - Added the required column `lastname` to the `User` table without a default value. This is not possible if the table is not empty.
  - Added the required column `password` to the `User` table without a default value. This is not possible if the table is not empty.

*/
-- AlterTable
ALTER TABLE "User" ADD COLUMN     "birthdate" TIMESTAMPTZ(6) NOT NULL,
ADD COLUMN     "cellphone" VARCHAR(20),
ADD COLUMN     "email" VARCHAR(320) NOT NULL,
ADD COLUMN     "firstname" VARCHAR(100) NOT NULL,
ADD COLUMN     "lastname" VARCHAR(100) NOT NULL,
ADD COLUMN     "password" VARCHAR(255) NOT NULL,
ADD COLUMN     "photo" VARCHAR(500);

-- CreateIndex
CREATE UNIQUE INDEX "user_email_unique" ON "User"("email");
