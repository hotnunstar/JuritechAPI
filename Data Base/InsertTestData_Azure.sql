INSERT INTO public."Utilizador"(
	"Nome", "Email", "Password")
	VALUES 
		('Joaquim Alves', 'joaquim@juritech.pt', '123'),
		('Teresa Guilherme', 'teresa@juritech.pt', '456'),
		('Antonio Fonseca', 'antonio@juritech.pt', '789'),
		('Ana Ribeiro', 'ana@juritech.pt', 'qwe'),
		('Alfredo Joaquim', 'alfredo@juritech.pt', 'asd'),
		('Pedro Cruz', 'pedro@juritech.pt', 'zxc');
	


INSERT INTO public."Tema"(
	"Nome")
	VALUES 
		('Imposto sobre o rendimento das pessoas coletivas'), 
		('Imposto sobre o rendimento das pessoas singulares'),
		('Imposto sobre valor acrescentado'), 
		('Imposto unico de circulacao'),
		('Imposto municipal sobre transmissões onerosas'),
		('Imposto municipal sobre bens imoveis'),
		('Impostos especiais sobre o consumo'),
		('Taxas'),
		('Execucao para prestacao de factos ou de coisas'), --9
		('Execucao para pagamento de quantia certa'),
		('Execucao de sentencas de anulacao de atos administrativo'),
		('Arresto'), --12
		('Arrolamento'),
		('Inexistencia do imposto'), --14
		('Taxa ou contribuicao'),
		('Falta de autorizacao para cobrança a data em que tiver ocorrido a liquidacao'),
		('Ilegitimidade da pessoa citada - reversao'),
		('Ilegitimidade da pessoa citada - outros'),
		('Falsidade do titulo executivo'),
		('Prescricao'), --20
		('Falta da notificacao da liquidacao do tributo no prazo de caducidade'),
		('Duplicação de coleta'),
		('Ilegalidade da liquidacao da divida exequenda'), --23
		('Posse'),
		('Penhora'),
		('Apensacao'),
		('Garantia'),
		('Verificacao e graduacao de creditos'), --28
		('contraordenacoes aduaneiras'),
		('contraordenacoes fiscais'),
		('outros');
	


-- nao deu --
INSERT INTO public."TipoProcesso"(
	"Nome", "IdTema")
	VALUES 
		('Impugnacao', 1),
		('Impugnacao', 2),
		('Impugnacao', 3),
		('Impugnacao', 4),
		('Impugnacao', 5),
		('Impugnacao', 6),
		('Impugnacao', 7),
		('Impugnacao', 8),
		('Impugnacao', 31),
		('Acao administrativa', 1),
		('Acao administrativa', 2),
		('Acao administrativa', 3),
		('Acao administrativa', 4),
		('Acao administrativa', 5),
		('Acao administrativa', 6),
		('Acao administrativa', 7),
		('Acao administrativa', 8),
		('Acao administrativa', 31),
		('Intimacao para um comportamento', 1),
		('Intimacao para um comportamento', 2),
		('Intimacao para um comportamento', 3),
		('Intimacao para um comportamento', 4),
		('Intimacao para um comportamento', 5),
		('Intimacao para um comportamento', 6),
		('Intimacao para um comportamento', 7),
		('Intimacao para um comportamento', 8),
		('Intimacao para um comportamento', 31),
		('Execucao de julgados', 9),
		('Execucao de julgados', 10),
		('Execucao de julgados', 11),
		('Processos cautelares', 12),
		('Processos cautelares', 13),
		('Processos cautelares', 31),
		('Oposicao', 14),
		('Oposicao', 15),
		('Oposicao', 16),
		('Oposicao', 17),
		('Oposicao', 18),
		('Oposicao', 19),
		('Oposicao', 20),
		('Oposicao', 21),
		('Oposicao', 22),
		('Oposicao', 23),
		('Oposicao', 31),
		('Embargos de terceiros', 24),
		('Embargos de terceiros', 31),
		('Recurso de atos do orgao de execucao fiscal', 20),
		('Recurso de atos do orgao de execucao fiscal', 25),
		('Recurso de atos do orgao de execucao fiscal', 26),
		('Recurso de atos do orgao de execucao fiscal', 27),
		('Recurso de atos do orgao de execucao fiscal', 28),
		('Recurso de atos do orgao de execucao fiscal', 31),
		('Recurso de contraordenacao', 29),
		('Recurso de contraordenacao', 30),
		('Recurso de contraordenacao', 31);

 -- nao deu --
