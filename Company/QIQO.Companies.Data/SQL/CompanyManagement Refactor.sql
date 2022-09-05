USE [master]
GO
--DROP DATABASE [CompanyManagement] 
--GO

/****** Object:  Database [CompanyManagement]    Script Date: 7/10/2022 12:46:10 PM ******/
CREATE DATABASE [CompanyManagement]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'AccountManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.D1\MSSQL\DATA\AccountManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'AccountManagement_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.D1\MSSQL\DATA\AccountManagement_Log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
-- WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CompanyManagement] SET COMPATIBILITY_LEVEL = 150
GO

ALTER DATABASE [CompanyManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompanyManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompanyManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompanyManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompanyManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompanyManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompanyManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompanyManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompanyManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompanyManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompanyManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompanyManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompanyManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompanyManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompanyManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CompanyManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompanyManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompanyManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompanyManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompanyManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompanyManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CompanyManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompanyManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [CompanyManagement] SET  MULTI_USER 
GO
ALTER DATABASE [CompanyManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompanyManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompanyManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompanyManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompanyManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CompanyManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'AccountManagement', N'ON'
GO
ALTER DATABASE [CompanyManagement] SET QUERY_STORE = OFF
GO
USE [CompanyManagement]
GO
/****** Object:  User [businessuser]    Script Date: 7/10/2022 12:46:10 PM ******/
CREATE USER [businessuser] FOR LOGIN [businessuser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [businessuser]
GO
ALTER ROLE [db_datareader] ADD MEMBER [businessuser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [businessuser]
GO
GRANT CONNECT TO [businessuser] AS [dbo]
GO
GRANT VIEW ANY COLUMN ENCRYPTION KEY DEFINITION TO [public] AS [dbo]
GO
GRANT VIEW ANY COLUMN MASTER KEY DEFINITION TO [public] AS [dbo]
GO

/****** Object:  Table [dbo].[Account]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountKey] [int] IDENTITY(1,1) NOT NULL,
	[CompanyKey] [int] NOT NULL,
	[AccountTypeKey] [int] NOT NULL,
	[AccountCode] [varchar](30) NOT NULL,
	[AccountName] [varchar](150) NOT NULL,
	[AccountDescription] [varchar](254) NOT NULL,
	[AccountDba] [varchar](150) NULL,
	[AccountStartDate] [datetime] NOT NULL,
	[AccountEndDate] [datetime] NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__Account__] PRIMARY KEY CLUSTERED 
(
	[AccountKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[AccountTypeKey] [int] IDENTITY(1,1) NOT NULL,
	[AccountTypeCode] [varchar](10) NOT NULL,
	[AccountTypeName] [varchar](50) NOT NULL,
	[AccountTypeDescription] [varchar](254) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressKey] [int] IDENTITY(1,1) NOT NULL,
	[AddressTypeKey] [int] NOT NULL,
	[EntityKey] [int] NOT NULL,
	[EntityTypeKey] [int] NOT NULL,
	[AddressLine1] [varchar](75) NOT NULL,
	[AddressLine2] [varchar](75) NULL,
	[AddressLine3] [varchar](75) NULL,
	[AddressLine4] [varchar](75) NULL,
	[AddressCity] [varchar](75) NOT NULL,
	[AddressState] [varchar](5) NOT NULL,
	[AddressCounty] [varchar](50) NOT NULL,
	[AddressCountry] [varchar](50) NOT NULL,
	[AddressPostalCode] [varchar](20) NOT NULL,
	[AddressNotes] [varchar](150) NULL,
	[AddressDefault] [bit] NOT NULL,
	[AddressActive] [bit] NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__Address__] PRIMARY KEY CLUSTERED 
(
	[AddressKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressPostal]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressPostal](
	[Country] [varchar](50) NOT NULL,
	[PostalCode] [varchar](20) NULL,
	[StateCode] [varchar](2) NULL,
	[StateFullName] [varchar](30) NULL,
	[CityName] [varchar](27) NULL,
	[CountyName] [varchar](50) NULL,
	[TimeZone] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [ClusteredIndex-20150809-131423]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE UNIQUE CLUSTERED INDEX [ucx_AddressPortal_All] ON [dbo].[AddressPostal]
(
	[Country] ASC,
	[PostalCode] ASC,
	[StateCode] ASC,
	[StateFullName] ASC,
	[CityName] ASC,
	[CountyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressType]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AddressType](
	[AddressTypeKey] [int] IDENTITY(1,1) NOT NULL,
	[AddressTypeCode] [varchar](10) NOT NULL,
	[AddressTypeName] [varchar](50) NOT NULL,
	[AddressTypeDescription] [varchar](150) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__AddressType__] PRIMARY KEY CLUSTERED 
(
	[AddressTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attribute]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attribute](
	[AttributeKey] [int] IDENTITY(1,1) NOT NULL,
	[EntityKey] [int] NOT NULL,
	[EntityTypeKey] [int] NOT NULL,
	[AttributeTypeKey] [int] NOT NULL,
	[AttributeValue] [varchar](max) NOT NULL,
	[AttributeDataTypeKey] [int] NOT NULL,
	[AttributeDisplayFormat] [varchar](50) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__Attribute__] PRIMARY KEY CLUSTERED 
(
	[AttributeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttributeType]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttributeType](
	[AttributeTypeKey] [int] IDENTITY(1,1) NOT NULL,
	[AttributeTypeCategory] [varchar](50) NOT NULL,
	[AttributeTypeCode] [varchar](10) NOT NULL,
	[AttributeTypeName] [varchar](50) NOT NULL,
	[AttributeTypeDescription] [varchar](150) NOT NULL,
	[AttributeDataTypeKey] [int] NOT NULL,
	[AttributeDefaultFormat] [varchar](150) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__AttributeType__] PRIMARY KEY CLUSTERED 
(
	[AttributeTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChangeDataAuditLog]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeDataAuditLog](
	[LogKey] [bigint] IDENTITY(1,1) NOT NULL,
	[Action] [char](1) NOT NULL,
	[BusinessObject] [varchar](30) NOT NULL,
	[AuditDateTime] [datetime] NOT NULL,
	[UserId] [varchar](30) NOT NULL,
	[Application] [varchar](150) NOT NULL,
	[Host] [varchar](128) NOT NULL,
	[Comment] [varchar](512) NULL,
	[DataOld] [xml] NULL,
	[DataNew] [xml] NULL,
PRIMARY KEY CLUSTERED 
(
	[LogKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentKey] [int] IDENTITY(1,1) NOT NULL,
	[EntityKey] [int] NOT NULL,
	[EntityType] [int] NOT NULL,
	[CommentTypeKey] [int] NOT NULL,
	[CommentValue] [varchar](max) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommentType]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentType](
	[CommentTypeKey] [int] IDENTITY(1,1) NOT NULL,
	[CommentTypeCategory] [varchar](50) NOT NULL,
	[CommentTypeCode] [varchar](10) NOT NULL,
	[CommentTypeName] [varchar](50) NOT NULL,
	[CommentTypeDescription] [varchar](150) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyKey] [int] IDENTITY(1,1) NOT NULL,
	[CompanyCode] [varchar](10) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[CompanyDescription] [varchar](255) NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__Company__] PRIMARY KEY CLUSTERED 
(
	[CompanyKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactKey] [int] IDENTITY(1,1) NOT NULL,
	[EntityKey] [int] NOT NULL,
	[EntityTypeKey] [int] NOT NULL,
	[ContactTypeKey] [int] NOT NULL,
	[ContactValue] [varchar](150) NOT NULL,
	[ContactDefault] [bit] NOT NULL,
	[ContactActive] [bit] NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__Contact__] PRIMARY KEY CLUSTERED 
(
	[ContactKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactType]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactType](
	[ContactTypeKey] [int] IDENTITY(1,1) NOT NULL,
	[ContactTypeCategory] [varchar](50) NOT NULL,
	[ContactTypeCode] [varchar](10) NOT NULL,
	[ContactTypeName] [varchar](50) NOT NULL,
	[ContactTypeDescription] [varchar](150) NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__ContactType__] PRIMARY KEY CLUSTERED 
(
	[ContactTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntityEntity]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntityEntity](
	[EntityEntityKey] [int] IDENTITY(1,1) NOT NULL,
	[PrimaryEntityKey] [int] NOT NULL,
	[PrimaryEntityTypeKey] [int] NOT NULL,
	[PrimaryEntityRoleKey] [int] NOT NULL,
	[SecondaryEntityKey] [int] NOT NULL,
	[SecondaryEntityTypeKey] [int] NOT NULL,
	[SecondaryEntityRoleKey] [int] NOT NULL,
	[EntityEntitySequence] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Comment] [varchar](150) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK_EntityEntityEntityEntityKey] PRIMARY KEY NONCLUSTERED 
(
	[EntityEntityKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20150701-155340]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE UNIQUE CLUSTERED INDEX [ucx_EntityEntity__] ON [dbo].[EntityEntity]
(
	[PrimaryEntityKey] ASC,
	[PrimaryEntityTypeKey] ASC,
	[PrimaryEntityRoleKey] ASC,
	[SecondaryEntityKey] ASC,
	[SecondaryEntityTypeKey] ASC,
	[SecondaryEntityRoleKey] ASC,
	[EntityEntitySequence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntityRole]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntityRole](
	[EntityRoleKey] [int] IDENTITY(1,1) NOT NULL,
	[EntityRoleCode] [varchar](10) NOT NULL,
	[EntityRoleName] [varchar](50) NOT NULL,
	[EntityRoleDescription] [varchar](254) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EntityRoleKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntityType]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntityType](
	[EntityTypeKey] [int] IDENTITY(1,1) NOT NULL,
	[EntityTypeCode] [varchar](10) NOT NULL,
	[EntityTypeName] [varchar](50) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PKEntityType] PRIMARY KEY CLUSTERED 
(
	[EntityTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorKey] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorNumber] [int] NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorProcedure] [nvarchar](128) NULL,
	[ErrorLine] [int] NULL,
	[ErrorMessage] [nvarchar](4000) NULL,
	[TableName] [nvarchar](128) NULL,
	[ProcedureName] [nvarchar](128) NULL,
	[ErrorDateTime] [datetime] NOT NULL,
	[ProcedureStep] [nchar](1) NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
--/****** Object:  Table [dbo].[FeeSchedule]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[FeeSchedule](
--	[FeeScheduleKey] [int] IDENTITY(1,1) NOT NULL,
--	[CompanyKey] [int] NOT NULL,
--	[AccountKey] [int] NOT NULL,
--	[ProductKey] [int] NOT NULL,
--	[FeeScheduleStartDate] [datetime] NOT NULL,
--	[FeeScheduleEndDate] [datetime] NOT NULL,
--	[FeeScheduleType] [char](1) NOT NULL,
--	[FeeScheduleValue] [numeric](10, 5) NOT NULL,
--	[AuditAddUserId] [varchar](30) NOT NULL,
--	[AuditAddDatetime] [datetime] NOT NULL,
--	[AuditUpdateUserId] [varchar](30) NOT NULL,
--	[AuditUpdateDatetime] [datetime] NOT NULL,
-- CONSTRAINT [PK__FeeSchedule__] PRIMARY KEY CLUSTERED 
--(
--	[FeeScheduleKey] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]
--GO
/****** Object:  Table [dbo].[Person]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonKey] [int] IDENTITY(1,1) NOT NULL,
	[PersonCode] [varchar](50) NOT NULL,
	[PersonFirstName] [varchar](50) NOT NULL,
	[PersonMiddleInitial] [char](1) NULL,
	[PersonLastName] [varchar](50) NOT NULL,
	[ParentPersonKey] [int] NULL,
	[PersonDob] [date] NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__Person__] PRIMARY KEY CLUSTERED 
(
	[PersonKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonType]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonType](
	[PersonTypeKey] [int] IDENTITY(1,1) NOT NULL,
	[PersonTypeCategory] [varchar](50) NOT NULL,
	[PersonTypeCode] [varchar](10) NOT NULL,
	[PersonTypeName] [varchar](50) NOT NULL,
	[PersonTypeDescription] [varchar](150) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PersonTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Ledger]    Script Date: 9/3/2022 9:56:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ledger](
	[LedgerKey] [int] IDENTITY(1,1) NOT NULL,
	[CompanyKey] [int] NOT NULL,
	[LedgerCode] [varchar](10) NOT NULL,
	[LedgerName] [varchar](50) NOT NULL,
	[LedgerDescription] [varchar](255) NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDateTime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK____5BB881F849F1E255] PRIMARY KEY CLUSTERED 
(
	[LedgerKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LedgerTxn]    Script Date: 9/3/2022 9:56:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedgerTxn](
	[LedgerTxnKey] [bigint] IDENTITY(1,1) NOT NULL,
	[LedgerKey] [int] NOT NULL,
	[TxnComment] [varchar](50) NOT NULL,
	[AccountFrom] [varchar](10) NOT NULL,
	[DepartmentFrom] [varchar](10) NULL,
	[LineOfBusinessFrom] [varchar](10) NULL,
	[AccountTo] [varchar](10) NOT NULL,
	[DepartmentTo] [varchar](10) NULL,
	[LineOfBusinessTo] [varchar](10) NULL,
	[TxnNumber] [int] NOT NULL,
	[PostDate] [datetime] NULL,
	[EntryDate] [datetime] NOT NULL,
	[Credit] [money] NOT NULL,
	[Debit] [money] NOT NULL,
	[EntityKey] [int] NOT NULL,
	[EntityTypeKey] [int] NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDateTime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK____5E981A79B1CA4153] PRIMARY KEY CLUSTERED 
(
	[LedgerTxnKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

--/****** Object:  Table [dbo].[Product]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[Product](
--	[ProductKey] [int] IDENTITY(1,1) NOT NULL,
--	[ProductTypeKey] [int] NOT NULL,
--	[ProductCode] [varchar](20) NOT NULL,
--	[ProductName] [varchar](150) NOT NULL,
--	[ProductDescription] [varchar](255) NULL,
--	[ProductName_short] [varchar](50) NOT NULL,
--	[ProductName_long] [varchar](255) NOT NULL,
--	[ProductImagePath] [varchar](255) NOT NULL,
--	[AuditAddUserId] [varchar](30) NOT NULL,
--	[AuditAddDatetime] [datetime] NOT NULL,
--	[AuditUpdateUserId] [varchar](30) NOT NULL,
--	[AuditUpdateDatetime] [datetime] NOT NULL,
-- CONSTRAINT [PK__Product__] PRIMARY KEY CLUSTERED 
--(
--	[ProductKey] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--/****** Object:  Table [dbo].[ProductType]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE TABLE [dbo].[ProductType](
--	[ProductTypeKey] [int] IDENTITY(1,1) NOT NULL,
--	[ProductTypeCategory] [varchar](50) NOT NULL,
--	[ProductTypeCode] [varchar](10) NOT NULL,
--	[ProductTypeName] [varchar](50) NOT NULL,
--	[ProductTypeDescription] [varchar](150) NOT NULL,
--	[AuditAddUserId] [varchar](30) NOT NULL,
--	[AuditAddDatetime] [datetime] NOT NULL,
--	[AuditUpdateUserId] [varchar](30) NOT NULL,
--	[AuditUpdateDatetime] [datetime] NOT NULL,
-- CONSTRAINT [PK__ProductType__] PRIMARY KEY CLUSTERED 
--(
--	[ProductTypeKey] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]
--GO
/****** Object:  Index [IX_Account]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE NONCLUSTERED INDEX [IX_Account] ON [dbo].[Account]
(
	[AccountKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20150705-105816]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20150705-105816] ON [dbo].[Account]
(
	[CompanyKey] ASC,
	[AccountCode] ASC,
	[AccountName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20150704-190917]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20150704-190917] ON [dbo].[AccountType]
(
	[AccountTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex-20150705-105452]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20150705-105452] ON [dbo].[Address]
(
	[AddressTypeKey] ASC,
	[EntityKey] ASC,
	[EntityTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [ui_AttributeEntityKeyEntityTypeKey_AttributeTypeKey]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [ui_AttributeEntityKeyEntityTypeKey_AttributeTypeKey] ON [dbo].[Attribute]
(
	[EntityKey] ASC,
	[EntityTypeKey] ASC,
	[AttributeTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20150721-150027]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20150721-150027] ON [dbo].[AttributeType]
(
	[AttributeTypeCategory] ASC,
	[AttributeTypeCode] ASC,
	[AttributeTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20150705-155746]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20150705-155746] ON [dbo].[ChangeDataAuditLog]
(
	[BusinessObject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex-20150704-170821]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20150704-170821] ON [dbo].[CommentType]
(
	[CommentTypeCategory] ASC,
	[CommentTypeCode] ASC,
	[CommentTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [idxEntityRoleEntityRoleCode]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE NONCLUSTERED INDEX [idxEntityRoleEntityRoleCode] ON [dbo].[EntityRole]
(
	[EntityRoleCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IXEntityType]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE NONCLUSTERED INDEX [IXEntityType] ON [dbo].[EntityType]
(
	[EntityTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
--/****** Object:  Index [ui_FeeSchedule_multiKey]    Script Date: 7/10/2022 12:46:11 PM ******/
--CREATE UNIQUE NONCLUSTERED INDEX [ui_FeeSchedule_multiKey] ON [dbo].[FeeSchedule]
--(
--	[CompanyKey] ASC,
--	[AccountKey] ASC,
--	[ProductKey] ASC,
--	[FeeScheduleStartDate] ASC
--)
--INCLUDE([FeeScheduleType],[FeeScheduleValue]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--GO
--SET ANSI_PADDING ON
--GO
--/****** Object:  Index [NonClusteredIndex-20150801-131647]    Script Date: 7/10/2022 12:46:11 PM ******/
--CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20150801-131647] ON [dbo].[Product]
--(
--	[ProductTypeKey] ASC,
--	[ProductCode] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--GO
--ALTER TABLE [dbo].[Account] ADD  DEFAULT (NEXT VALUE FOR [AccountKeySequence]) FOR [AccountKey]
--GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF__Account_Audita__6B24EA82]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF__Account_Audita__6C190EBB]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF__Account_Auditu__6D0D32F4]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF__Account_Auditu__6E01572D]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[AccountType] ADD  DEFAULT (NEXT VALUE FOR [AccountTypeKeySequence]) FOR [AccountTypeKey]
--GO
ALTER TABLE [dbo].[AccountType] ADD  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[AccountType] ADD  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[AccountType] ADD  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[AccountType] ADD  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[Address] ADD  DEFAULT (NEXT VALUE FOR [AddressKeySequence]) FOR [AddressKey]
--GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_AddressDefault]  DEFAULT ((0)) FOR [AddressDefault]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_AddressActive]  DEFAULT ((1)) FOR [AddressActive]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF__Address_Audita__4316F928]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF__Address_Audita__440B1D61]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF__Address_Auditu__44FF419A]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF__Address_Auditu__45F365D3]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[AddressType] ADD  CONSTRAINT [DF__Address_t__addre__45F365D3]  DEFAULT (NEXT VALUE FOR [AddressTypeKeySequence]) FOR [AddressTypeKey]
--GO
ALTER TABLE [dbo].[AddressType] ADD  CONSTRAINT [DF__Address_t_Audit_3C69FB99]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[AddressType] ADD  CONSTRAINT [DF__Address_t_Audit_3D5E1FD2]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[AddressType] ADD  CONSTRAINT [DF__Address_t_Audit_3E52440B]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[AddressType] ADD  CONSTRAINT [DF__Address_t_Audit_3F466844]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[Attribute] ADD  DEFAULT (NEXT VALUE FOR [AttributeKeySequence]) FOR [AttributeKey]
--GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF__Attribute_Audit_49C3F6B7]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF__Attribute_Audit_4AB81AF0]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF__Attribute_Audit_4BAC3F29]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[Attribute] ADD  CONSTRAINT [DF__Attribute_Audit_4CA06362]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[AttributeType] ADD  CONSTRAINT [DF__Attribute__attri__534D60F1]  DEFAULT (NEXT VALUE FOR [AttributeTypeKeySequence]) FOR [AttributeTypeKey]
--GO
ALTER TABLE [dbo].[AttributeType] ADD  CONSTRAINT [DF_AttributeType_AttributeDataTypeKey]  DEFAULT ((2)) FOR [AttributeDataTypeKey]
GO
ALTER TABLE [dbo].[AttributeType] ADD  CONSTRAINT [DF_AttributeType_AttributeDefaultFormat]  DEFAULT ('') FOR [AttributeDefaultFormat]
GO
ALTER TABLE [dbo].[AttributeType] ADD  CONSTRAINT [DF__Attribute_Audit_33D4B598]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[AttributeType] ADD  CONSTRAINT [DF__Attribute_Audit_34C8D9D1]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[AttributeType] ADD  CONSTRAINT [DF__Attribute_Audit_35BCFE0A]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[AttributeType] ADD  CONSTRAINT [DF__Attribute_Audit_36B12243]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  CONSTRAINT [DF_AuditLog_Audit_59FA5E80]  DEFAULT (NEXT VALUE FOR [AuditLogKeySequence]) FOR [LogKey]
--GO
ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (getdate()) FOR [AuditDateTime]
GO
ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (suser_sname()) FOR [UserId]
GO
ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (('App=('+rtrim(isnull(app_name(),'')))+') ') FOR [Application]
GO
ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (host_Name()) FOR [Host]
GO
--ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (suser_sname()) FOR [AuditAddUserId]
--GO
--ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (getdate()) FOR [AuditAddDatetime]
--GO
--ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
--GO
--ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
--GO
--ALTER TABLE [dbo].[Comment] ADD  DEFAULT (NEXT VALUE FOR [CommentKeySequence]) FOR [CommentKey]
--GO
ALTER TABLE [dbo].[Comment] ADD  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[Comment] ADD  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[Comment] ADD  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[Comment] ADD  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[CommentType] ADD  DEFAULT (NEXT VALUE FOR [CommentTypeKeySequence]) FOR [CommentTypeKey]
--GO
ALTER TABLE [dbo].[CommentType] ADD  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[CommentType] ADD  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[CommentType] ADD  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[CommentType] ADD  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[Company] ADD  DEFAULT (NEXT VALUE FOR [CompanyKeySequence]) FOR [CompanyKey]
--GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF__Company_Audita__5070F446]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF__Company_Audita__5165187F]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF__Company_Auditu__52593CB8]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF__Company_Auditu__534D60F1]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[Contact] ADD  DEFAULT (NEXT VALUE FOR [ContactKeySequence]) FOR [ContactKey]
--GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_ContactDefault]  DEFAULT ((0)) FOR [ContactDefault]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_ContactActive]  DEFAULT ((1)) FOR [ContactActive]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF__Contact_Audita__571DF1D5]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF__Contact_Audita__5812160E]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF__Contact_Auditu__59063A47]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF__Contact_Auditu__59FA5E80]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[ContactType] ADD  DEFAULT (NEXT VALUE FOR [ContactTypeKeySequence]) FOR [ContactTypeKey]
--GO
ALTER TABLE [dbo].[ContactType] ADD  CONSTRAINT [DF__Contact_t_Audit_5DCAEF64]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[ContactType] ADD  CONSTRAINT [DF__Contact_t_Audit_5EBF139D]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[ContactType] ADD  CONSTRAINT [DF__Contact_t_Audit_5FB337D6]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[ContactType] ADD  CONSTRAINT [DF__Contact_t_Audit_60A75C0F]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[EntityEntity] ADD  CONSTRAINT [DF_Entity_en__entit__0E6E26BF]  DEFAULT (NEXT VALUE FOR [EntityEntityKeySequence]) FOR [EntityEntityKey]
--GO
ALTER TABLE [dbo].[EntityEntity] ADD  CONSTRAINT [DFEntityEntityEntityEntitySequence]  DEFAULT ((1)) FOR [EntityEntitySequence]
GO
ALTER TABLE [dbo].[EntityEntity] ADD  CONSTRAINT [DFEntityEntityStartDate]  DEFAULT (getdate()) FOR [StartDate]
GO
ALTER TABLE [dbo].[EntityEntity] ADD  CONSTRAINT [DFEntityEntityEndDate]  DEFAULT (dateadd(year,(25),getdate())) FOR [EndDate]
GO
ALTER TABLE [dbo].[EntityEntity] ADD  CONSTRAINT [DF_Entity_en_Audit_7FEAFD3E]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[EntityEntity] ADD  CONSTRAINT [DF_Entity_en_Audit_00DF2177]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[EntityEntity] ADD  CONSTRAINT [DF_Entity_en_Audit_01D345B0]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[EntityEntity] ADD  CONSTRAINT [DF_Entity_en_Audit_02C769E9]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[EntityRole] ADD  DEFAULT (NEXT VALUE FOR [EntityRoleKeySequence]) FOR [EntityRoleKey]
--GO
ALTER TABLE [dbo].[EntityRole] ADD  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[EntityRole] ADD  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[EntityRole] ADD  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[EntityRole] ADD  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[EntityType] ADD  DEFAULT (NEXT VALUE FOR [EntityTypeKeySequence]) FOR [EntityTypeKey]
--GO
ALTER TABLE [dbo].[EntityType] ADD  CONSTRAINT [DF_Entity_ty_Audit_737017C0]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[EntityType] ADD  CONSTRAINT [DF_Entity_ty_Audit_74643BF9]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[EntityType] ADD  CONSTRAINT [DF_Entity_ty_Audit_75586032]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[EntityType] ADD  CONSTRAINT [DF_Entity_ty_Audit_764C846B]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[ErrorLog] ADD  DEFAULT (NEXT VALUE FOR [ErrorLogKeySequence]) FOR [ErrorKey]
--GO
ALTER TABLE [dbo].[ErrorLog] ADD  CONSTRAINT [DF_ErrorLog_ErrorDateTime]  DEFAULT (getdate()) FOR [ErrorDateTime]
GO
--ALTER TABLE [dbo].[FeeSchedule] ADD  DEFAULT (NEXT VALUE FOR [FeeScheduleKeySequence]) FOR [FeeScheduleKey]
--GO
--ALTER TABLE [dbo].[FeeSchedule] ADD  CONSTRAINT [DF__fee_sched_Audit_58520D30]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
--GO
--ALTER TABLE [dbo].[FeeSchedule] ADD  CONSTRAINT [DF__fee_sched_Audit_59463169]  DEFAULT (getdate()) FOR [AuditAddDatetime]
--GO
--ALTER TABLE [dbo].[FeeSchedule] ADD  CONSTRAINT [DF__fee_sched_Audit_5A3A55A2]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
--GO
--ALTER TABLE [dbo].[FeeSchedule] ADD  CONSTRAINT [DF__fee_sched_Audit_5B2E79DB]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
--GO
--ALTER TABLE [dbo].[Person] ADD  DEFAULT (NEXT VALUE FOR [PersonKeySequence]) FOR [PersonKey]
--GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF__Person_Auditad__056ECC6A]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF__Person_Auditad__0662F0A3]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF__Person_Auditup__075714DC]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [DF__Person_Auditup__084B3915]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[PersonType] ADD  DEFAULT (NEXT VALUE FOR [PersonTypeKeySequence]) FOR [PersonTypeKey]
--GO
ALTER TABLE [dbo].[PersonType] ADD  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[PersonType] ADD  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[PersonType] ADD  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[PersonType] ADD  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO
--ALTER TABLE [dbo].[Product] ADD  DEFAULT (NEXT VALUE FOR [ProductKeySequence]) FOR [ProductKey]
--GO
--ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product_Audita__7F2BE32F]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
--GO
--ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product_Audita__00200768]  DEFAULT (getdate()) FOR [AuditAddDatetime]
--GO
--ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product_Auditu__01142BA1]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
--GO
--ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product_Auditu__02084FDA]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
--GO
----ALTER TABLE [dbo].[ProductType] ADD  DEFAULT (NEXT VALUE FOR [ProductTypeKeySequence]) FOR [ProductTypeKey]
----GO
--ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF__Product_t_Audit_787EE5A0]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
--GO
--ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF__Product_t_Audit_797309D9]  DEFAULT (getdate()) FOR [AuditAddDatetime]
--GO
--ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF__Product_t_Audit_7A672E12]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
--GO
--ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF__Product_t_Audit_7B5B524B]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
--GO


