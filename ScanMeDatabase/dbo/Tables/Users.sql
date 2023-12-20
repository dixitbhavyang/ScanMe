CREATE TABLE [dbo].[Users] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Username]           NVARCHAR (MAX) NULL,
    [Email]              NVARCHAR (MAX) NULL,
    [Password]           NVARCHAR (8)   NULL,
    [Name]               NVARCHAR (MAX) NULL,
    [ProfilePicturePath] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);



