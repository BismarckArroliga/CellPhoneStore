CREATE DATABASE BD_CellPhoneStore
GO

USE BD_CellPhoneStore
GO

CREATE TABLE Cargos
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Nombre VARCHAR(50)
)
GO

CREATE TABLE Empleados
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Nombre VARCHAR(50),
  Apellido VARCHAR(50),
  Telefono VARCHAR(15),
  Direccion VARCHAR(50),
  Cedula VARCHAR(50),
  Cargo_Id INT

  CONSTRAINT empleados_cargos_id FOREIGN KEY (Cargo_Id) REFERENCES Cargos (Id)
)
GO

CREATE TABLE Usuarios
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Usuario VARCHAR(50),
  Contrasena VARCHAR(50),
  Empleado_Id INT

  CONSTRAINT usuarios_empleados_id FOREIGN KEY (Empleado_Id) REFERENCES Empleados (Id)
)
GO

CREATE TABLE Clientes
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Nombre VARCHAR(50),
  Apellido VARCHAR(50),
  Cedula VARCHAR(50)
)
GO

CREATE TABLE Estados
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Nombre VARCHAR(50)
)
GO

CREATE TABLE Productos
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Nombre VARCHAR(50),
  Marca VARCHAR(50),
  Descripcion TEXT,
  PrecioCosto DECIMAL(10,2),
  PrecioVenta DECIMAL(10,2),
  Stock INT DEFAULT 0,
  Estado_Id INT

  CONSTRAINT productos_estados_id FOREIGN KEY (Estado_Id) REFERENCES Estados (Id)
)
GO

CREATE TABLE TipoDocumento
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Nombre VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Proveedores
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Nombre VARCHAR(50),
  RUC VARCHAR(50),
  Direccion VARCHAR(50),
  Telefono VARCHAR(50),
  Email VARCHAR(50)
)
GO

CREATE TABLE Compras
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Fecha DATE,
  Documento_Id INT,
  Empleado_Id INT,
  Proveedor_Id INT,
  Total DECIMAL(10,2)

  CONSTRAINT compras_tipoDocumento_id FOREIGN KEY (Documento_Id) REFERENCES TipoDocumento (Id),
  CONSTRAINT compras_empleado_id FOREIGN KEY (Empleado_Id) REFERENCES Empleados (Id),
  CONSTRAINT compras_proveedor_id FOREIGN KEY (Proveedor_Id) REFERENCES Proveedores (Id)
)
GO

CREATE TABLE DetalleCompras
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Compra_Id INT,
  Producto_Id INT,
  Cantidad INT ,
  Costo DECIMAL(10,2),
  Descuento DECIMAL(10,2),
  Total DECIMAL(10,2)

  CONSTRAINT detalleCompras_compras_id FOREIGN KEY (Compra_Id) REFERENCES Compras (Id),
  CONSTRAINT detalleCompras_producto_id FOREIGN KEY (Producto_Id) REFERENCES Productos (Id)
)
GO

CREATE TABLE Ventas
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Fecha DATE,
  Documento_Id INT,
  Empleado_Id INT,
  Cliente_Id INT,
  Total DECIMAL(10,2)

  CONSTRAINT ventas_tipoDocumentos_id FOREIGN KEY (Documento_Id) REFERENCES TipoDocumento (Id),
  CONSTRAINT ventas_empleados_id FOREIGN KEY (Empleado_Id) REFERENCES Empleados (Id),
  CONSTRAINT ventas_clientes_id FOREIGN KEY (Cliente_Id) REFERENCES Clientes (Id)
)
GO

CREATE TABLE DetalleVentas
(
  Id INT PRIMARY KEY IDENTITY (1,1),
  Venta_Id INT,
  Producto_Id INT,
  Unidades INT,
  Precio DECIMAL(10,2),
  Descuento DECIMAL(10,2),
  Total DECIMAL(10,2)

  CONSTRAINT detalleVentas_ventas_id FOREIGN KEY (Venta_Id) REFERENCES Ventas (Id),
  CONSTRAINT detalleVentas_productos_id FOREIGN KEY (Producto_Id) REFERENCES Productos (Id)
)
GO
 

   /*=================== INSERCIONES ALAS TABLAS ===================*/

INSERT INTO Cargos (Nombre)
    VALUES ('ADMINISTRADOR'), ('REPORTEADOR'), ('VENDEDOR')
GO

