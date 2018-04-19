
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/16/2018 18:17:00
-- Generated from EDMX file: D:\c_sharp_Net\MVC\Ray.OA\Ray.OA.Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EFProduct];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OAUserInfo'
CREATE TABLE [dbo].[OAUserInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OAOrderInfo'
CREATE TABLE [dbo].[OAOrderInfo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [OAUserInfoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'OAUserInfo'
ALTER TABLE [dbo].[OAUserInfo]
ADD CONSTRAINT [PK_OAUserInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OAOrderInfo'
ALTER TABLE [dbo].[OAOrderInfo]
ADD CONSTRAINT [PK_OAOrderInfo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OAUserInfoId] in table 'OAOrderInfo'
ALTER TABLE [dbo].[OAOrderInfo]
ADD CONSTRAINT [FK_OAUserInfoOAOrderInfo]
    FOREIGN KEY ([OAUserInfoId])
    REFERENCES [dbo].[OAUserInfo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OAUserInfoOAOrderInfo'
CREATE INDEX [IX_FK_OAUserInfoOAOrderInfo]
ON [dbo].[OAOrderInfo]
    ([OAUserInfoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------