create database T_InLock;

use T_InLock;

create table Estudios
(
	 IdEstudio int primary key identity not null
	,NomeEstudio  varchar(500) not null
	,PaisOrigem varchar (500) not null
	,DataCriacao datetime not null
	,IdUsuario int foreign key references Usuarios (IdUsuario)
);

create table Jogos 
(
	IdJogo int primary key identity not null
   ,NomeJogo varchar(500) not null
   ,Descricao varchar(500) not null
   ,DataLancamento datetime not null
   ,IdEstudio int foreign key references Estudios (IdEstudio)
);

drop table Jogos

create table Jogos 
(
	IdJogo int primary key identity not null
   ,NomeJogo varchar(500) not null
   ,Descricao varchar(500) not null
   ,DataLancamento datetime not null
   ,Valor varchar(500) not null
   ,IdEstudio int foreign key references Estudios (IdEstudio)
);

create table Usuarios
(
	IdUsuario int primary key identity not null
	,Email varchar(500) not null unique
	,Senha  varchar(500) not null
	,Permissao  varchar (255) not null
);

drop table Jogos 

create table Jogos 
(
	IdJogo int primary key identity not null
   ,NomeJogo varchar(500) not null
   ,Descricao varchar(500) not null
   ,DataLancamento datetime not null
   ,IdEstudio int foreign key references Estudios (IdEstudio)
   ,Valor varchar(500) not null
);