--ALTER TABLE [dbo].[Ledger] ADD  DEFAULT (NEXT VALUE FOR [LedgerKey_seq]) FOR [LedgerKey]
--GO
ALTER TABLE [dbo].[Ledger] ADD  CONSTRAINT [DF__l_Audit__208CD6FA]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[Ledger] ADD  CONSTRAINT [DF__l_Audit__2180FB33]  DEFAULT (getdate()) FOR [AuditAddDateTime]
GO
ALTER TABLE [dbo].[Ledger] ADD  CONSTRAINT [DF__l_Audit__22751F6C]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[Ledger] ADD  CONSTRAINT [DF__l_Audit__236943A5]  DEFAULT (getdate()) FOR [AuditUpdateDateTime]
GO
--ALTER TABLE [dbo].[LedgerTxn] ADD  CONSTRAINT [DF__l__gener__3493CFA7]  DEFAULT (NEXT VALUE FOR [LedgerTxnKey_seq]) FOR [LedgerTxnKey]
--GO
ALTER TABLE [dbo].[LedgerTxn] ADD  CONSTRAINT [DF_LedgerTxn_EntityKey]  DEFAULT ((0)) FOR [EntityKey]
GO
ALTER TABLE [dbo].[LedgerTxn] ADD  CONSTRAINT [DF_LedgerTxn_EntityTypeKey]  DEFAULT ((0)) FOR [EntityTypeKey]
GO
ALTER TABLE [dbo].[LedgerTxn] ADD  CONSTRAINT [DF__l_Audit__2739D489]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[LedgerTxn] ADD  CONSTRAINT [DF__l_Audit__282DF8C2]  DEFAULT (getdate()) FOR [AuditAddDateTime]
GO
ALTER TABLE [dbo].[LedgerTxn] ADD  CONSTRAINT [DF__l_Audit__29221CFB]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[LedgerTxn] ADD  CONSTRAINT [DF__l_Audit__2A164134]  DEFAULT (getdate()) FOR [AuditUpdateDateTime]
GO



ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountType] FOREIGN KEY([AccountTypeKey])
REFERENCES [dbo].[AccountType] ([AccountTypeKey])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountType]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Company] FOREIGN KEY([CompanyKey])
REFERENCES [dbo].[Company] ([CompanyKey])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Company]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_AddressType] FOREIGN KEY([AddressTypeKey])
REFERENCES [dbo].[AddressType] ([AddressTypeKey])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_AddressType]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_AddressEntityType] FOREIGN KEY([EntityTypeKey])
REFERENCES [dbo].[EntityType] ([EntityTypeKey])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_AddressEntityType]
GO
ALTER TABLE [dbo].[Attribute]  WITH CHECK ADD  CONSTRAINT [FK_Attribute_AttributeType] FOREIGN KEY([AttributeTypeKey])
REFERENCES [dbo].[AttributeType] ([AttributeTypeKey])
GO
ALTER TABLE [dbo].[Attribute] CHECK CONSTRAINT [FK_Attribute_AttributeType]
GO
ALTER TABLE [dbo].[Attribute]  WITH CHECK ADD  CONSTRAINT [FK_AttributeEntityType] FOREIGN KEY([EntityTypeKey])
REFERENCES [dbo].[EntityType] ([EntityTypeKey])
GO
ALTER TABLE [dbo].[Attribute] CHECK CONSTRAINT [FK_AttributeEntityType]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_CommentType] FOREIGN KEY([CommentTypeKey])
REFERENCES [dbo].[CommentType] ([CommentTypeKey])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_CommentType]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_ContactType] FOREIGN KEY([ContactTypeKey])
REFERENCES [dbo].[ContactType] ([ContactTypeKey])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_ContactType]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_ContactEntityType] FOREIGN KEY([EntityTypeKey])
REFERENCES [dbo].[EntityType] ([EntityTypeKey])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_ContactEntityType]
GO
ALTER TABLE [dbo].[EntityEntity]  WITH CHECK ADD  CONSTRAINT [FK_PrimaryEntityKeyEntityTypeKey] FOREIGN KEY([PrimaryEntityTypeKey])
REFERENCES [dbo].[EntityType] ([EntityTypeKey])
GO
ALTER TABLE [dbo].[EntityEntity] CHECK CONSTRAINT [FK_PrimaryEntityKeyEntityTypeKey]
GO
ALTER TABLE [dbo].[EntityEntity]  WITH CHECK ADD  CONSTRAINT [FK_PrimaryEntityRoleKeyEntityRoleKey] FOREIGN KEY([PrimaryEntityRoleKey])
REFERENCES [dbo].[EntityRole] ([EntityRoleKey])
GO
ALTER TABLE [dbo].[EntityEntity] CHECK CONSTRAINT [FK_PrimaryEntityRoleKeyEntityRoleKey]
GO
ALTER TABLE [dbo].[EntityEntity]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryEntityKeyEntityTypeKey] FOREIGN KEY([SecondaryEntityTypeKey])
REFERENCES [dbo].[EntityType] ([EntityTypeKey])
GO
ALTER TABLE [dbo].[EntityEntity] CHECK CONSTRAINT [FK_SecondaryEntityKeyEntityTypeKey]
GO
ALTER TABLE [dbo].[EntityEntity]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryEntityRoleKeyEntityRoleKey] FOREIGN KEY([SecondaryEntityRoleKey])
REFERENCES [dbo].[EntityRole] ([EntityRoleKey])
GO
ALTER TABLE [dbo].[EntityEntity] CHECK CONSTRAINT [FK_SecondaryEntityRoleKeyEntityRoleKey]
GO



ALTER TABLE [dbo].[Ledger]  WITH CHECK ADD  CONSTRAINT [FK_Ledger_company] FOREIGN KEY([CompanyKey])
REFERENCES [dbo].[company] ([CompanyKey])
GO
ALTER TABLE [dbo].[Ledger] CHECK CONSTRAINT [FK_Ledger_company]
GO
ALTER TABLE [dbo].[LedgerTxn]  WITH CHECK ADD  CONSTRAINT [FK_LedgerTxn_Ledger] FOREIGN KEY([LedgerKey])
REFERENCES [dbo].[Ledger] ([LedgerKey])
GO
ALTER TABLE [dbo].[LedgerTxn] CHECK CONSTRAINT [FK_LedgerTxn_Ledger]
GO

--ALTER TABLE [dbo].[FeeSchedule]  WITH CHECK ADD  CONSTRAINT [FK_FeeSchedule_Account] FOREIGN KEY([AccountKey])
--REFERENCES [dbo].[Account] ([AccountKey])
--GO
--ALTER TABLE [dbo].[FeeSchedule] CHECK CONSTRAINT [FK_FeeSchedule_Account]
--GO
--ALTER TABLE [dbo].[FeeSchedule]  WITH CHECK ADD  CONSTRAINT [FK_FeeSchedule_Company] FOREIGN KEY([CompanyKey])
--REFERENCES [dbo].[Company] ([CompanyKey])
--GO
--ALTER TABLE [dbo].[FeeSchedule] CHECK CONSTRAINT [FK_FeeSchedule_Company]
--GO
--ALTER TABLE [dbo].[FeeSchedule]  WITH CHECK ADD  CONSTRAINT [FK_FeeSchedule_Product] FOREIGN KEY([ProductKey])
--REFERENCES [dbo].[Product] ([ProductKey])
--GO
--ALTER TABLE [dbo].[FeeSchedule] CHECK CONSTRAINT [FK_FeeSchedule_Product]
--GO
--ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductTypeKey])
--REFERENCES [dbo].[ProductType] ([ProductTypeKey])
--GO
--ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
--GO
--ALTER TABLE [dbo].[FeeSchedule]  WITH CHECK ADD  CONSTRAINT [CK_FeeScheduleType] CHECK  (([FeeScheduleType]='P' OR [FeeScheduleType]='F'))
--GO
--ALTER TABLE [dbo].[FeeSchedule] CHECK CONSTRAINT [CK_FeeScheduleType]
--GO

