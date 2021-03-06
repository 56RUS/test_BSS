USE [master]
GO
/****** Object:  Database [db_bss]    Script Date: 02.01.2019 18:41:27 ******/
CREATE DATABASE [db_bss]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_bss', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_bss.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'db_bss_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\db_bss_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [db_bss] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_bss].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_bss] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_bss] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_bss] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_bss] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_bss] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_bss] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_bss] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [db_bss] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_bss] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_bss] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_bss] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_bss] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_bss] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_bss] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_bss] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_bss] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_bss] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_bss] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_bss] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_bss] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_bss] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_bss] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_bss] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_bss] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [db_bss] SET  MULTI_USER 
GO
ALTER DATABASE [db_bss] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_bss] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_bss] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_bss] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [db_bss]
GO
/****** Object:  Table [dbo].[tbCalc]    Script Date: 02.01.2019 18:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCalc](
	[cId] [int] IDENTITY(1,1) NOT NULL,
	[cParam1] [int] NOT NULL,
	[cParam2] [int] NOT NULL,
	[cChecksum] [int] NOT NULL,
 CONSTRAINT [PK_tbCalc] PRIMARY KEY CLUSTERED 
(
	[cId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbOwner]    Script Date: 02.01.2019 18:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbOwner](
	[cId] [int] IDENTITY(1,1) NOT NULL,
	[cName] [varchar](50) NOT NULL,
	[cDate] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbOwner] PRIMARY KEY CLUSTERED 
(
	[cId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbOwnerCalc]    Script Date: 02.01.2019 18:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbOwnerCalc](
	[cId] [int] IDENTITY(1,1) NOT NULL,
	[cOwnerId] [int] NOT NULL,
	[cCalcId] [int] NOT NULL,
 CONSTRAINT [PK_tbOwnerCalc] PRIMARY KEY CLUSTERED 
(
	[cId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbCalc] ON 

INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (1, 5, 5, 10)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (2, 2, 6, 8)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (3, 9, 9, 18)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (4, 6, 2, 8)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (5, 3, 3, 6)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (6, 5, 5, 10)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (7, 2, 6, 8)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (8, 9, 9, 18)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (9, 6, 2, 8)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (10, 10, 13, 23)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (11, 23, 22, 45)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (12, 17, 34, 51)
INSERT [dbo].[tbCalc] ([cId], [cParam1], [cParam2], [cChecksum]) VALUES (13, 7, 65, 72)
SET IDENTITY_INSERT [dbo].[tbCalc] OFF
SET IDENTITY_INSERT [dbo].[tbOwner] ON 

INSERT [dbo].[tbOwner] ([cId], [cName], [cDate]) VALUES (1, N'Test1', N'12-12-18')
INSERT [dbo].[tbOwner] ([cId], [cName], [cDate]) VALUES (2, N'Test2', N'14-11-15')
INSERT [dbo].[tbOwner] ([cId], [cName], [cDate]) VALUES (3, N'Test5', N'12-12-18')
INSERT [dbo].[tbOwner] ([cId], [cName], [cDate]) VALUES (4, N'Test2', N'20-05-15')
INSERT [dbo].[tbOwner] ([cId], [cName], [cDate]) VALUES (5, N'Test4', N'13-06-17')
INSERT [dbo].[tbOwner] ([cId], [cName], [cDate]) VALUES (6, N'Test8', N'12-01-18')
SET IDENTITY_INSERT [dbo].[tbOwner] OFF
SET IDENTITY_INSERT [dbo].[tbOwnerCalc] ON 

INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (1, 1, 1)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (2, 1, 2)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (3, 2, 3)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (4, 2, 4)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (5, 3, 5)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (6, 3, 6)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (7, 3, 7)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (8, 4, 8)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (9, 4, 9)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (10, 5, 10)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (11, 5, 11)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (12, 6, 12)
INSERT [dbo].[tbOwnerCalc] ([cId], [cOwnerId], [cCalcId]) VALUES (13, 6, 13)
SET IDENTITY_INSERT [dbo].[tbOwnerCalc] OFF
USE [master]
GO
ALTER DATABASE [db_bss] SET  READ_WRITE 
GO
