USE [master]
GO
/****** Object:  Database [AcademyManager]    Script Date: 06/07/2023 09:40:25 ******/
CREATE DATABASE [AcademyManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AcademyManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AcademyManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AcademyManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AcademyManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AcademyManager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AcademyManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AcademyManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AcademyManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AcademyManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AcademyManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AcademyManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [AcademyManager] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [AcademyManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AcademyManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AcademyManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AcademyManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AcademyManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AcademyManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AcademyManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AcademyManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AcademyManager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AcademyManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AcademyManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AcademyManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AcademyManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AcademyManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AcademyManager] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AcademyManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AcademyManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AcademyManager] SET  MULTI_USER 
GO
ALTER DATABASE [AcademyManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AcademyManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AcademyManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AcademyManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AcademyManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AcademyManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AcademyManager] SET QUERY_STORE = OFF
GO
USE [AcademyManager]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/07/2023 09:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Academy]    Script Date: 06/07/2023 09:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Academy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Academy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classroom]    Script Date: 06/07/2023 09:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classroom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
	[AcademyId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Classroom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 06/07/2023 09:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Section] [nvarchar](max) NOT NULL,
	[AcademyId] [int] NOT NULL,
	[ClassroomId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 06/07/2023 09:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[AcademyId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 06/07/2023 09:40:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[AcademyId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Classroom_AcademyId]    Script Date: 06/07/2023 09:40:26 ******/
CREATE NONCLUSTERED INDEX [IX_Classroom_AcademyId] ON [dbo].[Classroom]
(
	[AcademyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Course_AcademyId]    Script Date: 06/07/2023 09:40:26 ******/
CREATE NONCLUSTERED INDEX [IX_Course_AcademyId] ON [dbo].[Course]
(
	[AcademyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Course_ClassroomId]    Script Date: 06/07/2023 09:40:26 ******/
CREATE NONCLUSTERED INDEX [IX_Course_ClassroomId] ON [dbo].[Course]
(
	[ClassroomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subject_AcademyId]    Script Date: 06/07/2023 09:40:26 ******/
CREATE NONCLUSTERED INDEX [IX_Subject_AcademyId] ON [dbo].[Subject]
(
	[AcademyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subject_CourseId]    Script Date: 06/07/2023 09:40:26 ******/
CREATE NONCLUSTERED INDEX [IX_Subject_CourseId] ON [dbo].[Subject]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subject_TeacherId]    Script Date: 06/07/2023 09:40:26 ******/
CREATE NONCLUSTERED INDEX [IX_Subject_TeacherId] ON [dbo].[Subject]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Teacher_AcademyId]    Script Date: 06/07/2023 09:40:26 ******/
CREATE NONCLUSTERED INDEX [IX_Teacher_AcademyId] ON [dbo].[Teacher]
(
	[AcademyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Academy] ADD  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[Academy] ADD  DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Classroom] ADD  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[Classroom] ADD  DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Course] ADD  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[Course] ADD  DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Subject] ADD  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[Subject] ADD  DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Teacher] ADD  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [dbo].[Teacher] ADD  DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Classroom]  WITH NOCHECK ADD  CONSTRAINT [FK_Classroom_Academy_AcademyId] FOREIGN KEY([AcademyId])
REFERENCES [dbo].[Academy] ([Id])
GO
ALTER TABLE [dbo].[Classroom] CHECK CONSTRAINT [FK_Classroom_Academy_AcademyId]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Academy_AcademyId] FOREIGN KEY([AcademyId])
REFERENCES [dbo].[Academy] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Academy_AcademyId]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Classroom_ClassroomId] FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classroom] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Classroom_ClassroomId]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Academy_AcademyId] FOREIGN KEY([AcademyId])
REFERENCES [dbo].[Academy] ([Id])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Academy_AcademyId]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Course_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Course_CourseId]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Teacher_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Teacher_TeacherId]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Academy_AcademyId] FOREIGN KEY([AcademyId])
REFERENCES [dbo].[Academy] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Academy_AcademyId]
GO
USE [master]
GO
ALTER DATABASE [AcademyManager] SET  READ_WRITE 
GO
