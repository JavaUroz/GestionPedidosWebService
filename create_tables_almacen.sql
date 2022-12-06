USE [master]
GO
/****** Object:  Database [Almacen]    Script Date: 06/12/2022 09:15:23 A.M. ******/
CREATE DATABASE [Almacen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Almacen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Almacen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Almacen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Almacen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Almacen] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Almacen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Almacen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Almacen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Almacen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Almacen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Almacen] SET ARITHABORT OFF 
GO
ALTER DATABASE [Almacen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Almacen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Almacen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Almacen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Almacen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Almacen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Almacen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Almacen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Almacen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Almacen] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Almacen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Almacen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Almacen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Almacen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Almacen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Almacen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Almacen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Almacen] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Almacen] SET  MULTI_USER 
GO
ALTER DATABASE [Almacen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Almacen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Almacen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Almacen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Almacen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Almacen] SET QUERY_STORE = OFF
GO
USE [Almacen]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[clId] [int] IDENTITY(1,1) NOT NULL,
	[clCuit] [nvarchar](50) NOT NULL,
	[clRazonSocial] [nvarchar](50) NOT NULL,
	[clDireccion] [nvarchar](50) NULL,
	[clTelefono] [nvarchar](50) NULL,
	[clEmail] [nvarchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[clId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idiomas]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idiomas](
	[Código] [int] NOT NULL,
	[Descripción] [nvarchar](255) NULL,
 CONSTRAINT [PK_Idiomas] PRIMARY KEY CLUSTERED 
(
	[Código] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paises]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paises](
	[Código] [int] NOT NULL,
	[Denominación] [nvarchar](255) NULL,
	[País] [nvarchar](255) NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[Código] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[prId] [int] IDENTITY(1,1) NOT NULL,
	[prDescripcion] [varchar](50) NULL,
	[prUnidadMedida] [varchar](50) NULL,
	[prPrecioVenta] [decimal](18, 2) NULL,
	[prPrecioCompra] [decimal](18, 2) NULL,
	[prFechaActPrecioVenta] [date] NULL,
	[prFechaActPrecioCompra] [date] NULL,
 CONSTRAINT [PK__Producto__466486D5D4A6A2B9] PRIMARY KEY CLUSTERED 
(
	[prId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductosPedidos]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductosPedidos](
	[ppId] [int] IDENTITY(1,1) NOT NULL,
	[ppIdProducto] [int] NOT NULL,
	[ppIdCliente] [int] NOT NULL,
	[ppCantidad] [float] NOT NULL,
	[ppPrecioVenta] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_ProductosPedidos] PRIMARY KEY CLUSTERED 
(
	[ppId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[Código] [int] NOT NULL,
	[Descripción] [nvarchar](255) NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[Código] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposCbte]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposCbte](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
	[FchDesde] [nvarchar](8) NULL,
	[FchHasta] [nvarchar](8) NULL,
 CONSTRAINT [PK_TiposCbte] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDoc]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDoc](
	[Id] [int] NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL,
	[FchDesde] [nvarchar](8) NULL,
	[FchHasta] [nvarchar](8) NULL,
 CONSTRAINT [PK_TiposDoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposMonedas]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposMonedas](
	[Id] [nvarchar](3) NOT NULL,
	[Descripcion] [nvarchar](250) NULL,
	[FchDesde] [nvarchar](8) NULL,
	[FchHasta] [nvarchar](8) NULL,
 CONSTRAINT [PK_TiposMonedas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposRespIva]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposRespIva](
	[Código] [int] NOT NULL,
	[Descripción] [nvarchar](255) NULL,
	[F3] [nvarchar](255) NULL,
	[F4] [nvarchar](255) NULL,
 CONSTRAINT [PK_TiposRespIva] PRIMARY KEY CLUSTERED 
(
	[Código] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadesMedida]    Script Date: 06/12/2022 09:15:23 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadesMedida](
	[Codigo] [nvarchar](255) NOT NULL,
	[Descripción] [nvarchar](255) NULL,
 CONSTRAINT [PK_UnidadesMedida] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Almacen] SET  READ_WRITE 
GO