INSERT INTO Empleados (Nombre, Apellido, Telefono, Direccion, Cedula, Cargo_Id)
    VALUES ('Denis', 'Hernandez', '+50589307934', 'Managua', '3812305981003B', 1),
           ('Camy', 'Hernandez', '+50589230099', 'Managua', '3811105201003B', 1)
GO

INSERT INTO Usuarios (Usuario, Contrasena, Empleado_Id)
    VALUES ('Denis', '212865', 1),
           ('Camy', '212855', 2)
GO

INSERT INTO Clientes (Nombre, Apellido, Cedula)
    VALUES ('Denis', 'Hernandez', '2811202201004N'),
           ('Carlos', 'Lopez', '2811105201001V'),
           ('Franklin', 'Peralta', '5811105201103N'),
           ('Walter', 'Garcia', '8811105208203B'),
           ('Elvis', 'VillaReyna', '2810105209003G')
GO

INSERT INTO Estados (Nombre)
    VALUES ('ACTIVO'), ('INACTIVO')
GO

INSERT INTO Productos (Nombre, Marca, Descripcion, PrecioCosto, PrecioVenta, Stock, Estado_Id)
  VALUES ('Samsung Galaxy S10', 'Samsung', '4GB', 340.00, 360.00, DEFAULT, 2),
         ('Readmi 10C', 'Readmi', '2GB', 150.00, 170.00, DEFAULT , 2)
GO

INSERT INTO TipoDocumento (Nombre)
    VALUES ('FACTURA')
GO

INSERT INTO Proveedores (Nombre, RUC, Direccion, Telefono, Email)
  VALUES ('JUAN PEREZ', '42040234412', 'Managua', '+50589776655', 'juanperez23@gmail.com'),
         ('SANTA CATALINA', '72070234100', 'Managua', '+50588776100', 'santacatl@gmail.com')
GO


/*==================PROCEDIMIENTOS ALMACENADOS===================*/

-----------------------------------------PROCEDIMIENTOS PARA EMPLEADOS
CREATE PROC sp_empleados
  @op CHAR(1) = NULL ,
  @id INT = NULL ,
  @nombre VARCHAR(50) = NULL ,
  @apellido VARCHAR(50) = NULL ,
  @telefono VARCHAR(15) = NULL ,
  @direccion VARCHAR(50) = NULL ,
  @cedula VARCHAR(50) = NULL ,
  @cargo_Id INT = NULL
AS
  BEGIN
    IF(@op = 'L')
      BEGIN
        SELECT e.Id, e.Nombre, e.Apellido, e.Telefono, e.Direccion, e.Cedula, c.Nombre AS Cargo FROM Empleados AS e
		INNER JOIN Cargos AS c ON c.Id = e.Cargo_Id 
      END 
    IF (@op = 'I')
		BEGIN
		INSERT INTO Empleados (Nombre, Apellido, Telefono, Direccion, Cedula, Cargo_Id)
			VALUES (@nombre, @apellido, @telefono, @direccion, @cedula, @cargo_Id)
		END
	  ELSE 
    IF (@op = 'U')
	  IF NOT EXISTS (SELECT * FROM Empleados WHERE Cedula = @cedula AND Id != @id)
      BEGIN
        UPDATE Empleados SET Nombre = @nombre, Apellido = @apellido, Telefono = @telefono, Direccion = @direccion, Cedula = @cedula, Cargo_Id = @cargo_Id
        WHERE Id = @id
      END
	IF (@op = 'C')
		BEGIN
			SELECT * FROM Cargos
		END
	IF (@op = 'B')
		BEGIN
			SELECT * FROM Empleados WHERE Id = @id
		END
  END
GO

-----------------------------------------PROCEDIMIENTOS PARA USUARIOS
CREATE PROC sp_usuarios
  @op CHAR(1) = NULL,
  @usuario VARCHAR(50) = NULL ,
  @contrasena VARCHAR(50) = NULL ,
  @empleado_Id INT = NULL
