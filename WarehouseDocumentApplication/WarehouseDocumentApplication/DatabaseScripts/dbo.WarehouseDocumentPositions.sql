CREATE TABLE [dbo].[WarehouseDocumentPositions] (
    [Id]          INT             NOT NULL,
    [HeaderId]    INT             NOT NULL,
    [ProductName] NVARCHAR (250)  NOT NULL,
    [Quantity]    INT             NOT NULL,
    [NetPrice]    DECIMAL (12, 2) NOT NULL,
    [GrossPrice]  DECIMAL (12, 2) NOT NULL,
	[NetValue]    DECIMAL (15, 2) NOT NULL,
	[GrossValue]  DECIMAL (15, 2) NOT NULL,
    CONSTRAINT [PK_dbo.WarehouseDocumentPositions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.WarehouseDocumentHeaders] FOREIGN KEY ([HeaderId]) REFERENCES [dbo].[WarehouseDocumentHeaders] ([Id]),
	CONSTRAINT [CHK_PositionQuantity] CHECK([Quantity] > 0),
	CONSTRAINT [CHK_PositionNetPrice] CHECK([NetPrice] > 0),
	CONSTRAINT [CHK_PositionGrossPrice] CHECK([GrossPrice] > 0)
);
