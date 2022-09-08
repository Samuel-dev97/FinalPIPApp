USE [master]
GO
/****** Object:  Database [LoftERP.PIP]    Script Date: 5/4/2022 8:54:00 PM ******/
CREATE DATABASE [LoftERP.PIP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LoftERP.PIP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LoftERP.PIP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LoftERP.PIP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LoftERP.PIP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LoftERP.PIP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LoftERP.PIP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET ARITHABORT OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LoftERP.PIP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LoftERP.PIP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LoftERP.PIP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LoftERP.PIP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LoftERP.PIP] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LoftERP.PIP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LoftERP.PIP] SET  MULTI_USER 
GO
ALTER DATABASE [LoftERP.PIP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LoftERP.PIP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LoftERP.PIP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LoftERP.PIP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LoftERP.PIP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LoftERP.PIP] SET QUERY_STORE = OFF
GO
USE [LoftERP.PIP]
GO
/****** Object:  Schema [Identity]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE SCHEMA [Identity]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/4/2022 8:54:01 PM ******/
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
/****** Object:  Table [dbo].[DepartmentBudgets]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentBudgets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[BudgetAmount] [decimal](18, 2) NOT NULL,
	[ActualBudgetAmount] [decimal](18, 2) NOT NULL,
	[Q1] [decimal](18, 2) NOT NULL,
	[Q2] [decimal](18, 2) NOT NULL,
	[Q3] [decimal](18, 2) NOT NULL,
	[Q4] [decimal](18, 2) NOT NULL,
	[PercentegaScore] [int] NOT NULL,
	[Year] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsCurrent] [bit] NOT NULL,
 CONSTRAINT [PK_DepartmentBudgets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Specification] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeIncentiveMonthlies]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeIncentiveMonthlies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExpectedPIPPayable] [decimal](18, 2) NOT NULL,
	[ActualPIPPayable] [decimal](18, 2) NOT NULL,
	[MDPenalty] [decimal](18, 2) NOT NULL,
	[PercentageScore] [int] NOT NULL,
	[Month] [date] NULL,
	[EmployeeId] [int] NOT NULL,
	[DepartmentId] [int] NULL,
	[FirstAuthorizer] [nvarchar](max) NULL,
	[SecondAuthorizer] [nvarchar](max) NULL,
	[ThirdAuthorizer] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_EmployeeIncentiveMonthlies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeIncentives]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeIncentives](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TotalIncentivePayTarget] [decimal](18, 2) NOT NULL,
	[TotalPayableYearEnd] [decimal](18, 2) NOT NULL,
	[TotalMonthlyPIP] [decimal](18, 2) NOT NULL,
	[PIPPayableMonthly] [decimal](18, 2) NOT NULL,
	[IsCurrent] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[EmployeeId] [int] NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_EmployeeIncentives] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentStatus] [int] NOT NULL,
	[EmploymentStatusId] [int] NOT NULL,
	[City] [nvarchar](max) NULL,
	[Nationality] [nvarchar](max) NULL,
	[NAPSA] [nvarchar](max) NULL,
	[MaritalStatus] [int] NOT NULL,
	[TerminationDate] [datetime2](7) NOT NULL,
	[ConfirmationDate] [datetime2](7) NOT NULL,
	[JoinedDate] [datetime2](7) NOT NULL,
	[PrivateEmail] [nvarchar](max) NULL,
	[WorkEmail] [nvarchar](max) NULL,
	[MobilePhone] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[MiddleName] [nvarchar](max) NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Gender] [int] NOT NULL,
	[BasicPay] [decimal](18, 2) NOT NULL,
	[DepartmentId] [int] NULL,
	[PayGradeId] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayGrades]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayGrades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[MaxSalary] [decimal](18, 2) NOT NULL,
	[MinSalary] [decimal](18, 2) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_PayGrades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Identity].[Role]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Identity].[Role](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Identity].[RoleClaims]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Identity].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Identity].[User]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Identity].[User](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[LastModifiedOn] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedOn] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[RefreshTokenExpiryTime] [datetime2](7) NOT NULL,
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
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Identity].[UserClaims]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Identity].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Identity].[UserLogins]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Identity].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [Identity].[UserRoles]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Identity].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Identity].[UserTokens]    Script Date: 5/4/2022 8:54:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Identity].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentBudgets_DepartmentId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentBudgets_DepartmentId] ON [dbo].[DepartmentBudgets]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeIncentiveMonthlies_DepartmentId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeIncentiveMonthlies_DepartmentId] ON [dbo].[EmployeeIncentiveMonthlies]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeIncentiveMonthlies_EmployeeId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeIncentiveMonthlies_EmployeeId] ON [dbo].[EmployeeIncentiveMonthlies]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_EmployeeIncentives_EmployeeId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeIncentives_EmployeeId] ON [dbo].[EmployeeIncentives]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_DepartmentId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_DepartmentId] ON [dbo].[Employees]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employees_PayGradeId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Employees_PayGradeId] ON [dbo].[Employees]
(
	[PayGradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [Identity].[Role]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [Identity].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [Identity].[User]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [Identity].[User]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [Identity].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [Identity].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 5/4/2022 8:54:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [Identity].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DepartmentBudgets]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentBudgets_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DepartmentBudgets] CHECK CONSTRAINT [FK_DepartmentBudgets_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[EmployeeIncentiveMonthlies]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeIncentiveMonthlies_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[EmployeeIncentiveMonthlies] CHECK CONSTRAINT [FK_EmployeeIncentiveMonthlies_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[EmployeeIncentiveMonthlies]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeIncentiveMonthlies_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EmployeeIncentiveMonthlies] CHECK CONSTRAINT [FK_EmployeeIncentiveMonthlies_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[EmployeeIncentives]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeIncentives_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeeIncentives] CHECK CONSTRAINT [FK_EmployeeIncentives_Employees_EmployeeId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments_DepartmentId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_PayGrades_PayGradeId] FOREIGN KEY([PayGradeId])
REFERENCES [dbo].[PayGrades] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_PayGrades_PayGradeId]
GO
ALTER TABLE [Identity].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [Identity].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Identity].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Role_RoleId]
GO
ALTER TABLE [Identity].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_User_UserId] FOREIGN KEY([UserId])
REFERENCES [Identity].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Identity].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_User_UserId]
GO
ALTER TABLE [Identity].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_User_UserId] FOREIGN KEY([UserId])
REFERENCES [Identity].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Identity].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_User_UserId]
GO
ALTER TABLE [Identity].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [Identity].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Identity].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Role_RoleId]
GO
ALTER TABLE [Identity].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_User_UserId] FOREIGN KEY([UserId])
REFERENCES [Identity].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Identity].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_User_UserId]
GO
ALTER TABLE [Identity].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_User_UserId] FOREIGN KEY([UserId])
REFERENCES [Identity].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Identity].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_User_UserId]
GO
USE [master]
GO
ALTER DATABASE [LoftERP.PIP] SET  READ_WRITE 
GO
