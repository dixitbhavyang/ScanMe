CREATE TABLE [dbo].[QRCodes] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [User_Id]       INT            NOT NULL,
    [Template_Id]   INT            NOT NULL,
    [QR_Image_Path] NVARCHAR (MAX) NULL,
    [Creation_Date] DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.QRCodes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.QRCodes_dbo.QRCode_Template_Template_Id] FOREIGN KEY ([Template_Id]) REFERENCES [dbo].[QRCode_Template] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.QRCodes_dbo.Users_User_Id] FOREIGN KEY ([User_Id]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Id]
    ON [dbo].[QRCodes]([User_Id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Template_Id]
    ON [dbo].[QRCodes]([Template_Id] ASC);