/****** Object:  StoredProcedure [dbo].[uspLogError]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspLogError]
@tableName nvarchar(128) = '',
@procedureName nvarchar(128) = '',
@step nchar(1) = ''
AS
INSERT INTO ErrorLog (ErrorNumber, ErrorSeverity, ErrorState, ErrorProcedure, ErrorLine, ErrorMessage, TableName, ProcedureName, ProcedureStep)
SELECT
        ERROR_NUMBER() AS ErrorNumber
        ,ERROR_SEVERITY() AS ErrorSeverity
        ,ERROR_STATE() AS ErrorState
        ,ERROR_PROCEDURE() AS ErrorProcedure
        ,ERROR_LINE() AS ErrorLine
        ,ERROR_MESSAGE() AS ErrorMessage, @tableName, @procedureName, @step

GO
GRANT EXECUTE ON [dbo].[uspLogError] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/****** Object:  StoredProcedure [dbo].[uspAccountAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Account
**	Procedure Name: uspAccountAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountAll]
AS
SET NOCOUNT ON

SELECT [AccountKey], 
	[CompanyKey], 
	[AccountTypeKey], 
	[AccountCode], 
	[AccountName], 
	[AccountDescription], 
	[AccountDba], 
	[AccountStartDate], 
	[AccountEndDate], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Account


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAccountAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountAllByCompany]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Account
**	Procedure Name: uspAccountAllByCompany
**	Author: Richard Richards
**	Created: 07/05/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountAllByCompany]
	@CompanyKey int
AS
SET NOCOUNT ON

SELECT [AccountKey], 
	[CompanyKey], 
	[AccountTypeKey], 
	[AccountCode], 
	[AccountName], 
	[AccountDescription], 
	[AccountDba], 
	[AccountStartDate], 
	[AccountEndDate], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Account
WHERE CompanyKey = @CompanyKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAccountAllByCompany] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountAllByPerson]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Account
**	Procedure Name: uspAccountAllByPerson
**	Author: Richard Richards
**	Created: 07/05/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountAllByPerson]
	@PersonKey int
AS
SET NOCOUNT ON

SELECT A.[AccountKey], 
	A.[CompanyKey], 
	A.[AccountTypeKey], 
	A.[AccountCode], 
	A.[AccountName], 
	A.[AccountDescription], 
	A.[AccountDba], 
	A.[AccountStartDate], 
	A.[AccountEndDate], 
	A.[AuditAddUserId], 
	A.[AuditAddDatetime], 
	A.[AuditUpdateUserId], 
	A.[AuditUpdateDatetime]
FROM Account A INNER JOIN EntityEntity B
ON A.AccountKey = B.PrimaryEntityKey
AND B.PrimaryEntityTypeKey = 3 -- Account
AND B.SecondaryEntityTypeKey IN (3,4) -- Account or sales rep
WHERE B.SecondaryEntityKey = @PersonKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAccountAllByPerson] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: Account
**	Procedure Name: uspAccountDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountDelete]
	@AccountKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	--DELETE FROM Account
	--WHERE [AccountKey] = @AccountKey
	UPDATE Account SET AccountEndDate = GETDATE()
	WHERE AccountKey = @AccountKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Account', 'uspAccountDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspAccountDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountFind]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Account
**	Procedure Name: uspAccountFind 1, 'sport'
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountFind]
	@CompanyKey int,
	@AccountPattern varchar(50)
AS
SET NOCOUNT ON

SELECT [AccountKey], 
	[CompanyKey], 
	[AccountTypeKey], 
	[AccountCode], 
	[AccountName], 
	[AccountDescription], 
	[AccountDba], 
	[AccountStartDate], 
	[AccountEndDate], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Account
WHERE [CompanyKey] = @CompanyKey
AND ([AccountCode] LIKE '%' + @AccountPattern + '%'
	OR [AccountName] LIKE '%' + @AccountPattern + '%'
	OR [AccountDescription] LIKE '%' + @AccountPattern + '%'
	OR [AccountDba] LIKE '%' + @AccountPattern + '%')

SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspAccountFind] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Account
**	Procedure Name: uspAccountGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountGet]
	@AccountKey int
AS
SET NOCOUNT ON

SELECT [AccountKey], 
	[CompanyKey], 
	[AccountTypeKey], 
	[AccountCode], 
	[AccountName], 
	[AccountDescription], 
	[AccountDba], 
	[AccountStartDate], 
	[AccountEndDate], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Account
WHERE [AccountKey] = @AccountKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAccountGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountGetByCode]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Account
**	Procedure Name: uspAccountGetByCode
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountGetByCode]
	@AccountCode varchar(10),
	@CompanyCode varchar(10)
AS
SET NOCOUNT ON

SELECT A.[AccountKey], 
	A.[CompanyKey], 
	A.[AccountTypeKey], 
	A.[AccountCode], 
	A.[AccountName], 
	A.[AccountDescription], 
	A.[AccountDba], 
	A.[AccountStartDate], 
	A.[AccountEndDate], 
	A.[AuditAddUserId], 
	A.[AuditAddDatetime], 
	A.[AuditUpdateUserId], 
	A.[AuditUpdateDatetime]
FROM Account A INNER JOIN Company B
ON A.CompanyKey = B.CompanyKey
WHERE [AccountCode] = @AccountCode
AND B.CompanyCode = @CompanyCode


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAccountGetByCode] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountTypeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AccountType
**	Procedure Name: uspAccountTypeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountTypeAll]
AS
SET NOCOUNT ON

SELECT [AccountTypeKey], 
	[AccountTypeCode], 
	[AccountTypeName], 
	[AccountTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM AccountType


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAccountTypeAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountTypeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: AccountType
**	Procedure Name: uspAccountTypeDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountTypeDelete]
	@AccountTypeKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM AccountType
	WHERE [AccountTypeKey] = @AccountTypeKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'AccountType', 'uspAccountTypeDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspAccountTypeDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountTypeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AccountType
**	Procedure Name: uspAccountTypeGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountTypeGet]
	@AccountTypeKey int
AS
SET NOCOUNT ON

SELECT [AccountTypeKey], 
	[AccountTypeCode], 
	[AccountTypeName], 
	[AccountTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM AccountType
WHERE [AccountTypeKey] = @AccountTypeKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAccountTypeGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountTypeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: AccountType
**	Procedure Name: uspAccountTypeUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountTypeUpsert]

	@AccountTypeKey int,
	@AccountTypeCode varchar(10),
	@AccountTypeName varchar(50),
	@AccountTypeDescription varchar(254),
	@key int out
AS
SET NOCOUNT ON
IF @AccountTypeKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO AccountType (
		[AccountTypeCode],
		[AccountTypeName],
		[AccountTypeDescription]
	)
	VALUES (
		@AccountTypeCode,
		@AccountTypeName,
		@AccountTypeDescription
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'AccountType', 'uspAccountTypeUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE AccountType SET 
		[AccountTypeCode] = @AccountTypeCode,
		[AccountTypeName] = @AccountTypeName,
		[AccountTypeDescription] = @AccountTypeDescription
	WHERE [AccountTypeKey] = @AccountTypeKey
		AND ([AccountTypeCode] <> @AccountTypeCode
		OR [AccountTypeName] <> @AccountTypeName
		OR [AccountTypeDescription] <> @AccountTypeDescription);
	SELECT @key = @AccountTypeKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'AccountType', 'uspAccountTypeUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspAccountTypeUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAccountUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: Account
**	Procedure Name: uspAccountUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAccountUpsert]

	@AccountKey int,
	@CompanyKey int,
	@AccountTypeKey int,
	@AccountCode varchar(30),
	@AccountName varchar(150),
	@AccountDescription varchar(254),
	@AccountDba varchar(150),
	@AccountStartDate datetime,
	@AccountEndDate datetime,
	@key int out
AS
SET NOCOUNT ON
IF @AccountKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO Account ([CompanyKey],
		[AccountTypeKey],
		[AccountCode],
		[AccountName],
		[AccountDescription],
		[AccountDba],
		[AccountStartDate],
		[AccountEndDate]
	)
	VALUES (@CompanyKey,
		@AccountTypeKey,
		@AccountCode,
		@AccountName,
		@AccountDescription,
		@AccountDba,
		@AccountStartDate,
		@AccountEndDate
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Account', 'uspAccountUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE Account SET 
		[CompanyKey] = @CompanyKey,
		[AccountTypeKey] = @AccountTypeKey,
		[AccountCode] = @AccountCode,
		[AccountName] = @AccountName,
		[AccountDescription] = @AccountDescription,
		[AccountDba] = @AccountDba,
		[AccountStartDate] = @AccountStartDate,
		[AccountEndDate] = @AccountEndDate
	WHERE [AccountKey] = @AccountKey
	AND ([CompanyKey] <> @CompanyKey
		OR [AccountTypeKey] <> @AccountTypeKey
		OR [AccountCode] <> @AccountCode
		OR [AccountName] <> @AccountName
		OR [AccountDescription] <> @AccountDescription
		OR [AccountDba] <> @AccountDba
		OR [AccountStartDate] <> @AccountStartDate
		OR [AccountEndDate] <> @AccountEndDate);
	SELECT @key = @AccountKey;
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Account', 'uspAccountUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspAccountUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Address
**	Procedure Name: uspAddressAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressAll]
AS
SET NOCOUNT ON

SELECT [AddressKey], 
	[AddressTypeKey], 
	[EntityKey], 
	[EntityTypeKey], 
	[AddressLine1], 
	[AddressLine2], 
	[AddressLine3], 
	[AddressLine4], 
	[AddressCity], 
	[AddressState], 
	[AddressCounty], 
	[AddressCountry], 
	[AddressPostalCode], 
	[AddressNotes], 
	--[AddressDefault], 
	--[AddressActive], 
	CAST([AddressDefault] AS int) AS [AddressDefault], 
	CAST([AddressActive] AS int) AS [AddressActive], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Address


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAddressAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressAllByEntity]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Address
**	Procedure Name: uspAddressAllByEntity
**	Author: Richard Richards
**	Created: 07/05/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressAllByEntity]
	@EntityKey int,
	@EntityTypeKey int
AS
SET NOCOUNT ON

SELECT [AddressKey], 
	[AddressTypeKey], 
	[EntityKey], 
	[EntityTypeKey], 
	[AddressLine1], 
	[AddressLine2], 
	[AddressLine3], 
	[AddressLine4], 
	[AddressCity], 
	[AddressState], 
	[AddressCounty], 
	[AddressCountry], 
	[AddressPostalCode], 
	[AddressNotes], 
	CAST([AddressDefault] AS int) AS [AddressDefault], 
	CAST([AddressActive] AS int) AS [AddressActive],
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM [Address]
WHERE EntityKey = @EntityKey
AND EntityTypeKey = @EntityTypeKey

SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAddressAllByEntity] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: Address
**	Procedure Name: uspAddressDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressDelete]
	@AddressKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	UPDATE [Address] SET AddressActive = 0
	WHERE [AddressKey] = @AddressKey;
	SELECT @key = @AddressKey;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Address', 'uspAddressDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspAddressDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Address
**	Procedure Name: uspAddressGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressGet]
	@AddressKey int
AS
SET NOCOUNT ON

SELECT [AddressKey], 
	[AddressTypeKey], 
	[EntityKey], 
	[EntityTypeKey], 
	[AddressLine1], 
	[AddressLine2], 
	[AddressLine3], 
	[AddressLine4], 
	[AddressCity], 
	[AddressState], 
	[AddressCounty], 
	[AddressCountry], 
	[AddressPostalCode], 
	[AddressNotes], 
	CAST([AddressDefault] AS int) AS [AddressDefault], 
	CAST([AddressActive] AS int) AS [AddressActive], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Address
WHERE [AddressKey] = @AddressKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAddressGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressPostalAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AddressPostal
**	Procedure Name: uspAddressPostalAll
**	Author: Richard Richards
**	Created: 08/16/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressPostalAll]
AS
SET NOCOUNT ON

SELECT [Country], 
	[PostalCode], 
	[StateCode], 
	[StateFullName], 
	[CityName], 
	[CountyName], 
	[TimeZone]
FROM AddressPostal


SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspAddressPostalAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressPostalAllByCountry]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AddressPostal
**	Procedure Name: uspAddressPostalAllByCountry
**	Author: Richard Richards
**	Created: 08/16/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressPostalAllByCountry]
	@Country varchar(50)
AS
SET NOCOUNT ON

SELECT [Country], 
	[PostalCode], 
	[StateCode], 
	[StateFullName], 
	[CityName], 
	[CountyName], 
	[TimeZone]
FROM AddressPostal
WHERE [Country] = @Country


SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspAddressPostalAllByCountry] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressPostalByCodeountiesByPostal]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AddressPostal
**	Procedure Name: uspAddressPostalByCodeountiesByPostal '37174'
**	Author: Richard Richards
**	Created: 08/16/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressPostalByCodeountiesByPostal]
	@PostalCode varchar(20)
AS
SET NOCOUNT ON

SELECT DISTINCT [Country], 
	[PostalCode], 
	[StateCode], 
	[StateFullName], 
	[CityName], 
	[CountyName], 
	[TimeZone] = 0
FROM AddressPostal
WHERE [PostalCode] = @PostalCode
AND [CountyName] <> ''
ORDER BY [CountyName]

SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspAddressPostalByCodeountiesByPostal] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressPostalByCodeountiesByState]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AddressPostal
**	Procedure Name: uspAddressPostalByCodeountiesByState 'TN'
**	Author: Richard Richards
**	Created: 08/16/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressPostalByCodeountiesByState]
	@StateCode varchar(50)
AS
SET NOCOUNT ON

SELECT DISTINCT [Country], 
	[PostalCode] = '', 
	[StateCode], 
	[StateFullName], 
	[CityName] = '', 
	[CountyName], 
	[TimeZone] = 0
FROM AddressPostal
WHERE [StateCode] = @StateCode
AND [CountyName] <> ''
ORDER BY [CountyName]

SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspAddressPostalByCodeountiesByState] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressPostalGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AddressPostal
**	Procedure Name: uspAddressPostalGet '37211'
**	Author: Richard Richards
**	Created: 08/16/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressPostalGet]
	@PostalCode varchar(20)
AS
SET NOCOUNT ON

SELECT [Country], 
	[PostalCode], 
	[StateCode], 
	[StateFullName], 
	[CityName], 
	[CountyName], 
	[TimeZone]
FROM AddressPostal
WHERE [PostalCode] = @PostalCode


SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspAddressPostalGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressPostal_StatesByCountry]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*****************************************************************
**	Table Name: AddressPostal
**	Procedure Name: uspAddressPostal_StatesByCountry
**	Author: Richard Richards
**	Created: 08/16/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressPostal_StatesByCountry]
	@Country varchar(50)
AS
SET NOCOUNT ON

SELECT DISTINCT [Country], 
	[PostalCode] = '', 
	[StateCode], 
	[StateFullName], 
	[CityName] = '', 
	[CountyName] = '', 
	[TimeZone] = 0
FROM AddressPostal
WHERE [Country] = @Country
AND [StateFullName] <> ''
ORDER BY 4

SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspAddressPostal_StatesByCountry] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressTypeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AddressType
**	Procedure Name: uspAddressTypeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressTypeAll]
AS
SET NOCOUNT ON

SELECT [AddressTypeKey], 
	[AddressTypeCode], 
	[AddressTypeName], 
	[AddressTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM AddressType


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAddressTypeAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressTypeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: AddressType
**	Procedure Name: uspAddressTypeDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressTypeDelete]
	@AddressTypeKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM AddressType
	WHERE [AddressTypeKey] = @AddressTypeKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'AddressType', 'uspAddressTypeDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspAddressTypeDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressTypeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AddressType
**	Procedure Name: uspAddressTypeGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressTypeGet]
	@AddressTypeKey int
AS
SET NOCOUNT ON

SELECT [AddressTypeKey], 
	[AddressTypeCode], 
	[AddressTypeName], 
	[AddressTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM AddressType
WHERE [AddressTypeKey] = @AddressTypeKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAddressTypeGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressTypeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: AddressType
**	Procedure Name: uspAddressTypeUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressTypeUpsert]

	@AddressTypeKey int,
	@AddressTypeCode varchar(10),
	@AddressTypeName varchar(50),
	@AddressTypeDescription varchar(150),
	@key int out
AS
SET NOCOUNT ON
IF @AddressTypeKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO AddressType (
		[AddressTypeCode],
		[AddressTypeName],
		[AddressTypeDescription]
	)
	VALUES (
		@AddressTypeCode,
		@AddressTypeName,
		@AddressTypeDescription
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'AddressType', 'uspAddressTypeUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE AddressType SET 
		[AddressTypeCode] = @AddressTypeCode,
		[AddressTypeName] = @AddressTypeName,
		[AddressTypeDescription] = @AddressTypeDescription
	WHERE [AddressTypeKey] = @AddressTypeKey
		AND ([AddressTypeCode] <> @AddressTypeCode
		OR [AddressTypeName] <> @AddressTypeName
		OR [AddressTypeDescription] <> @AddressTypeDescription);
	SELECT @key = @AddressTypeKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'AddressType', 'uspAddressTypeUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspAddressTypeUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAddressUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: Address
**	Procedure Name: uspAddressUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAddressUpsert]

	@AddressKey int,
	@AddressTypeKey int,
	@EntityKey int,
	@EntityTypeKey int,
	@AddressLine1 varchar(75),
	@AddressLine2 varchar(75),
	@AddressLine3 varchar(75),
	@AddressLine4 varchar(75),
	@AddressCity varchar(75),
	@AddressState varchar(5),
	@AddressCounty varchar(50),
	@AddressCountry varchar(50),
	@AddressPostalCode varchar(20),
	@AddressNotes varchar(150),
	@AddressDefault bit,
	@AddressActive bit,
	@key int out
AS
SET NOCOUNT ON
IF @AddressKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO Address (
		[AddressTypeKey],
		[EntityKey],
		[EntityTypeKey],
		[AddressLine1],
		[AddressLine2],
		[AddressLine3],
		[AddressLine4],
		[AddressCity],
		[AddressState],
		[AddressCounty],
		[AddressCountry],
		[AddressPostalCode],
		[AddressNotes],
		[AddressDefault],
		[AddressActive]
	)
	VALUES (
		@AddressTypeKey,
		@EntityKey,
		@EntityTypeKey,
		@AddressLine1,
		@AddressLine2,
		@AddressLine3,
		@AddressLine4,
		@AddressCity,
		@AddressState,
		@AddressCounty,
		@AddressCountry,
		@AddressPostalCode,
		@AddressNotes,
		@AddressDefault,
		@AddressActive
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Address', 'uspAddressUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE Address SET 
		[AddressTypeKey] = @AddressTypeKey,
		[EntityKey] = @EntityKey,
		[EntityTypeKey] = @EntityTypeKey,
		[AddressLine1] = @AddressLine1,
		[AddressLine2] = @AddressLine2,
		[AddressLine3] = @AddressLine3,
		[AddressLine4] = @AddressLine4,
		[AddressCity] = @AddressCity,
		[AddressState] = @AddressState,
		[AddressCounty] = @AddressCounty,
		[AddressCountry] = @AddressCountry,
		[AddressPostalCode] = @AddressPostalCode,
		[AddressNotes] = @AddressNotes,
		[AddressDefault] = @AddressDefault,
		[AddressActive] = @AddressActive
	WHERE [AddressKey] = @AddressKey
		AND ([AddressTypeKey] <> @AddressTypeKey
		OR [EntityKey] <> @EntityKey
		OR [EntityTypeKey] <> @EntityTypeKey
		OR [AddressLine1] <> @AddressLine1
		OR [AddressLine2] <> @AddressLine2
		OR [AddressLine3] <> @AddressLine3
		OR [AddressLine4] <> @AddressLine4
		OR [AddressCity] <> @AddressCity
		OR [AddressState] <> @AddressState
		OR [AddressCounty] <> @AddressCounty
		OR [AddressCountry] <> @AddressCountry
		OR [AddressPostalCode] <> @AddressPostalCode
		OR [AddressNotes] <> @AddressNotes
		OR [AddressDefault] <> @AddressDefault
		OR [AddressActive] <> @AddressActive);
	SELECT @key = @AddressKey;
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Address', 'uspAddressUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspAddressUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Attribute
**	Procedure Name: uspAttributeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeAll]
AS
SET NOCOUNT ON

SELECT [AttributeKey], 
	[EntityKey], 
	[EntityTypeKey], 
	[AttributeTypeKey], 
	[AttributeValue], 
	[AttributeDataTypeKey], 
	[AttributeDisplayFormat], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Attribute


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAttributeAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeAllByEntity]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Attribute
**	Procedure Name: uspAttributeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeAllByEntity]
	@EntityKey int,
	@EntityTypeKey int
AS
SET NOCOUNT ON

CREATE TABLE #attByCategorys (AttributeTypeCategory varchar(50))

IF @EntityTypeKey = 1 -- Company
	INSERT INTO #attByCategorys VALUES ('Company'),('Company Contact')
IF @EntityTypeKey = 3 -- Account
	INSERT INTO #attByCategorys VALUES ('Account'),('Account Contact'),('General Contact')
IF @EntityTypeKey = 2 -- Person / employee
	INSERT INTO #attByCategorys VALUES ('Employee'),('General Contact')
IF @EntityTypeKey = 4 -- Products
	INSERT INTO #attByCategorys VALUES ('Product')

SELECT ISNULL(A.[AttributeKey], 0) AS AttributeKey, 
	ISNULL(A.[EntityKey], @EntityKey) AS EntityKey, 
	ISNULL(A.[EntityTypeKey], @EntityTypeKey) AS EntityTypeKey,
	B.[AttributeTypeKey], 
	ISNULL(A.[AttributeValue],'') AS AttributeValue, 
	B.[AttributeDataTypeKey], 
	ISNULL(NULLIF(A.[AttributeDisplayFormat], ''), B.AttributeDefaultFormat) AS AttributeDisplayFormat, 
	ISNULL(A.[AuditAddUserId], SUSER_NAME()) AS AuditAddUserId, 
	ISNULL(A.[AuditAddDatetime], GETDATE()) AS AuditAddDatetime, 
	ISNULL(A.[AuditUpdateUserId], SUSER_NAME()) AS AuditUpdateUserId, 
	ISNULL(A.[AuditUpdateDatetime], GETDATE()) AS AuditUpdateDatetime --, B.*
FROM AttributeType B LEFT JOIN Attribute A 
ON A.AttributeTypeKey = B.AttributeTypeKey
AND A.EntityKey = @EntityKey
AND A.EntityTypeKey = @EntityTypeKey
WHERE B.AttributeTypeCategory IN (SELECT AttributeTypeCategory FROM #attByCategorys)

DROP TABLE #attByCategorys

/*
SELECT [AttributeKey], 
	[EntityKey], 
	[EntityTypeKey], 
	[AttributeTypeKey], 
	[AttributeValue], 
	[AttributeDataTypeKey], 
	[AttributeDisplayFormat], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Attribute A
WHERE A.EntityKey = @EntityKey
AND A.EntityTypeKey = @EntityTypeKey
*/

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspAttributeAllByEntity] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: Attribute
**	Procedure Name: uspAttributeDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeDelete]
	@AttributeKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM Attribute
	WHERE [AttributeKey] = @AttributeKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Attribute', 'uspAttributeDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspAttributeDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Attribute
**	Procedure Name: uspAttributeGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeGet]
	@AttributeKey int
AS
SET NOCOUNT ON

SELECT [AttributeKey], 
	[EntityKey], 
	[EntityTypeKey], 
	[AttributeTypeKey], 
	[AttributeValue], 
	[AttributeDataTypeKey], 
	[AttributeDisplayFormat], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Attribute
