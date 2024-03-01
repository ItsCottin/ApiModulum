/*
    Autor: Rodrigo Cotting
    Data: 23/08/2023
    Descrição: Inicio da construção, criação das tabelas TBL_USUARIO e TBL_ITOKEN

    Autor: Rodrigo Cotting
    Data: 29/02/2024
    Descrição: Criação de toda estrutura base do banco de dados para o sistema Modulum 
*/

CREATE TABLE TBL_USUARIO
(
    ID_USU int primary key identity,
    LOGIN_USU varchar(50) not null,
    NOME_USU varchar(100) not null,
    CPF_USU varchar(14),
    EMAIL_USU varchar(50) not null,
    SENHA_USU varchar(800) not null,
    TP_USU varchar(10) not null default 'COMUM',
    DT_ALTER_USU datetime
);

CREATE TABLE TBL_EMPRESA
(
    ID_EMP int primary key identity,
    ID_USU int foreign key (ID_USU) references TBL_USUARIO(ID_USU) not null,
    NOME_EMP varchar(50) not null,
    CNPJ_EMP varchar(18) not null,
    NOME_FAN_EMP varchar(50)
);


CREATE TABLE TBL_CONTATO
(
    ID_CON int primary key identity,
    ID_USU int foreign key (ID_USU) references TBL_USUARIO(ID_USU) not null,
    ID_EMP int foreign key (ID_EMP) references TBL_EMPRESA(ID_EMP) null,
    TIPO_CON varchar(20) not null default 'COMUM',
    NUMERO_CON varchar(20) not null
);

CREATE TABLE TBL_RAMAL
(
    ID_RAM int primary key identity,
    ID_CON int foreign key (ID_CON) references TBL_CONTATO(ID_CON) not null,
    NUMERO_RAM int not null
);

CREATE TABLE TBL_LOCAL
(
    ID_LOC int primary key identity,
    ID_USU int foreign key (ID_USU) references TBL_USUARIO(ID_USU) not null,
    ID_EMP int foreign key (ID_EMP) references TBL_EMPRESA(ID_EMP) null,
    ID_END int foreign key (ID_END) references address_searchs(id) not null, -- Tabela 'address_searchs' já existente contendo todos os endereços do brasil pré cadastrado atualizado no ano de 2014
    TIPO_LOCAL varchar(20) not null default 'RESIDENCIAL',
    NUMERO_LOC int not null,
    UF_LOC varchar(2) not null, -- Adicionado essa coluna para melhor performance em fluxos de consulta
    CIDADE_LOC varchar(50) not null, -- Adicionado essa coluna para melhor performance em fluxos de consulta
    CEP_LOC int not null, -- Adicionado essa coluna para melhor performance em fluxos de consulta
    ENDERECO_LOC varchar(50) not null -- Adicionado essa coluna para melhor performance em fluxos de consulta
);

CREATE TABLE TBL_APLICACAO
(
    ID_APL int primary key identity,
    ID_USU int foreign key (ID_USU) references TBL_USUARIO(ID_USU) not null,
    ID_EMP int foreign key (ID_EMP) references TBL_EMPRESA(ID_EMP) null,
    NOME_APL varchar(100) not null,
);

CREATE TABLE TBL_TELA
(
    ID_TELA int primary key identity,
    ID_APL int foreign key (ID_APL) references TBL_APLICACAO(ID_APL) not null,
    NOME_MENU_TELA varchar(50) not null,
    NOME_TABELA_TELA varchar(50) not null,
    JSON_BASE text not null,
    HTML_BASE text not null,
    NOME_CAMPO_PK varchar(50) not null
);

CREATE TABLE TBL_ACESSO
(
    ID_APL int foreign key (ID_APL) references TBL_APLICACAO(ID_APL) not null,
    ID_TELA int foreign key (ID_TELA) references TBL_TELA(ID_TELA) not null,
    ID_USU int foreign key (ID_USU) references TBL_USUARIO(ID_USU) not null,
    primary key (ID_APL, ID_TELA, ID_USU) -- chave primária composta
);

CREATE TABLE TBL_CAMPO
(
    ID_CAMP int primary key identity,
    ID_TELA int foreign key (ID_TELA) references TBL_TELA(ID_TELA) not null,
    TIPO_CAMP varchar(10) not null,
    TAMANHO_CAMP int null,
    NOME_CAMP_TELA varchar(50) not null,
    NOME_CAMP_TABELA varchar(50) not null,
    OBRIGATORIO_CAMP bit -- campo boolean (Verdadeiro 'true' = 1, False 'false' = 0), 
);

CREATE TABLE TBL_RELACAO
(
    ID_RELA int primary key identity,
    ID_TELA int foreign key (ID_TELA) references TBL_TELA(ID_TELA) not null,
    ID_RELA_FK int foreign key (ID_RELA_FK) references TBL_RELACAO(ID_RELA) null,
    TIPO_RELA varchar(50) not null,
);

/*
Tabela utilizada pelo sistema para segurança e autenticação
Tabela não presente no MER
*/
CREATE TABLE TBL_ITOKEN
(
    LOGIN_USU varchar(50) not null,
    ID_TOKEN varchar(50) not null,
    ITOKEN VARCHAR(100) not null,
    IS_ACTIVE BIT not null,
    DATA_VALIDADE DATETIME
);

-- INSERT INTO TBL_USUARIO VALUES ('rcf', 'Rodrigo Cotting Fontes',null,'cottingfontes@hotmail.com',null,'123456',null,null,'ADMIN',null,null,null,null,null,getdate())