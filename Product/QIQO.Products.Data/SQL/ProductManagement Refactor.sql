USE [master]
GO
/****** Object:  Database [ProductManagement]    Script Date: 7/10/2022 12:46:10 PM ******/
CREATE DATABASE [ProductManagement]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'ProductManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.D1\MSSQL\DATA\ProductManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'ProductManagement_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.D1\MSSQL\DATA\ProductManagement_Log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
-- WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProductManagement] SET COMPATIBILITY_LEVEL = 150
GO

ALTER DATABASE [ProductManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [ProductManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ProductManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProductManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProductManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProductManagement', N'ON'
GO
ALTER DATABASE [ProductManagement] SET QUERY_STORE = OFF
GO
USE [ProductManagement]
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

/****** Object:  Table [dbo].[Product]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductKey] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeKey] [int] NOT NULL,
	[ProductCode] [varchar](20) NOT NULL,
	[ProductName] [varchar](150) NOT NULL,
	[ProductDescription] [varchar](255) NULL,
	[ProductName_short] [varchar](50) NOT NULL,
	[ProductName_long] [varchar](255) NOT NULL,
	[ProductImagePath] [varchar](255) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__Product__] PRIMARY KEY CLUSTERED 
(
	[ProductKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductType]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductType](
	[ProductTypeKey] [int] IDENTITY(1,1) NOT NULL,
	[ProductTypeCategory] [varchar](50) NOT NULL,
	[ProductTypeCode] [varchar](10) NOT NULL,
	[ProductTypeName] [varchar](50) NOT NULL,
	[ProductTypeDescription] [varchar](150) NOT NULL,
	[AuditAddUserId] [varchar](30) NOT NULL,
	[AuditAddDatetime] [datetime] NOT NULL,
	[AuditUpdateUserId] [varchar](30) NOT NULL,
	[AuditUpdateDatetime] [datetime] NOT NULL,
 CONSTRAINT [PK__ProductType__] PRIMARY KEY CLUSTERED 
(
	[ProductTypeKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Index [NonClusteredIndex-20150705-155746]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex-20150705-155746] ON [dbo].[ChangeDataAuditLog]
(
	[BusinessObject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [NonClusteredIndex-20150801-131647]    Script Date: 7/10/2022 12:46:11 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex-20150801-131647] ON [dbo].[Product]
(
	[ProductTypeKey] ASC,
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
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
ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (getdate()) FOR [AuditDateTime]
GO
ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (suser_sname()) FOR [UserId]
GO
ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (('App=('+rtrim(isnull(app_name(),'')))+') ') FOR [Application]
GO
ALTER TABLE [dbo].[ChangeDataAuditLog] ADD  DEFAULT (host_name()) FOR [Host]
GO

ALTER TABLE [dbo].[ErrorLog] ADD  CONSTRAINT [DF_ErrorLog_ErrorDateTime]  DEFAULT (getdate()) FOR [ErrorDateTime]
GO

ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product_Audita__7F2BE32F]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product_Audita__00200768]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product_Auditu__01142BA1]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product_Auditu__02084FDA]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO


ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF__Product_t_Audit_787EE5A0]  DEFAULT (suser_sname()) FOR [AuditAddUserId]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF__Product_t_Audit_797309D9]  DEFAULT (getdate()) FOR [AuditAddDatetime]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF__Product_t_Audit_7A672E12]  DEFAULT (suser_sname()) FOR [AuditUpdateUserId]
GO
ALTER TABLE [dbo].[ProductType] ADD  CONSTRAINT [DF__Product_t_Audit_7B5B524B]  DEFAULT (getdate()) FOR [AuditUpdateDatetime]
GO

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductTypeKey])
REFERENCES [dbo].[ProductType] ([ProductTypeKey])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_ProductType]
GO
ALTER TABLE [dbo].[Attribute]  WITH CHECK ADD  CONSTRAINT [FK_Attribute_AttributeType] FOREIGN KEY([AttributeTypeKey])
REFERENCES [dbo].[AttributeType] ([AttributeTypeKey])
GO
ALTER TABLE [dbo].[Attribute] CHECK CONSTRAINT [FK_Attribute_AttributeType]
GO

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

CREATE TABLE #attByCategory (AttributeTypeCategory varchar(50))

IF @EntityTypeKey = 1 -- Company
	INSERT INTO #attByCategory VALUES ('Company'),('Company Contact')
IF @EntityTypeKey = 3 -- Account
	INSERT INTO #attByCategory VALUES ('Account'),('Account Contact'),('General Contact')
IF @EntityTypeKey = 2 -- Person / employee
	INSERT INTO #attByCategory VALUES ('Employee'),('General Contact')
IF @EntityTypeKey = 4 -- Products
	INSERT INTO #attByCategory VALUES ('Product')

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
WHERE B.AttributeTypeCategory IN (SELECT AttributeTypeCategory FROM #attByCategory)

DROP TABLE #attByCategory

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





GO


/****** Object:  StoredProcedure [dbo].[uspProductAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Product
**	Procedure Name: uspProductAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspProductAll]
AS
SET NOCOUNT ON

SELECT [ProductKey], 
	[ProductTypeKey], 
	[ProductCode], 
	[ProductName], 
	[ProductDescription], 
	[ProductName_short], 
	[ProductName_long], 
	[ProductImagePath], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Product


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspProductAll] TO [businessuser] AS [dbo]
GO
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
/****** Object:  StoredProcedure [dbo].[uspProductDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*****************************************************************
**	Table Name: Product
**	Procedure Name: uspProductDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspProductDelete]
	@ProductKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	--DELETE FROM EntityEntity
	--WHERE SecondaryEntityKey = @ProductKey
	--AND SecondaryEntityTypeKey = 4;

	DELETE FROM Product
	WHERE [ProductKey] = @ProductKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'Product', 'uspProductDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspProductDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspProductGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: Product
**	Procedure Name: uspProductGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspProductGet]
	@ProductKey int
AS
SET NOCOUNT ON

SELECT [ProductKey], 
	[ProductTypeKey], 
	[ProductCode], 
	[ProductName], 
	[ProductDescription], 
	[ProductName_short], 
	[ProductName_long], 
	[ProductImagePath], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM Product
WHERE [ProductKey] = @ProductKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspProductGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspProductTypeAll]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: ProductType
**	Procedure Name: uspProductTypeAll
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspProductTypeAll]
AS
SET NOCOUNT ON

SELECT [ProductTypeKey], 
	[ProductTypeCategory], 
	[ProductTypeCode], 
	[ProductTypeName], 
	[ProductTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM ProductType


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspProductTypeAll] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspProductTypeDelete]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



/*****************************************************************
**	Table Name: ProductType
**	Procedure Name: uspProductTypeDelete
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspProductTypeDelete]
	@ProductTypeKey int,
	@key int out
AS
SET NOCOUNT ON

BEGIN TRY
	DELETE FROM ProductType
	WHERE [ProductTypeKey] = @ProductTypeKey;
	SELECT @key = @@ROWCOUNT;
END TRY
BEGIN CATCH
		EXEC uspLogError 'ProductType', 'uspProductTypeDelete';
	THROW;
END CATCH

SET NOCOUNT OFF




GO
GRANT EXECUTE ON [dbo].[uspProductTypeDelete] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspProductTypeGet]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: ProductType
**	Procedure Name: uspProductTypeGet
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspProductTypeGet]
	@ProductTypeKey int
AS
SET NOCOUNT ON

SELECT [ProductTypeKey], 
	[ProductTypeCategory], 
	[ProductTypeCode], 
	[ProductTypeName], 
	[ProductTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM ProductType
WHERE [ProductTypeKey] = @ProductTypeKey


SET NOCOUNT OFF



GO
GRANT EXECUTE ON [dbo].[uspProductTypeGet] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspProductTypeGetByCategory]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*****************************************************************
**	Table Name: ProductType
**	Procedure Name: uspProductTypeGetByCategory
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspProductTypeGetByCategory]
	@ProductTypeCategory int
AS
SET NOCOUNT ON

SELECT [ProductTypeKey], 
	[ProductTypeCategory], 
	[ProductTypeCode], 
	[ProductTypeName], 
	[ProductTypeDescription], 
	[AuditAddUserId], 
	[AuditAddDatetime], 
	[AuditUpdateUserId], 
	[AuditUpdateDatetime]
FROM ProductType
WHERE [ProductTypeCategory] = @ProductTypeCategory


SET NOCOUNT OFF

GO
GRANT EXECUTE ON [dbo].[uspProductTypeGetByCategory] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspProductTypeUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: ProductType
**	Procedure Name: uspProductTypeUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspProductTypeUpsert]

	@ProductTypeKey int,
	@ProductTypeCategory varchar(50),
	@ProductTypeCode varchar(10),
	@ProductTypeName varchar(50),
	@ProductTypeDescription varchar(150),
	@key int out
AS
SET NOCOUNT ON
IF @ProductTypeKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO ProductType (
		[ProductTypeCategory],
		[ProductTypeCode],
		[ProductTypeName],
		[ProductTypeDescription]
	)
	VALUES (
		@ProductTypeCategory,
		@ProductTypeCode,
		@ProductTypeName,
		@ProductTypeDescription
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'ProductType', 'uspProductTypeUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE ProductType SET 
		[ProductTypeCategory] = @ProductTypeCategory,
		[ProductTypeCode] = @ProductTypeCode,
		[ProductTypeName] = @ProductTypeName,
		[ProductTypeDescription] = @ProductTypeDescription
	WHERE [ProductTypeKey] = @ProductTypeKey
		AND ([ProductTypeCategory] <> @ProductTypeCategory
		OR [ProductTypeCode] <> @ProductTypeCode
		OR [ProductTypeName] <> @ProductTypeName
		OR [ProductTypeDescription] <> @ProductTypeDescription);
	SELECT @key = @ProductTypeKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'ProductType', 'uspProductTypeUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspProductTypeUpsert] TO [businessuser] AS [dbo]
GO
/****** Object:  StoredProcedure [dbo].[uspProductUpsert]    Script Date: 7/10/2022 12:46:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





/*****************************************************************
**	Table Name: Product
**	Procedure Name: uspProductUpsert
**	Author: Richard Richards
**	Created: 04/21/2018
**	Copyright: QIQO Software, (c) 2015-2018
******************************************************************/

CREATE PROC [dbo].[uspProductUpsert]

	@ProductKey int,
	@ProductTypeKey int,
	@ProductCode varchar(20),
	@ProductName varchar(150),
	@ProductDescription varchar(255),
	@ProductName_short varchar(50),
	@ProductName_long varchar(255),
	@ProductImagePath varchar(255),
	@key int out
AS
SET NOCOUNT ON
IF @ProductKey = 0 BEGIN
	BEGIN TRY
	INSERT INTO Product (
		[ProductTypeKey],
		[ProductCode],
		[ProductName],
		[ProductDescription],
		[ProductName_short],
		[ProductName_long],
		[ProductImagePath]
	)
	VALUES (
		@ProductTypeKey,
		@ProductCode,
		@ProductName,
		@ProductDescription,
		@ProductName_short,
		@ProductName_long,
		@ProductImagePath
	)
	SELECT @key = SCOPE_IDENTITY();
	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Product', 'uspProductUpsert', 'I';
		THROW;
	END CATCH
END
ELSE BEGIN
	BEGIN TRY
	UPDATE Product SET 
		[ProductTypeKey] = @ProductTypeKey,
		[ProductCode] = @ProductCode,
		[ProductName] = @ProductName,
		[ProductDescription] = @ProductDescription,
		[ProductName_short] = @ProductName_short,
		[ProductName_long] = @ProductName_long,
		[ProductImagePath] = @ProductImagePath
	WHERE [ProductKey] = @ProductKey
		AND ([ProductTypeKey] <> @ProductTypeKey
		OR [ProductCode] <> @ProductCode
		OR [ProductName] <> @ProductName
		OR [ProductDescription] <> @ProductDescription
		OR [ProductName_short] <> @ProductName_short
		OR [ProductName_long] <> @ProductName_long
		OR [ProductImagePath] <> @ProductImagePath);
	SELECT @key = @ProductKey;

	END TRY
	BEGIN CATCH
		EXEC uspLogError 'Product', 'uspProductUpsert', 'U';
		THROW;
	END CATCH
END

SET NOCOUNT OFF







GO
GRANT EXECUTE ON [dbo].[uspProductUpsert] TO [businessuser] AS [dbo]
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

/****** Object:  Trigger [dbo].[tgrProductAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrProductAudit]
    ON [dbo].[Product]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [Product] A INNER JOIN inserted B
		ON A.ProductKey = B.ProductKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [Product] A INNER JOIN inserted B
		ON A.ProductKey = B.ProductKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [Product] A INNER JOIN deleted B
		ON A.ProductKey = B.ProductKey
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
				   ,'Product'
				   ,'Product'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[Product] ENABLE TRIGGER [tgrProductAudit]
GO
/****** Object:  Trigger [dbo].[tgrProductAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrProductAuditDelete]
    ON [dbo].[Product]
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
				   ,'Product'
				   ,'Product record deleted'
				   ,@old_xml)

    END




GO
ALTER TABLE [dbo].[Product] ENABLE TRIGGER [tgrProductAuditDelete]
GO
/****** Object:  Trigger [dbo].[tgrProductTypeAudit]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrProductTypeAudit]
    ON [dbo].[ProductType]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NOCOUNT ON

		UPDATE A SET
			A.AuditAddDatetime = ISNULL(A.AuditAddDatetime, GETDATE()),
			A.AuditAddUserId = ISNULL(A.AuditAddUserId, SUSER_SNAME()),
			A.AuditUpdateDatetime = GETDATE(),
			A.AuditUpdateUserId = SUSER_SNAME()
		FROM [ProductType] A INNER JOIN inserted B
		ON A.ProductTypeKey = B.ProductTypeKey

		DECLARE @old_xml XML, @new_xml XML

		SELECT @new_xml = (SELECT B.* 
		FROM [ProductType] A INNER JOIN inserted B
		ON A.ProductTypeKey = B.ProductTypeKey
		FOR XML RAW, ELEMENTS)

		SELECT @old_xml = (SELECT B.* 
		FROM [ProductType] A INNER JOIN deleted B
		ON A.ProductTypeKey = B.ProductTypeKey
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
				   ,'ProductType'
				   ,'ProductType'
				   ,@old_xml
				   ,@new_xml)

    END




GO
ALTER TABLE [dbo].[ProductType] ENABLE TRIGGER [tgrProductTypeAudit]
GO
/****** Object:  Trigger [dbo].[tgrProductTypeAuditDelete]    Script Date: 7/10/2022 12:46:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[tgrProductTypeAuditDelete]
    ON [dbo].[ProductType]
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
				   ,'ProductType'
				   ,'ProductType record deleted'
				   ,@old_xml)

    END




GO
ALTER TABLE [dbo].[ProductType] ENABLE TRIGGER [tgrProductTypeAuditDelete]
GO
USE [master]
GO
ALTER DATABASE [ProductManagement] SET  READ_WRITE 
GO
