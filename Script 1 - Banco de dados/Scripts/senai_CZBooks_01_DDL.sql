
--DDL
-- Cria um banco de dados
CREATE DATABASE CZBooks;

USE CZBooks;
GO

-- Cria a tabela tiposUsuarios
CREATE TABLE tiposUsuarios
(
	idTipoUsuario			INT PRIMARY KEY IDENTITY
	,tituloTipoUsuario		VARCHAR(200) UNIQUE NOT NULL
);
GO

-- Cria a tabela usuarios
CREATE TABLE usuarios
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario)
	,nomeUsuario		VARCHAR(200) NOT NULL
	,email				VARCHAR(200) UNIQUE NOT NULL
	,senha				VARCHAR(200) NOT NULL
);
GO

-- Cria tabela bibliotecas
CREATE TABLE bibliotecas
(
	idBiblioteca		INT PRIMARY KEY IDENTITY
	,nomeBiblioteca		VARCHAR(200) NOT NULL
	,endereco			VARCHAR(200) UNIQUE NOT NULL
);
GO

--Cria tabela tipoLivros
CREATE TABLE tipoLivros
(
	idTipoLivro		INT PRIMARY KEY IDENTITY
	,tituloTipoLivro	VARCHAR(200) NOT NULL
);
GO

--Cria tabela livros
CREATE TABLE livros
(
	idLivro				INT PRIMARY KEY IDENTITY
	,idTipoLivro		INT FOREIGN KEY REFERENCES tipoLivros(idTipoLivro)
	,idBiblioteca		INT FOREIGN KEY REFERENCES bibliotecas(idBiblioteca)
	,nomeLivro			VARCHAR(200) NOT NULL
	,sinopse			VARCHAR(250) UNIQUE NOT NULL
	,categoria			VARCHAR(100) NOT NULL
	,dataPublicacao		DATE NOT NULL
	,preco				decimal(19,4) NOT NULL
);
GO

--Cria a tabela autor 
Create TABLE autor
(
	idAutor				INT PRIMARY KEY IDENTITY
	,idLivro			INT FOREIGN KEY REFERENCES livros(idLivro)
	,idUsuario			INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,nomeAutor			VARCHAR (200)UNIQUE NOT NULL
	,dataNascimento		DATE NOT NULL 

);
GO



-- Resuminho:
/*
	PRIMARY KEY = Chave Primária
	FOREIGN KEY = Chave Estrangeira
	IDENTITY	= Define que o campo será auto-incrementado e único
	NOT NULL	= Define que não pode ser nulo, ou seja, obrigatório
	UNIQUE		= Define que o valor do campo é único, ou seja, não se repete
	DEFAULT		= Define um valor padrão, caso nenhum seja informado
	GO			= Pausa a leitura e executa o bloco de código acima
*/