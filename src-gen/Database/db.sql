CREATE TABLE Tienda (
   Id int NOT NULL IDENTITY, 
Nombre nvarchar(max) ,
TipoId int NOT NULL,
HoraAperturaId int NOT NULL,
HoraCierreId int NOT NULL,
   CONSTRAINT Pk_Tienda_Id PRIMARY KEY  (Id)
);
GO
 
CREATE TABLE TipoTienda (
   Id int NOT NULL IDENTITY, 
Nombre nvarchar(max) ,
Codigo nvarchar(max) ,
   CONSTRAINT Pk_TipoTienda_Id PRIMARY KEY  (Id)
);
GO
 
CREATE TABLE Horario (
   Id int NOT NULL IDENTITY, 
Nombre nvarchar(max) ,
   CONSTRAINT Pk_Horario_Id PRIMARY KEY  (Id)
);
GO
 
CREATE TABLE Producto (
   Id int NOT NULL IDENTITY, 
Nombre nvarchar(max) ,
Descripcion nvarchar(max) ,
Cantidad int ,
Descuento int ,
Valor int ,
Codigo nvarchar(max) ,
TiendaId int ,
   CONSTRAINT Pk_Producto_Id PRIMARY KEY  (Id)
);
GO
 
CREATE TABLE Cliente (
   Id int NOT NULL IDENTITY, 
Nombre nvarchar(max) ,
TarjetaCredito nvarchar(max) ,
   CONSTRAINT Pk_Cliente_Id PRIMARY KEY  (Id)
);
GO
 
ALTER TABLE Tienda 
ADD CONSTRAINT fk_Tienda_TipoTienda 
FOREIGN KEY ( TipoId ) 
REFERENCES TipoTienda( Id ) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE Tienda 
ADD CONSTRAINT fk_Tienda_Horario 
FOREIGN KEY ( HoraAperturaId ) 
REFERENCES Horario( Id ) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE Tienda 
ADD CONSTRAINT fk_Tienda_Horario 
FOREIGN KEY ( HoraCierreId ) 
REFERENCES Horario( Id ) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

ALTER TABLE Producto 
ADD CONSTRAINT fk_Producto_Tienda 
FOREIGN KEY ( TiendaId ) 
REFERENCES Tienda( Id ) 
ON DELETE NO ACTION 
ON UPDATE NO ACTION;
GO

