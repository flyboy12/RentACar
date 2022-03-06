
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/12/2022 17:33:23
-- Generated from EDMX file: C:\Users\blueh\Desktop\drive-download-20220212T120254Z-001\gun44\RentACar\RentACar.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ArabaKiralama];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MusteriId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OdemelerSet] DROP CONSTRAINT [FK_MusteriId];
GO
IF OBJECT_ID(N'[dbo].[FK_ArabaId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OdemelerSet] DROP CONSTRAINT [FK_ArabaId];
GO
IF OBJECT_ID(N'[dbo].[FK_BayilerArabalar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArabalarSet] DROP CONSTRAINT [FK_BayilerArabalar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MusterilerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MusterilerSet];
GO
IF OBJECT_ID(N'[dbo].[OdemelerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OdemelerSet];
GO
IF OBJECT_ID(N'[dbo].[ArabalarSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArabalarSet];
GO
IF OBJECT_ID(N'[dbo].[BayilerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BayilerSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MusterilerSet'
CREATE TABLE [dbo].[MusterilerSet] (
    [MusteriId] int IDENTITY(1,1) NOT NULL,
    [AdSoyad] nvarchar(max)  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL,
    [TCKimlikNo] nvarchar(max)  NOT NULL,
    [EhliyetDurumu] nvarchar(max)  NOT NULL,
    [MusteriAdres] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OdemelerSet'
CREATE TABLE [dbo].[OdemelerSet] (
    [OdemeId] int IDENTITY(1,1) NOT NULL,
    [OdemeTutar] decimal(18,0)  NOT NULL,
    [OdemeTarih] datetime  NOT NULL,
    [VadeFarki] float  NOT NULL,
    [MusteriId] int  NOT NULL,
    [ArabaId] int  NOT NULL
);
GO

-- Creating table 'ArabalarSet'
CREATE TABLE [dbo].[ArabalarSet] (
    [ArabaId] int IDENTITY(1,1) NOT NULL,
    [Marka] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Ozellik] nvarchar(max)  NOT NULL,
    [KM] int  NOT NULL,
    [HGS] nvarchar(max)  NOT NULL,
    [GunlukTutar] decimal(18,0)  NOT NULL,
    [BayiId] int  NOT NULL
);
GO

-- Creating table 'BayilerSet'
CREATE TABLE [dbo].[BayilerSet] (
    [BayiId] int IDENTITY(1,1) NOT NULL,
    [Adi] nvarchar(max)  NOT NULL,
    [Yetkilisi] nvarchar(max)  NOT NULL,
    [BayiAdres] nvarchar(max)  NOT NULL,
    [BayiTelefon] nvarchar(max)  NOT NULL,
    [BayiCiro] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MusteriId] in table 'MusterilerSet'
ALTER TABLE [dbo].[MusterilerSet]
ADD CONSTRAINT [PK_MusterilerSet]
    PRIMARY KEY CLUSTERED ([MusteriId] ASC);
GO

-- Creating primary key on [OdemeId] in table 'OdemelerSet'
ALTER TABLE [dbo].[OdemelerSet]
ADD CONSTRAINT [PK_OdemelerSet]
    PRIMARY KEY CLUSTERED ([OdemeId] ASC);
GO

-- Creating primary key on [ArabaId] in table 'ArabalarSet'
ALTER TABLE [dbo].[ArabalarSet]
ADD CONSTRAINT [PK_ArabalarSet]
    PRIMARY KEY CLUSTERED ([ArabaId] ASC);
GO

-- Creating primary key on [BayiId] in table 'BayilerSet'
ALTER TABLE [dbo].[BayilerSet]
ADD CONSTRAINT [PK_BayilerSet]
    PRIMARY KEY CLUSTERED ([BayiId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MusteriId] in table 'OdemelerSet'
ALTER TABLE [dbo].[OdemelerSet]
ADD CONSTRAINT [FK_MusteriId]
    FOREIGN KEY ([MusteriId])
    REFERENCES [dbo].[MusterilerSet]
        ([MusteriId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MusteriId'
CREATE INDEX [IX_FK_MusteriId]
ON [dbo].[OdemelerSet]
    ([MusteriId]);
GO

-- Creating foreign key on [ArabaId] in table 'OdemelerSet'
ALTER TABLE [dbo].[OdemelerSet]
ADD CONSTRAINT [FK_ArabaId]
    FOREIGN KEY ([ArabaId])
    REFERENCES [dbo].[ArabalarSet]
        ([ArabaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArabaId'
CREATE INDEX [IX_FK_ArabaId]
ON [dbo].[OdemelerSet]
    ([ArabaId]);
GO

-- Creating foreign key on [BayiId] in table 'ArabalarSet'
ALTER TABLE [dbo].[ArabalarSet]
ADD CONSTRAINT [FK_BayilerArabalar]
    FOREIGN KEY ([BayiId])
    REFERENCES [dbo].[BayilerSet]
        ([BayiId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BayilerArabalar'
CREATE INDEX [IX_FK_BayilerArabalar]
ON [dbo].[ArabalarSet]
    ([BayiId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------