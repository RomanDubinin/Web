
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/21/2014 20:39:47
-- Generated from EDMX file: D:\Web\Forum\Forum\ForumModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ForumDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserRole_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRole] DROP CONSTRAINT [FK_UserRole_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ConversationUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Conversations] DROP CONSTRAINT [FK_ConversationUser];
GO
IF OBJECT_ID(N'[dbo].[FK_MessageUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_MessageUser];
GO
IF OBJECT_ID(N'[dbo].[FK_MessageConversation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_MessageConversation];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Conversations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Conversations];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Conversations'
CREATE TABLE [dbo].[Conversations] (
    [ConversationId] int IDENTITY(1,1) NOT NULL,
    [Theme] nvarchar(max)  NOT NULL,
    [Creator_UserId] int  NOT NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [MessageId] int IDENTITY(1,1) NOT NULL,
    [Statement] nvarchar(max)  NOT NULL,
    [DateTime] datetime  NOT NULL,
    [User_UserId] int  NOT NULL,
    [Conversation_ConversationId] int  NOT NULL
);
GO

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [Roles_RoleId] int  NOT NULL,
    [Users_UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ConversationId] in table 'Conversations'
ALTER TABLE [dbo].[Conversations]
ADD CONSTRAINT [PK_Conversations]
    PRIMARY KEY CLUSTERED ([ConversationId] ASC);
GO

-- Creating primary key on [MessageId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([MessageId] ASC);
GO

-- Creating primary key on [Roles_RoleId], [Users_UserId] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY CLUSTERED ([Roles_RoleId], [Users_UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Roles_RoleId] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_Roles]
    FOREIGN KEY ([Roles_RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_UserId] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [FK_UserRole_Users]
    FOREIGN KEY ([Users_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Users'
CREATE INDEX [IX_FK_UserRole_Users]
ON [dbo].[UserRole]
    ([Users_UserId]);
GO

-- Creating foreign key on [Creator_UserId] in table 'Conversations'
ALTER TABLE [dbo].[Conversations]
ADD CONSTRAINT [FK_ConversationUser]
    FOREIGN KEY ([Creator_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConversationUser'
CREATE INDEX [IX_FK_ConversationUser]
ON [dbo].[Conversations]
    ([Creator_UserId]);
GO

-- Creating foreign key on [User_UserId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_MessageUser]
    FOREIGN KEY ([User_UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageUser'
CREATE INDEX [IX_FK_MessageUser]
ON [dbo].[Messages]
    ([User_UserId]);
GO

-- Creating foreign key on [Conversation_ConversationId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_MessageConversation]
    FOREIGN KEY ([Conversation_ConversationId])
    REFERENCES [dbo].[Conversations]
        ([ConversationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageConversation'
CREATE INDEX [IX_FK_MessageConversation]
ON [dbo].[Messages]
    ([Conversation_ConversationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------