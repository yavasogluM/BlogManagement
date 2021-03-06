USE [master]
GO
/****** Object:  Database [BlogManagementDB]    Script Date: 4/6/2020 12:18:15 AM ******/
CREATE DATABASE [BlogManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BlogManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlogManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BlogManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BlogManagementDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlogManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BlogManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogManagementDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BlogManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogManagementDB] SET RECOVERY FULL 
GO
ALTER DATABASE [BlogManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [BlogManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BlogManagementDB', N'ON'
GO
ALTER DATABASE [BlogManagementDB] SET QUERY_STORE = OFF
GO
USE [BlogManagementDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BlogManagementDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/6/2020 12:18:15 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApiVersionEntities]    Script Date: 4/6/2020 12:18:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiVersionEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[VersionName] [nvarchar](max) NULL,
	[VersionDetail] [nvarchar](max) NULL,
 CONSTRAINT [PK_ApiVersionEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleEntities]    Script Date: 4/6/2020 12:18:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[ArticleTitle] [nvarchar](max) NULL,
	[ArticleContent] [nvarchar](max) NULL,
	[AuthorId] [int] NULL,
 CONSTRAINT [PK_ArticleEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorEntities]    Script Date: 4/6/2020 12:18:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[AuthorName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_AuthorEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentEntities]    Script Date: 4/6/2020 12:18:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CommentContent] [nvarchar](max) NULL,
	[CommentatorName] [nvarchar](max) NULL,
	[ArticleId] [int] NULL,
 CONSTRAINT [PK_CommentEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogEntities]    Script Date: 4/6/2020 12:18:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[LogTitle] [nvarchar](max) NULL,
	[LogText] [nvarchar](max) NULL,
 CONSTRAINT [PK_LogEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200330195213_InitialCreate', N'3.1.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200330200945_ArticleComment', N'3.1.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200402131657_UserCreate', N'3.1.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200403194824_AuthorCreate', N'3.1.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200405100159_LogCreate', N'3.1.3')
SET IDENTITY_INSERT [dbo].[ApiVersionEntities] ON 

INSERT [dbo].[ApiVersionEntities] ([Id], [IsDeleted], [CreateDate], [VersionName], [VersionDetail]) VALUES (1, 1, CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), N'v1', N'versiyon 1 bilgileri')
INSERT [dbo].[ApiVersionEntities] ([Id], [IsDeleted], [CreateDate], [VersionName], [VersionDetail]) VALUES (2, 1, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), N'v2', N'versiyon 2 ile ilgili güncellemele')
SET IDENTITY_INSERT [dbo].[ApiVersionEntities] OFF
SET IDENTITY_INSERT [dbo].[ArticleEntities] ON 

INSERT [dbo].[ArticleEntities] ([Id], [IsDeleted], [CreateDate], [ArticleTitle], [ArticleContent], [AuthorId]) VALUES (1, 0, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), N'başlık', N'içerik', 1)
SET IDENTITY_INSERT [dbo].[ArticleEntities] OFF
SET IDENTITY_INSERT [dbo].[AuthorEntities] ON 

INSERT [dbo].[AuthorEntities] ([Id], [IsDeleted], [CreateDate], [AuthorName], [Password]) VALUES (1, 0, CAST(N'2019-01-01T00:00:00.0000000' AS DateTime2), N'test', N'sifre1')
INSERT [dbo].[AuthorEntities] ([Id], [IsDeleted], [CreateDate], [AuthorName], [Password]) VALUES (2, 0, CAST(N'2019-02-01T00:00:00.0000000' AS DateTime2), N'yazar', N'erfis2')
SET IDENTITY_INSERT [dbo].[AuthorEntities] OFF
SET IDENTITY_INSERT [dbo].[CommentEntities] ON 

INSERT [dbo].[CommentEntities] ([Id], [IsDeleted], [CreateDate], [CommentContent], [CommentatorName], [ArticleId]) VALUES (1, 0, CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), N'yorum içeriği', N'yorumcu', 1)
SET IDENTITY_INSERT [dbo].[CommentEntities] OFF
SET IDENTITY_INSERT [dbo].[LogEntities] ON 

INSERT [dbo].[LogEntities] ([Id], [IsDeleted], [CreateDate], [LogTitle], [LogText]) VALUES (1, 0, CAST(N'2020-04-06T00:17:53.9789487' AS DateTime2), N'GetCurrentVersion Metodunda Hata', N'System.NullReferenceException: Object reference not set to an instance of an object.
   at BlogManagement.API.Controllers.ApiVersionController.GetCurrentVersion() in C:\Users\prs\Downloads\BlogManagement\BlogManagement\BlogManagement.API\Controllers\ApiVersionController.cs:line 45')
SET IDENTITY_INSERT [dbo].[LogEntities] OFF
/****** Object:  Index [IX_ArticleEntities_AuthorId]    Script Date: 4/6/2020 12:18:15 AM ******/
CREATE NONCLUSTERED INDEX [IX_ArticleEntities_AuthorId] ON [dbo].[ArticleEntities]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CommentEntities_ArticleId]    Script Date: 4/6/2020 12:18:15 AM ******/
CREATE NONCLUSTERED INDEX [IX_CommentEntities_ArticleId] ON [dbo].[CommentEntities]
(
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ArticleEntities]  WITH CHECK ADD  CONSTRAINT [FK_ArticleEntities_AuthorEntities_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[AuthorEntities] ([Id])
GO
ALTER TABLE [dbo].[ArticleEntities] CHECK CONSTRAINT [FK_ArticleEntities_AuthorEntities_AuthorId]
GO
ALTER TABLE [dbo].[CommentEntities]  WITH CHECK ADD  CONSTRAINT [FK_CommentEntities_ArticleEntities_ArticleId] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[ArticleEntities] ([Id])
GO
ALTER TABLE [dbo].[CommentEntities] CHECK CONSTRAINT [FK_CommentEntities_ArticleEntities_ArticleId]
GO
USE [master]
GO
ALTER DATABASE [BlogManagementDB] SET  READ_WRITE 
GO
