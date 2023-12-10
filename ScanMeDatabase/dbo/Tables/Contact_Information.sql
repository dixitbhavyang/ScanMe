CREATE TABLE [dbo].[Contact_Information] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [User_Id] INT            NOT NULL,
    [Email]   NVARCHAR (MAX) NULL,
    [Phone]   NVARCHAR (10)  NULL,
    [Address] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Contact_Information] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Contact_Information_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[Contact_Information]([User_Id] ASC);

