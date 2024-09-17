create table usuario_autenticacao
(
	id varchar(150) primary key not null,
	email varchar(30) not null,
	hash_senha varchar(250) not null,
	logado_em timestamp not null
);