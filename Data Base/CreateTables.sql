-- Table: public.Utilizador

-- DROP TABLE IF EXISTS public."Utilizador";

CREATE TABLE IF NOT EXISTS public."Utilizador"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Nome" text COLLATE pg_catalog."default" NOT NULL,
    "Email" text COLLATE pg_catalog."default" NOT NULL,
    "Password" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_Utilizador" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Utilizador"
    OWNER to juritech;

-- Table: public.Tema

-- DROP TABLE IF EXISTS public."Tema";

CREATE TABLE IF NOT EXISTS public."Tema"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "IdUtilizador" integer NOT NULL,
    "Nome" character varying COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_Tema" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Utilizador" FOREIGN KEY ("IdUtilizador")
        REFERENCES public."Utilizador" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Tema"
    OWNER to juritech;

-- Table: public.TipoProcesso

-- DROP TABLE IF EXISTS public."TipoProcesso";

CREATE TABLE IF NOT EXISTS public."TipoProcesso"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "IdUtilizador" integer NOT NULL,
    "IdTema" integer NOT NULL,
    "Nome" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_TipoProcesso" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_IdUtilizador" FOREIGN KEY ("IdUtilizador")
        REFERENCES public."Utilizador" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_IdTema" FOREIGN KEY ("IdTema")
        REFERENCES public."Tema" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TipoProcesso"
    OWNER to juritech;


-- Table: public.Processo

-- DROP TABLE IF EXISTS public."Processo";

CREATE TABLE IF NOT EXISTS public."Processo"
(
    "IdUtilizador" integer NOT NULL,
    "NrProcesso" text COLLATE pg_catalog."default" NOT NULL,
    "Nome" text COLLATE pg_catalog."default" NOT NULL,
    "DataEntrada" text NOT NULL,
    "Valor" money NOT NULL,
    "IdTipo" integer NOT NULL,
    "Estado" boolean NOT NULL,
    "Notas" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_Processo" PRIMARY KEY ("IdUtilizador", "NrProcesso"),
    CONSTRAINT "FK_IdUtilizador" FOREIGN KEY ("IdUtilizador")
        REFERENCES public."Utilizador" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_Tipo" FOREIGN KEY ("IdTipo")
        REFERENCES public."TipoProcesso" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Processo"
    OWNER to juritech;


-- Table: public.Estado

-- DROP TABLE IF EXISTS public."Estado";

CREATE TABLE IF NOT EXISTS public."Estado"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Nome" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_Id" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Estado"
    OWNER to juritech;


-- Table: public.FaseProcessual

-- DROP TABLE IF EXISTS public."FaseProcessual";

CREATE TABLE IF NOT EXISTS public."FaseProcessual"
(
    "IdUtilizador" integer NOT NULL,
    "IdEstado" integer NOT NULL,
    "NrProcesso" text COLLATE pg_catalog."default" NOT NULL,
    "DataEntrada" text NOT NULL,
    "DataSaida" text,
    "NrDias" integer,
    CONSTRAINT "PK_FaseProcessual" PRIMARY KEY ("IdUtilizador", "IdEstado", "NrProcesso", "DataEntrada"),
    CONSTRAINT "FK_IdEstado" FOREIGN KEY ("IdEstado")
        REFERENCES public."Estado" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_NrProcesso" FOREIGN KEY ("IdUtilizador", "NrProcesso")
        REFERENCES public."Processo" ("IdUtilizador", "NrProcesso") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
	CONSTRAINT "FK_Utilizador" FOREIGN KEY ("IdUtilizador")
        REFERENCES public."Utilizador" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."FaseProcessual"
    OWNER to juritech;



-- Table: public.Codigo

-- DROP TABLE IF EXISTS public."Codigo";

CREATE TABLE IF NOT EXISTS public."Codigo"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Nome" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "FK_Id" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Codigo"
    OWNER to juritech;


-- Table: public.Artigo

-- DROP TABLE IF EXISTS public."Artigo";

CREATE TABLE IF NOT EXISTS public."Artigo"
(
    "IdCodigo" integer NOT NULL,
    "NrArtigo" integer NOT NULL,
	"IdUtilizador" integer NOT NULL,
    "Nome" text COLLATE pg_catalog."default" NOT NULL,
    "Dias" integer,
    "Meses" integer,
    "Anos" integer,
    "Ferias" boolean NOT NULL,
    "DiasNaoUteis" boolean NOT NULL,
    CONSTRAINT "PK_Artigo" PRIMARY KEY ("IdCodigo", "NrArtigo", "IdUtilizador"),
    CONSTRAINT "FK_IdCodigo" FOREIGN KEY ("IdCodigo")
        REFERENCES public."Codigo" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_IdUtilizador" FOREIGN KEY ("IdUtilizador")
        REFERENCES public."Utilizador" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Artigo"
    OWNER to juritech;


-- Table: public.TipoPrazo

-- DROP TABLE IF EXISTS public."TipoPrazo";

CREATE TABLE IF NOT EXISTS public."TipoPrazo"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Nome" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_TipoPrazo" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TipoPrazo"
    OWNER to juritech;


-- Table: public.PrazoCodigo

-- DROP TABLE IF EXISTS public."PrazoCodigo";

CREATE TABLE IF NOT EXISTS public."PrazoCodigo"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "IdTipoPrazo" integer NOT NULL,
    "IdCodigo" integer NOT NULL,
    CONSTRAINT "PK_IdPrazoCodigo" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_IdCodigo" FOREIGN KEY ("IdCodigo")
        REFERENCES public."Codigo" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_IdTipoPrazo" FOREIGN KEY ("IdTipoPrazo")
        REFERENCES public."TipoPrazo" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."PrazoCodigo"
    OWNER to juritech;


-- Table: public.Prazo

-- DROP TABLE IF EXISTS public."Prazo";

CREATE TABLE IF NOT EXISTS public."Prazo"
(
    "IdPrazoCodigo" integer NOT NULL,
    "IdUtilizador" integer NOT NULL,
    "NrProcesso" text COLLATE pg_catalog."default" NOT NULL,
    "DataInicial" text NOT NULL,
    "DataFinal" text NOT NULL,
    "NrArtigo" integer NOT NULL,
    "IdCodigo" integer NOT NULL,
    CONSTRAINT "PK_Prazo" PRIMARY KEY ("IdPrazoCodigo", "IdUtilizador", "NrProcesso"),
    CONSTRAINT "NrArtigo" FOREIGN KEY ("IdCodigo", "NrArtigo", "IdUtilizador")
        REFERENCES public."Artigo" ("IdCodigo", "NrArtigo", "IdUtilizador") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "NrProcesso" FOREIGN KEY ("IdUtilizador", "NrProcesso")
        REFERENCES public."Processo" ("IdUtilizador", "NrProcesso") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Prazo"
    OWNER to juritech;
