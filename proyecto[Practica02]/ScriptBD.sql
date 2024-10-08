USE [Actividad1_5]
GO
/****** Object:  Table [dbo].[T_DetallesFacturas]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_DetallesFacturas](
	[ID_Detalle] [int] NOT NULL,
	[ID_Factura] [int] NOT NULL,
	[ID_Producto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [int] NOT NULL,
 CONSTRAINT [PK_Detalles] PRIMARY KEY CLUSTERED 
(
	[ID_Factura] ASC,
	[ID_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Facturas]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Facturas](
	[ID_Factura] [int] IDENTITY(1,1) NOT NULL,
	[ID_MetodoPago] [int] NOT NULL,
	[Cliente] [varchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED 
(
	[ID_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_MetodosPago]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_MetodosPago](
	[ID_MetodoPago] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MetodosPago] PRIMARY KEY CLUSTERED 
(
	[ID_MetodoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Productos]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Productos](
	[ID_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[T_DetallesFacturas] ([ID_Detalle], [ID_Factura], [ID_Producto], [Cantidad], [Precio]) VALUES (1, 1, 1, 23, 59)
INSERT [dbo].[T_DetallesFacturas] ([ID_Detalle], [ID_Factura], [ID_Producto], [Cantidad], [Precio]) VALUES (1, 2, 3, 23, 96)
GO
SET IDENTITY_INSERT [dbo].[T_Facturas] ON 

INSERT [dbo].[T_Facturas] ([ID_Factura], [ID_MetodoPago], [Cliente], [Fecha]) VALUES (1, 1, N'dddd', CAST(N'2024-09-06T15:59:29.987' AS DateTime))
INSERT [dbo].[T_Facturas] ([ID_Factura], [ID_MetodoPago], [Cliente], [Fecha]) VALUES (2, 1, N'thiago', CAST(N'2024-09-06T16:20:36.917' AS DateTime))
SET IDENTITY_INSERT [dbo].[T_Facturas] OFF
GO
INSERT [dbo].[T_MetodosPago] ([ID_MetodoPago], [Nombre]) VALUES (0, N'Efectivo')
INSERT [dbo].[T_MetodosPago] ([ID_MetodoPago], [Nombre]) VALUES (1, N'Tarjeta')
GO
SET IDENTITY_INSERT [dbo].[T_Productos] ON 

INSERT [dbo].[T_Productos] ([ID_Producto], [Nombre], [Precio], [Stock], [Activo]) VALUES (1, N'mancuerna de 13 kg', CAST(59.00 AS Decimal(10, 2)), 89, 1)
INSERT [dbo].[T_Productos] ([ID_Producto], [Nombre], [Precio], [Stock], [Activo]) VALUES (2, N'mancuerna de 16 kg', CAST(3.00 AS Decimal(10, 2)), 84, 0)
INSERT [dbo].[T_Productos] ([ID_Producto], [Nombre], [Precio], [Stock], [Activo]) VALUES (3, N'string', CAST(0.00 AS Decimal(10, 2)), 0, 1)
INSERT [dbo].[T_Productos] ([ID_Producto], [Nombre], [Precio], [Stock], [Activo]) VALUES (4, N'JAMAL', CAST(23.00 AS Decimal(10, 2)), 23, 1)
INSERT [dbo].[T_Productos] ([ID_Producto], [Nombre], [Precio], [Stock], [Activo]) VALUES (5, N'ahmed', CAST(11.00 AS Decimal(10, 2)), 11, 1)
SET IDENTITY_INSERT [dbo].[T_Productos] OFF
GO
ALTER TABLE [dbo].[T_DetallesFacturas]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Facturas] FOREIGN KEY([ID_Factura])
REFERENCES [dbo].[T_Facturas] ([ID_Factura])
GO
ALTER TABLE [dbo].[T_DetallesFacturas] CHECK CONSTRAINT [FK_Detalles_Facturas]
GO
ALTER TABLE [dbo].[T_DetallesFacturas]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Productos] FOREIGN KEY([ID_Producto])
REFERENCES [dbo].[T_Productos] ([ID_Producto])
GO
ALTER TABLE [dbo].[T_DetallesFacturas] CHECK CONSTRAINT [FK_Detalles_Productos]
GO
ALTER TABLE [dbo].[T_Facturas]  WITH CHECK ADD  CONSTRAINT [FK_Facturas_MetodosPago] FOREIGN KEY([ID_MetodoPago])
REFERENCES [dbo].[T_MetodosPago] ([ID_MetodoPago])
GO
ALTER TABLE [dbo].[T_Facturas] CHECK CONSTRAINT [FK_Facturas_MetodosPago]
GO
/****** Object:  StoredProcedure [dbo].[SP_BorrarProducto]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_BorrarProducto]
(
@codigo int
)
as
begin
update T_Productos set Activo=0 where ID_Producto = @codigo
end
GO
/****** Object:  StoredProcedure [dbo].[SP_EditarArticulo]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EditarArticulo]
    @codigo INT,
    @nombre VARCHAR(100),
    @precio DECIMAL(18, 2),
    @stock INT,
    @activo BIT
AS
BEGIN
   

    UPDATE T_Productos
    SET
        Nombre = @nombre,
        Precio = @precio,
        Stock = @stock,
        Activo = @activo
    WHERE
        ID_Producto = @codigo;


END;
GO
/****** Object:  StoredProcedure [dbo].[SP_GuardarDetalle]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_GuardarDetalle]
(
@detalle int,
@factura int,
@producto int,
@cantidad int,
@precio decimal(10,2)
)
as
begin
INSERT INTO T_DetallesFacturas(ID_Detalle, ID_Factura, ID_Producto,Cantidad,Precio) VALUES (@detalle, @factura, @producto,@cantidad,@precio);
end
GO
/****** Object:  StoredProcedure [dbo].[SP_GuardarFactura]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GuardarFactura]
	@cliente varchar(50),
	@metodopago int,
	@id int output
AS
BEGIN
	INSERT INTO T_Facturas(cliente, fecha, ID_MetodoPago) VALUES (@cliente, GETDATE(), @metodopago);
	SET @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GuardarProducto]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_GuardarProducto]
@nombre varchar(50),
@precio decimal(10,2),
@stock int,
@activo bit
as
begin
insert into T_Productos (Nombre,Precio,Stock,Activo) values(@nombre,@precio,@stock,@activo) 
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RecuperarFacturas]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RecuperarFacturas]
	
AS
BEGIN
	Select F.*,D.ID_Detalle,D.ID_Producto,D.Cantidad,D.Precio,P.Nombre,P.Precio as PrecioProducto,P.Activo from T_Facturas as F
	inner join T_DetallesFacturas as D on F.ID_Factura = D.ID_Factura
	inner join T_Productos as P on P.ID_Producto = D.ID_Producto
	order by F.ID_Factura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RecuperarFacturas_Codigo]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RecuperarFacturas_Codigo]
@codigo	int
AS
BEGIN
	Select F.*,D.ID_Detalle,D.ID_Producto,D.Cantidad,D.Precio,P.Nombre,P.Precio as PrecioProducto,P.Activo from T_Facturas as F
	inner join T_DetallesFacturas as D on F.ID_Factura = D.ID_Factura
	inner join T_Productos as P on P.ID_Producto = D.ID_Producto
	where F.ID_Factura = @codigo
	order by F.ID_Factura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RecuperarProducto_Codigo]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RecuperarProducto_Codigo]
@codigo int
as
begin
select * from T_Productos where ID_Producto = @codigo
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RecuperarProductos]    Script Date: 9/17/2024 4:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RecuperarProductos]
as
begin
select * from T_Productos
end
GO
