create database T_AutoPecas;

use T_AutoPecas;

-- DDL

create table Pecas 
(
	IdPecas int primary key identity not null 
	,CodigoPeca int not null unique
	,Descricao varchar (350) 
	,Peso varchar (350) not null
	,PrecoCusto  varchar (350) not null
	,PrecoVenda varchar (350) not null
	,IdFornecedor  int foreign key references Fornecedores (IdFornecedor)
);


create table Fornecedores 
(
	IdFornecedor int primary key identity not null
	,Nome varchar (350) not null
	,Cnpj varchar (350) not null unique
	,RazaoSocial varchar (350) not null
	,Endereco varchar (350) not null
	,IdUsuario int foreign key references Usuarios (IdUsuario)
);

create table Usuarios
(
	IdUsuario int primary key identity not null
	,Email varchar (350) not null
	,Senha varchar (350) not null
);

-- DML

insert into Usuarios (Email, Senha) Values ('tiagosola@gmail.com','123456')
										   ,('raysantos@gmail.com','654321')

insert into Fornecedores (Nome, Cnpj, RazaoSocial, Endereco, IdUsuario)
Values ('TiagoInterprisses','61.906.969/0001-10','Ti e Ago Companhia ME','Rua Urbino 24', 1)
	   ,('RayssaSpeed','20.057.627/0001-96','Ray e Sa Mobilistica RJ','Avenida Padre Francisco Sales Colturato 983', 2)

insert into Pecas (CodigoPeca, Descricao, Peso, PrecoCusto, PrecoVenda, IdFornecedor)
Values ('534243','Aro 22. Cromadão','500g','R$235,00','R$335,00', 2)
	  ,('787324','Placa Mãe Nividia','250g','R$700,00','R$900,00', 1)
	  ,('085312','Motor Turbo 300 Cavalos','900Kg','R$1.000,00','R$2.500,00', 2)
	  ,('153423','Placa de Vídio Nividia 1980 GTX','1Kg','R$3.000,00','R$5.000,00', 1)

-- DQL

SELECT * FROM Usuarios
SELECT * FROM Fornecedores
SELECT * FROM Pecas