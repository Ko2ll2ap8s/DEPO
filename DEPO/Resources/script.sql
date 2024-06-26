USE [DEPO]
GO
/****** Object:  Table [dbo].[Organisaton]    Script Date: 16.04.2024 20:52:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organisaton](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[INN] [int] NOT NULL,
	[LegalAddress] [nvarchar](50) NOT NULL,
	[ActualAddress] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Organisaton] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 16.04.2024 20:52:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Worker](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[PassportSeries] [int] NOT NULL,
	[PassportNumber] [int] NOT NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Organisaton] ON 

INSERT [dbo].[Organisaton] ([Id], [Name], [INN], [LegalAddress], [ActualAddress]) VALUES (1, N'Светлана', 54353455, N'Ул.Пушкина 13', N'Ул.Пушкина 12')
INSERT [dbo].[Organisaton] ([Id], [Name], [INN], [LegalAddress], [ActualAddress]) VALUES (2, N'Игорь', 53454354, N'Ул Мира 4', N'Пр Ленина 6')
INSERT [dbo].[Organisaton] ([Id], [Name], [INN], [LegalAddress], [ActualAddress]) VALUES (4, N'Ульяна', 65345466, N'Ул 8 Марта 77', N'Ул Дзержинского 12')
INSERT [dbo].[Organisaton] ([Id], [Name], [INN], [LegalAddress], [ActualAddress]) VALUES (5, N'ООО Ред', 545466, N'Ул. Борисова 23', N'Ул. Борисова 55')
INSERT [dbo].[Organisaton] ([Id], [Name], [INN], [LegalAddress], [ActualAddress]) VALUES (6, N'Светлана', 54353455, N'Ул.Пушкина 13', N'Ул.Пушкина 12')
INSERT [dbo].[Organisaton] ([Id], [Name], [INN], [LegalAddress], [ActualAddress]) VALUES (7, N'Игорь', 53454354, N'Ул Мира 4', N'Пр Ленина 6')
INSERT [dbo].[Organisaton] ([Id], [Name], [INN], [LegalAddress], [ActualAddress]) VALUES (8, N'Ульяна', 65345466, N'Ул 8 Марта 77', N'Ул Дзержинского 12')
INSERT [dbo].[Organisaton] ([Id], [Name], [INN], [LegalAddress], [ActualAddress]) VALUES (9, N'ООО Ред', 545466, N'Ул. Борисова 23', N'Ул. Борисова 55')
SET IDENTITY_INSERT [dbo].[Organisaton] OFF
GO
SET IDENTITY_INSERT [dbo].[Worker] ON 

INSERT [dbo].[Worker] ([Id], [Name], [Surname], [Patronymic], [BirthDate], [PassportSeries], [PassportNumber]) VALUES (1, N'Виктор', N'Павин', N'Павлович', CAST(N'2000-12-22' AS Date), 1322, 234567)
INSERT [dbo].[Worker] ([Id], [Name], [Surname], [Patronymic], [BirthDate], [PassportSeries], [PassportNumber]) VALUES (2, N'Станислав', N'Евушин', N'Евгеньевич', CAST(N'1999-01-03' AS Date), 5678, 345234)
INSERT [dbo].[Worker] ([Id], [Name], [Surname], [Patronymic], [BirthDate], [PassportSeries], [PassportNumber]) VALUES (3, N'Виктория', N'Смолина', N'Александровна', CAST(N'1998-10-08' AS Date), 5644, 567890)
SET IDENTITY_INSERT [dbo].[Worker] OFF
GO
