CREATE TABLE [dbo].[Users] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Username]           NVARCHAR (MAX) NOT NULL,
    [Email]              NVARCHAR (MAX) NOT NULL,
    [Password]           NVARCHAR (8)   NOT NULL,
    [Name]               NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [ProfilePicturePath] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

