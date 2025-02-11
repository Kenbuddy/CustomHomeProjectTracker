USE [master]
GO
/****** Object:  Database [DesignTechHomesTest]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE DATABASE [DesignTechHomesTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DesignTechHomesTest', SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DesignTechHomesTest_log', SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DesignTechHomesTest] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DesignTechHomesTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DesignTechHomesTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DesignTechHomesTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DesignTechHomesTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DesignTechHomesTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DesignTechHomesTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DesignTechHomesTest] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DesignTechHomesTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DesignTechHomesTest] SET  MULTI_USER 
GO
ALTER DATABASE [DesignTechHomesTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DesignTechHomesTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DesignTechHomesTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DesignTechHomesTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DesignTechHomesTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DesignTechHomesTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DesignTechHomesTest] SET QUERY_STORE = ON
GO
ALTER DATABASE [DesignTechHomesTest] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DesignTechHomesTest]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/11/2025 12:49:24 AM ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[AddressLine1] [nvarchar](256) NULL,
	[AddressLine2] [nvarchar](256) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](30) NULL,
	[EmailAddress] [nvarchar](256) NULL,
	[PhoneNumber] [nvarchar](30) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](450) NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageUploads]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageUploads](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[ImageData] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_ImageUploads] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectNotes]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectNotes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[Timestamp] [datetime2](7) NOT NULL,
	[Note] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ProjectNotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 2/11/2025 12:49:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[ClientId] [int] NOT NULL,
	[AddressLine1] [nvarchar](256) NULL,
	[AddressLine2] [nvarchar](256) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[PostalCode] [nvarchar](30) NULL,
	[StartDate] [datetime2](7) NULL,
	[EstimatedCompletionDate] [datetime2](7) NULL,
	[Status] [int] NOT NULL,
	[Budget] [decimal](18, 6) NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](450) NOT NULL,
	[ModifiedOn] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'8.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250205063320_InitialCreate', N'8.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250205071448_InitialCreate2', N'8.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250207060256_UpdateClientsModel', N'8.0.11')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250211063809_RenameProjectNotessToProjectNotes', N'8.0.11')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'084526c8-9a77-4f6d-9a11-494c0ae01b6e', N'TestUser1@gmail.com', N'TESTUSER1@GMAIL.COM', N'TestUser1@gmail.com', N'TESTUSER1@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEOiA6MSdASjjDE0M4yLBdl9aHbqmwgSqGbzs8Ui3J1uN60xQD+4YrQcVQdGJKLp18A==', N'OEPIOLICILOZ6ISLE2DSZR6XXZW22WBI', N'86a5a881-b130-42ff-a873-781f8580271c', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7447ea1f-6190-4fa9-b223-2709bc78f87e', N'ken.holtgrewe@gmail.com', N'KEN.HOLTGREWE@GMAIL.COM', N'ken.holtgrewe@gmail.com', N'KEN.HOLTGREWE@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEE4zjYDCSZuyFP5+Md2q7VjMbqalTRcLSrpgCwNHomhQUSMBtZkOfTZMXP2VfoqDzw==', N'4D42W3NV3CGNOIIESVVCCI6BHL2WZEDX', N'f45b6b68-70dd-4f3e-9c28-5101da9bd85e', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 
GO
INSERT [dbo].[Clients] ([Id], [FirstName], [LastName], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [EmailAddress], [PhoneNumber], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1, N'Ken', N'Holtgrewe', N'16810 Orchid Mist Dr', N'ghjfghjfh', N'Cypress', N'TX', N'77433', N'ken.holtgrewe@gmail.com', N'2815466277', CAST(N'2025-02-07T00:40:03.4123122' AS DateTime2), N'ken.holtgrewe@gmail.com', CAST(N'2025-02-07T01:05:57.8639793' AS DateTime2), N'ken.holtgrewe@gmail.com')
GO
INSERT [dbo].[Clients] ([Id], [FirstName], [LastName], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [EmailAddress], [PhoneNumber], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (2, N'Ned', N'Ryerson', N'123 Sunset Lane', NULL, N'Punxsutawney ', N'PA', N'12345', N'123@abc.com', N'1234567890', CAST(N'2025-02-07T01:45:42.0277428' AS DateTime2), N'ken.holtgrewe@gmail.com', CAST(N'2025-02-07T01:45:42.0277488' AS DateTime2), N'ken.holtgrewe@gmail.com')
GO
INSERT [dbo].[Clients] ([Id], [FirstName], [LastName], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [EmailAddress], [PhoneNumber], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (4, N'Obi-Wan', N'Kenobi', N'Desert Cave', NULL, N'sdfsd', N'lkj', N'lkjlkj', N'lkjlk', N'987987987987', CAST(N'2025-02-07T01:57:11.4051526' AS DateTime2), N'ken.holtgrewe@gmail.com', CAST(N'2025-02-07T01:57:11.4051588' AS DateTime2), N'ken.holtgrewe@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectNotes] ON 
GO
INSERT [dbo].[ProjectNotes] ([Id], [ProjectId], [Timestamp], [Note]) VALUES (4, 5, CAST(N'2025-02-10T00:53:33.5420000' AS DateTime2), N'This was a great project!')
GO
INSERT [dbo].[ProjectNotes] ([Id], [ProjectId], [Timestamp], [Note]) VALUES (5, 5, CAST(N'2025-02-10T00:57:44.6680000' AS DateTime2), N'Betty Botter bought some butter.')
GO
INSERT [dbo].[ProjectNotes] ([Id], [ProjectId], [Timestamp], [Note]) VALUES (6, 5, CAST(N'2025-02-10T00:58:04.7070000' AS DateTime2), N'Ned Nott was shot, and Sam Shott was not. So it''s better to be Shott than Nott.')
GO
INSERT [dbo].[ProjectNotes] ([Id], [ProjectId], [Timestamp], [Note]) VALUES (7, 4, CAST(N'2025-02-11T00:10:30.6730000' AS DateTime2), N'Ned! Ned Ryerson?!')
GO
INSERT [dbo].[ProjectNotes] ([Id], [ProjectId], [Timestamp], [Note]) VALUES (8, 4, CAST(N'2025-02-11T00:40:52.6380000' AS DateTime2), N'Ned sells insurance.')
GO
SET IDENTITY_INSERT [dbo].[ProjectNotes] OFF
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 
GO
INSERT [dbo].[Projects] ([Id], [Name], [ClientId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [StartDate], [EstimatedCompletionDate], [Status], [Budget], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1, N'Test Project 1', 1, N'sdfsd', N'fghfghfgh', N'Houston', N'TX', N'77070', NULL, NULL, 1, CAST(400000.000000 AS Decimal(18, 6)), CAST(N'2025-02-07T01:23:39.6409501' AS DateTime2), N'ken.holtgrewe@gmail.com', CAST(N'2025-02-10T00:43:37.4849159' AS DateTime2), N'ken.holtgrewe@gmail.com')
GO
INSERT [dbo].[Projects] ([Id], [Name], [ClientId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [StartDate], [EstimatedCompletionDate], [Status], [Budget], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (3, N'Tatooine Development', 4, N'234234', N'34534', N'45645', N'56765', N'567567', CAST(N'2025-02-20T00:00:00.0000000' AS DateTime2), CAST(N'2025-10-23T00:00:00.0000000' AS DateTime2), 0, CAST(2500000.000000 AS Decimal(18, 6)), CAST(N'2025-02-07T02:01:31.8363626' AS DateTime2), N'ken.holtgrewe@gmail.com', CAST(N'2025-02-07T02:01:31.8363677' AS DateTime2), N'ken.holtgrewe@gmail.com')
GO
INSERT [dbo].[Projects] ([Id], [Name], [ClientId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [StartDate], [EstimatedCompletionDate], [Status], [Budget], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (4, N'Test Project 2', 2, N'dfgdfgfg', N'fghfgh', N'Knoxville', N'TN', N'234234', NULL, NULL, 1, CAST(750000.000000 AS Decimal(18, 6)), CAST(N'2025-02-10T00:47:11.7895513' AS DateTime2), N'ken.holtgrewe@gmail.com', CAST(N'2025-02-11T00:32:55.5505235' AS DateTime2), N'ken.holtgrewe@gmail.com')
GO
INSERT [dbo].[Projects] ([Id], [Name], [ClientId], [AddressLine1], [AddressLine2], [City], [State], [PostalCode], [StartDate], [EstimatedCompletionDate], [Status], [Budget], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (5, N'Test Project 3', 1, NULL, NULL, NULL, NULL, NULL, CAST(N'2024-01-13T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-13T00:00:00.0000000' AS DateTime2), 2, CAST(845000.000000 AS Decimal(18, 6)), CAST(N'2025-02-10T00:53:20.2501988' AS DateTime2), N'ken.holtgrewe@gmail.com', CAST(N'2025-02-10T00:53:20.2502044' AS DateTime2), N'ken.holtgrewe@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImageUploads_ProjectId]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_ImageUploads_ProjectId] ON [dbo].[ImageUploads]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjectNotes_ProjectId]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProjectNotes_ProjectId] ON [dbo].[ProjectNotes]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Projects_ClientId]    Script Date: 2/11/2025 12:49:24 AM ******/
CREATE NONCLUSTERED INDEX [IX_Projects_ClientId] ON [dbo].[Projects]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ImageUploads]  WITH CHECK ADD  CONSTRAINT [FK_ImageUploads_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageUploads] CHECK CONSTRAINT [FK_ImageUploads_Projects_ProjectId]
GO
ALTER TABLE [dbo].[ProjectNotes]  WITH CHECK ADD  CONSTRAINT [FK_ProjectNotes_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjectNotes] CHECK CONSTRAINT [FK_ProjectNotes_Projects_ProjectId]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Clients_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [FK_Projects_Clients_ClientId]
GO
USE [master]
GO
ALTER DATABASE [DesignTechHomesTest] SET  READ_WRITE 
GO
