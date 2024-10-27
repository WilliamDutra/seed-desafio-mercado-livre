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


create table produto 
(
	id varchar(150) primary key,
	nome varchar(100) not null,
	descricao text not null,
	valor money not null,
	quantidade int not null,
	categoria_id varchar(150) not null,
	cadastrado_em timestamp,
	usuario_id varchar(150) not null
);


create table foto
(
	id varchar(150) primary key,
	nome varchar(100) not null,
	tipo varchar(50) not null
);

create table galeria
(
	produto_id varchar(150) not null,
	foto_id varchar(150) not null
);