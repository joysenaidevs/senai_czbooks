-- DQL

-- Define o banco de dados que será utilizado
USE CZBooks;
GO

--Lista todos os tipos de usuarios
SELECT * FROM tiposUsuarios;

-- Lista todos os usuários
SELECT * FROM usuarios;

--Lista todas as bibliotecas
SELECT * FROM bibliotecas;

--Lista todos o tipos de livros
SELECT * FROM tipoLivros; 

-- Lista todos os livros
SELECT * FROM livros;

-- Lista todos os autores
SELECT * FROM autor;

-- Seleciona os dados dos usuários mostrando o tipo de usuário
SELECT idUsuario, tituloTipoUsuario, nomeUsuario, email FROM usuarios
INNER JOIN tiposUsuarios
ON usuarios.idTipoUsuario = tiposUsuarios.idTipoUsuario;

--Seleciona os dados dos livros, tipos de livros e a biblioteca
SELECT idLivro, nomeLivro,nomeBiblioteca, sinopse, categoria, dataPublicacao, preco
FROM livros L
INNER JOIN tipoLivros TL
ON L.idTipoLivro = TL.idTipoLivro
INNER JOIN bibliotecas b
ON L.idBiblioteca = b.idBiblioteca


--Seleciona os dados dos livros ,dos tipos de livros e dos usuarios
SELECT nomeUsuario, email,nomeLivro livros,tituloTipoLivro tipoLivro
FROM usuarios U
INNER JOIN autor A
ON A.idUsuario = U.idUsuario
INNER JOIN livros L
ON A.idLivro = L.idLivro
INNER JOIN tipoLivros TL
ON L.idTipoLivro = TL.idTipoLivro


-- Busca um usuário através do seu e-mail e senha
SELECT tituloTipoUsuario, nomeUsuario, email 
FROM usuarios U 
INNER JOIN tiposUsuarios TU 
ON U.idTipoUsuario = TU.idTipoUsuario 
WHERE email = 'adm@adm.com' AND senha = 'adm123';