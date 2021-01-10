USE [TimeTableManagement]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 1/3/2021 11:34:33 PM ******/
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 1/3/2021 11:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[TeacherCode] [varchar](5) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherClassSubjectMapping]    Script Date: 1/3/2021 11:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherClassSubjectMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](5) NOT NULL,
	[DateCode] [int] NOT NULL,
	[TimeSlotCode] [int] NOT NULL,
	[SubjectCode] [varchar](5) NOT NULL,
	[TeacherCode] [varchar](5) NULL,
	[IsTeacherAbsent] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeachersLeave]    Script Date: 1/3/2021 11:34:33 PM ******/
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
/****** Object:  Table [dbo].[TimeSlot]    Script Date: 1/3/2021 11:34:33 PM ******/
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
/****** Object:  Table [dbo].[WorkingDays]    Script Date: 1/3/2021 11:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingDays](
	[Id] [int] NOT NULL,
	[Name] [varchar](15) NOT NULL,
	[Code] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 
GO
INSERT [dbo].[Subject] ([Id], [SubjectName], [SubjectCode]) VALUES (1, N'Sinhala', N'S0001')
GO
INSERT [dbo].[Subject] ([Id], [SubjectName], [SubjectCode]) VALUES (2, N'English', N'S0002')
GO
INSERT [dbo].[Subject] ([Id], [SubjectName], [SubjectCode]) VALUES (3, N'Maths', N'S0003')
GO
INSERT [dbo].[Subject] ([Id], [SubjectName], [SubjectCode]) VALUES (4, N'Science', N'S0004')
GO
INSERT [dbo].[Subject] ([Id], [SubjectName], [SubjectCode]) VALUES (5, N'IT', N'S0005')
GO
INSERT [dbo].[Subject] ([Id], [SubjectName], [SubjectCode]) VALUES (6, N'Music', N'S0006')
GO
INSERT [dbo].[Subject] ([Id], [SubjectName], [SubjectCode]) VALUES (7, N'Tamil', N'S0007')
GO
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 
GO
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherCode]) VALUES (1, N'Teacher1', N'T0001')
GO
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherCode]) VALUES (3, N'Teacher2', N'T0002')
GO
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherCode]) VALUES (4, N'Teacher3', N'T0003')
GO
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherCode]) VALUES (5, N'Teacher4', N'T0004')
GO
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherCode]) VALUES (6, N'Teacher5', N'T0005')
GO
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherCode]) VALUES (7, N'Teacher6', N'T0006')
GO
INSERT [dbo].[Teacher] ([Id], [TeacherName], [TeacherCode]) VALUES (8, N'Teacher7', N'T0007')
GO
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[TeacherClassSubjectMapping] ON 
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (1, N'6A', 1, 1, N'S0001', N'T0001', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (2, N'6A', 1, 2, N'S0002', N'T0002', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (3, N'6A', 2, 1, N'S0002', N'T0002', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (4, N'6A', 2, 2, N'S0003', N'T0003', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (5, N'6A', 3, 1, N'S0004', N'T0004', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (6, N'6A', 3, 2, N'S0005', N'T0005', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (7, N'6A', 4, 1, N'S0003', N'T0003', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (8, N'6A', 4, 2, N'S0006', N'T0006', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (9, N'6A', 5, 1, N'S0001', N'T0001', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (10, N'6A', 5, 2, N'S0007', N'T0007', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (11, N'7A', 1, 1, N'S0003', N'T0003', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (12, N'7A', 1, 2, N'S0004', N'T0004', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (13, N'7A', 2, 1, N'S0001', N'T0001', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (14, N'7A', 2, 2, N'S0004', N'T0004', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (15, N'7A', 3, 1, N'S0005', N'T0005', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (16, N'7A', 3, 2, N'S0002', N'T0002', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (17, N'7A', 4, 1, N'S0007', N'T0007', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (18, N'7A', 4, 2, N'S0001', N'T0001', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (19, N'7A', 5, 1, N'S0003', N'T0003', 0, 1)
GO
INSERT [dbo].[TeacherClassSubjectMapping] ([Id], [ClassName], [DateCode], [TimeSlotCode], [SubjectCode], [TeacherCode], [IsTeacherAbsent], [IsActive]) VALUES (20, N'7A', 5, 2, N'S0002', N'T0002', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[TeacherClassSubjectMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[TeachersLeave] ON 
GO
INSERT [dbo].[TeachersLeave] ([Id], [TeacherCode], [DateCode], [ApplicableDate], [IsActive]) VALUES (1, N'T0001', N'1', CAST(N'2021-01-04T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[TeachersLeave] ([Id], [TeacherCode], [DateCode], [ApplicableDate], [IsActive]) VALUES (2, N'T0002', N'2', CAST(N'2021-01-05T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[TeachersLeave] ([Id], [TeacherCode], [DateCode], [ApplicableDate], [IsActive]) VALUES (3, N'T0003', N'3', CAST(N'2021-01-06T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[TeachersLeave] ([Id], [TeacherCode], [DateCode], [ApplicableDate], [IsActive]) VALUES (4, N'T0004', N'4', CAST(N'2021-01-07T00:00:00.000' AS DateTime), 1)
GO
INSERT [dbo].[TeachersLeave] ([Id], [TeacherCode], [DateCode], [ApplicableDate], [IsActive]) VALUES (5, N'T0005', N'5', CAST(N'2021-01-08T00:00:00.000' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[TeachersLeave] OFF
GO
INSERT [dbo].[TimeSlot] ([Id], [TimeSlotName], [TimeSlotCode]) VALUES (1, N'Period1', 1)
GO
INSERT [dbo].[TimeSlot] ([Id], [TimeSlotName], [TimeSlotCode]) VALUES (2, N'Period2', 2)
GO
INSERT [dbo].[TimeSlot] ([Id], [TimeSlotName], [TimeSlotCode]) VALUES (3, N'Period3', 3)
GO
INSERT [dbo].[TimeSlot] ([Id], [TimeSlotName], [TimeSlotCode]) VALUES (4, N'Period4', 4)
GO
INSERT [dbo].[WorkingDays] ([Id], [Name], [Code]) VALUES (1, N'Monday', 1)
GO
INSERT [dbo].[WorkingDays] ([Id], [Name], [Code]) VALUES (2, N'Tuesday', 2)
GO
INSERT [dbo].[WorkingDays] ([Id], [Name], [Code]) VALUES (3, N'Wednesday', 3)
GO
INSERT [dbo].[WorkingDays] ([Id], [Name], [Code]) VALUES (4, N'Thursday', 4)
GO
INSERT [dbo].[WorkingDays] ([Id], [Name], [Code]) VALUES (5, N'Friday', 5)
GO
ALTER TABLE [dbo].[TeacherClassSubjectMapping] ADD  CONSTRAINT [DF_TeacherClassSubjectMapping_IsTeacherAbsent]  DEFAULT ((0)) FOR [IsTeacherAbsent]
GO
ALTER TABLE [dbo].[TeacherClassSubjectMapping] ADD  CONSTRAINT [DF_TeacherClassSubjectMapping_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[TeachersLeave] ADD  CONSTRAINT [DF_TeachersLeave_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  StoredProcedure [dbo].[GetFreeTeachers]    Script Date: 1/3/2021 11:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetFreeTeachers] 
	-- Add the parameters for the stored procedure here
	@dateCode varchar(5),
	@timeSlot varchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select TeacherName,TeacherCode from Teacher where Id not in
	(select  T.Id
	from TeacherClassSubjectMapping TCSM,Teacher T where TCSM.TeacherCode=T.TeacherCode AND TCSM.DateCode=@dateCode AND TCSM.TimeSlotCode=@timeSlot)
END
GO
/****** Object:  StoredProcedure [dbo].[GetStudentTimeTable]    Script Date: 1/3/2021 11:34:33 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetTeachersAvailability]    Script Date: 1/3/2021 11:34:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTeachersAvailability] 
	-- Add the parameters for the stored procedure here
	@ClassName varchar(5),
	@Date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TCSM.ClassName,TCSM.DateCode,TCSM.TimeSlotCode,TCSM.SubjectCode,S.SubjectName,T.[TeacherName],
	(CASE WHEN T.TeacherCode IN (select TL.TeacherCode from WorkingDays WD,TeachersLeave TL
	WHERE WD.[Name]= DATENAME(WEEKDAY, TL.ApplicableDate) AND TL.ApplicableDate=@Date) THEN 'ABSENT' ELSE 'NOT ABSENT' END) AS IsTeacherAbsent 
	FROM TeacherClassSubjectMapping TCSM,[Subject] S,Teacher T 
	WHERE TCSM.ClassName=@ClassName AND TCSM.SubjectCode=S.SubjectCode AND T.TeacherCode=TCSM.TeacherCode AND TCSM.DateCode=(select WD.Code from WorkingDays WD,
	TeachersLeave TL
	WHERE WD.[Name]= DATENAME(WEEKDAY, TL.ApplicableDate)
	AND TL.ApplicableDate=@Date)
	ORDER BY TCSM.DateCode,TCSM.TimeSlotCode
END
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherTimeTable]    Script Date: 1/3/2021 11:34:33 PM ******/
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
	SELECT TCSM.TeacherCode,T.[TeacherName],SubjectCode,DateCode, WD.[Name] FROM TeacherClassSubjectMapping TCSM,Teacher T,WorkingDays WD
	WHERE T.TeacherCode=@TeacherCode AND T.TeacherCode=TCSM.TeacherCode AND WD.Code=TCSM.DateCode
	ORDER BY DateCode,TimeSlotCode
END
GO