AS
  BEGIN
    IF (@op = 'L')
      BEGIN
        SELECT e.Id, e.Nombre, e.Apellido, c.Nombre as Cargo FROM Usuarios AS u
        INNER JOIN Empleados AS e ON e.Id = u.Empleado_Id
        INNER JOIN Cargos AS c ON c.Id = e.Cargo_Id
        WHERE u.Usuario = @usuario AND u.Contrasena = @contrasena
      END
    IF (@op = 'I')
      BEGIN
        INSERT INTO Usuarios (Usuario, Contrasena, Empleado_Id)
            VALUES (@usuario, @contrasena, @empleado_Id)
      END
    IF (@op = 'U')
	  BEGIN
		 UPDATE Usuarios SET Usuario = @usuario, Contrasena = @contrasena
		 WHERE  Empleado_Id = @empleado_Id
	  END
	   IF (@op = 'B')
	BEGIN
		 SELECT * FROM Usuarios WHERE Empleado_Id = @empleado_Id
	END
  END
GO

-----------------------------------------PROCEMIENTOS PARA CLIENTES
CREATE PROC sp_clientes
  @op CHAR(1) = NULL ,
  @id INT = NULL ,
  @nombre VARCHAR(50) = NULL ,
  @apellido VARCHAR(50) = NULL ,
  @cedula VARCHAR(50) = NULL
AS
  BEGIN
    IF (@op = 'L')
      BEGIN
        SELECT * FROM Clientes
      END
    IF (@op = 'I')
      BEGIN
        INSERT INTO Clientes (Nombre, Apellido, Cedula)
            VALUES (@nombre, @apellido, @cedula)
      END
    IF (@op = 'U')
      BEGIN
        UPDATE Clientes SET Nombre = @nombre, Apellido = @apellido, Cedula = @cedula
        WHERE Id = @id
      END
	IF (@op = 'B')
	  BEGIN
		SELECT * FROM Clientes WHERE Id = @id 
      END
  END
GO
-----------------------------------------PROCEMIENTOS PARA PRODUCTOS
CREATE PROC sp_productos
  @op CHAR(1) = NULL ,
  @id INT = NULL ,
  @nombre VARCHAR(50) = NULL ,
  @marca VARCHAR(50) = NULL ,
  @descripcion TEXT = NULL ,
  @precioCosto DECIMAL(10,2) = NULL ,
  @precioVenta DECIMAL(10,2) = NULL ,
  @stock INT = NULL,
  @unidades INT = NULL,
  @estado_Id INT = NULL
AS
  BEGIN
    IF (@op = 'L') -- LISTAR PRODUCTOS
      BEGIN
        SELECT p.Id, p.Nombre, p.Marca, p.Descripcion, p.PrecioCosto, p.PrecioVenta, p.Stock, e.Nombre AS Estado FROM Productos AS p
        INNER JOIN Estados AS e ON e.Id = p.Estado_Id
      END
	IF (@op = 'I') -- INSERTAR PRODUCTOS
      BEGIN
		INSERT INTO Productos (Nombre, Marca, Descripcion, PrecioCosto, PrecioVenta, Estado_Id) 
			VALUES(@nombre, @marca, @descripcion, @precioCosto, @precioVenta, @estado_Id)
      END
    IF (@op = 'U') -- ACTUALIZAR PRODUCTOS
      BEGIN
        UPDATE Productos SET Nombre = @nombre, Marca = @marca, Descripcion = @descripcion, PrecioCosto = @precioCosto, PrecioVenta = @precioVenta, Estado_Id = @estado_Id
        WHERE  Id = @id
	  END
	IF (@op = 'E') -- LISTAR ESTADOS 
      BEGIN
         SELECT * FROM Estados
	  END
	IF (@op = 'B') -- BUSCAR
      BEGIN
         SELECT * FROM Productos WHERE Id = @id
	  END
	IF (@op = 'R') -- RESTAR EXISTENCIAS
		BEGIN
			UPDATE Productos SET Stock = Stock - @unidades WHERE Id = @id
		END
	IF (@op = 'S') -- SUMAR EXISTENCIAS
		BEGIN
			UPDATE Productos SET Stock = Stock + @unidades WHERE Id = @id
		END
	END
GO

-----------------------------------------PROCEMIENTOS PARA PROVEEDORES
CREATE PROC sp_proveedores
  @op CHAR(1) = NULL ,
  @id INT = NULL ,
  @nombre VARCHAR(50) = NULL ,
  @ruc VARCHAR(50) = NULL ,
  @direccion VARCHAR(50) = NULL ,
  @telefono VARCHAR(50) = NULL ,
  @email VARCHAR(50) = NULL
