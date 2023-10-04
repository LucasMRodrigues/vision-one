CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL Identity(1,1), 
    [Username] NVARCHAR(500) NOT NULL,
    [Email] NVARCHAR(255) NOT NULL,
	[Password] NVARCHAR(255) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([UserId])
)