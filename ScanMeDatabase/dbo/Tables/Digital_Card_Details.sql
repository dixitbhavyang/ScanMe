CREATE TABLE [dbo].[Digital_Card_Details] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Digital_Card_Id] INT            NOT NULL,
    [Field_Name]      NVARCHAR (MAX) NULL,
    [Field_Value]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Digital_Card_Details] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Digital_Card_Details_dbo.Digital_Card_Digital_Card_Id] FOREIGN KEY ([Digital_Card_Id]) REFERENCES [dbo].[Digital_Card] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Digital_Card_Id]
    ON [dbo].[Digital_Card_Details]([Digital_Card_Id] ASC);