AS
  BEGIN
    IF (@op = 'L')
      BEGIN
        SELECT * FROM Proveedores
      END
    IF (@op = 'I')
      BEGIN
        INSERT INTO Proveedores (Nombre, RUC, Direccion, Telefono, Email)
            VALUES (@nombre, @ruc, @direccion, @telefono, @email)
      END
    IF (@op = 'U')
      BEGIN
        UPDATE Proveedores SET Nombre = @nombre, RUC = @ruc, Direccion = @direccion, Telefono = @telefono, Email = @email
        WHERE Id = @id
      END
	IF (@op = 'B')
      BEGIN
        SELECT * FROM Proveedores WHERE Id = @id
      END
  END
GO


CREATE PROC sp_tipoDocumento
AS
  SELECT * FROM TipoDocumento;
GO


--- ESTRUCTURA PARA EL DETALLLE DE COMPRA
	CREATE TYPE [dbo].[EDetalleCompra] AS TABLE (
	[Producto_Id] INT NULL,
	[Cantidad] INT NULL,
	[Costo] DECIMAL(10,2) NULL,
	[Descuento] DECIMAL(10,2) NULL,
	[Total] DECIMAL(10,2) NULL
)
GO 

CREATE PROC sp_compras
  @op CHAR(1) = NULL,
  @id INT = NULL,
  @fecha DATE = NULL ,
  @documento_Id INT = NULL ,
  @empleado_Id INT = NULL ,
  @proveedor_Id INT = NULL ,
  @total DECIMAL(10,2) = NULL,
  @detalleCompra [EDetalleCompra] READONLY
AS
	BEGIN
	IF (@op = 'L')
		BEGIN
		 SELECT c.Id, c.Fecha, td.Nombre AS Documento, c.Empleado_Id, c.Proveedor_Id, c.Total
		 FROM Compras AS c 
		 INNER JOIN TipoDocumento AS td ON td.Id = c.Documento_Id 
		END

	IF (@op = 'I')
		BEGIN TRY
			DECLARE @idCompra INT = 0;					
			BEGIN TRAN registro
				INSERT INTO Compras(Fecha, Documento_Id, Empleado_Id, Proveedor_Id, Total)
					VALUES (CONVERT(DATE, GETDATE(), 103), @documento_Id, @empleado_Id, @proveedor_Id, @total)
			
				SET @idCompra = SCOPE_IDENTITY();
				
				INSERT INTO DetalleCompras (Compra_Id, Producto_Id, Cantidad, Costo, Descuento, Total)
					SELECT @idCompra, Producto_Id, Cantidad, Costo,Descuento, Total FROM @detalleCompra
				
				UPDATE p SET p.Stock = p.Stock + dc.Cantidad,
				p.Estado_Id = 1
				FROM Productos AS p
				INNER JOIN @DetalleCompra AS dc ON dc.Producto_Id = p.Id

			COMMIT TRAN registro
		END TRY
		BEGIN CATCH
			/* Si ocurre un error borrara todo y no se insertara niguna fila */
			ROLLBACK TRAN registro
		END CATCH
	END
	IF (@op = 'T')
		BEGIN
			SELECT COUNT(*) FROM Compras
		END
GO


 --- ESTRUCTURA PARA EL DETALLLE DE VENTA
	CREATE TYPE [dbo].[EDetalleVenta] AS TABLE (
	[Producto_Id] INT NULL,
	[Unidades] INT NULL,
	[Precio] DECIMAL(10,2) NULL,
	[Descuento] DECIMAL(10,2) NULL,
	[Total] DECIMAL(10,2) NULL
)
GO 

CREATE PROC sp_ventas
  @op CHAR(1) = NULL,
  @id INT = NULL,
  @fecha DATE = NULL ,
  @documento_Id INT = NULL ,
  @empleado_Id INT = NULL ,
  @cliente_Id INT = NULL ,
  @total DECIMAL(10,2) = NULL,
  @DetalleVenta [EDetalleVenta] READONLY
