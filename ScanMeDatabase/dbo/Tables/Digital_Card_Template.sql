CREATE TABLE [dbo].[Digital_Card_Template] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Template_Name]        NVARCHAR (MAX) NULL,
    [Template_Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Digital_Card_Template] PRIMARY KEY CLUSTERED ([Id] ASC)
);

