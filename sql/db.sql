create table usuario_autenticacao
(
	id varchar(150) primary key not null,
	email varchar(30) not null,
	hash_senha varchar(250) not null,
	logado_em timestamp not null
);


create table categoria
(
	id varchar(150) primary key,
	nome varchar(100) not null,
	descricao varchar(255) not null
);

create table subcategoria
(
	id varchar(150) primary key,
	nome varchar(100) not null,
	categoria_id varchar(150) not null
);
