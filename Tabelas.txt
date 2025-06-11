CREATE database Credito
use Credito

CREATE TABLE Credito.dbo.Cliente (
	Id uniqueidentifier NOT NULL,
	Nome nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Cpf nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Uf nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	Celular nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	CONSTRAINT PK_Cliente PRIMARY KEY (Id)
);

CREATE TABLE Credito.dbo.Financiamento (
	Id uniqueidentifier NOT NULL,
	ClienteId uniqueidentifier NOT NULL,
	TipoCredito int NOT NULL,
	ValorTotal decimal(18,2) NOT NULL,
	DataUltimoVencimento datetime2 NOT NULL,
	ValorInicialFinanciamento decimal(18,2) DEFAULT 0.0 NOT NULL,
	CONSTRAINT PK_Financiamento PRIMARY KEY (Id)
);
CREATE NONCLUSTERED INDEX IX_Financiamento_ClienteId ON Credito.dbo.Financiamento (ClienteId);


-- Credito.dbo.Financiamento foreign keys
ALTER TABLE Credito.dbo.Financiamento ADD CONSTRAINT FK_Financiamento_Cliente_ClienteId FOREIGN KEY (ClienteId) REFERENCES Credito.dbo.Cliente(Id) ON DELETE CASCADE;


CREATE TABLE Credito.dbo.Parcela (
	Id uniqueidentifier NOT NULL,
	FinanciamentoId uniqueidentifier NOT NULL,
	NumeroParcela int NOT NULL,
	ValorParcela decimal(18,2) NOT NULL,
	DataVencimento datetime2 NOT NULL,
	DataPagamento datetime2 NULL,
	CONSTRAINT PK_Parcela PRIMARY KEY (Id)
);
CREATE NONCLUSTERED INDEX IX_Parcela_FinanciamentoId ON Credito.dbo.Parcela (FinanciamentoId);


-- Credito.dbo.Parcela foreign keys
ALTER TABLE Credito.dbo.Parcela ADD CONSTRAINT FK_Parcela_Financiamento_FinanciamentoId FOREIGN KEY (FinanciamentoId) REFERENCES Credito.dbo.Financiamento(Id) ON DELETE CASCADE;


select 
c.Id, c.Nome, c.Cpf, c.Uf, c.Celular,
SUM(CASE WHEN p.DataPagamento IS NOT NULL THEN p.ValorParcela ELSE 0 END) as TotalPago,
SUM(p.ValorParcela) as ValorTotal
from Cliente c 
JOIN Financiamento f 
	on c.Id = f.ClienteId 
join Parcela p 
	on f.Id = p.FinanciamentoId 
WHERE 
	c.uf = 'SP'
GROUP BY 
	c.Id, c.Nome, c.Cpf, c.Uf, c.Celular 
HAVING
	(SUM(CASE WHEN p.DataPagamento IS NOT NULL THEN p.ValorParcela ELSE 0 END) / SUM(p.ValorParcela)) > 0.60
	
	
	
select DISTINCT top (4)
c.Id, c.Nome, c.Cpf, c.Uf, c.Celular
from Cliente c 
JOIN Financiamento f 
	on c.Id = f.ClienteId 
join Parcela p 
	on f.Id = p.FinanciamentoId 
WHERE 
	p.DataVencimento > GETDATE() 
  	AND p.DataPagamento  IS NULL
  	AND p.DataVencimento > DATEADD(DAY, 5, GETDATE())
 ORDER by c.Id 
