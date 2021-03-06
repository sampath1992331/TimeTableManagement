USE [TimeTableManagement]
GO
/****** Object:  Table [dbo].[FreePeriods]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FreePeriods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherCode] [varchar](10) NULL,
	[DateCode] [int] NULL,
	[Class] [varchar](10) NULL,
	[TimeSlot] [varchar](50) NULL,
	[IsFree] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[Notification] [varchar](500) NULL,
	[IsSent] [bit] NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](50) NULL,
	[SubjectCode] [varchar](5) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[TeacherCode] [varchar](5) NOT NULL,
	[SubjectCode] [varchar](50) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeachersLeave]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeachersLeave](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherCode] [varchar](5) NOT NULL,
	[DateCode] [varchar](5) NOT NULL,
	[ApplicableDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherTimeTable]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherTimeTable](
	[TeacherCode] [varchar](10) NULL,
	[DateCode] [int] NULL,
	[TeacherTableID] [int] IDENTITY(1,1) NOT NULL,
	[Class] [varchar](10) NULL,
	[TimeSlot] [varchar](50) NULL,
 CONSTRAINT [PK_TeacherTimeTable] PRIMARY KEY CLUSTERED 
(
	[TeacherTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlot](
	[Id] [int] NOT NULL,
	[TimeSlotName] [varchar](10) NOT NULL,
	[TimeSlotCode] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](5) NOT NULL,
	[DateCode] [int] NOT NULL,
	[TimeSlotCode] [int] NOT NULL,
	[SubjectCode] [varchar](5) NOT NULL,
	[TeacherCode] [varchar](5) NULL,
	[IsTeacherAbsent] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[NewAssignedTeacher] [varchar](5) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TeachersLeave] ADD  CONSTRAINT [DF_TeachersLeave_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[TimeTable] ADD  CONSTRAINT [DF_TeacherClassSubjectMapping_IsTeacherAbsent]  DEFAULT ((0)) FOR [IsTeacherAbsent]
GO
ALTER TABLE [dbo].[TimeTable] ADD  CONSTRAINT [DF_TeacherClassSubjectMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  StoredProcedure [dbo].[ApplyLeaves]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sampath
-- =============================================
CREATE PROCEDURE [dbo].[ApplyLeaves] 

	@teacherCode varchar(5),
	@dateCode varchar(5),
	@applicableDate datetime,
	@result int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[TeachersLeave]
	([TeacherCode],[DateCode],[ApplicableDate],[IsActive])
	VALUES(@teacherCode,@dateCode,@applicableDate,1)

	SET @result = scope_identity()
	
END
GO
/****** Object:  StoredProcedure [dbo].[AssignTeachers]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sampath
-- EXEC [dbo].[AssignTeachers]  @newAssignedTeacher='T0001',@className='6A',@dateCode=1,@TimeSlotCode='2'
-- =============================================
CREATE PROCEDURE [dbo].[AssignTeachers] 

	@newAssignedTeacher varchar(10),
	@className varchar(50),
	@dateCode int,
	@TimeSlotCode varchar(50)

AS
BEGIN
DECLARE @V1 int
DECLARE @V2 int
DECLARE @V3 int

UPDATE [dbo].[TimeTable]
SET [IsTeacherAbsent]=1,[NewAssignedTeacher]=@newAssignedTeacher
WHERE [ClassName] =@className AND [DateCode] =@dateCode AND [TimeSlotCode] = CAST(@TimeSlotCode AS int)

SET @V1 = @@ROWCOUNT
 IF(@V1 != 0)
 BEGIN
 Print(@V1)
		UPDATE [dbo].[TeacherTimeTable]
		SET [Class] = @className
		WHERE [Class] ='FREE' AND [DateCode] =@dateCode AND [TimeSlot] = @TimeSlotCode
		SET @V2 = @@ROWCOUNT

		IF(@V2 != 0)
		Print(@V2)
		BEGIN
			Update [dbo].[FreePeriods]
			SET [IsFree] =0 
			WHERE [TeacherCode] =@newAssignedTeacher AND [DateCode] =@dateCode AND [TimeSlot] = @TimeSlotCode

			SET @V3 = @@ROWCOUNT
			Print(@V3)
		END
 END





END
GO
/****** Object:  StoredProcedure [dbo].[GetFreeTeachers]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sampath

-- =============================================
CREATE PROCEDURE [dbo].[GetFreeTeachers] 

	@dateCode int,
	@timeSlot varchar(50)

AS
BEGIN

SELECt * FROM [dbo].[TeacherTimeTable] WHERE   DateCode =1 AND Class='Free' AND [TimeSlot] =@timeSlot
END
GO
/****** Object:  StoredProcedure [dbo].[GetLeaveTeachers]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sampath

-- =============================================
CREATE PROCEDURE [dbo].[GetLeaveTeachers] 

	@dateCode varchar(10),
	@timeSlot varchar(50)

AS
BEGIN

SELECT DISTINCT [TimeSlotCode] ,TL.TeacherCode,TT.ClassName  FROM [dbo].[TimeTable] TT 
INNER JOIN [dbo].[TeachersLeave] TL ON
TT.[TeacherCode] = TL.TeacherCode
WHERE TL.DateCode=@dateCode AND TL.IsActive =0
END
GO
/****** Object:  StoredProcedure [dbo].[GetStudentTimeTable]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStudentTimeTable] 
	-- Add the parameters for the stored procedure here
	@ClassName varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TCSM.ClassName,TCSM.DateCode,TCSM.TimeSlotCode,TCSM.SubjectCode,S.SubjectName,T.[TeacherName]
	FROM TeacherClassSubjectMapping TCSM,[Subject] S,Teacher T WHERE TCSM.ClassName=@ClassName AND TCSM.SubjectCode=S.SubjectCode AND T.TeacherCode=TCSM.TeacherCode
	ORDER BY TCSM.DateCode,TCSM.TimeSlotCode
END
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherTimeTable]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeacherTimeTable] 
	-- Add the parameters for the stored procedure here
	@TeacherCode varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [dbo].[TeacherTimeTable] TT  WHERE 
	TT.[TeacherCode] =@TeacherCode
END
GO
/****** Object:  StoredProcedure [dbo].[SendNotifications]    Script Date: 1/10/2021 3:53:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sampath
-- =============================================
CREATE PROCEDURE [dbo].[SendNotifications] 

	@notification varchar(500),
	@result int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[Notifications]
	([Notification],[IsSent])
	VALUES(@notification,0)

	SET @result = scope_identity()
	
END
GO
