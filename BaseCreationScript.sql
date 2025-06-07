CREATE TABLE [dbo].[Users] (
    [id]    INT            IDENTITY (1, 1) NOT NULL,
    [login] NVARCHAR (50)  NOT NULL,
    [parol] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

INSERT INTO Users values ('admin','admin');

CREATE TABLE [dbo].[Places] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Region]      NVARCHAR (MAX) NOT NULL,
    [imagePath]   NVARCHAR (MAX) NOT NULL,
    [discription] NVARCHAR (MAX) NOT NULL,
    [objectName]  NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

