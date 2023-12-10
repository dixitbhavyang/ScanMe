CREATE TABLE [dbo].[QRCode_Template] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Template_Name]        NVARCHAR (MAX) NULL,
    [Template_Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.QRCode_Template] PRIMARY KEY CLUSTERED ([Id] ASC)
);