WHERE [AttributeKey] = @AttributeKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAttributeGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeTypeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AttributeType
**	Procedure Name: uspAttributeTypeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeTypeAll]
AS
SET NOCOUNT ON

SELECT [AttributeTypeKey], 
	[AttributeTypeCategory], 
	[AttributeTypeCode], 
	[AttributeTypeName], 
	[AttributeTypeDescription], 
	[AttributeDataTypeKey],
	[AttributeDefaultFormat],
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM AttributeType


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAttributeTypeAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeTypeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: AttributeType
**	Procedure Name: uspAttributeTypeDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeTypeDelete]
	@AttributeTypeKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM AttributeType
	WHERE [AttributeTypeKey] = @AttributeTypeKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'AttributeType', 'uspAttributeTypeDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspAttributeTypeDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeTypeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AttributeType
**	Procedure Name: uspAttributeTypeGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeTypeGet]
	@AttributeTypeKey int
AS
SET NOCOUNT ON

SELECT [AttributeTypeKey], 
	[AttributeTypeCategory], 
	[AttributeTypeCode], 
	[AttributeTypeName], 
	[AttributeTypeDescription], 
	[AttributeDataTypeKey],
	[AttributeDefaultFormat],
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM AttributeType
WHERE [AttributeTypeKey] = @AttributeTypeKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAttributeTypeGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeTypeGetByCode]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AttributeType
**	Procedure Name: uspAttributeTypeGetByCode
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeTypeGetByCode]
	@AttributeTypeCode int
AS
SET NOCOUNT ON

SELECT [AttributeTypeKey], 
	[AttributeTypeCategory], 
	[AttributeTypeCode], 
	[AttributeTypeName], 
	[AttributeTypeDescription], 
	[AttributeDataTypeKey],
	[AttributeDefaultFormat],
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM AttributeType
WHERE [AttributeTypeCategory] = @AttributeTypeCode


SET NOCOUNT OFF

GO
GRANT EXECUTE ON [dbo].[uspAttributeTypeGetByCode] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeTypeGetByCategory]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AttributeType
**	Procedure Name: uspAttributeTypeGetByCategory
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeTypeGetByCategory]
	@AttributeTypeCategory varchar(50)
AS
SET NOCOUNT ON

SELECT [AttributeTypeKey], 
	[AttributeTypeCategory], 
	[AttributeTypeCode], 
	[AttributeTypeName], 
	[AttributeTypeDescription], 
	[AttributeDataTypeKey],
	[AttributeDefaultFormat],
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM AttributeType
WHERE [AttributeTypeCategory] = @AttributeTypeCategory


SET NOCOUNT OFF

GO
GRANT EXECUTE ON [dbo].[uspAttributeTypeGetByCategory] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeTypeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: AttributeType
**	Procedure Name: uspAttributeTypeUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeTypeUpsert]

	@AttributeTypeKey int,
	@AttributeTypeCategory varchar(50),
	@AttributeTypeCode varchar(10),
	@AttributeTypeName varchar(50),
	@AttributeTypeDescription varchar(150),
	@AttributeDataTypeKey int,
	@AttributeDefaultFormat varchar(150),
	@key int out
AS
SET NOCOUNT ON
IF @AttributeTypeKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO AttributeType (
		[AttributeTypeCategory],
		[AttributeTypeCode],
		[AttributeTypeName],
		[AttributeTypeDescription],
		[AttributeDataTypeKey],
		[AttributeDefaultFormat]
	)
	VALUES (
		@AttributeTypeCategory,
		@AttributeTypeCode,
		@AttributeTypeName,
		@AttributeTypeDescription,
		@AttributeDataTypeKey,
		@AttributeDefaultFormat
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'AttributeType', 'uspAttributeTypeUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE AttributeType SET 
		[AttributeTypeCategory] = @AttributeTypeCategory,
		[AttributeTypeCode] = @AttributeTypeCode,
		[AttributeTypeName] = @AttributeTypeName,
		[AttributeTypeDescription] = @AttributeTypeDescription,
		[AttributeDataTypeKey] = @AttributeDataTypeKey,
		[AttributeDefaultFormat] = @AttributeDefaultFormat
	WHERE [AttributeTypeKey] = @AttributeTypeKey
		AND ([AttributeTypeCategory] <> @AttributeTypeCategory
		OR [AttributeTypeCode] <> @AttributeTypeCode
		OR [AttributeTypeName] <> @AttributeTypeName
		OR [AttributeTypeDescription] <> @AttributeTypeDescription
		OR [AttributeDataTypeKey] <> @AttributeDataTypeKey
		OR [AttributeDefaultFormat] <> @AttributeDefaultFormat);
	SELECT @key = @AttributeTypeKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'AttributeType', 'uspAttributeTypeUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspAttributeTypeUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAttributeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: Attribute
**	Procedure Name: uspAttributeUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAttributeUpsert]

	@AttributeKey int,
	@EntityKey int,
	@EntityTypeKey int,
	@AttributeTypeKey int,
	@AttributeValue varchar(MAX),
	@AttributeDataTypeKey int,
	@AttributeDisplayFormat varchar(50),
	@key int out
AS
SET NOCOUNT ON
IF @AttributeKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO Attribute (
		[EntityKey],
		[EntityTypeKey],
		[AttributeTypeKey],
		[AttributeValue],
		[AttributeDataTypeKey],
		[AttributeDisplayFormat]
	)
	VALUES (
		@EntityKey,
		@EntityTypeKey,
		@AttributeTypeKey,
		@AttributeValue,
		@AttributeDataTypeKey,
		@AttributeDisplayFormat
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Attribute', 'uspAttributeUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE Attribute SET 
		[EntityKey] = @EntityKey,
		[EntityTypeKey] = @EntityTypeKey,
		[AttributeTypeKey] = @AttributeTypeKey,
		[AttributeValue] = @AttributeValue,
		[AttributeDataTypeKey] = @AttributeDataTypeKey,
		[AttributeDisplayFormat] = @AttributeDisplayFormat
	WHERE [AttributeKey] = @AttributeKey
		AND ([EntityKey] <> @EntityKey
		OR [EntityTypeKey] <> @EntityTypeKey
		OR [AttributeTypeKey] <> @AttributeTypeKey
		OR [AttributeValue] <> @AttributeValue
		OR [AttributeDataTypeKey] <> @AttributeDataTypeKey
		OR [AttributeDisplayFormat] <> @AttributeDisplayFormat);
	SELECT @key = @AttributeKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Attribute', 'uspAttributeUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspAttributeUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAuditLogAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AuditLog
**	Procedure Name: uspAuditLogAll
**	Author: Richard Richards
**	Created: 07/05/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAuditLogAll]
AS
SET NOCOUNT ON

SELECT TOP 1000 [LogKey], 
	[Action], 
	[BusinessObject], 
	[AuditDateTime], 
	[UserId], 
	[Application], 
	[Host], 
	ISNULL([Comment], '') AS [Comment], 
	ISNULL([DataOld], '') AS [DataOld], 
	ISNULL([DataNew], '') AS [DataNew]
FROM ChangeDataAuditLog
ORDER BY [AuditDateTime] DESC


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAuditLogAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAuditLogAllBusinessObject]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AuditLog
**	Procedure Name: uspAuditLogAll
**	Author: Richard Richards
**	Created: 07/05/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAuditLogAllBusinessObject]
	@BusinessObject varchar(30)
AS
SET NOCOUNT ON

SELECT [LogKey], 
	[Action], 
	[BusinessObject], 
	[AuditDateTime], 
	[UserId], 
	[Application], 
	[Host], 
	ISNULL([Comment], '') AS [Comment], 
	ISNULL([DataOld], '') AS [DataOld], 
	ISNULL([DataNew], '') AS [DataNew]
FROM ChangeDataAuditLog
WHERE BusinessObject = @BusinessObject

SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAuditLogAllBusinessObject] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAuditLogDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: AuditLog
**	Procedure Name: uspAuditLogDelete
**	Author: Richard Richards
**	Created: 07/05/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAuditLogDelete]
	@AuditLogKey bigint,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM ChangeDataAuditLog
	WHERE [LogKey] = -2 --@AuditLogKey
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'AuditLog', 'uspAuditLogDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspAuditLogDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAuditLogGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: AuditLog
**	Procedure Name: uspAuditLogGet
**	Author: Richard Richards
**	Created: 07/05/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAuditLogGet]
	@AuditLogKey bigint
AS
SET NOCOUNT ON

SELECT [LogKey], 
	[Action], 
	[BusinessObject], 
	[AuditDateTime], 
	[UserId], 
	[Application], 
	[Host], 
	[Comment], 
	[DataOld], 
	[DataNew]
FROM ChangeDataAuditLog
WHERE [LogKey] = @AuditLogKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspAuditLogGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspAuditLogUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: AuditLog
**	Procedure Name: uspAuditLogUpsert
**	Author: Richard Richards
**	Created: 07/05/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspAuditLogUpsert]

	@AuditLogKey bigint,
	@AuditAction char(1),
	@AuditBusinessObject varchar(30),
	@Auditdatetime datetime,
	@AuditUserId varchar(30),
	@AuditApplication varchar(150),
	@AuditHost varchar(128),
	@AuditComment varchar(512),
	@AuditDataOld xml,
	@AuditDataNew xml,
	@key int out
AS
SET NOCOUNT ON
	
IF @AuditLogKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO ChangeDataAuditLog (
		[Action],
		[BusinessObject],
		[AuditDateTime],
		[UserId],
		[Application],
		[Host],
		[Comment],
		[DataOld],
		[DataNew]
	)
	VALUES (
		@AuditAction,
		@AuditBusinessObject,
		@Auditdatetime,
		@AuditUserId,
		@AuditApplication,
		@AuditHost,
		@AuditComment,
		@AuditDataOld,
		@AuditDataNew
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'AuditLog', 'uspAuditLogUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	INSERT INTO ChangeDataAuditLog(
		[Action],
		[BusinessObject],
		[AuditDateTime],
		[UserId],
		[Application],
		[Host],
		[Comment],
		[DataOld],
		[DataNew]
	)
	VALUES (
		@AuditAction,
		@AuditBusinessObject,
		@Auditdatetime,
		@AuditUserId,
		@AuditApplication,
		@AuditHost,
		@AuditComment,
		@AuditDataOld,
		@AuditDataNew
	)
	SELECT @key = SCOPE_IDENTITY();

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'AuditLog', 'uspAuditLogUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspAuditLogUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Comment
**	Procedure Name: uspCommentAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCommentAll]
AS
SET NOCOUNT ON

SELECT [CommentKey], 
	[EntityKey], 
	[EntityType], 
	[CommentTypeKey], 
	[CommentValue], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Comment


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspCommentAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentAllByEntity]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*****************************************************************
**	Table Name: Comment
**	Procedure Name: uspCommentAllByEntity
**	Author: Richard Richards
**	Created: 03/15/2016
**	Copyright: QIQO Software, (c) 2016
******************************************************************/

CREATE PROC [dbo].[uspCommentAllByEntity]
	@EntityKey int,
	@EntityTypeKey int
AS
SET NOCOUNT ON

SELECT [CommentKey], 
	[EntityKey], 
	[EntityType], 
	[CommentTypeKey], 
	[CommentValue], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Comment
WHERE EntityKey = @EntityKey
AND EntityType = @EntityTypeKey

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspCommentAllByEntity] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: Comment
**	Procedure Name: uspCommentDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCommentDelete]
	@CommentKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM Comment
	WHERE [CommentKey] = @CommentKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Comment', 'uspCommentDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspCommentDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Comment
**	Procedure Name: uspCommentGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCommentGet]
	@CommentKey int
AS
SET NOCOUNT ON

SELECT [CommentKey], 
	[EntityKey], 
	[EntityType], 
	[CommentTypeKey], 
	[CommentValue], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Comment
WHERE [CommentKey] = @CommentKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspCommentGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentTypeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: CommentType
**	Procedure Name: uspCommentTypeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCommentTypeAll]
AS
SET NOCOUNT ON

SELECT [CommentTypeKey], 
	[CommentTypeCategory], 
	[CommentTypeCode], 
	[CommentTypeName], 
	[CommentTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM CommentType


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspCommentTypeAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentTypeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: CommentType
**	Procedure Name: uspCommentTypeDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCommentTypeDelete]
	@CommentTypeKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM CommentType
	WHERE [CommentTypeKey] = @CommentTypeKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'CommentType', 'uspCommentTypeDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspCommentTypeDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentTypeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: CommentType
**	Procedure Name: uspCommentTypeGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCommentTypeGet]
	@CommentTypeKey int
AS
SET NOCOUNT ON

SELECT [CommentTypeKey], 
	[CommentTypeCategory], 
	[CommentTypeCode], 
	[CommentTypeName], 
	[CommentTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM CommentType
WHERE [CommentTypeKey] = @CommentTypeKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspCommentTypeGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentTypeGetByCategory]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: CommentType
**	Procedure Name: uspCommentTypeGetByCategory
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCommentTypeGetByCategory]
	@CommentTypeCategory varchar(50)
AS
SET NOCOUNT ON

SELECT [CommentTypeKey], 
	[CommentTypeCategory], 
	[CommentTypeCode], 
	[CommentTypeName], 
	[CommentTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM CommentType
WHERE [CommentTypeCategory] = @CommentTypeCategory


SET NOCOUNT OFF

GO
GRANT EXECUTE ON [dbo].[uspCommentTypeGetByCategory] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentTypeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: CommentType
**	Procedure Name: uspCommentTypeUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCommentTypeUpsert]

	@CommentTypeKey int,
	@CommentTypeCategory varchar(50),
	@CommentTypeCode varchar(10),
	@CommentTypeName varchar(50),
	@CommentTypeDescription varchar(150),
	@key int out
AS
SET NOCOUNT ON
IF @CommentTypeKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO CommentType (
		[CommentTypeCategory],
		[CommentTypeCode],
		[CommentTypeName],
		[CommentTypeDescription]
	)
	VALUES (
		@CommentTypeCategory,
		@CommentTypeCode,
		@CommentTypeName,
		@CommentTypeDescription
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'CommentType', 'uspCommentTypeUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE CommentType SET 
		[CommentTypeCategory] = @CommentTypeCategory,
		[CommentTypeCode] = @CommentTypeCode,
		[CommentTypeName] = @CommentTypeName,
		[CommentTypeDescription] = @CommentTypeDescription
	WHERE [CommentTypeKey] = @CommentTypeKey
		AND ([CommentTypeCategory] <> @CommentTypeCategory
		OR [CommentTypeCode] <> @CommentTypeCode
		OR [CommentTypeName] <> @CommentTypeName
		OR [CommentTypeDescription] <> @CommentTypeDescription);
	SELECT @key = @CommentTypeKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'CommentType', 'uspCommentTypeUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspCommentTypeUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCommentUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: Comment
**	Procedure Name: uspCommentUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCommentUpsert]

	@CommentKey int,
	@EntityKey int,
	@EntityType int,
	@CommentTypeKey int,
	@CommentValue varchar(MAX),
	@key int out
AS
SET NOCOUNT ON
IF @CommentKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO Comment (
		[EntityKey],
		[EntityType],
		[CommentTypeKey],
		[CommentValue]
	)
	VALUES (
		@EntityKey,
		@EntityType,
		@CommentTypeKey,
		@CommentValue
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Comment', 'uspCommentUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE Comment SET 
		[EntityKey] = @EntityKey,
		[EntityType] = @EntityType,
		[CommentTypeKey] = @CommentTypeKey,
		[CommentValue] = @CommentValue
	WHERE [CommentKey] = @CommentKey
		AND ([EntityKey] <> @EntityKey
		OR [EntityType] <> @EntityType
		OR [CommentTypeKey] <> @CommentTypeKey
		OR [CommentValue] <> @CommentValue);
	SELECT @key = @CommentKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Comment', 'uspCommentUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspCommentUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCompanyAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Company
**	Procedure Name: uspCompanyAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCompanyAll]
AS
SET NOCOUNT ON

SELECT [CompanyKey], 
	[CompanyCode], 
	[CompanyName], 
	[CompanyDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Company


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspCompanyAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCompanyDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: Company
**	Procedure Name: uspCompanyDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCompanyDelete]
	@CompanyKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	--DELETE FROM Company
	--WHERE [CompanyKey] = @CompanyKey;
	--SELECT @key = @@ROWCOUNT;
	SELECT @key = 1;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Company', 'uspCompanyDelete';
	THROW;
END CATCH

SET NOCOUNT OFF





GO
GRANT EXECUTE ON [dbo].[uspCompanyDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCompanyDeleteByCode]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: Company
**	Procedure Name: uspCompanyDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCompanyDeleteByCode]
	@CompanyCode int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM Company
	WHERE [CompanyCode] = @CompanyCode;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Company', 'uspCompanyDelete';
	THROW;
END CATCH

SET NOCOUNT OFF





GO
GRANT EXECUTE ON [dbo].[uspCompanyDeleteByCode] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCompanyGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Company
**	Procedure Name: uspCompanyGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCompanyGet]
	@CompanyKey int
AS
SET NOCOUNT ON

SELECT [CompanyKey], 
	[CompanyCode], 
	[CompanyName], 
	[CompanyDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Company
WHERE [CompanyKey] = @CompanyKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspCompanyGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCompanyGetByCode]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Company
**	Procedure Name: uspCompanyGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCompanyGetByCode]
	@CompanyCode varchar(10)
AS
SET NOCOUNT ON

SELECT [CompanyKey], 
	[CompanyCode], 
	[CompanyName], 
	[CompanyDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Company
WHERE [CompanyCode] = @CompanyCode


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspCompanyGetByCode] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspCompanyUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: Company
**	Procedure Name: uspCompanyUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspCompanyUpsert]

	@CompanyKey int,
	@CompanyCode varchar(10),
	@CompanyName varchar(50),
	@CompanyDescription varchar(255),
	@key int out
AS
--SET NOCOUNT ON
IF @CompanyKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO Company (
		[CompanyCode],
		[CompanyName],
		[CompanyDescription]
	)
	VALUES (
		@CompanyCode,
		@CompanyName,
		@CompanyDescription
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Company', 'uspCompanyUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE Company SET 
		[CompanyCode] = @CompanyCode,
		[CompanyName] = @CompanyName,
		[CompanyDescription] = @CompanyDescription
	WHERE [CompanyKey] = @CompanyKey
		AND ([CompanyCode] <> @CompanyCode
		OR [CompanyName] <> @CompanyName
		OR [CompanyDescription] <> @CompanyDescription);
	SELECT @key = @CompanyKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Company', 'uspCompanyUpsert', 'U';
		THROW;
	END CATCH
END

--SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspCompanyUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Contact
**	Procedure Name: uspContactAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactAll]
AS
SET NOCOUNT ON

SELECT [ContactKey], 
	[EntityKey], 
	[EntityTypeKey], 
	[ContactTypeKey], 
	[ContactValue], 
	CAST([ContactDefault] AS int) AS [ContactDefault], 
	CAST([ContactActive] AS int) AS [ContactActive], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Contact


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspContactAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactAllByEntity]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*****************************************************************
**	Table Name: Contact
**	Procedure Name: uspContactAllByEntity 1, 3
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactAllByEntity]
	@EntityKey int,
	@EntityTypeKey int
AS
SET NOCOUNT ON

SELECT [ContactKey], 
	[EntityKey], 
	[EntityTypeKey], 
	[ContactTypeKey], 
	[ContactValue], 
	CAST([ContactDefault] AS int) AS [ContactDefault], 
	CAST([ContactActive] AS int) AS [ContactActive], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Contact 
WHERE EntityKey = @EntityKey
AND EntityTypeKey = @EntityTypeKey


SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspContactAllByEntity] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: Contact
**	Procedure Name: uspContactDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactDelete]
	@ContactKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM Contact
	WHERE [ContactKey] = @ContactKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Contact', 'uspContactDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspContactDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Contact
**	Procedure Name: uspContactGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactGet]
	@ContactKey int
AS
SET NOCOUNT ON

SELECT [ContactKey], 
	[EntityKey], 
	[EntityTypeKey], 
	[ContactTypeKey], 
	[ContactValue], 
	CAST([ContactDefault] AS int) AS [ContactDefault], 
	CAST([ContactActive] AS int) AS [ContactActive], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Contact
