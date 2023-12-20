CREATE TABLE [dbo].[Business_Card] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [User_Id]       INT            NOT NULL,
    [Template_Id]   INT            NOT NULL,
    [Card_Name]     NVARCHAR (MAX) NULL,
    [Creation_Date] DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.Business_Card] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Digital_Card_dbo.Digital_Card_Template_Template_Id] FOREIGN KEY ([Template_Id]) REFERENCES [dbo].[Business_Card_Template] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Digital_Card_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Template_Id]
    ON [dbo].[Business_Card]([Template_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[Business_Card]([User_Id] ASC);

