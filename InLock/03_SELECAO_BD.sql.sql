use T_InLock;

select * from Usuarios

select * from Estudios

select * from Jogos

--Listar todos os jogos e seus respectivos estúdios
SELECT J.*, E.*
from Jogos as J
join Estudios as E	
on J.IdEstudio = E.IdEstudio

--Buscar e trazer na lista todos os estúdios,
--mesmo que eles não contenham nenhum jogo de referência;

SELECT J.*, E.*
FROM Jogos as J
RIGHT JOIN Estudios as E
ON J.IdEstudio = E.IdEstudio


--Buscar um usuário por email e senha

select * from Usuarios where Email = 'admin@admin.com' and Senha = 'admin'

 
--Buscar um jogo por JogoId

select * from Jogos where IdJogo = 2


--Buscar um estúdio por EstudioId

select * from Estudios where IdEstudio = 10
