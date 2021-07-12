-- DML

-- Define o banco de dados que ser� utilizado
USE CZBooks;
GO

-- Insere os tipos de usuarios
INSERT INTO tiposUsuarios(tituloTipoUsuario)
VALUES					 ('Administrador')
						,('Cliente')
						,('autor');
GO

-- Insere os usu�rios
INSERT INTO usuarios(idTipoUsuario, nomeUsuario, email, senha)
VALUES				(1, 'Administrador', 'adm@adm.com', 'adm123')
				   ,(2, 'Joyce', 'joyce@email.com', 'joyce123')
				   ,(3, 'Clarice Lispector', 'clarice@email.com', 'clarice123')
				   ,(3, 'John Green', 'john@email.com', 'green123');
GO

-- Insere as bibliotecas
INSERT INTO bibliotecas(nomeBiblioteca, endereco)
VALUES					('Biblioteca S�o Paulo', 'R. Da Consola��o,94');
GO

INSERT INTO tipoLivros(tituloTipoLivro)
VALUES					('Fic��o')
						,('Fabula')
						,('Lendas e mitos')
						,('Hist�ria em quadrinhos')
						,('Contos')
GO

INSERT INTO livros(idBiblioteca,idTipoLivro,nomeLivro,sinopse,categoria,dataPublicacao,preco)
VALUES				(1,5,'Teu Segredo', ' Flores envenenadas na jarra. Roxas azuis, encarnadas, atapetam o ar.', 'Drama', '01/02/2017', 20.90)
					,(1,1,'A culpa � das estrelas', 'Hazel Grace Lancaster e Augustus Waters s�o dois adolescentes que se conhecem em um grupo de apoio para pacientes com c�ncer.', 'Romance', '05/06/2014', 30.00);
GO

INSERT INTO autor(idLivro, idUsuario,nomeAutor,dataNascimento)
VALUES			(1,3,'John Green', '24/08/1977')
				,(2,3,'Clarice Lispector','10/12/1920');
GO