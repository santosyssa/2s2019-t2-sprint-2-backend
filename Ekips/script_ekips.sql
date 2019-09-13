CREATE DATABASE T_Ekips

USE T_Ekips

-- DDL

CREATE TABLE Departamentos
(
	IdDepartamento		INT PRIMARY KEY IDENTITY
	,Nome				VARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE Cargos
(
	IdCargo				INT PRIMARY KEY IDENTITY
	,Nome				VARCHAR(255) NOT NULL UNIQUE
	,Estado				BIT NOT NULL DEFAULT(1)
);

CREATE TABLE Usuarios
(
	IdUsuario			INT PRIMARY KEY IDENTITY
	,Email				VARCHAR(255) NOT NULL UNIQUE
	,Senha				VARCHAR(255) NOT NULL
	,Permissao			VARCHAR(255) NOT NULL
);

CREATE TABLE Funcionarios
(
	IdFuncionario		INT PRIMARY KEY IDENTITY
	,Nome				VARCHAR(255) NOT NULL 
	,CPF				VARCHAR(500) NOT NULL UNIQUE
	,DataNascimento		DATETIME NOT NULL
	,Salario			VARCHAR(500) NOT NULL
	,IdDepartamento		INT FOREIGN KEY REFERENCES Departamentos (IdDepartamento)
	,IdCargo			INT FOREIGN KEY REFERENCES Cargos (IdCargo)
	,IdUsuario			INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
);

-- DML

insert into Departamentos 
					values ('Administração')
						  ,('Tecnologia')
						  ,('Marketing')

insert into Cargos (Nome, Estado)
					values ('Líder', 1)
						  ,('Telemarketing', 1)
					      ,('Técnico de Informática', 1)
						  ,('Técnico Contabil', 0)
						  ,('Assistênte Social', 1)
						  
insert into Usuarios (Email, Senha, Permissao)
										values ('dudruns@gmail.com', 'tanansinho', 'Administrador')
											  ,('fenomeno@gmail.com', 'realtimao', 'Comum')
											  ,('dezesseis@gmail.com', 'rafaoutubro', 'Comum')

insert into Funcionarios (Nome, CPF, DataNascimento, Salario, IdDepartamento, IdCargo, IdUsuario)
			values ('Eduardo', '160.500.990-30', '2003-02-26T00:00:00', 'R$12.000,00', 2, 1, 1)
		          ,('Ronaldo', '746.352.720-44', '1976-09-22T00:00:00', 'R$1.050,00', 3, 2, 2)
				  ,('Iury', '274.019.120-07', '2002-03-06T00:00:00', 'R$6.150,00', 1, 5, 3)
	
-- DQL

select * from Departamentos
select * from Cargos
select * from Usuarios
select * from Funcionarios