USE [master]
GO
/****** Object:  Database [TaskManagement]    Script Date: 11/17/2013 3:11:13 PM ******/
CREATE DATABASE [TaskManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TaskManagement.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TaskManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TaskManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TaskManagement] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskManagement] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TaskManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaskManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaskManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [TaskManagement] SET  MULTI_USER 
GO
ALTER DATABASE [TaskManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TaskManagement', N'ON'
GO
USE [TaskManagement]
GO
/****** Object:  Table [dbo].[Estimates]    Script Date: 11/17/2013 3:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estimates](
	[time] [int] NOT NULL,
	[type] [varchar](50) NOT NULL,
	[taskId] [int] NOT NULL,
 CONSTRAINT [PK_Estimates] PRIMARY KEY CLUSTERED 
(
	[time] ASC,
	[type] ASC,
	[taskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 11/17/2013 3:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[profileId] [int] NOT NULL,
	[userId] [int] NOT NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[profileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profiles_Tasks]    Script Date: 11/17/2013 3:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles_Tasks](
	[profileId] [int] NOT NULL,
	[taskId] [int] NOT NULL,
 CONSTRAINT [PK_Profiles_Tasks] PRIMARY KEY CLUSTERED 
(
	[profileId] ASC,
	[taskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 11/17/2013 3:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tasks](
	[taskId] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](50) NULL,
	[notes] [varchar](50) NULL,
	[priority] [int] NOT NULL,
	[dueDate] [date] NOT NULL,
	[dateCreated] [date] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[taskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/17/2013 3:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[userId] [int] NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Estimates]  WITH CHECK ADD  CONSTRAINT [FK_Estimates_Task] FOREIGN KEY([taskId])
REFERENCES [dbo].[Tasks] ([taskId])
GO
ALTER TABLE [dbo].[Estimates] CHECK CONSTRAINT [FK_Estimates_Task]
GO
ALTER TABLE [dbo].[Profiles]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userId])
GO
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_Profiles_Users]
GO
ALTER TABLE [dbo].[Profiles_Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Tasks_Profile] FOREIGN KEY([profileId])
REFERENCES [dbo].[Profiles] ([profileId])
GO
ALTER TABLE [dbo].[Profiles_Tasks] CHECK CONSTRAINT [FK_Profiles_Tasks_Profile]
GO
ALTER TABLE [dbo].[Profiles_Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Profiles_Tasks_Task] FOREIGN KEY([taskId])
REFERENCES [dbo].[Tasks] ([taskId])
GO
ALTER TABLE [dbo].[Profiles_Tasks] CHECK CONSTRAINT [FK_Profiles_Tasks_Task]
GO
USE [master]
GO
ALTER DATABASE [TaskManagement] SET  READ_WRITE 
GO
