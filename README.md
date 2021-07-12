# senai_czbooks
BD  Modelagens conceitual, lógico e físico (este pode ser exportado diretamente do SSMS);  Scripts de criação (DDL), manipulação (DML) e consulta (DQL).  Back-End  Solução do projeto com todos os arquivos desenvolvidos (não somente o arquivo .sln);  Coleção de requisições exportadas do Postman.  Front-End Web  Todos os arquivos do projeto criado utilizando a estrutura do Create-React-App com todas as telas necessárias.  Front-End Mobile  Todos os arquivos do projeto criado utilizando a estrutura do Expo.1. Mundo comum Um cliente chamado CZBooks criou uma biblioteca para armazenamento e venda de livros e artigos do meio. Para se adequar ao mercado, agilizar seus processos internos e expandir o alcance aos seus clientes, a empresa deseja implantar sistemas em seus procedimentos.  2. Chamado para a aventura CZBooks lhe contratou para desenvolver um sistema web/mobile integrado onde seja possível realizar a gestão de produtos da biblioteca. Sistema Web Perfis de usuário: 1. Administrador: Área administrativa da empresa; 2. Autor: Aquele que escreveu o livro; 3. Cliente: Qualquer visitante ou possível comprador. Funcionalidades: 1. O administrador poderá cadastrar qualquer tipo de usuário; 2. O administrador poderá cadastrar os dados da instituição; 3. O administrador poderá cadastrar as categorias dos livros; 4. O administrador poderá cadastrar livros; 5. Qualquer usuário autenticado poderá ver todos os livros cadastrados; 6. O usuário autor poderá ver os livros que escreveu;  Sistema Mobile Perfis de usuário:  1. Administrador: Área administrativa da empresa; 2. Autor: Aquele que escreveu o livro; 3. Cliente: Qualquer visitante ou possível comprador. Funcionalidades: 1. Qualquer usuário autenticado poderá ver todos os livros cadastrados; 2. O usuário autor poderá ver os livros que escreveu;  3. Banco de dados De acordo com a cultura criada, o primeiro passo para a construção de um sistema é realizar a modelagem do banco de dados que será utilizado em seus modelos conceitual, lógico e físico. Para ajudar na construção, a cliente disponibilizou um exemplo com os dados de cada livro e como devem ser cadastrados: Os livros devem possuir título, sinopse, categoria, autor, data de publicação e preço. Você utilizará este exemplo como base na construção do banco de dados  4. Back-End (API) De acordo com os padrões modernos no desenvolvimento de projetos de software atuais, você decidiu que o software solicitado pelo CZBooks deverá ser criado em plataforma API (Application Programming Interface). Você deverá desenvolver a API seguindo as funcionalidades listadas anteriormente.