WHERE [ContactKey] = @ContactKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspContactGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactTypeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: ContactType
**	Procedure Name: uspContactTypeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactTypeAll]
AS
SET NOCOUNT ON

SELECT [ContactTypeKey], 
	[ContactTypeCategory], 
	[ContactTypeCode], 
	[ContactTypeName], 
	[ContactTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM ContactType


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspContactTypeAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactTypeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: ContactType
**	Procedure Name: uspContactTypeDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactTypeDelete]
	@ContactTypeKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM ContactType
	WHERE [ContactTypeKey] = @ContactTypeKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'ContactType', 'uspContactTypeDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspContactTypeDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactTypeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: ContactType
**	Procedure Name: uspContactTypeGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactTypeGet]
	@ContactTypeKey int
AS
SET NOCOUNT ON

SELECT [ContactTypeKey], 
	[ContactTypeCategory], 
	[ContactTypeCode], 
	[ContactTypeName], 
	[ContactTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM ContactType
WHERE [ContactTypeKey] = @ContactTypeKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspContactTypeGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactTypeGetByCategory]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: ContactType
**	Procedure Name: uspContactTypeGetByCategory
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactTypeGetByCategory]
	@ContactTypeCategory int
AS
SET NOCOUNT ON

SELECT [ContactTypeKey], 
	[ContactTypeCategory], 
	[ContactTypeCode], 
	[ContactTypeName], 
	[ContactTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM ContactType
WHERE [ContactTypeCategory] = @ContactTypeCategory


SET NOCOUNT OFF

GO
GRANT EXECUTE ON [dbo].[uspContactTypeGetByCategory] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactTypeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: ContactType
**	Procedure Name: uspContactTypeUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactTypeUpsert]

	@ContactTypeKey int,
	@ContactTypeCategory varchar(50),
	@ContactTypeCode varchar(10),
	@ContactTypeName varchar(50),
	@ContactTypeDescription varchar(150),
	@key int out
AS
SET NOCOUNT ON
IF @ContactTypeKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO ContactType (
		[ContactTypeCategory],
		[ContactTypeCode],
		[ContactTypeName],
		[ContactTypeDescription]
	)
	VALUES (
		@ContactTypeCategory,
		@ContactTypeCode,
		@ContactTypeName,
		@ContactTypeDescription
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'ContactType', 'uspContactTypeUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE ContactType SET 
		[ContactTypeCategory] = @ContactTypeCategory,
		[ContactTypeCode] = @ContactTypeCode,
		[ContactTypeName] = @ContactTypeName,
		[ContactTypeDescription] = @ContactTypeDescription
	WHERE [ContactTypeKey] = @ContactTypeKey
		AND ([ContactTypeCategory] <> @ContactTypeCategory
		OR [ContactTypeCode] <> @ContactTypeCode
		OR [ContactTypeName] <> @ContactTypeName
		OR [ContactTypeDescription] <> @ContactTypeDescription);
	SELECT @key = @ContactTypeKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'ContactType', 'uspContactTypeUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspContactTypeUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspContactUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: Contact
**	Procedure Name: uspContactUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspContactUpsert]

	@ContactKey int,
	@EntityKey int,
	@EntityTypeKey int,
	@ContactTypeKey int,
	@ContactValue varchar(150),
	@ContactDefault bit,
	@ContactActive bit,
	@key int out
AS
SET NOCOUNT ON
IF @ContactKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO Contact (
		[EntityKey],
		[EntityTypeKey],
		[ContactTypeKey],
		[ContactValue],
		[ContactDefault],
		[ContactActive]
	)
	VALUES (
		@EntityKey,
		IIF(@EntityTypeKey = 0, 2, @EntityTypeKey),
		@ContactTypeKey,
		@ContactValue,
		@ContactDefault,
		@ContactActive
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Contact', 'uspContactUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE Contact SET 
		[EntityKey] = @EntityKey,
		[EntityTypeKey] = @EntityTypeKey,
		[ContactTypeKey] = @ContactTypeKey,
		[ContactValue] = @ContactValue,
		[ContactDefault] = @ContactDefault,
		[ContactActive] = @ContactActive
	WHERE [ContactKey] = @ContactKey
		AND ([EntityKey] <> @EntityKey
		OR [EntityTypeKey] <> @EntityTypeKey
		OR [ContactTypeKey] <> @ContactTypeKey
		OR [ContactValue] <> @ContactValue
		OR [ContactDefault] <> @ContactDefault
		OR [ContactActive] <> @ContactActive);
	SELECT @key = @ContactKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Contact', 'uspContactUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspContactUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspEntityEntityAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: EntityEntity
**	Procedure Name: uspEntityEntityAll
**	Author: Richard Richards
**	Created: 04/2/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspEntityEntityAll]
AS
SET NOCOUNT ON

SELECT [EntityEntityKey], 
	[PrimaryEntityKey], 
	[PrimaryEntityTypeKey],
	[PrimaryEntityRoleKey], 
	[SecondaryEntityKey],
	[SecondaryEntityTypeKey],
	[SecondaryEntityRoleKey],
	[EntityEntitySequence], 
	[StartDate],
	[EndDate],
	[Comment], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM EntityEntity


SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspEntityEntityAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspEntityEntityAllByEntity]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: EntityEntity
**	Procedure Name: uspEntityEntityAllByEntity
**	Author: Richard Richards
**	Created: 04/2/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspEntityEntityAllByEntity]
	@EntityKey int,
	@EntityTypeKey int

AS
SET NOCOUNT ON

SELECT A.[EntityEntityKey], 
	A.[PrimaryEntityKey], 
	A.[PrimaryEntityTypeKey],
	A.[PrimaryEntityRoleKey], 
	A.[SecondaryEntityKey],
	A.[SecondaryEntityTypeKey],
	A.[SecondaryEntityRoleKey],
	A.[EntityEntitySequence], 
	A.[StartDate],
	A.[EndDate],
	A.[Comment], 
	A.[AuditAddUserId], 
	A.[AuditAddDatetime], 
	A.[AuditUpdateUserId], 
	A.[AuditUpdateDatetime]
FROM EntityEntity A 
WHERE A.[PrimaryEntityKey] = @EntityKey
AND A.[PrimaryEntityTypeKey] = @EntityTypeKey


SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspEntityEntityAllByEntity] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspEntityEntityDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: EntityEntity
**	Procedure Name: uspEntityEntityDelete
**	Author: Richard Richards
**	Created: 04/2/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspEntityEntityDelete]
	@EntityEntityKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM EntityEntity
	WHERE [EntityEntityKey] = @EntityEntityKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'EntityEntity', 'uspEntityEntityDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspEntityEntityDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspEntityEntityGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: EntityEntity
**	Procedure Name: uspEntityEntityGet
**	Author: Richard Richards
**	Created: 04/2/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspEntityEntityGet]
	@EntityEntityKey int
AS
SET NOCOUNT ON

SELECT [EntityEntityKey], 
	[PrimaryEntityKey], 
	[PrimaryEntityTypeKey],
	[PrimaryEntityRoleKey], 
	[SecondaryEntityKey],
	[SecondaryEntityTypeKey],
	[SecondaryEntityRoleKey],
	[EntityEntitySequence], 
	[StartDate],
	[EndDate],
	[Comment], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM EntityEntity
WHERE [EntityEntityKey] = @EntityEntityKey


SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspEntityEntityGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspEntityEntityUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: EntityEntity
**	Procedure Name: uspEntityEntityUpsert
**	Author: Richard Richards
**	Created: 04/2/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspEntityEntityUpsert]
	@EntityEntityKey int, 
	@PrimaryEntityKey int, 
	@PrimaryEntityTypeKey int,
	@PrimaryEntityRoleKey int, 
	@SecondaryEntityKey int,
	@SecondaryEntityTypeKey int,
	@SecondaryEntityRoleKey int,
	@EntityEntitySequence int, 
	@StartDate datetime,
	@EndDate datetime,
	@Comment varchar(150),
	@key int out
AS
SET NOCOUNT ON
IF @EntityEntityKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO EntityEntity ( --[EntityEntityKey], 
		[PrimaryEntityKey], 
		[PrimaryEntityTypeKey],
		[PrimaryEntityRoleKey], 
		[SecondaryEntityKey],
		[SecondaryEntityTypeKey],
		[SecondaryEntityRoleKey],
		[EntityEntitySequence], 
		[StartDate],
		[EndDate],
		[Comment]
	)
	VALUES (-- @EntityEntityKey, 
		@PrimaryEntityKey, 
		@PrimaryEntityTypeKey,
		@PrimaryEntityRoleKey, 
		@SecondaryEntityKey,
		@SecondaryEntityTypeKey,
		@SecondaryEntityRoleKey,
		@EntityEntitySequence, 
		@StartDate,
		@EndDate,
		@Comment
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'EntityEntity', 'uspEntityEntityUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE EntityEntity SET 
		[PrimaryEntityKey] = @PrimaryEntityKey,
		[PrimaryEntityTypeKey] = @PrimaryEntityTypeKey,
		[PrimaryEntityRoleKey] = @PrimaryEntityRoleKey,
		[SecondaryEntityKey] = @SecondaryEntityKey,
		[SecondaryEntityTypeKey] = @SecondaryEntityTypeKey,
		[SecondaryEntityRoleKey] = @SecondaryEntityRoleKey,
		[EntityEntitySequence] = @EntityEntitySequence,
		[StartDate] = @StartDate,
		[EndDate] = @EndDate,
		[Comment] = @Comment
	WHERE [EntityEntityKey] = @EntityEntityKey
		AND ([PrimaryEntityKey] <> @PrimaryEntityKey
		OR  [PrimaryEntityTypeKey] <> @PrimaryEntityTypeKey
		OR [PrimaryEntityRoleKey] <> @PrimaryEntityRoleKey
		OR [SecondaryEntityKey] <> @SecondaryEntityKey
		OR [SecondaryEntityTypeKey] <> @SecondaryEntityTypeKey
		OR [SecondaryEntityRoleKey] <> @SecondaryEntityRoleKey
		OR [EntityEntitySequence] <> @EntityEntitySequence
		OR [StartDate] <> @StartDate
		OR [EndDate] <> @EndDate
		OR [Comment] <> @Comment);
	SELECT @key = @EntityEntityKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'EntityEntity', 'uspEntityEntityUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF






GO
GRANT EXECUTE ON [dbo].[uspEntityEntityUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspEntityTypeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: EntityType
**	Procedure Name: uspEntityTypeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspEntityTypeAll]
AS
SET NOCOUNT ON

SELECT [EntityTypeKey], 
	[EntityTypeCode], 
	[EntityTypeName], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM EntityType


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspEntityTypeAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspEntityTypeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: EntityType
**	Procedure Name: uspEntityTypeDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspEntityTypeDelete]
	@EntityTypeKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM EntityType
	WHERE [EntityTypeKey] = @EntityTypeKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'EntityType', 'uspEntityTypeDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspEntityTypeDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspEntityTypeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: EntityType
**	Procedure Name: uspEntityTypeGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspEntityTypeGet]
	@EntityTypeKey int
AS
SET NOCOUNT ON

SELECT [EntityTypeKey], 
	[EntityTypeCode], 
	[EntityTypeName], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM EntityType
WHERE [EntityTypeKey] = @EntityTypeKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspEntityTypeGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspEntityTypeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: EntityType
**	Procedure Name: uspEntityTypeUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspEntityTypeUpsert]

	@EntityTypeKey int,
	@EntityTypeCode varchar(10),
	@EntityTypeName varchar(50),
	@key int out
AS
SET NOCOUNT ON
IF @EntityTypeKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO EntityType (
		[EntityTypeCode],
		[EntityTypeName]
	)
	VALUES (
		@EntityTypeCode,
		@EntityTypeName
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'EntityType', 'uspEntityTypeUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE EntityType SET 
		[EntityTypeCode] = @EntityTypeCode,
		[EntityTypeName] = @EntityTypeName
	WHERE [EntityTypeKey] = @EntityTypeKey
		AND ([EntityTypeCode] <> @EntityTypeCode
		OR [EntityTypeName] <> @EntityTypeName);
	SELECT @key = @EntityTypeKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'EntityType', 'uspEntityTypeUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspEntityTypeUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspFeeScheduleAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--/*****************************************************************
--**	Table Name: FeeSchedule
--**	Procedure Name: uspFeeScheduleAll
--**	Author: Richard Richards
--**	Created: 07/15/2015
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspFeeScheduleAll]
--AS
--SET NOCOUNT ON

--SELECT [FeeScheduleKey], 
--	[CompanyKey], 
--	[AccountKey], 
--	[ProductKey], 
--	[FeeScheduleStartDate], 
--	[FeeScheduleEndDate], 
--	[FeeScheduleType], 
--	[FeeScheduleValue], 
--	[AuditAddUserId], 
--	[AuditAddDatetime], 
--	[AuditUpdateUserId], 
--	[AuditUpdateDatetime]
--FROM FeeSchedule


--SET NOCOUNT OFF




--GO
--GRANT EXECUTE ON [dbo].[uspFeeScheduleAll] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspFeeScheduleAllByAccount]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO


