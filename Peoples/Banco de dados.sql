create database T_People

use T_People

create table Funcionarios
(
	IdFuncionario int primary key identity
	,Nome  varchar(220) not null unique
	,Sobrenome varchar(220) not null unique
);


insert into Funcionarios (Nome, Sobrenome) values
				 ('Eduardo','Lima')
				,('Iury','Guimarães')
				,('Murilo','Pontes')

select * from Funcionarios

