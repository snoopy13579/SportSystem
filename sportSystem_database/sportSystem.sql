USE [master]
GO
/****** Object:  Database [sportSystem]    Script Date: 2019/1/16 16:27:13 ******/
CREATE DATABASE [sportSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sportSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\sportSystem.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sportSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\sportSystem_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [sportSystem] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sportSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sportSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sportSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sportSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sportSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sportSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [sportSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [sportSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sportSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sportSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sportSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sportSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sportSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sportSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sportSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sportSystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [sportSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sportSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sportSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sportSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sportSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sportSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sportSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sportSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sportSystem] SET  MULTI_USER 
GO
ALTER DATABASE [sportSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sportSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sportSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sportSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [sportSystem] SET DELAYED_DURABILITY = DISABLED 
GO
USE [sportSystem]
GO
/****** Object:  Table [dbo].[athletes]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[athletes](
	[Ano] [varchar](20) NOT NULL,
	[Aname] [varchar](40) NULL,
	[Asex] [varchar](4) NULL,
	[Aage] [int] NULL,
	[team] [varchar](40) NOT NULL,
	[Ecount] [int] NULL CONSTRAINT [DF_athletes_Acount]  DEFAULT ((0)),
 CONSTRAINT [PK_athletes_1] PRIMARY KEY CLUSTERED 
(
	[Ano] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[grade]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[grade](
	[Ano] [varchar](20) NOT NULL,
	[Eno] [varchar](20) NOT NULL,
	[grade] [int] NULL,
	[eventGrade] [nchar](20) NULL,
 CONSTRAINT [PK_grade] PRIMARY KEY CLUSTERED 
(
	[Ano] ASC,
	[Eno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[spevent]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[spevent](
	[Eno] [varchar](20) NOT NULL,
	[Edate] [datetime] NULL,
	[Eplace] [varchar](40) NULL,
	[Ename] [varchar](40) NULL,
	[Eattrib] [varchar](4) NULL,
 CONSTRAINT [PK_spevent] PRIMARY KEY CLUSTERED 
(
	[Eno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[team_grade]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[team_grade](
	[team] [varchar](40) NOT NULL,
	[sum] [int] NULL,
	[Acount] [int] NULL CONSTRAINT [DF_team_grade_Acount]  DEFAULT ((0))
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10001', N'姓名1', N'男', 12, N'队一', 3)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10002', N'姓名2', N'男', 11, N'队二', 2)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10003', N'姓名3', N'女', 12, N'队一', 1)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10004', N'姓名4', N'男', 11, N'队三', 2)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10005', N'姓名5', N'女', 15, N'队一', 2)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10006', N'姓名6', N'男', 14, N'队二', 2)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10007', N'姓名7', N'男', 13, N'队三', 1)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10008', N'姓名8', N'男', 11, N'队一', 1)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10009', N'姓名9', N'女', 13, N'队三', 2)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10010', N'姓名10', N'男', 18, N'队三', 2)
INSERT [dbo].[athletes] ([Ano], [Aname], [Asex], [Aage], [team], [Ecount]) VALUES (N'10011', N'姓名11', N'女', 13, N'队二', 0)
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10001', N'100', 9, N'14                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10001', N'103', 7, N'60                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10001', N'104', 5, N'15                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10002', N'103', 10, N'50                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10002', N'104', 9, N'19                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10003', N'104', 10, N'20                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10004', N'103', 10, N'50                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10004', N'104', 7, N'17                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10005', N'102', 9, N'2                   ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10005', N'104', 4, N'14                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10006', N'100', 8, N'13                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10006', N'105', 9, N'60                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10007', N'104', 9, N'19                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10008', N'103', 10, N'50                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10009', N'102', 10, N'3                   ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10009', N'104', 6, N'16                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10010', N'100', 10, N'16                  ')
INSERT [dbo].[grade] ([Ano], [Eno], [grade], [eventGrade]) VALUES (N'10010', N'105', 10, N'57                  ')
INSERT [dbo].[spevent] ([Eno], [Edate], [Eplace], [Ename], [Eattrib]) VALUES (N'100', CAST(N'2018-05-02 23:04:51.000' AS DateTime), N'体育馆一', N'乒乓球', N'降')
INSERT [dbo].[spevent] ([Eno], [Edate], [Eplace], [Ename], [Eattrib]) VALUES (N'101', CAST(N'2018-05-03 23:02:13.000' AS DateTime), N'体育馆二', N'羽毛球', N'降')
INSERT [dbo].[spevent] ([Eno], [Edate], [Eplace], [Ename], [Eattrib]) VALUES (N'102', CAST(N'2018-05-05 00:00:00.000' AS DateTime), N'体育馆三', N'足球', N'降')
INSERT [dbo].[spevent] ([Eno], [Edate], [Eplace], [Ename], [Eattrib]) VALUES (N'103', CAST(N'2018-05-09 00:00:00.000' AS DateTime), N'体育馆四', N'田径', N'升')
INSERT [dbo].[spevent] ([Eno], [Edate], [Eplace], [Ename], [Eattrib]) VALUES (N'104', CAST(N'2018-05-10 00:00:00.000' AS DateTime), N'体育馆五', N'排球', N'降')
INSERT [dbo].[spevent] ([Eno], [Edate], [Eplace], [Ename], [Eattrib]) VALUES (N'105', CAST(N'2019-01-13 23:24:57.000' AS DateTime), N'体育馆六', N'马拉松', N'升')
INSERT [dbo].[team_grade] ([team], [sum], [Acount]) VALUES (N'队一', 54, 4)
INSERT [dbo].[team_grade] ([team], [sum], [Acount]) VALUES (N'队二', 36, 3)
INSERT [dbo].[team_grade] ([team], [sum], [Acount]) VALUES (N'队三', 62, 4)
ALTER TABLE [dbo].[grade]  WITH CHECK ADD  CONSTRAINT [FK_grade_athletes] FOREIGN KEY([Ano])
REFERENCES [dbo].[athletes] ([Ano])
GO
ALTER TABLE [dbo].[grade] CHECK CONSTRAINT [FK_grade_athletes]
GO
ALTER TABLE [dbo].[grade]  WITH CHECK ADD  CONSTRAINT [FK_grade_spevent] FOREIGN KEY([Eno])
REFERENCES [dbo].[spevent] ([Eno])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[grade] CHECK CONSTRAINT [FK_grade_spevent]
GO
/****** Object:  StoredProcedure [dbo].[all_schedule]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[all_schedule]
as
SELECT DISTINCT athletes.Ano,
	spevent.Eno,
	athletes.Aname,
	athletes.Asex,
	athletes.Aage,
	athletes.team,
	spevent.Ename,
	spevent.Edate,
	spevent.Eplace
	FROM athletes,grade,spevent
	WHERE athletes.Ano=grade.Ano AND grade.Eno=spevent.Eno
	ORDER BY athletes.Ano,spevent.Eno ASC;

GO
/****** Object:  StoredProcedure [dbo].[insert_athletes]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insert_athletes]
	@a  varchar(20),
	@b  varchar(40),
	@c  varchar(4),
	@d  int,
	@e  varchar(40)
as
begin
   INSERT INTO athletes(Ano,Aname,Asex,Aage,team) VALUES (@a,@b,@c,@d,@e);
end

GO
/****** Object:  StoredProcedure [dbo].[personal_grade]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE procedure [dbo].[personal_grade]
 @m varchar(10)
as
begin
	SELECT RANK() OVER (ORDER BY eventGrade DESC) AS 排名,grade.Ano,grade.Eno,Ename,Aname,grade,team,grade.eventGrade
	FROM grade,athletes,spevent
	WHERE athletes.Ano=grade.Ano AND grade.Eno=spevent.Eno AND grade.Eno=@m
end

GO
/****** Object:  StoredProcedure [dbo].[result_team]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[result_team]
as
begin
	SELECT RANK() OVER (ORDER BY sum DESC) AS 排名,team,sum,Acount
	FROM team_grade
end

GO
/****** Object:  Trigger [dbo].[trig_delete_acount]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trig_delete_acount]
on [dbo].[athletes]
after delete
as
begin
    DECLARE @a int,@ano varchar(40);	
	SET @ano=(SELECT team from deleted);
	SET @a=(SELECT DISTINCT Acount
	FROM athletes,team_grade where team_grade.team=@ano);
    update team_grade set Acount=@a-1 where team=@ano;
end
GO
/****** Object:  Trigger [dbo].[trig_insert_acount]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trig_insert_acount]
on [dbo].[athletes]
after insert
as
begin
    DECLARE @a int,@ano varchar(40);	
	SET @ano=(SELECT team from inserted);
	SET @a=(SELECT DISTINCT Acount
	FROM athletes,team_grade where team_grade.team=@ano);
    update team_grade set Acount=@a+1 where team=@ano;
end
GO
/****** Object:  Trigger [dbo].[trig_delete]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trig_delete]
on [dbo].[grade]
after delete
as
begin
    DECLARE @a int;
	SET @a=(SELECT DISTINCT SUM(grade)
	FROM grade,athletes
	WHERE athletes.Ano=grade.Ano AND athletes.team='队一');
    update team_grade set team_grade.sum=@a WHERE team_grade.team='队一';
end
GO
/****** Object:  Trigger [dbo].[trig_delete_2]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trig_delete_2]
on [dbo].[grade]
after delete
as
begin
    DECLARE @a int;
	SET @a=(SELECT DISTINCT SUM(grade)
	FROM grade,athletes
	WHERE athletes.Ano=grade.Ano AND athletes.team='队二');
    update team_grade set team_grade.sum=@a WHERE team_grade.team='队二';
end
GO
/****** Object:  Trigger [dbo].[trig_delete_3]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trig_delete_3]
on [dbo].[grade]
after delete
as
begin
    DECLARE @a int;
	SET @a=(SELECT DISTINCT SUM(grade)
	FROM grade,athletes
	WHERE athletes.Ano=grade.Ano AND athletes.team='队三');
    update team_grade set team_grade.sum=@a WHERE team_grade.team='队三';
end
GO
/****** Object:  Trigger [dbo].[trig_delete_ecount]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trig_delete_ecount]
on [dbo].[grade]
after delete
as
begin
    DECLARE @a int,@ano varchar(40);	
	SET @ano=(SELECT Ano from deleted);
	SET @a=(SELECT DISTINCT Ecount
	FROM athletes,grade where athletes.Ano=@ano);
    update athletes set Ecount=@a-1 where Ano=@ano;
end
GO
/****** Object:  Trigger [dbo].[trig_insert]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trig_insert]
on [dbo].[grade]
after insert
as
begin
    DECLARE @a int;
	SET @a=(SELECT DISTINCT SUM(grade)
	FROM grade,athletes
	WHERE athletes.Ano=grade.Ano AND athletes.team='队一');
    update team_grade set team_grade.sum=@a WHERE team_grade.team='队一';
end
GO
/****** Object:  Trigger [dbo].[trig_insert_2]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trig_insert_2]
on [dbo].[grade]
after insert
as
begin
    DECLARE @a int;
	SET @a=(SELECT DISTINCT SUM(grade)
	FROM grade,athletes
	WHERE athletes.Ano=grade.Ano AND athletes.team='队二');
    update team_grade set team_grade.sum=@a WHERE team_grade.team='队二';
end
GO
/****** Object:  Trigger [dbo].[trig_insert_3]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trig_insert_3]
on [dbo].[grade]
after insert
as
begin
    DECLARE @a int;
	SET @a=(SELECT DISTINCT SUM(grade)
	FROM grade,athletes
	WHERE athletes.Ano=grade.Ano AND athletes.team='队三');
    update team_grade set team_grade.sum=@a WHERE team_grade.team='队三';
end
GO
/****** Object:  Trigger [dbo].[trig_insert_ecount]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trig_insert_ecount]
on [dbo].[grade]
after insert
as
begin
    DECLARE @a int,@ano varchar(40);	
	SET @ano=(SELECT Ano from inserted);
	SET @a=(SELECT DISTINCT Ecount
	FROM athletes,grade where athletes.Ano=@ano);
    update athletes set Ecount=@a+1 where Ano=@ano;
end
GO
/****** Object:  Trigger [dbo].[trig_update]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trig_update]
on [dbo].[grade]
after update
as
begin
    DECLARE @a int;
	SET @a=(SELECT DISTINCT SUM(grade)
	FROM grade,athletes
	WHERE athletes.Ano=grade.Ano AND athletes.team='队一');
    update team_grade set team_grade.sum=@a WHERE team_grade.team='队一';
end
GO
/****** Object:  Trigger [dbo].[trig_update_2]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trig_update_2]
on [dbo].[grade]
after update
as
begin
    DECLARE @a int;
	SET @a=(SELECT DISTINCT SUM(grade)
	FROM grade,athletes
	WHERE athletes.Ano=grade.Ano AND athletes.team='队二');
    update team_grade set team_grade.sum=@a WHERE team_grade.team='队二';
end

GO
/****** Object:  Trigger [dbo].[trig_update_3]    Script Date: 2019/1/16 16:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[trig_update_3]
on [dbo].[grade]
after update
as
begin
    DECLARE @a int;
	SET @a=(SELECT DISTINCT SUM(grade)
	FROM grade,athletes
	WHERE athletes.Ano=grade.Ano AND athletes.team='队三');
    update team_grade set team_grade.sum=@a WHERE team_grade.team='队三';
end

GO
USE [master]
GO
ALTER DATABASE [sportSystem] SET  READ_WRITE 
GO