--/*****************************************************************
--**	Table Name: FeeSchedule
--**	Procedure Name: uspFeeScheduleAllByAccount 2
--**	Author: Richard Richards
--**	Created: 07/15/2015
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspFeeScheduleAllByAccount]
--	@AccountKey int
--AS
--SET NOCOUNT ON

--SELECT A.[FeeScheduleKey], 
--	A.[CompanyKey], 
--	A.[AccountKey], 
--	A.[ProductKey], 
--	A.[FeeScheduleStartDate], 
--	A.[FeeScheduleEndDate], 
--	A.[FeeScheduleType], 
--	A.[FeeScheduleValue], 
--	A.[AuditAddUserId], 
--	A.[AuditAddDatetime], 
--	A.[AuditUpdateUserId], 
--	A.[AuditUpdateDatetime],
--	B.ProductDescription,
--	B.ProductCode,
--	C.AccountCode,
--	C.AccountName
--FROM FeeSchedule A INNER JOIN Product B
--ON A.ProductKey = B.ProductKey
--JOIN Account C
--ON A.AccountKey = C.AccountKey
--AND A.CompanyKey = C.CompanyKey
--WHERE A.AccountKey = @AccountKey
--AND GETDATE() BETWEEN [FeeScheduleStartDate] AND [FeeScheduleEndDate]
--ORDER BY B.ProductTypeKey, B.ProductDescription


--SET NOCOUNT OFF



--GO
--GRANT EXECUTE ON [dbo].[uspFeeScheduleAllByAccount] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspFeeScheduleAllByCompany]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO


--/*****************************************************************
--**	Table Name: FeeSchedule
--**	Procedure Name: uspFeeScheduleAll
--**	Author: Richard Richards
--**	Created: 07/15/2015
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspFeeScheduleAllByCompany]
--	@CompanyKey int
--AS
--SET NOCOUNT ON

--SELECT A.[FeeScheduleKey], 
--	A.[CompanyKey], 
--	A.[AccountKey], 
--	A.[ProductKey], 
--	A.[FeeScheduleStartDate], 
--	A.[FeeScheduleEndDate], 
--	A.[FeeScheduleType], 
--	A.[FeeScheduleValue], 
--	A.[AuditAddUserId], 
--	A.[AuditAddDatetime], 
--	A.[AuditUpdateUserId], 
--	A.[AuditUpdateDatetime],
--	B.ProductDescription,
--	B.ProductCode,
--	C.AccountCode,
--	C.AccountName
--FROM FeeSchedule A INNER JOIN Product B
--ON A.ProductKey = B.ProductKey
--JOIN Account C
--ON A.AccountKey = C.AccountKey
--AND A.CompanyKey = C.CompanyKey
--WHERE A.CompanyKey = @CompanyKey
--AND GETDATE() BETWEEN [FeeScheduleStartDate] AND [FeeScheduleEndDate]


--SET NOCOUNT OFF



--GO
--GRANT EXECUTE ON [dbo].[uspFeeScheduleAllByCompany] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspFeeScheduleAllByProduct]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO



--/*****************************************************************
--**	Table Name: FeeSchedule
--**	Procedure Name: uspFeeScheduleAllByProduct 25
--**	Author: Richard Richards
--**	Created: 07/15/2015
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspFeeScheduleAllByProduct]
--	@ProductKey int
--AS
--SET NOCOUNT ON

--SELECT A.[FeeScheduleKey], 
--	A.[CompanyKey], 
--	A.[AccountKey], 
--	A.[ProductKey], 
--	A.[FeeScheduleStartDate], 
--	A.[FeeScheduleEndDate], 
--	A.[FeeScheduleType], 
--	A.[FeeScheduleValue], 
--	A.[AuditAddUserId], 
--	A.[AuditAddDatetime], 
--	A.[AuditUpdateUserId], 
--	A.[AuditUpdateDatetime],
--	B.ProductDescription,
--	B.ProductCode,
--	C.AccountCode,
--	C.AccountName
--FROM FeeSchedule A INNER JOIN Product B
--ON A.ProductKey = B.ProductKey
--JOIN Account C
--ON A.AccountKey = C.AccountKey
--AND A.CompanyKey = C.CompanyKey
--WHERE A.ProductKey = @ProductKey
--AND GETDATE() BETWEEN [FeeScheduleStartDate] AND [FeeScheduleEndDate]


--SET NOCOUNT OFF




--GO
--GRANT EXECUTE ON [dbo].[uspFeeScheduleAllByProduct] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspFeeScheduleDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO


--/*****************************************************************
--**	Table Name: FeeSchedule
--**	Procedure Name: uspFeeScheduleDelete
--**	Author: Richard Richards
--**	Created: 07/15/2015
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspFeeScheduleDelete]
--	@FeeScheduleKey int,
--	@key int out
--AS
--SET NOCOUNT ON

--BEGIN TRY
--	DELETE FROM FeeSchedule
--	WHERE [FeeScheduleKey] = @FeeScheduleKey;
	
--	SELECT @key = @@ROWCOUNT;
--END TRY
--BEGIN CATCH
--		EXEC uspLogError 'FeeSchedule', 'uspFeeScheduleDelete';
--	THROW;
--END CATCH

--SET NOCOUNT OFF



--GO
--GRANT EXECUTE ON [dbo].[uspFeeScheduleDelete] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspFeeScheduleGet]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO


--/*****************************************************************
--**	Table Name: FeeSchedule
--**	Procedure Name: uspFeeScheduleGet
--**	Author: Richard Richards
--**	Created: 07/15/2015
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspFeeScheduleGet]
--	@FeeScheduleKey int
--AS
--SET NOCOUNT ON

--SELECT [FeeScheduleKey], 
--	[CompanyKey], 
--	[AccountKey], 
--	[ProductKey], 
--	[FeeScheduleStartDate], 
--	[FeeScheduleEndDate], 
--	[FeeScheduleType], 
--	[FeeScheduleValue], 
--	[AuditAddUserId], 
--	[AuditAddDatetime], 
--	[AuditUpdateUserId], 
--	[AuditUpdateDatetime]
--FROM FeeSchedule
--WHERE [FeeScheduleKey] = @FeeScheduleKey


--SET NOCOUNT OFF




--GO
--GRANT EXECUTE ON [dbo].[uspFeeScheduleGet] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspFeeScheduleGetByCode]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO


--/*****************************************************************
--**	Table Name: FeeSchedule
--**	Procedure Name: uspFeeScheduleGet
--**	Author: Richard Richards
--**	Created: 07/15/2015
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspFeeScheduleGetByCode]
--	@ProductCode varchar(10),
--	@AccountCode varchar(10)
--AS
--SET NOCOUNT ON

--SELECT A.[FeeScheduleKey], 
--	A.[CompanyKey], 
--	A.[AccountKey], 
--	A.[ProductKey], 
--	A.[FeeScheduleStartDate], 
--	A.[FeeScheduleEndDate], 
--	A.[FeeScheduleType], 
--	A.[FeeScheduleValue], 
--	A.[AuditAddUserId], 
--	A.[AuditAddDatetime], 
--	A.[AuditUpdateUserId], 
--	A.[AuditUpdateDatetime]
--FROM FeeSchedule A INNER JOIN Product B
--ON A.ProductKey = B.ProductKey
--INNER JOIN Account C
--ON A.AccountKey = C.AccountKey
--WHERE B.ProductCode = @ProductCode
--AND C.AccountCode = @AccountCode


--SET NOCOUNT OFF



--GO
--GRANT EXECUTE ON [dbo].[uspFeeScheduleGetByCode] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspFeeScheduleUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO



--/*****************************************************************
--**	Table Name: FeeSchedule
--**	Procedure Name: uspFeeScheduleUpsert
--**	Author: Richard Richards
--**	Created: 07/15/2015
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspFeeScheduleUpsert]

--	@FeeScheduleKey int,
--	@CompanyKey int,
--	@AccountKey int,
--	@ProductKey int,
--	@FeeScheduleStartDate datetime,
--	@FeeScheduleEndDate datetime,
--	@FeeScheduleType char(1),
--	@FeeScheduleValue float,
--	@key int out
--AS
--SET NOCOUNT ON
--IF @FeeScheduleKey = 0 BEGIN
--	BEGIN TRY
--	INSERT INTO FeeSchedule (
--		[CompanyKey],
--		[AccountKey],
--		[ProductKey],
--		[FeeScheduleStartDate],
--		[FeeScheduleEndDate],
--		[FeeScheduleType],
--		[FeeScheduleValue]
--	)
--	VALUES (
--		@CompanyKey,
--		@AccountKey,
--		@ProductKey,
--		@FeeScheduleStartDate,
--		@FeeScheduleEndDate,
--		@FeeScheduleType,
--		@FeeScheduleValue
--	)
--	SELECT @key = SCOPE_IDENTITY();
--	END TRY
--	BEGIN CATCH
--		EXEC uspLogError 'FeeSchedule', 'uspFeeScheduleUpsert', 'I';
--		THROW;
--	END CATCH
--END
--ELSE BEGIN
--	BEGIN TRY
--	UPDATE FeeSchedule SET 
--		[CompanyKey] = @CompanyKey,
--		[AccountKey] = @AccountKey,
--		[ProductKey] = @ProductKey,
--		[FeeScheduleStartDate] = @FeeScheduleStartDate,
--		[FeeScheduleEndDate] = @FeeScheduleEndDate,
--		[FeeScheduleType] = @FeeScheduleType,
--		[FeeScheduleValue] = @FeeScheduleValue
--	WHERE [FeeScheduleKey] = @FeeScheduleKey
--		AND ([CompanyKey] <> @CompanyKey
--		OR [AccountKey] <> @AccountKey
--		OR [ProductKey] <> @ProductKey
--		OR [FeeScheduleStartDate] <> @FeeScheduleStartDate
--		OR [FeeScheduleEndDate] <> @FeeScheduleEndDate
--		OR [FeeScheduleType] <> @FeeScheduleType
--		OR [FeeScheduleValue] <> @FeeScheduleValue);
	
--	SELECT @key = @FeeScheduleKey;
--	END TRY
--	BEGIN CATCH
--		EXEC uspLogError 'FeeSchedule', 'uspFeeScheduleUpsert', 'U';
--		THROW;
--	END CATCH
--END

--SET NOCOUNT OFF





--GO
--GRANT EXECUTE ON [dbo].[uspFeeScheduleUpsert] TO [businessuser] AS [dbo]
--GO

/*****************************************************************
**	Table Name: Person
**	Procedure Name: uspPersonAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonAll]
AS
SET NOCOUNT ON

SELECT [PersonKey], 
	[PersonCode], 
	[PersonFirstName], 
	[PersonMiddleInitial], 
	[PersonLastName], 
	[ParentPersonKey], 
	[PersonDob], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Person


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspPersonAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonAllByAccount]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Entity_Person
**	Procedure Name: uspEntity_PersonGetByrel
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonAllByAccount]
	@AccountKey int
AS
SET NOCOUNT ON

SELECT B.[PersonKey], 
	B.[PersonCode], 
	B.[PersonFirstName], 
	B.[PersonMiddleInitial], 
	B.[PersonLastName], 
	B.[ParentPersonKey], 
	B.[PersonDob], 
	B.[AuditAddUserId], 
	B.[AuditAddDatetime], 
	B.[AuditUpdateUserId], 
	B.[AuditUpdateDatetime]
FROM EntityEntity A INNER JOIN Person B
ON A.SecondaryEntityKey = B.PersonKey
AND A.SecondaryEntityTypeKey = 6
INNER JOIN Account C
ON A.PrimaryEntityKey = C.AccountKey
AND A.PrimaryEntityTypeKey = 3
--INNER JOIN PersonType E
--ON A.SecondaryEntityTypeKey = E.PersonTypeKey
WHERE C.AccountKey = @AccountKey

SET NOCOUNT OFF


GO
GRANT EXECUTE ON [dbo].[uspPersonAllByAccount] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonBycreds]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Person
**	Procedure Name: uspPersonBycreds
**	Author: Richard Richards
**	Created: 07/21/2015
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonBycreds]
	@userName varchar(30)
AS
SET NOCOUNT ON

SELECT A.[PersonKey], 
	A.[PersonCode], 
	A.[PersonFirstName], 
	A.[PersonMiddleInitial], 
	A.[PersonLastName], 
	A.[ParentPersonKey], 
	A.[PersonDob], 
	A.[AuditAddUserId], 
	A.[AuditAddDatetime], 
	A.[AuditUpdateUserId], 
	A.[AuditUpdateDatetime]
FROM Person A INNER JOIN Attribute B
ON A.PersonKey = B.EntityKey
AND B.EntityTypeKey = 2
WHERE B.AttributeTypeKey = 5
AND B.AttributeValue = @userName


SET NOCOUNT OFF

GO
GRANT EXECUTE ON [dbo].[uspPersonBycreds] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: Person
**	Procedure Name: uspPersonDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonDelete]
	@PersonKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	--DELETE FROM Person
	--WHERE [PersonKey] = @PersonKey
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Person', 'uspPersonDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspPersonDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonDeleteByCode]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: Person
**	Procedure Name: uspPersonDeleteByCode
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonDeleteByCode]
	@PersonCode varchar(10),
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM Person
	WHERE [PersonCode] = @PersonCode;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Person', 'uspPersonDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspPersonDeleteByCode] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Person
**	Procedure Name: uspPersonGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonGet]
	@PersonKey int
AS
SET NOCOUNT ON

SELECT [PersonKey], 
	[PersonCode], 
	[PersonFirstName], 
	[PersonMiddleInitial], 
	[PersonLastName], 
	[ParentPersonKey], 
	[PersonDob], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Person
WHERE [PersonKey] = @PersonKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspPersonGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonTypeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: PersonType
**	Procedure Name: uspPersonTypeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonTypeAll]
AS
SET NOCOUNT ON

SELECT [PersonTypeKey], 
	[PersonTypeCategory], 
	[PersonTypeCode], 
	[PersonTypeName], 
	[PersonTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM PersonType


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspPersonTypeAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonTypeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: PersonType
**	Procedure Name: uspPersonTypeDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonTypeDelete]
	@PersonTypeKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM PersonType
	WHERE [PersonTypeKey] = @PersonTypeKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'PersonType', 'uspPersonTypeDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspPersonTypeDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonTypeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: PersonType
**	Procedure Name: uspPersonTypeGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonTypeGet]
	@PersonTypeKey int
AS
SET NOCOUNT ON

SELECT [PersonTypeKey], 
	[PersonTypeCategory], 
	[PersonTypeCode], 
	[PersonTypeName], 
	[PersonTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM PersonType
WHERE [PersonTypeKey] = @PersonTypeKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspPersonTypeGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonTypeGetByCategory]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: PersonType
**	Procedure Name: uspPersonTypeGetByCategory
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonTypeGetByCategory]
	@PersonTypeCategory int
AS
SET NOCOUNT ON

SELECT [PersonTypeKey], 
	[PersonTypeCategory], 
	[PersonTypeCode], 
	[PersonTypeName], 
	[PersonTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM PersonType
WHERE [PersonTypeCategory] = @PersonTypeCategory


SET NOCOUNT OFF

GO
GRANT EXECUTE ON [dbo].[uspPersonTypeGetByCategory] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonTypeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: PersonType
**	Procedure Name: uspPersonTypeUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonTypeUpsert]

	@PersonTypeKey int,
	@PersonTypeCategory varchar(50),
	@PersonTypeCode varchar(10),
	@PersonTypeName varchar(50),
	@PersonTypeDescription varchar(150),
	@key int out
AS
SET NOCOUNT ON
IF @PersonTypeKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO PersonType (
		[PersonTypeCategory],
		[PersonTypeCode],
		[PersonTypeName],
		[PersonTypeDescription]
	)
	VALUES (
		@PersonTypeCategory,
		@PersonTypeCode,
		@PersonTypeName,
		@PersonTypeDescription
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'PersonType', 'uspPersonTypeUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE PersonType SET 
		[PersonTypeCategory] = @PersonTypeCategory,
		[PersonTypeCode] = @PersonTypeCode,
		[PersonTypeName] = @PersonTypeName,
		[PersonTypeDescription] = @PersonTypeDescription
	WHERE [PersonTypeKey] = @PersonTypeKey
		AND ([PersonTypeCategory] <> @PersonTypeCategory
		OR [PersonTypeCode] <> @PersonTypeCode
		OR [PersonTypeName] <> @PersonTypeName
		OR [PersonTypeDescription] <> @PersonTypeDescription);
	SELECT @key = @PersonTypeKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'PersonType', 'uspPersonTypeUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspPersonTypeUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspPersonUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: Person
**	Procedure Name: uspPersonUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspPersonUpsert]

	@PersonKey int,
	@PersonCode varchar(50),
	@PersonFirstName varchar(50),
	@PersonMiddleInitial char(1),
	@PersonLastName varchar(50),
	@ParentPersonKey int,
	@PersonDob date,
	@key int out
AS
--SET NOCOUNT ON
IF @PersonKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO Person (
		[PersonCode],
		[PersonFirstName],
		[PersonMiddleInitial],
		[PersonLastName],
		[ParentPersonKey],
		[PersonDob]
	)
	VALUES (
		@PersonCode,
		@PersonFirstName,
		@PersonMiddleInitial,
		@PersonLastName,
		@ParentPersonKey,
		@PersonDob
	)
	SELECT @key = SCOPE_IDENTITY(); -- As InsertedID
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Person', 'uspPersonUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE Person SET 
		[PersonCode] = @PersonCode,
		[PersonFirstName] = @PersonFirstName,
		[PersonMiddleInitial] = @PersonMiddleInitial,
		[PersonLastName] = @PersonLastName,
		[ParentPersonKey] = @ParentPersonKey,
		[PersonDob] = @PersonDob
	WHERE [PersonKey] = @PersonKey
		AND ([PersonCode] <> @PersonCode
		OR [PersonFirstName] <> @PersonFirstName
		OR [PersonMiddleInitial] <> @PersonMiddleInitial
		OR [PersonLastName] <> @PersonLastName
		OR [ParentPersonKey] <> @ParentPersonKey
		OR [PersonDob] <> @PersonDob);

	SELECT @key = @PersonKey

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Person', 'uspPersonUpsert', 'U';
		THROW;
	END CATCH
END

--SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspPersonUpsert] TO [businessuser] AS [dbo]
GO
--/****** Object:  StoredProcedure [dbo].[uspProductAll]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--/*****************************************************************
--**	Table Name: Product
--**	Procedure Name: uspProductAll
--**	Author: Richard Richards
--**	Created: 04/21/2018
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductAll]
--AS
--SET NOCOUNT ON

--SELECT [ProductKey], 
--	[ProductTypeKey], 
--	[ProductCode], 
--	[ProductName], 
--	[ProductDescription], 
--	[ProductName_short], 
--	[ProductName_long], 
--	[ProductImagePath], 
--	[AuditAddUserId], 
--	[AuditAddDatetime], 
--	[AuditUpdateUserId], 
--	[AuditUpdateDatetime]
--FROM Product


--SET NOCOUNT OFF



--GO
--GRANT EXECUTE ON [dbo].[uspProductAll] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspProductAllByAccount]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--/*****************************************************************
--**	Table Name: Product
--**	Procedure Name: uspProductAllByAccount
--**	Author: Richard Richards
--**	Created: 07/05/2015
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductAllByAccount]
--	@AccountKey int
--AS
--SET NOCOUNT ON

--SELECT A.[ProductKey], 
--	A.[ProductTypeKey], 
--	A.[ProductCode], 
--	A.[ProductName], 
--	A.[ProductDescription], 
--	A.[ProductName_short], 
--	A.[ProductName_long], 
--	A.[ProductImagePath], 
--	A.[AuditAddUserId], 
--	A.[AuditAddDatetime], 
--	A.[AuditUpdateUserId], 
--	A.[AuditUpdateDatetime]
--FROM Product A INNER JOIN EntityEntity B
--ON A.ProductKey = B.SecondaryEntityKey
--AND B.SecondaryEntityTypeKey = 4
--AND B.PrimaryEntityKey = @AccountKey
--AND B.PrimaryEntityTypeKey = 3 --Account


--SET NOCOUNT OFF

--GO
--GRANT EXECUTE ON [dbo].[uspProductAllByAccount] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspProductDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO




--/*****************************************************************
--**	Table Name: Product
--**	Procedure Name: uspProductDelete
--**	Author: Richard Richards
--**	Created: 04/21/2018
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductDelete]
--	@ProductKey int,
--	@key int out
--AS
--SET NOCOUNT ON

--BEGIN TRY
--	DELETE FROM EntityEntity
--	WHERE SecondaryEntityKey = @ProductKey
--	AND SecondaryEntityTypeKey = 4;

--	DELETE FROM Product
--	WHERE [ProductKey] = @ProductKey;
--	SELECT @key = @@ROWCOUNT;
--END TRY
--BEGIN CATCH
--		EXEC uspLogError 'Product', 'uspProductDelete';
--	THROW;
--END CATCH

--SET NOCOUNT OFF




--GO
--GRANT EXECUTE ON [dbo].[uspProductDelete] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspProductGet]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--/*****************************************************************
--**	Table Name: Product
--**	Procedure Name: uspProductGet
--**	Author: Richard Richards
--**	Created: 04/21/2018
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductGet]
--	@ProductKey int
--AS
--SET NOCOUNT ON

--SELECT [ProductKey], 
--	[ProductTypeKey], 
--	[ProductCode], 
--	[ProductName], 
--	[ProductDescription], 
--	[ProductName_short], 
--	[ProductName_long], 
--	[ProductImagePath], 
--	[AuditAddUserId], 
--	[AuditAddDatetime], 
--	[AuditUpdateUserId], 
--	[AuditUpdateDatetime]
--FROM Product
--WHERE [ProductKey] = @ProductKey


--SET NOCOUNT OFF



--GO
--GRANT EXECUTE ON [dbo].[uspProductGet] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspProductTypeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--/*****************************************************************
--**	Table Name: ProductType
--**	Procedure Name: uspProductTypeAll
--**	Author: Richard Richards
--**	Created: 04/21/2018
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductTypeAll]
--AS
--SET NOCOUNT ON

--SELECT [ProductTypeKey], 
--	[ProductTypeCategory], 
--	[ProductTypeCode], 
--	[ProductTypeName], 
--	[ProductTypeDescription], 
--	[AuditAddUserId], 
--	[AuditAddDatetime], 
--	[AuditUpdateUserId], 
--	[AuditUpdateDatetime]
--FROM ProductType


--SET NOCOUNT OFF



--GO
--GRANT EXECUTE ON [dbo].[uspProductTypeAll] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspProductTypeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO



--/*****************************************************************
--**	Table Name: ProductType
--**	Procedure Name: uspProductTypeDelete
--**	Author: Richard Richards
--**	Created: 04/21/2018
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductTypeDelete]
--	@ProductTypeKey int,
--	@key int out
--AS
--SET NOCOUNT ON

--BEGIN TRY
--	DELETE FROM ProductType
--	WHERE [ProductTypeKey] = @ProductTypeKey;
--	SELECT @key = @@ROWCOUNT;
--END TRY
--BEGIN CATCH
--		EXEC uspLogError 'ProductType', 'uspProductTypeDelete';
--	THROW;
--END CATCH

--SET NOCOUNT OFF




--GO
--GRANT EXECUTE ON [dbo].[uspProductTypeDelete] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspProductTypeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--/*****************************************************************
--**	Table Name: ProductType
--**	Procedure Name: uspProductTypeGet
--**	Author: Richard Richards
--**	Created: 04/21/2018
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductTypeGet]
--	@ProductTypeKey int
--AS
--SET NOCOUNT ON

--SELECT [ProductTypeKey], 
--	[ProductTypeCategory], 
--	[ProductTypeCode], 
--	[ProductTypeName], 
--	[ProductTypeDescription], 
--	[AuditAddUserId], 
--	[AuditAddDatetime], 
--	[AuditUpdateUserId], 
--	[AuditUpdateDatetime]
--FROM ProductType
--WHERE [ProductTypeKey] = @ProductTypeKey


--SET NOCOUNT OFF



--GO
--GRANT EXECUTE ON [dbo].[uspProductTypeGet] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspProductTypeGetByCategory]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--/*****************************************************************
--**	Table Name: ProductType
--**	Procedure Name: uspProductTypeGetByCategory
--**	Author: Richard Richards
--**	Created: 04/21/2018
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductTypeGetByCategory]
--	@ProductTypeCategory int
--AS
--SET NOCOUNT ON

--SELECT [ProductTypeKey], 
--	[ProductTypeCategory], 
--	[ProductTypeCode], 
--	[ProductTypeName], 
--	[ProductTypeDescription], 
--	[AuditAddUserId], 
--	[AuditAddDatetime], 
--	[AuditUpdateUserId], 
--	[AuditUpdateDatetime]
--FROM ProductType
--WHERE [ProductTypeCategory] = @ProductTypeCategory


--SET NOCOUNT OFF

--GO
--GRANT EXECUTE ON [dbo].[uspProductTypeGetByCategory] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspProductTypeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO





--/*****************************************************************
--**	Table Name: ProductType
--**	Procedure Name: uspProductTypeUpsert
--**	Author: Richard Richards
--**	Created: 04/21/2018
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductTypeUpsert]

--	@ProductTypeKey int,
--	@ProductTypeCategory varchar(50),
--	@ProductTypeCode varchar(10),
--	@ProductTypeName varchar(50),
--	@ProductTypeDescription varchar(150),
--	@key int out
--AS
--SET NOCOUNT ON
--IF @ProductTypeKey = 0 BEGIN
--	BEGIN TRY
--	INSERT INTO ProductType (
--		[ProductTypeCategory],
--		[ProductTypeCode],
--		[ProductTypeName],
--		[ProductTypeDescription]
--	)
--	VALUES (
--		@ProductTypeCategory,
--		@ProductTypeCode,
--		@ProductTypeName,
--		@ProductTypeDescription
--	)
--	SELECT @key = SCOPE_IDENTITY();
--	END TRY
--	BEGIN CATCH
--		EXEC uspLogError 'ProductType', 'uspProductTypeUpsert', 'I';
--		THROW;
--	END CATCH
--END
--ELSE BEGIN
--	BEGIN TRY
--	UPDATE ProductType SET 
--		[ProductTypeCategory] = @ProductTypeCategory,
--		[ProductTypeCode] = @ProductTypeCode,
--		[ProductTypeName] = @ProductTypeName,
--		[ProductTypeDescription] = @ProductTypeDescription
--	WHERE [ProductTypeKey] = @ProductTypeKey
--		AND ([ProductTypeCategory] <> @ProductTypeCategory
--		OR [ProductTypeCode] <> @ProductTypeCode
--		OR [ProductTypeName] <> @ProductTypeName
--		OR [ProductTypeDescription] <> @ProductTypeDescription);
--	SELECT @key = @ProductTypeKey;

--	END TRY
--	BEGIN CATCH
--		EXEC uspLogError 'ProductType', 'uspProductTypeUpsert', 'U';
--		THROW;
--	END CATCH
--END

--SET NOCOUNT OFF







--GO
--GRANT EXECUTE ON [dbo].[uspProductTypeUpsert] TO [businessuser] AS [dbo]
--GO
--/****** Object:  StoredProcedure [dbo].[uspProductUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO





--/*****************************************************************
--**	Table Name: Product
--**	Procedure Name: uspProductUpsert
--**	Author: Richard Richards
--**	Created: 04/21/2018
--**	Copyright: QIQO Software, (c) 2015-2018
--******************************************************************/

