CREATE DATABASE MyFinance;
GO

USE MyFinance;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [PlanoConta] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(50) NOT NULL,
    [Tipo] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_PlanoConta] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Transacao] (
    [Id] int NOT NULL IDENTITY,
    [Historico] nvarchar(256) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Data] datetime2 NOT NULL,
    [PlanoContaId] int NOT NULL,
    CONSTRAINT [PK_Transacao] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transacao_PlanoConta_PlanoContaId] FOREIGN KEY ([PlanoContaId]) REFERENCES [PlanoConta] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Tipo') AND [object_id] = OBJECT_ID(N'[PlanoConta]'))
    SET IDENTITY_INSERT [PlanoConta] ON;
INSERT INTO [PlanoConta] ([Id], [Descricao], [Tipo])
VALUES (1, N'Combustível', N'D'),
(2, N'Supermercado', N'D'),
(3, N'Almoço', N'D'),
(4, N'IPTU', N'D'),
(5, N'IPVA', N'D'),
(6, N'Salário', N'R'),
(7, N'Crédito de Juros', N'R'),
(8, N'Apartamento de Aluguel', N'R');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Descricao', N'Tipo') AND [object_id] = OBJECT_ID(N'[PlanoConta]'))
    SET IDENTITY_INSERT [PlanoConta] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Data', N'Historico', N'PlanoContaId', N'Valor') AND [object_id] = OBJECT_ID(N'[Transacao]'))
    SET IDENTITY_INSERT [Transacao] ON;
INSERT INTO [Transacao] ([Id], [Data], [Historico], [PlanoContaId], [Valor])
VALUES (100, '2022-12-20T14:00:00.0000000', N'Gasolina Viagem', 1, 289.0),
(200, '2022-12-24T13:30:00.0000000', N'Almoço Família', 3, 289.0),
(300, '2023-01-05T00:00:00.0000000', N'Salário', 6, 289.0),
(400, '2023-01-10T13:30:00.0000000', N'IPVA Blazer', 5, 289.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Data', N'Historico', N'PlanoContaId', N'Valor') AND [object_id] = OBJECT_ID(N'[Transacao]'))
    SET IDENTITY_INSERT [Transacao] OFF;
GO

CREATE INDEX [IX_Transacao_PlanoContaId] ON [Transacao] ([PlanoContaId]);
GO

COMMIT TRANSACTION;