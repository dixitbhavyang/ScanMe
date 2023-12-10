CREATE TABLE [dbo].[Social_Media_Links] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [User_Id]  INT            NOT NULL,
    [Platform] NVARCHAR (MAX) NULL,
    [Link]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Social_Media_Links] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Social_Media_Links_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[Social_Media_Links]([User_Id] ASC);