--CREATE PROC [dbo].[uspProductUpsert]

--	@ProductKey int,
--	@ProductTypeKey int,
--	@ProductCode varchar(20),
--	@ProductName varchar(150),
--	@ProductDescription varchar(255),
--	@ProductName_short varchar(50),
--	@ProductName_long varchar(255),
--	@ProductImagePath varchar(255),
--	@key int out
--AS
--SET NOCOUNT ON
--IF @ProductKey = 0 BEGIN
--	BEGIN TRY
--	INSERT INTO Product (
--		[ProductTypeKey],
--		[ProductCode],
--		[ProductName],
--		[ProductDescription],
--		[ProductName_short],
--		[ProductName_long],
--		[ProductImagePath]
--	)
--	VALUES (
--		@ProductTypeKey,
--		@ProductCode,
--		@ProductName,
--		@ProductDescription,
--		@ProductName_short,
--		@ProductName_long,
--		@ProductImagePath
--	)
--	SELECT @key = SCOPE_IDENTITY();
--	END TRY
--	BEGIN CATCH
--		EXEC uspLogError 'Product', 'uspProductUpsert', 'I';
--		THROW;
--	END CATCH
--END
--ELSE BEGIN
--	BEGIN TRY
--	UPDATE Product SET 
--		[ProductTypeKey] = @ProductTypeKey,
--		[ProductCode] = @ProductCode,
--		[ProductName] = @ProductName,
--		[ProductDescription] = @ProductDescription,
--		[ProductName_short] = @ProductName_short,
--		[ProductName_long] = @ProductName_long,
--		[ProductImagePath] = @ProductImagePath
--	WHERE [ProductKey] = @ProductKey
--		AND ([ProductTypeKey] <> @ProductTypeKey
--		OR [ProductCode] <> @ProductCode
--		OR [ProductName] <> @ProductName
--		OR [ProductDescription] <> @ProductDescription
--		OR [ProductName_short] <> @ProductName_short
--		OR [ProductName_long] <> @ProductName_long
--		OR [ProductImagePath] <> @ProductImagePath);
--	SELECT @key = @ProductKey;

--	END TRY
--	BEGIN CATCH
--		EXEC uspLogError 'Product', 'uspProductUpsert', 'U';
--		THROW;
--	END CATCH
--END

--SET NOCOUNT OFF







--GO
--GRANT EXECUTE ON [dbo].[uspProductUpsert] TO [businessuser] AS [dbo]
--GO
/****** Object:  Trigger [dbo].[tgrAccountAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAccountAudit]
    ON [dbo].[Account]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [Account] A INNER JOIN inserted B
		ON A.AccountKey = B.AccountKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [Account] A INNER JOIN inserted B
		ON A.AccountKey = B.AccountKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [Account] A INNER JOIN deleted B
		ON A.AccountKey = B.AccountKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'Account'
				   ,'Account'
				   ,@old_xml
				   ,@new_xml)
    END




GO
ALTER TABLE [dbo].[Account] ENABLE TRIGGER [tgrAccountAudit]
GO
/****** Object:  Trigger [dbo].[tgrAccountAuditDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAccountAuditDelete]
    ON [dbo].[Account]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'Account'
				   ,'Account record deleted'
				   ,@old_xml)
    END




GO
ALTER TABLE [dbo].[Account] ENABLE TRIGGER [tgrAccountAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrAccountTypeAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgrAccountTypeAudit]
    ON [dbo].[AccountType]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [AccountType] A INNER JOIN inserted B
		ON A.AccountTypeKey = B.AccountTypeKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [AccountType] A INNER JOIN inserted B
		ON A.AccountTypeKey = B.AccountTypeKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [AccountType] A INNER JOIN deleted B
		ON A.AccountTypeKey = B.AccountTypeKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'AccountType'
				   ,'AccountType'
				   ,@old_xml
				   ,@new_xml)

    END



GO
ALTER TABLE [dbo].[AccountType] ENABLE TRIGGER [tgrAccountTypeAudit]
GO
/****** Object:  Trigger [dbo].[tgrAccountTypeAuditDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgrAccountTypeAuditDelete]
    ON [dbo].[AccountType]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML

		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'AccountType'
				   ,'AccountType record deleted'
				   ,@old_xml
				   )

    END



GO
ALTER TABLE [dbo].[AccountType] ENABLE TRIGGER [tgrAccountTypeAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrAddressAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAddressAudit]
    ON [dbo].[Address]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [Address] A INNER JOIN inserted B
		ON A.AddressKey = B.AddressKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [Address] A INNER JOIN inserted B
		ON A.AddressKey = B.AddressKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [Address] A INNER JOIN deleted B
		ON A.AddressKey = B.AddressKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'Address'
				   ,'Address'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[Address] ENABLE TRIGGER [tgrAddressAudit]
GO
/****** Object:  Trigger [dbo].[tgrAddressAuditDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAddressAuditDelete]
    ON [dbo].[Address]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML

		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'Address'
				   ,'Address record deleted'
				   ,@old_xml
				   )

    END




GO
ALTER TABLE [dbo].[Address] ENABLE TRIGGER [tgrAddressAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrAddressTypeAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAddressTypeAudit]
    ON [dbo].[AddressType]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [AddressType] A INNER JOIN inserted B
		ON A.AddressTypeKey = B.AddressTypeKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [AddressType] A INNER JOIN inserted B
		ON A.AddressTypeKey = B.AddressTypeKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [AddressType] A INNER JOIN deleted B
		ON A.AddressTypeKey = B.AddressTypeKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'AddressType'
				   ,'AddressType'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[AddressType] ENABLE TRIGGER [tgrAddressTypeAudit]
GO
/****** Object:  Trigger [dbo].[tgrAddressTypeAuditDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAddressTypeAuditDelete]
    ON [dbo].[AddressType]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'AddressType'
				   ,'AddressType record deleted'
				   ,@old_xml
				   )

    END




GO
ALTER TABLE [dbo].[AddressType] ENABLE TRIGGER [tgrAddressTypeAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrAttributeAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAttributeAudit]
    ON [dbo].[Attribute]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [Attribute] A INNER JOIN inserted B
		ON A.AttributeKey = B.AttributeKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [Attribute] A INNER JOIN inserted B
		ON A.AttributeKey = B.AttributeKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [Attribute] A INNER JOIN deleted B
		ON A.AttributeKey = B.AttributeKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'Attribute'
				   ,'Attribute'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[Attribute] ENABLE TRIGGER [tgrAttributeAudit]
GO
/****** Object:  Trigger [dbo].[tgrAttributeAuditDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAttributeAuditDelete]
    ON [dbo].[Attribute]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		
		DECLARE @old_xml XML

		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'Attribute'
				   ,'Attribute record deleted'
				   ,@old_xml
				   )

    END




GO
ALTER TABLE [dbo].[Attribute] ENABLE TRIGGER [tgrAttributeAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrAttributeTypeAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAttributeTypeAudit]
    ON [dbo].[AttributeType]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [AttributeType] A INNER JOIN inserted B
		ON A.AttributeTypeKey = B.AttributeTypeKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [AttributeType] A INNER JOIN inserted B
		ON A.AttributeTypeKey = B.AttributeTypeKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [AttributeType] A INNER JOIN deleted B
		ON A.AttributeTypeKey = B.AttributeTypeKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'AttributeType'
				   ,'AttributeType'
				   ,@old_xml
				   ,@new_xml)

    END


GO
ALTER TABLE [dbo].[AttributeType] ENABLE TRIGGER [tgrAttributeTypeAudit]
GO
/****** Object:  Trigger [dbo].[tgrAttributeTypeAuditDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrAttributeTypeAuditDelete]
    ON [dbo].[AttributeType]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML

		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'AttributeType'
				   ,'AttributeType record deleted'
				   ,@old_xml
				   )

    END


GO
ALTER TABLE [dbo].[AttributeType] ENABLE TRIGGER [tgrAttributeTypeAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrAuditLogAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO


--CREATE TRIGGER [dbo].[tgrAuditLogAudit]
--    ON [dbo].[ChangeDataAuditLog]
--    FOR INSERT, UPDATE
--    AS
--    BEGIN
--        SET NOCOUNT ON

--		UPDATE A SET
--			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
--			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
--			A.AuditUpdateDatetime = GETDATE(),
--			A.AuditUpdateUserId = SUSER_SNAME()
--		FROM [ChangeDataAuditLog] A INNER JOIN inserted B
--		ON A.AuditLogKey = B.AuditLogKey

--    END



--GO
--ALTER TABLE [dbo].[ChangeDataAuditLog] ENABLE TRIGGER [tgrAuditLogAudit]
--GO
/****** Object:  Trigger [dbo].[tgrCommentAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgrCommentAudit]
    ON [dbo].[Comment]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [Comment] A INNER JOIN inserted B
		ON A.CommentKey = B.CommentKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [Comment] A INNER JOIN inserted B
		ON A.CommentKey = B.CommentKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [Comment] A INNER JOIN deleted B
		ON A.CommentKey = B.CommentKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'Comment'
				   ,'Comment'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[Comment] ENABLE TRIGGER [tgrCommentAudit]
GO
/****** Object:  Trigger [dbo].[tgrCommentAuditDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgrCommentAuditDelete]
    ON [dbo].[Comment]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		
		DECLARE @old_xml XML

		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'Comment'
				   ,'Comment record deleted'
				   ,@old_xml
				   )

    END




GO
ALTER TABLE [dbo].[Comment] ENABLE TRIGGER [tgrCommentAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrCommentTypeAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgrCommentTypeAudit]
    ON [dbo].[CommentType]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [CommentType] A INNER JOIN inserted B
		ON A.CommentTypeKey = B.CommentTypeKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [CommentType] A INNER JOIN inserted B
		ON A.CommentTypeKey = B.CommentTypeKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [CommentType] A INNER JOIN deleted B
		ON A.CommentTypeKey = B.CommentTypeKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'CommentType'
				   ,'CommentType'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[CommentType] ENABLE TRIGGER [tgrCommentTypeAudit]
GO
/****** Object:  Trigger [dbo].[tgrCommentTypeAuditDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgrCommentTypeAuditDelete]
    ON [dbo].[CommentType]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'CommentType'
				   ,'CommentType record deleted'
				   ,@old_xml
				   )

    END




GO
ALTER TABLE [dbo].[CommentType] ENABLE TRIGGER [tgrCommentTypeAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrCompanyAudit]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrCompanyAudit]
    ON [dbo].[Company]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [Company] A INNER JOIN inserted B
		ON A.CompanyKey = B.CompanyKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [Company] A INNER JOIN inserted B
		ON A.CompanyKey = B.CompanyKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [Company] A INNER JOIN deleted B
		ON A.CompanyKey = B.CompanyKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'Company'
				   ,'Company'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[Company] ENABLE TRIGGER [tgrCompanyAudit]
GO
/****** Object:  Trigger [dbo].[tgrCompanyAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrCompanyAuditDelete]
    ON [dbo].[Company]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'Company'
				   ,'Company record deleted'
				   ,@old_xml
				   )

    END




GO
ALTER TABLE [dbo].[Company] ENABLE TRIGGER [tgrCompanyAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrContactAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrContactAudit]
    ON [dbo].[Contact]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [Contact] A INNER JOIN inserted B
		ON A.ContactKey = B.ContactKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [Contact] A INNER JOIN inserted B
		ON A.ContactKey = B.ContactKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [Contact] A INNER JOIN deleted B
		ON A.ContactKey = B.ContactKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'Contact'
				   ,'Contact'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[Contact] ENABLE TRIGGER [tgrContactAudit]
GO
/****** Object:  Trigger [dbo].[tgrContactAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrContactAuditDelete]
    ON [dbo].[Contact]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'Contact'
				   ,'Contact record deleted'
				   ,@old_xml
				   )

    END




GO
ALTER TABLE [dbo].[Contact] ENABLE TRIGGER [tgrContactAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrContactTypeAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrContactTypeAudit]
    ON [dbo].[ContactType]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [ContactType] A INNER JOIN inserted B
		ON A.ContactTypeKey = B.ContactTypeKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [ContactType] A INNER JOIN inserted B
		ON A.ContactTypeKey = B.ContactTypeKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [ContactType] A INNER JOIN deleted B
		ON A.ContactTypeKey = B.ContactTypeKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'ContactType'
				   ,'ContactType'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[ContactType] ENABLE TRIGGER [tgrContactTypeAudit]
GO
/****** Object:  Trigger [dbo].[tgrContactTypeAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrContactTypeAuditDelete]
    ON [dbo].[ContactType]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'ContactType'
				   ,'ContactType record deleted'
				   ,@old_xml
				   )

    END




GO
ALTER TABLE [dbo].[ContactType] ENABLE TRIGGER [tgrContactTypeAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrEntityEntityAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrEntityEntityAudit]
    ON [dbo].[EntityEntity]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [EntityEntity] A INNER JOIN inserted B
		ON A.EntityEntityKey = B.EntityEntityKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [EntityEntity] A INNER JOIN inserted B
		ON A.EntityEntityKey = B.EntityEntityKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [EntityEntity] A INNER JOIN deleted B
		ON A.EntityEntityKey = B.EntityEntityKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'EntityEntity'
				   ,'EntityEntity'
				   ,@old_xml
				   ,@new_xml)

    END


GO
ALTER TABLE [dbo].[EntityEntity] ENABLE TRIGGER [tgrEntityEntityAudit]
GO
/****** Object:  Trigger [dbo].[tgrEntityEntityAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrEntityEntityAuditDelete]
    ON [dbo].[EntityEntity]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'EntityEntity'
				   ,'EntityEntity record deleted'
				   ,@old_xml
				   )

    END


GO
ALTER TABLE [dbo].[EntityEntity] ENABLE TRIGGER [tgrEntityEntityAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrEntityRoleAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE TRIGGER [dbo].[tgrEntityRoleAudit]
    ON [dbo].[EntityRole]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [EntityRole] A INNER JOIN inserted B
		ON A.EntityRoleKey = B.EntityRoleKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [EntityRole] A INNER JOIN inserted B
		ON A.EntityRoleKey = B.EntityRoleKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [EntityRole] A INNER JOIN deleted B
		ON A.EntityRoleKey = B.EntityRoleKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'EntityRole'
				   ,'EntityRole'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[EntityRole] ENABLE TRIGGER [tgrEntityRoleAudit]
GO
/****** Object:  Trigger [dbo].[tgrEntityRoleAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE TRIGGER [dbo].[tgrEntityRoleAuditDelete]
    ON [dbo].[EntityRole]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML

		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'EntityRole'
				   ,'EntityRole record deleted'
				   ,@old_xml
				   )

    END




GO
ALTER TABLE [dbo].[EntityRole] ENABLE TRIGGER [tgrEntityRoleAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrEntityTypeAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE TRIGGER [dbo].[tgrEntityTypeAudit]
    ON [dbo].[EntityType]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [EntityType] A INNER JOIN inserted B
		ON A.EntityTypeKey = B.EntityTypeKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [EntityType] A INNER JOIN inserted B
		ON A.EntityTypeKey = B.EntityTypeKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [EntityType] A INNER JOIN deleted B
		ON A.EntityTypeKey = B.EntityTypeKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'EntityType'
				   ,'EntityType'
				   ,@old_xml
				   ,@new_xml)

    END





GO
ALTER TABLE [dbo].[EntityType] ENABLE TRIGGER [tgrEntityTypeAudit]
GO
/****** Object:  Trigger [dbo].[tgrEntityTypeAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE TRIGGER [dbo].[tgrEntityTypeAuditDelete]
    ON [dbo].[EntityType]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'EntityType'
				   ,'EntityType record deleted'
				   ,@old_xml)

    END





GO
ALTER TABLE [dbo].[EntityType] ENABLE TRIGGER [tgrEntityTypeAuditDelete]
GO
--/****** Object:  Trigger [dbo].[tgrFeeScheduleAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TRIGGER [dbo].[tgrFeeScheduleAudit]
--    ON [dbo].[FeeSchedule]
--    FOR INSERT, UPDATE
--    AS
--    BEGIN
--        SET NOCOUNT ON

--		UPDATE A SET
--			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
--			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
--			A.AuditUpdateDatetime = GETDATE(),
--			A.AuditUpdateUserId = SUSER_SNAME()
--		FROM [FeeSchedule] A INNER JOIN inserted B
--		ON A.FeeScheduleKey = B.FeeScheduleKey

--		DECLARE @old_xml XML, @new_xml XML

--		SELECT @new_xml = (SELECT B.* 
--		FROM [FeeSchedule] A INNER JOIN inserted B
--		ON A.FeeScheduleKey = B.FeeScheduleKey
--		FOR XML RAW, ELEMENTS)

--		SELECT @old_xml = (SELECT B.* 
--		FROM [FeeSchedule] A INNER JOIN deleted B
--		ON A.FeeScheduleKey = B.FeeScheduleKey
--		FOR XML RAW, ELEMENTS)

--		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
--		INSERT INTO [dbo].[ChangeDataAuditLog]
--				   ([Action]
--				   ,[BusinessObject]
--				   ,[Comment]
--				   ,[DataOld]
--				   ,[DataNew])
--			 VALUES
--				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
--						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
--						ELSE 'U' END
--				   ,'FeeSchedule'
--				   ,'FeeSchedule'
--				   ,@old_xml
--				   ,@new_xml)

--    END




--GO
--ALTER TABLE [dbo].[FeeSchedule] ENABLE TRIGGER [tgrFeeScheduleAudit]
--GO
--/****** Object:  Trigger [dbo].[tgrFeeScheduleAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TRIGGER [dbo].[tgrFeeScheduleAuditDelete]
--    ON [dbo].[FeeSchedule]
--    AFTER DELETE
--    AS
--    BEGIN
--        SET NOCOUNT ON
--		DECLARE @old_xml XML
--		SELECT @old_xml = (SELECT B.* 
--		FROM deleted B
--		FOR XML RAW, ELEMENTS)

--		IF (@old_xml IS NOT NULL)
--		INSERT INTO [dbo].[ChangeDataAuditLog]
--				   ([Action]
--				   ,[BusinessObject]
--				   ,[Comment]
--				   ,[DataOld]
--				   )
--			 VALUES
--				   ('D' 
--				   ,'FeeSchedule'
--				   ,'FeeSchedule record deleted'
--				   ,@old_xml)

--    END




--GO
--ALTER TABLE [dbo].[FeeSchedule] ENABLE TRIGGER [tgrFeeScheduleAuditDelete]
--GO
/****** Object:  Trigger [dbo].[tgrPersonAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrPersonAudit]
    ON [dbo].[Person]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [Person] A INNER JOIN inserted B
		ON A.PersonKey = B.PersonKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [Person] A INNER JOIN inserted B
		ON A.PersonKey = B.PersonKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [Person] A INNER JOIN deleted B
		ON A.PersonKey = B.PersonKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'Person'
				   ,'Person'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[Person] ENABLE TRIGGER [tgrPersonAudit]
GO
/****** Object:  Trigger [dbo].[tgrPersonAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrPersonAuditDelete]
    ON [dbo].[Person]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'Person'
				   ,'Person record deleted'
				   ,@old_xml)

    END




GO
ALTER TABLE [dbo].[Person] ENABLE TRIGGER [tgrPersonAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrPersonTypeAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgrPersonTypeAudit]
    ON [dbo].[PersonType]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [PersonType] A INNER JOIN inserted B
		ON A.PersonTypeKey = B.PersonTypeKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [PersonType] A INNER JOIN inserted B
		ON A.PersonTypeKey = B.PersonTypeKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [PersonType] A INNER JOIN deleted B
		ON A.PersonTypeKey = B.PersonTypeKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew])
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'PersonType'
				   ,'PersonType'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[PersonType] ENABLE TRIGGER [tgrPersonTypeAudit]
GO
/****** Object:  Trigger [dbo].[tgrPersonTypeAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[tgrPersonTypeAuditDelete]
    ON [dbo].[PersonType]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'PersonType'
				   ,'PersonType record deleted'
				   ,@old_xml)

    END




GO
ALTER TABLE [dbo].[PersonType] ENABLE TRIGGER [tgrPersonTypeAuditDelete]
GO
--/****** Object:  Trigger [dbo].[tgrProductAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TRIGGER [dbo].[tgrProductAudit]
--    ON [dbo].[Product]
--    FOR INSERT, UPDATE
--    AS
--    BEGIN
--        SET NOCOUNT ON

--		UPDATE A SET
--			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
--			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
--			A.AuditUpdateDatetime = GETDATE(),
--			A.AuditUpdateUserId = SUSER_SNAME()
--		FROM [Product] A INNER JOIN inserted B
--		ON A.ProductKey = B.ProductKey

--		DECLARE @old_xml XML, @new_xml XML

--		SELECT @new_xml = (SELECT B.* 
--		FROM [Product] A INNER JOIN inserted B
--		ON A.ProductKey = B.ProductKey
--		FOR XML RAW, ELEMENTS)

--		SELECT @old_xml = (SELECT B.* 
--		FROM [Product] A INNER JOIN deleted B
--		ON A.ProductKey = B.ProductKey
--		FOR XML RAW, ELEMENTS)

--		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
--		INSERT INTO [dbo].[ChangeDataAuditLog]
--				   ([Action]
--				   ,[BusinessObject]
--				   ,[Comment]
--				   ,[DataOld]
--				   ,[DataNew])
--			 VALUES
--				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
--						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
--						ELSE 'U' END
--				   ,'Product'
--				   ,'Product'
--				   ,@old_xml
--				   ,@new_xml)

--    END




--GO
--ALTER TABLE [dbo].[Product] ENABLE TRIGGER [tgrProductAudit]
--GO
--/****** Object:  Trigger [dbo].[tgrProductAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TRIGGER [dbo].[tgrProductAuditDelete]
--    ON [dbo].[Product]
--    AFTER DELETE
--    AS
--    BEGIN
--        SET NOCOUNT ON
--		DECLARE @old_xml XML
--		SELECT @old_xml = (SELECT B.* 
--		FROM deleted B
--		FOR XML RAW, ELEMENTS)

--		IF (@old_xml IS NOT NULL)
--		INSERT INTO [dbo].[ChangeDataAuditLog]
--				   ([Action]
--				   ,[BusinessObject]
--				   ,[Comment]
--				   ,[DataOld]
--				   )
--			 VALUES
--				   ('D' 
--				   ,'Product'
--				   ,'Product record deleted'
--				   ,@old_xml)

--    END




--GO
--ALTER TABLE [dbo].[Product] ENABLE TRIGGER [tgrProductAuditDelete]
--GO
--/****** Object:  Trigger [dbo].[tgrProductTypeAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TRIGGER [dbo].[tgrProductTypeAudit]
--    ON [dbo].[ProductType]
--    FOR INSERT, UPDATE
--    AS
--    BEGIN
--        SET NOCOUNT ON

--		UPDATE A SET
--			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
--			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
--			A.AuditUpdateDatetime = GETDATE(),
--			A.AuditUpdateUserId = SUSER_SNAME()
--		FROM [ProductType] A INNER JOIN inserted B
--		ON A.ProductTypeKey = B.ProductTypeKey

--		DECLARE @old_xml XML, @new_xml XML

--		SELECT @new_xml = (SELECT B.* 
--		FROM [ProductType] A INNER JOIN inserted B
--		ON A.ProductTypeKey = B.ProductTypeKey
--		FOR XML RAW, ELEMENTS)

--		SELECT @old_xml = (SELECT B.* 
--		FROM [ProductType] A INNER JOIN deleted B
--		ON A.ProductTypeKey = B.ProductTypeKey
--		FOR XML RAW, ELEMENTS)

--		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
--		INSERT INTO [dbo].[ChangeDataAuditLog]
--				   ([Action]
--				   ,[BusinessObject]
--				   ,[Comment]
--				   ,[DataOld]
--				   ,[DataNew])
--			 VALUES
--				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
--						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
--						ELSE 'U' END
--				   ,'ProductType'
--				   ,'ProductType'
--				   ,@old_xml
--				   ,@new_xml)

--    END




--GO
--ALTER TABLE [dbo].[ProductType] ENABLE TRIGGER [tgrProductTypeAudit]
--GO
--/****** Object:  Trigger [dbo].[tgrProductTypeAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--CREATE TRIGGER [dbo].[tgrProductTypeAuditDelete]
--    ON [dbo].[ProductType]
--    AFTER DELETE
--    AS
--    BEGIN
--        SET NOCOUNT ON
--		DECLARE @old_xml XML
--		SELECT @old_xml = (SELECT B.* 
--		FROM deleted B
--		FOR XML RAW, ELEMENTS)

--		IF (@old_xml IS NOT NULL)
--		INSERT INTO [dbo].[ChangeDataAuditLog]
--				   ([Action]
--				   ,[BusinessObject]
--				   ,[Comment]
--				   ,[DataOld]
--				   )
--			 VALUES
--				   ('D' 
--				   ,'ProductType'
--				   ,'ProductType record deleted'
--				   ,@old_xml)

--    END




--GO
--ALTER TABLE [dbo].[ProductType] ENABLE TRIGGER [tgrProductTypeAuditDelete]
--GO



/****** Object:  StoredProcedure [dbo].[uspLedgerAll]    Script Date: 9/3/2022 9:56:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*****************************************************************
**	Table Name: Ledger
**	Procedure Name: uspLedgerAll
**	Author: Richard Richards
**	Created: 06/23/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerAll]
	@CompanyKey int
AS
SET NOCOUNT ON

SELECT [LedgerKey], 
	[CompanyKey], 
	--[coaKey], 
	[LedgerCode], 
	[LedgerName], 
	[LedgerDescription], 
	[AuditAddUserId], 
	[AuditAddDateTime], 
	[AuditUpdateUserId], 
	[AuditUpdateDateTime]
FROM Ledger
WHERE CompanyKey = @CompanyKey


SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspLedgerAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspLedgerDel]    Script Date: 9/3/2022 9:56:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*****************************************************************
**	Table Name: Ledger
**	Procedure Name: uspLedgerDel
**	Author: Richard Richards
**	Created: 06/23/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerDel]
	@LedgerKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	--DELETE FROM Ledger
	--WHERE [LedgerKey] = @LedgerKey
	RETURN 1;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Ledger', 'uspLedgerDel';
	THROW;
END CATCH

SET NOCOUNT OFF





GO
GRANT EXECUTE ON [dbo].[uspLedgerDel] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspLedgerGet]    Script Date: 9/3/2022 9:56:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*****************************************************************
**	Table Name: Ledger
**	Procedure Name: uspLedgerGet
**	Author: Richard Richards
**	Created: 06/23/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerGet]
	@LedgerKey int
AS
SET NOCOUNT ON

SELECT [LedgerKey], 
	[CompanyKey], 
	--[coaKey], 
	[LedgerCode], 
	[LedgerName], 
	[LedgerDescription], 
	[AuditAddUserId], 
	[AuditAddDateTime], 
	[AuditUpdateUserId], 
	[AuditUpdateDateTime]
FROM Ledger
WHERE [LedgerKey] = @LedgerKey


SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspLedgerGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspLedgerGetByCode]    Script Date: 9/3/2022 9:56:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*****************************************************************
**	Table Name: Ledger
**	Procedure Name: uspLedgerGet
**	Author: Richard Richards
**	Created: 06/23/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerGetByCode]
	@LedgerCode varchar(10)
AS
SET NOCOUNT ON

SELECT [LedgerKey], 
	[CompanyKey], 
	--[coaKey], 
	[LedgerCode], 
	[LedgerName], 
	[LedgerDescription], 
	[AuditAddUserId], 
	[AuditAddDateTime], 
	[AuditUpdateUserId], 
	[AuditUpdateDateTime]
FROM Ledger
WHERE [LedgerCode] = @LedgerCode


SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspLedgerGetByCode] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspLedgerTxnAll]    Script Date: 9/3/2022 9:56:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*****************************************************************
**	Table Name: LedgerTxn
**	Procedure Name: uspLedgerTxnAll
**	Author: Richard Richards
**	Created: 06/23/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerTxnAll]
	@LedgerKey int
AS
SET NOCOUNT ON

SELECT [LedgerTxnKey], 
	[LedgerKey], 
	TxnComment,
	[AccountFrom], 
	[DepartmentFrom], 
	[LineOfBusinessFrom], 
	[AccountTo], 
	[DepartmentTo], 
	[LineOfBusinessTo], 
	[TxnNumber], 
	[PostDate], 
	[EntryDate], 
	[Credit], 
	[Debit], 
	A.EntityKey,
	A.EntityTypeKey,
	[AuditAddUserId], 
	[AuditAddDateTime], 
	[AuditUpdateUserId], 
	[AuditUpdateDateTime]
FROM LedgerTxn A
WHERE A.LedgerKey = @LedgerKey


SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspLedgerTxnAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspLedgerTxnAllByCode]    Script Date: 9/3/2022 9:56:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*****************************************************************
**	Table Name: LedgerTxn
**	Procedure Name: uspLedgerTxnAllByCode]
**	Author: Richard Richards
**	Created: 07/14/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerTxnAllByCode]
	@LedgerCode varchar(10)
AS
SET NOCOUNT ON

SELECT A.[LedgerTxnKey], 
	A.[LedgerKey], 
	A.TxnComment,
	A.[AccountFrom], 
	A.[DepartmentFrom], 
	A.[LineOfBusinessFrom], 
	A.[AccountTo], 
	A.[DepartmentTo], 
	A.[LineOfBusinessTo], 
	A.[TxnNumber], 
	A.[PostDate], 
	A.[EntryDate], 
	A.[Credit], 
	A.[Debit], 
	A.EntityKey,
	A.EntityTypeKey,
	A.[AuditAddUserId], 
	A.[AuditAddDateTime], 
	A.[AuditUpdateUserId], 
	A.[AuditUpdateDateTime]
FROM LedgerTxn A INNER JOIN Ledger B
ON A.LedgerKey = B.LedgerKey
WHERE B.LedgerCode = @LedgerCode


SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspLedgerTxnAllByCode] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspLedgerTxnDel]    Script Date: 9/3/2022 9:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*****************************************************************
**	Table Name: LedgerTxn
**	Procedure Name: uspLedgerTxnDel
**	Author: Richard Richards
**	Created: 06/23/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerTxnDel]
	@LedgerTxnKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	--DELETE FROM LedgerTxn
	--WHERE [LedgerTxnKey] = @LedgerTxnKey
	RETURN 1;
END TRY
BEGIN CATCH
		EXEC uspLogError 'LedgerTxn', 'uspLedgerTxnDel';
	THROW;
END CATCH

SET NOCOUNT OFF





GO
GRANT EXECUTE ON [dbo].[uspLedgerTxnDel] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspLedgerTxnGet]    Script Date: 9/3/2022 9:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*****************************************************************
**	Table Name: LedgerTxn
**	Procedure Name: uspLedgerTxnGet
**	Author: Richard Richards
**	Created: 06/23/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerTxnGet]
	@LedgerTxnKey bigint
AS
SET NOCOUNT ON

SELECT [LedgerTxnKey], 
	[LedgerKey], 
	TxnComment,
	[AccountFrom], 
	[DepartmentFrom], 
	[LineOfBusinessFrom], 
	[AccountTo], 
	[DepartmentTo], 
	[LineOfBusinessTo], 
	[TxnNumber], 
	[PostDate], 
	[EntryDate], 
	[Credit], 
	[Debit], 
	EntityKey,
	EntityTypeKey,
	[AuditAddUserId], 
	[AuditAddDateTime], 
	[AuditUpdateUserId], 
	[AuditUpdateDateTime]
FROM LedgerTxn
WHERE [LedgerTxnKey] = @LedgerTxnKey


SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspLedgerTxnGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspLedgerTxnUpsert]    Script Date: 9/3/2022 9:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/*****************************************************************
**	Table Name: LedgerTxn
**	Procedure Name: uspLedgerTxnUpsert
**	Author: Richard Richards
**	Created: 06/23/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerTxnUpsert]
	@LedgerTxnKey bigint,
	@LedgerKey int,
	@TxnComment varchar(50),
	@AccountFrom varchar(10),
	@DepartmentFrom varchar(10),
	@LineOfBusinessFrom varchar(10),
	@AccountTo varchar(10),
	@DepartmentTo varchar(10),
	@LineOfBusinessTo varchar(10),
	@TxnNumber int,
	@PostDate datetime,
	@EntryDate datetime,
	@Credit money,
	@Debit money,
	@EntityKey int,
	@EntityTypeKey int,
	@key int out
AS
SET NOCOUNT ON
IF @LedgerTxnKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO LedgerTxn (-- [LedgerTxnKey],
		[LedgerKey],
		TxnComment,
		[AccountFrom],
		[DepartmentFrom],
		[LineOfBusinessFrom],
		[AccountTo],
		[DepartmentTo],
		[LineOfBusinessTo],
		[TxnNumber],
		[PostDate],
		[EntryDate],
		[Credit],
		[Debit]
		,EntityKey
		,EntityTypeKey
	)
	VALUES (-- @newKey,
		@LedgerKey,
		@TxnComment,
		@AccountFrom,
		@DepartmentFrom,
		@LineOfBusinessFrom,
		@AccountTo,
		@DepartmentTo,
		@LineOfBusinessTo,
		@TxnNumber,
		@PostDate,
		@EntryDate,
		@Credit,
		@Debit,
		@EntityKey,
		@EntityTypeKey
	)
	SELECT @key = @@IDENTITY;
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'LedgerTxn', 'uspLedgerTxnUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE LedgerTxn SET 
		[LedgerKey] = @LedgerKey,
		TxnComment = @TxnComment,
		[AccountFrom] = @AccountFrom,
		[DepartmentFrom] = @DepartmentFrom,
		[LineOfBusinessFrom] = @LineOfBusinessFrom,
		[AccountTo] = @AccountTo,
		[DepartmentTo] = @DepartmentTo,
		[LineOfBusinessTo] = @LineOfBusinessTo,
		[TxnNumber] = @TxnNumber,
		[PostDate] = @PostDate,
		[EntryDate] = @EntryDate,
		[Credit] = @Credit,
		[Debit] = @Debit,
		EntityKey = @EntityKey,
		EntityTypeKey = @EntityTypeKey
	WHERE [LedgerTxnKey] = @LedgerTxnKey;
	SELECT @key = @LedgerTxnKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'LedgerTxn', 'uspLedgerTxnUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF








GO
GRANT EXECUTE ON [dbo].[uspLedgerTxnUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspLedgerUpsert]    Script Date: 9/3/2022 9:56:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






/*****************************************************************
**	Table Name: Ledger
**	Procedure Name: uspLedgerUpsert
**	Author: Richard Richards
**	Created: 06/23/2015
**	Copyright: QIQO Software, (c) 2015
******************************************************************/