INSERT INTO public."Processo"(
	"NrProcesso", "Nome", "DataEntrada", "Valor", "IdTipo", "IdUtilizador", "Notas")
	VALUES 
		(010, 'NomeProcesso10', '09-04-2022', 20.50, 2, 1, 'Roubar o gajo'),
		(011, 'NomeProcesso11', '07-03-2022', 17.32,  1, 2, 'Assaltar o gajo'),
		(012, 'NomeProcesso12', '30-03-2022', 25.99, 3, 3, 'Quase ganho'),
		(013, 'NomeProcesso13', '02-01-2022', 206.10, 4, 4, 'Roubar o gajo'),
		(014, 'NomeProcesso14', '20-03-2022', 77.75, 2, 5, 'Assaltar o gajo'),
		(015, 'NomeProcesso15', '15-03-2022', 100, 4, 6, 'Quase ganho');


INSERT INTO public."Estado"(
	"Nome")
	VALUES
	('Fase articulados'),
	('Fase instrucao'),
	('Fase decisoria');

-- nao deu --
INSERT INTO public."FaseProcessual"(
	"IdEstado", "DataEntrada", "NrProcesso", "DataSaida", "NrDias")
	VALUES 
		(1, '09-04-2022', 010, null, null),
		(2, '07-03-2022', 011, null, null),
		(2, '30-03-2022', 012, null, null),
		(3, '02-01-2022', 013, '02-02-2022', 31),
		(3, '20-03-2022', 014, '11-04-2022', 22),
		(1, '15-03-2022', 015, null, null);


INSERT INTO public."Codigo"(
	"Nome")
	VALUES
	('Procedimento administrativo'),
	('Processo civil'),
	('Processo penal'),
	('Regime ilicito de mera ordenacao social');

-- nao deu --
INSERT INTO public."Artigo"(
	"IdCodigo", "NrArtigo", "IdUtilizador", "Nome", "Dias", "Meses", "Anos", "Ferias", "DiasNaoUteis")
	VALUES 
		(1, 100, 3, 'artigo1', 1, 2, 1, true, false),
		(2, 101, 2, 'artigo2', 5, 8, 2, true, true),
		(3, 102, 4, 'artigo3', 3, 11, 0, false, true),
		(4, 103, 6, 'artigo4', 5, 1, 0, false, false);	


INSERT INTO public."TipoPrazo"(
	"Nome")
	VALUES
	('Procedimental'),
	('Caducidade'),
	('Processual'),
	('Prescricao');


INSERT INTO public."PrazoCodigo"(
	"IdTipoPrazo", "IdCodigo")
	VALUES
	(1, 1),
	(2, 2),
	(3, 3),
	(4, 4);

-- nao deu --
--Completar esta tabela de dados..
INSERT INTO public."Prazo"(
	"IdPrazoCodigo", "NrProcesso", "DataInicial", "DataFinal")
	VALUES 
		(1, 010, '09-04-2022', null),
		(2, 011, '07-03-2022', null),
		(3, 012, '30-03-2022', null),
		(4, 013, '02-01-2022', null),
		(1, 014, '20-03-2022', null),
		(2, 015, '15-03-2022', null)
	ON CONFLICT (IdPrazoCodigo) DO NOTHING;	