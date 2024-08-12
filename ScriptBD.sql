-- BORRADO DE BASE DE DATOS
USE master;
GO
DROP DATABASE IZUMUClientes;
GO

-- CREACIÓN DE BASE DE DATOS
CREATE DATABASE IZUMUClientes;
GO
USE IZUMUClientes;
GO
--CREACION DE TABLAS
CREATE TABLE IZ_TIPODOCUMENTO(
	TipoDoc nvarchar(5) primary key,
	Descripcion nvarchar(30),
	FechaReg datetime default Getdate()
	);

CREATE TABLE IZ_PLAN(
    IdPlan int primary key,
	NombrePlan nvarchar(100),
	FechaReg datetime default Getdate()
	);

CREATE TABLE IZ_CLIENTE(
	TipoDoc nvarchar(5),
	NumeroDocumento nvarchar(15) primary key,
	FechaNacimiento date,
	PrimerNombre nvarchar(200) not null,
	SegundoNombre nvarchar(200) not null,
	PrimerApellido nvarchar(200) not null,
	SegundoApellido nvarchar(200) not null,
	Direccion nvarchar(300),
	NumeroCelular nvarchar(13),
	Email nvarchar(200),
	IdPlan integer,
	FechaReg datetime default Getdate(),
	CONSTRAINT fk_TipoDoc FOREIGN KEY (TipoDoc) REFERENCES IZ_TIPODOCUMENTO (TipoDoc),
	CONSTRAINT fk_IdPlan FOREIGN KEY (IdPlan) REFERENCES IZ_PLAN (IdPlan),
	);

	--Inserción de datos
	INSERT INTO IZ_TIPODOCUMENTO (TipoDoc, Descripcion)
    VALUES ('CC', 'Cedula de ciudadania');
	INSERT INTO IZ_TIPODOCUMENTO (TipoDoc, Descripcion)
    VALUES ('TI', 'Tarjeta de identidad');
	INSERT INTO IZ_TIPODOCUMENTO (TipoDoc, Descripcion)
    VALUES ('RC', 'Registro civil');
	INSERT INTO IZ_TIPODOCUMENTO (TipoDoc, Descripcion)
    VALUES ('CE', 'Cedula de extranjeria');
	INSERT INTO IZ_TIPODOCUMENTO (TipoDoc, Descripcion)
    VALUES ('PA', 'Pasaporte');

	--Inserción de datos
	INSERT INTO IZ_PLAN (IdPlan, NombrePlan)
    VALUES (1, 'PLAN ESMERALDA ELITE');
	INSERT INTO IZ_PLAN (IdPlan, NombrePlan)
    VALUES (2, 'PLAN ZAFIRO ELITE SUPERIOR');
	INSERT INTO IZ_PLAN (IdPlan, NombrePlan)
    VALUES (3, 'PLAN DIAMANTE ELITE SUPERIOR');
	INSERT INTO IZ_PLAN (IdPlan, NombrePlan)
    VALUES (4, 'PLAN DIAMANTE ELITE');
	INSERT INTO IZ_PLAN (IdPlan, NombrePlan)
    VALUES (5, 'PLAN ZAFIRO EXCLUSIVO');
	INSERT INTO IZ_PLAN (IdPlan, NombrePlan)
    VALUES (6, 'PLAN ZAFIRO ELITE');
	INSERT INTO IZ_PLAN (IdPlan, NombrePlan)
    VALUES (7, 'PLAN OCEANO');
	INSERT INTO IZ_PLAN (IdPlan, NombrePlan)
    VALUES (8, 'PLAN COLINA EXCLUSIVO');
	INSERT INTO IZ_PLAN (IdPlan, NombrePlan)
    VALUES (9, 'PLAN RUBI INTEGRAL');
GO
	--SELECT * FROM IZ_TIPODOCUMENTO;
	--SELECT * FROM IZ_PLAN;
	--SELECT * FROM IZ_CLIENTE;