CREATE PROC [dbo].[uspLedgerUpsert]

	@LedgerKey int,
	@CompanyKey int,
	--@coaKey int,
	@LedgerCode varchar(10),
	@LedgerName varchar(50),
	@LedgerDescription varchar(255),
	@key int out
AS
SET NOCOUNT ON
IF @LedgerKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO Ledger (--[LedgerKey],
		[CompanyKey],
		--[coaKey],
		[LedgerCode],
		[LedgerName],
		[LedgerDescription]
	)
	VALUES (--@newKey,
		@CompanyKey,
		--@coaKey,
		@LedgerCode,
		@LedgerName,
		@LedgerDescription
	)
	SELECT @key = @@IDENTITY;
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Ledger', 'uspLedgerUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE Ledger SET 
		[CompanyKey] = @CompanyKey,
		--[coaKey] = @coaKey,
		[LedgerCode] = @LedgerCode,
		[LedgerName] = @LedgerName,
		[LedgerDescription] = @LedgerDescription
	WHERE [LedgerKey] = @LedgerKey;
	SELECT @key = @LedgerKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Ledger', 'uspLedgerUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF



/****** Object:  Trigger [dbo].[tgrLedgerAuditDel]    Script Date: 9/3/2022 10:13:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrLedgerAuditDel]
    ON [dbo].[Ledger]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'Ledger'
				   ,'Ledger record deleted'
				   ,@old_xml)

    END




GO
ALTER TABLE [dbo].[Ledger] ENABLE TRIGGER [tgrLedgerAuditDel]
GO
/****** Object:  Trigger [dbo].[tgrLedgerAudit]    Script Date: 9/3/2022 10:13:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrLedgerAudit]
    ON [dbo].[Ledger]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDateTime = ISNULL(A.AuditAddDateTime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDateTime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [Ledger] A INNER JOIN inserted B
		ON A.LedgerKey = B.LedgerKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [Ledger] A INNER JOIN inserted B
		ON A.LedgerKey = B.LedgerKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [Ledger] A INNER JOIN deleted B
		ON A.LedgerKey = B.LedgerKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew]
				   )
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'Ledger'
				   ,'Ledger'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[Ledger] ENABLE TRIGGER [tgrLedgerAudit]
GO
/****** Object:  Trigger [dbo].[tgrLedgerTxnAuditDel]    Script Date: 9/3/2022 10:13:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrLedgerTxnAuditDel]
    ON [dbo].[LedgerTxn]
    AFTER DELETE
    AS
    BEGIN
        SET NOCOUNT ON
		DECLARE @old_xml XML
		SELECT @old_xml = (SELECT B.* 
		FROM deleted B
		FOR XML RAW, ELEMENTS)

		IF (@old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   )
			 VALUES
				   ('D' 
				   ,'LedgerTxn'
				   ,'LedgerTxn record deleted'
				   ,@old_xml)

    END


GO
ALTER TABLE [dbo].[LedgerTxn] ENABLE TRIGGER [tgrLedgerTxnAuditDel]
GO
/****** Object:  Trigger [dbo].[tgrLedgerTxnAudit]    Script Date: 9/3/2022 10:13:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrLedgerTxnAudit]
    ON [dbo].[LedgerTxn]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDateTime = ISNULL(A.AuditAddDateTime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDateTime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [LedgerTxn] A INNER JOIN inserted B
		ON A.LedgerTxnKey = B.LedgerTxnKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [LedgerTxn] A INNER JOIN inserted B
		ON A.LedgerTxnKey = B.LedgerTxnKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [LedgerTxn] A INNER JOIN deleted B
		ON A.LedgerTxnKey = B.LedgerTxnKey
		FOR XML RAW, ELEMENTS)

		IF (@new_xml IS NOT NULL OR @old_xml IS NOT NULL)
		INSERT INTO [dbo].[ChangeDataAuditLog]
				   ([Action]
				   ,[BusinessObject]
				   ,[Comment]
				   ,[DataOld]
				   ,[DataNew]
				   )
			 VALUES
				   (CASE -- WHEN @old_xml IS NULL AND @new_xml IS NULL THEN 'D' 
						WHEN @old_xml IS NULL AND @new_xml IS NOT NULL THEN 'I'
						ELSE 'U' END
				   ,'LedgerTxn'
				   ,'LedgerTxn'
				   ,@old_xml
				   ,@new_xml)

    END


GO
ALTER TABLE [dbo].[LedgerTxn] ENABLE TRIGGER [tgrLedgerTxnAudit]
GO





GO
GRANT EXECUTE ON [dbo].[uspLedgerUpsert] TO [businessuser] AS [dbo]
GO

USE [master]
GO
ALTER DATABASE [CompanyManagement] SET  READ_WRITE 
GO
