CREATE TABLE TBL_USUARIO
(
    ID_USU int primary key identity,
    LOGIN_USU varchar(50) not null,
    NOME_USU varchar(100) not null,
    CPF_USU varchar(14),
    EMAIL_USU varchar(50) not null,
    ENDERECO_USU varchar(150),
    SENHA_USU varchar(800) not null,
    TELEFONE_USU varchar(18),
    CELULAR_USU varchar(18),
    TP_USU VARCHAR(10) default 'COMUM',
    CEP_USU VARCHAR(11),
    BAIRRO_USU VARCHAR(100),
    UF_USU VARCHAR(10),
    CIDADE_USU VARCHAR(100),
    NUMERO_CASA_USU VARCHAR(10),
    DT_ALTER_USU DATETIME
);

CREATE TABLE TBL_ITOKEN
(
    LOGIN_USU varchar(50) not null,
    ID_TOKEN varchar(50) not null,
    ITOKEN VARCHAR(100) not null,
    IS_ACTIVE BIT not null,
	DATA_VALIDADE DATETIME
);

-- INSERT INTO TBL_USUARIO VALUES ('rcf', 'Rodrigo Cotting Fontes',null,'cottingfontes@hotmail.com',null,'123456',null,null,'ADMIN',null,null,null,null,null,getdate())