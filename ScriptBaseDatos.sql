-- =========================================
-- Create table template Windows Azure SQL Database 
-- =========================================

CREATE TABLE Usuario
(
	IdUsuario int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(100) not null
)

CREATE TABLE Categoria
(
	IdCategoria int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(100) not null,
	Imagen varchar(100)
)

CREATE TABLE Restaurant
(
	IdRestaurant int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(100),
	Descripcion varchar(100),
	Direccion varchar(100)
)

CREATE TABLE Favorito
(
	IdRestaurant int,
	IdUsuario int,
	Fecha datetime,
	PRIMARY KEY (IdRestaurant,IdUsuario),
	FOREIGN KEY (IdRestaurant) REFERENCES Restaurant(IdRestaurant),
	FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
)

CREATE TABLE Calificacion
(
	IdRestaurant int,
	IdUsuario int,
	Fecha datetime,
	Puntaje decimal(2,2),
	Comentario varchar(100),
	PRIMARY KEY (IdRestaurant,IdUsuario),
	FOREIGN KEY (IdRestaurant) REFERENCES Restaurant(IdRestaurant),
	FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
)

CREATE TABLE Restaurant_Categoria
(
	IdRestaurant int,
	IdCategoria int,
	PRIMARY KEY (IdRestaurant,IdCategoria),
	FOREIGN KEY (IdRestaurant) REFERENCES Restaurant(IdRestaurant),
	FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
)
