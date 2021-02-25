CREATE TABLE [dbo].[WarehouseDocumentHeaders] (
    [Id]             INT             NOT NULL,
    [IssueDate]      DATE            NOT NULL,
    [CustomerNumber] NVARCHAR (250)  NOT NULL,
    [DocumentName]   NVARCHAR (250)  NOT NULL,
    [NetValue]       DECIMAL (18, 2) NOT NULL,
    [GrossValue]     DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_dbo.WarehouseDocumentHeaders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UK_DocumentName] UNIQUE NONCLUSTERED ([DocumentName] ASC)
);