AS
	BEGIN
	IF (@op = 'L')
		BEGIN
			 SELECT v.Id, v.Fecha, td.Nombre AS Documento, v.Empleado_Id, v.Cliente_Id, v.Total
			 FROM Ventas AS v 
			 INNER JOIN TipoDocumento AS td ON td.Id = v.Documento_Id 
		END
	IF(@op = 'I')
		BEGIN
		BEGIN TRY
			DECLARE @idVenta INT = 0
			/* INICIAR TRANSACCIÓN */
			BEGIN TRAN registro

			INSERT INTO Ventas (Fecha, Documento_Id, Empleado_Id, Cliente_Id, Total) 
				VALUES (CONVERT(DATE, GETDATE(),103), @documento_Id, @empleado_Id, @cliente_Id, @total)
			
			SET @idVenta = SCOPE_IDENTITY() /* OBTENER LA ULTIMA VENTA REALIZADA */

			INSERT INTO DetalleVentas (Venta_Id, Producto_Id, Unidades, Precio, Descuento, Total)
				SELECT @idVenta, Producto_Id , Unidades, Precio, Descuento, Total from @DetalleVenta
			COMMIT TRAN registro 
		 END TRY
			BEGIN CATCH
			/* Si ocurre un error borrara todo y no se insertara niguna fila */
			ROLLBACK TRAN registro
			END CATCH
		END
	IF (@op = 'T')
		BEGIN
			SELECT COUNT(*) FROM Ventas
		END
	END
GO

CREATE PROC sp_estados
  @op CHAR(1) = NULL,
  @producto_id INT = NULL
AS 
	BEGIN
	IF (@op = 'A')
		BEGIN
			UPDATE Productos SET Estado_Id = 1 WHERE Id = @producto_id
		END
	IF (@op = 'I')
		BEGIN
			UPDATE Productos SET Estado_Id = 2 WHERE Id = @producto_id
		END
	IF (@op = 'S')
		BEGIN
			SELECT SUM(Stock) as Stock FROM Productos WHERE Id = @producto_id
		END
	END
GO
 
-------------------------------------------------DETALLES COMPRAS
CREATE PROC sp_detalleCompras
  @compra_id INT = NULL
AS
	BEGIN
 		BEGIN 
			SELECT dc.Id, dc.Compra_Id, p.Nombre AS Producto, dc.Cantidad, dc.Costo, dc.Descuento, dc.Total
			FROM DetalleCompras AS dc
			INNER JOIN Productos AS p ON P.Id = dc.Producto_Id
			WHERE Compra_Id = @compra_id
		END
	END
GO

-------------------------------------------------DETALLES VENTAS
CREATE PROC sp_detalleVentas
  @venta_id INT = NULL
AS
BEGIN
	BEGIN
		SELECT dv.Id, dv.Venta_Id, p.Nombre AS Producto, dv.Unidades, dv.Precio, dv.Descuento, dv.Total 
		FROM DetalleVentas AS dv
		INNER JOIN Productos AS p ON P.Id = dv.Producto_Id
		WHERE Venta_Id = @venta_id
	END
END
GO
-------------------------------------------------GENERAR REPORTES DEL SISTEMA
CREATE PROC sp_reportes
  @op CHAR(1) = NULL
AS
	BEGIN
	IF (@op = 'P')
		BEGIN
			SELECT p.Id, p.Nombre, p.Marca, p.Descripcion, p.PrecioCosto, p.PrecioVenta, p.Stock, e.Nombre AS Estado
			FROM Productos AS p 
			INNER JOIN Estados AS e ON e.Id = p.Estado_Id
			WHERE Estado_Id = 1
		END
	IF (@op = 'C')
		BEGIN
			SELECT d.Compra_Id, Fecha, pv.Nombre AS Proveedor ,p.Nombre AS Producto, d.Cantidad, d.Costo, d.Descuento, d.Total FROM Compras AS c
			INNER JOIN Proveedores AS pv ON pv.Id = c.Proveedor_Id
			INNER JOIN DetalleCompras AS d ON d.Compra_Id = C.Id
			INNER JOIN Productos AS p ON p.Id = d.Producto_Id
			WHERE Fecha = CONVERT(DATE,GETDATE(), 103)
		END
	IF (@op = 'V')
		BEGIN
			SELECT dv.Venta_Id, v.Fecha, c.Nombre + '' + c.Apellido AS Cliente, p.Nombre AS Producto, dv.Precio, dv.Unidades, dv.Descuento, dv.Total 
			FROM Ventas AS v
			INNER JOIN Clientes AS c ON c.Id = V.Cliente_Id 
			INNER JOIN DetalleVentas AS dv ON dv.Venta_Id = v.Id			
			INNER JOIN Productos AS p ON p.Id = dv.Producto_Id 		
			WHERE Fecha = CONVERT(DATE,GETDATE(), 103)
		END
	END
GO



