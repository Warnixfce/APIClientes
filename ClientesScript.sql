USE [master]
GO
CREATE DATABASE [Clientes]
 CONTAINMENT = NONE
GO
ALTER DATABASE [Clientes] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Clientes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Clientes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Clientes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Clientes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Clientes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Clientes] SET ARITHABORT OFF 
GO
ALTER DATABASE [Clientes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Clientes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Clientes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Clientes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Clientes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Clientes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Clientes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Clientes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Clientes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Clientes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Clientes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Clientes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Clientes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Clientes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Clientes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Clientes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Clientes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Clientes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Clientes] SET  MULTI_USER 
GO
ALTER DATABASE [Clientes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Clientes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Clientes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Clientes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Clientes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Clientes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Clientes] SET QUERY_STORE = OFF
GO
USE [Clientes]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 5/15/2023 9:36:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[CUIT] [varchar](20) NOT NULL,
	[Domicilio] [varchar](50) NOT NULL,
	[TelCelular] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ID_Cliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [TelCelular], [Email]) VALUES (1, N'John Christopher', N'Depp', CAST(N'1963-06-09' AS Date), N'20-14586433-4', N'Los Angeles Beach 357', N'1599876899', N'johnny.depp@gmail.com')
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [TelCelular], [Email]) VALUES (2, N'Scarlett Ingrid', N'Johansson', CAST(N'1984-11-22' AS Date), N'27-30876196-6', N'5th Avenue 533', N'1577762334', N'blackwidowSJ@gmail.com')
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [TelCelular], [Email]) VALUES (3, N'Ian Murray', N'McKellen', CAST(N'1939-05-25' AS Date), N'20-10987654-4', N'Burnley Av. 349', N'1587664395', N'youshallnotpass@gmail.com')
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [TelCelular], [Email]) VALUES (4, N'Forest Steven', N'Whitaker', CAST(N'1961-07-15' AS Date), N'20-13977352-4', N'Longview ST 844', N'1544369912', N'forest.whitaker@gmail.com')
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [TelCelular], [Email]) VALUES (5, N'Shakira Isabel', N'Mebarak Ripoll', CAST(N'1977-02-02' AS Date), N'27-25864115-6', N'Miami Beach 457', N'1564335267', N'myhipsdontlie@gmail.com')
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [TelCelular], [Email]) VALUES (6, N'Mary Louise', N'Streep', CAST(N'1949-06-22' AS Date), N'27-98673554-6', N'Summit St. 677', N'1533425876', N'thatsallDWP@gmail.com')
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombres], [Apellidos], [FechaNacimiento], [CUIT], [Domicilio], [TelCelular], [Email]) VALUES (7, N'Sasha', N'Colby', CAST(N'1985-07-26' AS Date), N'27-25697884-6', N'Honolulu 765', N'1558976588', N'aliengoddess@gmail.com')
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
USE [master]
GO
ALTER DATABASE [Clientes] SET  READ_WRITE 
GO