--CREACIÓN PROCEDIMIENTOS ALMACENADOS
CREATE PROCEDURE SP_GET_IZUMU_CLIENTESXDOC
	@TipoDoc nvarchar(50),
    @NumDoc nvarchar(50)
AS
   SELECT TipoDoc,	
           NumeroDocumento,
           FechaNacimiento, 
           PrimerNombre, 	
           SegundoNombre, 	
           PrimerApellido, 	
           SegundoApellido,	
           Direccion,		
           NumeroCelular,	
           Email,			
		   PL.IdPlan,
           PL.NombrePlan
   FROM IZ_CLIENTE CLI, IZ_PLAN PL
   WHERE CLI.IdPlan = PL.IdPlan
   AND CLI.TipoDoc = @TipoDoc
   AND CLI.NumeroDocumento = @NumDoc;
GO

CREATE PROCEDURE SP_GET_IZUMU_CLIENTES
AS
   SELECT  TipoDoc,	
           NumeroDocumento,
           FechaNacimiento, 
           PrimerNombre, 	
           SegundoNombre, 	
           PrimerApellido, 	
           SegundoApellido,	
           Direccion,		
           NumeroCelular,	
           Email,
		   PL.IdPlan,
           PL.NombrePlan
   FROM IZ_CLIENTE CLI, IZ_PLAN PL
   where CLI.IdPlan = PL.IdPlan;
GO

CREATE PROCEDURE SP_UPDATE_IZUMU_CLIENTES
	@TipoDoc nvarchar(50),
    @NumDoc nvarchar(50),
    @FechaNacimiento date,
	@PrimerNombre nvarchar(200),
	@SegundoNombre nvarchar(200),
	@PrimerApellido nvarchar(200),
	@SegundoApellido nvarchar(200),
	@Direccion nvarchar(300),
	@NumeroCelular nvarchar(13),
	@Email nvarchar(200),
	@IdPlan integer,
	@NombrePlan nVarchar(100)

AS
   UPDATE IZ_CLIENTE
   SET FechaNacimiento = @FechaNacimiento,
	   PrimerNombre = @PrimerNombre, 	
	   SegundoNombre = @SegundoNombre, 	
	   PrimerApellido = @PrimerApellido, 
	   SegundoApellido = @SegundoApellido,
	   Direccion = @Direccion,		
	   NumeroCelular = @NumeroCelular,	
	   Email = @Email,			
	   IdPlan = @IdPlan
   WHERE TipoDoc = @TipoDoc
   AND NumeroDocumento = @NumDoc;

GO

CREATE PROCEDURE SP_INSERT_IZUMUCLIENTES
	@TipoDoc nvarchar(50),
    @NumDoc nvarchar(50),
	@FechaNacimiento date,
	@PrimerNombre nvarchar(50),
	@SegundoNombre nvarchar(50),
	@PrimerApellido nvarchar(50),
	@SegundoApellido nvarchar(50),
	@Direccion nVarchar(100),
	@NumeroCelular nVarchar(15),
	@Email nVarchar(100),
	@IdPlan int,
	@NombrePlan nVarchar(100)
AS
   INSERT INTO IZ_CLIENTE (TipoDoc, NumeroDocumento, FechaNacimiento, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Direccion, NumeroCelular, Email, IdPlan)
    VALUES(@TipoDoc, @NumDoc, @FechaNacimiento, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @Direccion, @NumeroCelular, @Email, @IdPlan);

GO

CREATE PROCEDURE SP_DELETE_IZUMUCLIENTES
	@TipoDoc nvarchar(50),
    @NumDoc nvarchar(50)
AS
   DELETE IZ_CLIENTE
   WHERE TipoDoc= @TipoDoc
   AND NumeroDocumento = @NumDoc;
GO

CREATE PROCEDURE SP_GET_IZUMU_TIPODOC
AS
   SELECT TipoDoc, Descripcion
   FROM IZ_TIPODOCUMENTO;
GO

CREATE PROCEDURE SP_GET_IZUMU_PLAN
AS
   SELECT IdPlan, NombrePlan 
   FROM IZ_PLAN;
GO