
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/15/2017 12:05:17
-- Generated from EDMX file: F:\OA\DLOA\DLOA.Model\DLOA.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserInfoRoleInfo_UserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRoleInfo] DROP CONSTRAINT [FK_UserInfoRoleInfo_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRoleInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfoRoleInfo] DROP CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_RoleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleInfoActionInfo_ActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleInfoActionInfo] DROP CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoUserAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserActionSet] DROP CONSTRAINT [FK_UserInfoUserAction];
GO
IF OBJECT_ID(N'[dbo].[FK_UserActionActionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserActionSet] DROP CONSTRAINT [FK_UserActionActionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkFlowInstanceWorkFlowStep]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkFlowStepSet] DROP CONSTRAINT [FK_WorkFlowInstanceWorkFlowStep];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoSet];
GO
IF OBJECT_ID(N'[dbo].[RoleInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfoSet];
GO
IF OBJECT_ID(N'[dbo].[ActionInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionInfoSet];
GO
IF OBJECT_ID(N'[dbo].[UserActionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserActionSet];
GO
IF OBJECT_ID(N'[dbo].[WorkFlowModelSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkFlowModelSet];
GO
IF OBJECT_ID(N'[dbo].[WorkFlowInstanceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkFlowInstanceSet];
GO
IF OBJECT_ID(N'[dbo].[WorkFlowStepSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkFlowStepSet];
GO
IF OBJECT_ID(N'[dbo].[UserInfoRoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfoRoleInfo];
GO
IF OBJECT_ID(N'[dbo].[RoleInfoActionInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleInfoActionInfo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserInfoSet'
CREATE TABLE [dbo].[UserInfoSet] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(10)  NOT NULL,
    [UserPwd] nvarchar(max)  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL
);
GO

-- Creating table 'RoleInfoSet'
CREATE TABLE [dbo].[RoleInfoSet] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(max)  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL
);
GO

-- Creating table 'ActionInfoSet'
CREATE TABLE [dbo].[ActionInfoSet] (
    [ActionId] int IDENTITY(1,1) NOT NULL,
    [ActionTitle] nvarchar(500)  NOT NULL,
    [ControllerName] varchar(50)  NOT NULL,
    [ActionName] varchar(50)  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [RoleInfoRoleId] int  NOT NULL,
    [IsMenu] bit  NOT NULL,
    [MenuIcon] varchar(100)  NULL
);
GO

-- Creating table 'UserActionSet'
CREATE TABLE [dbo].[UserActionSet] (
    [IsAllow] bit  NOT NULL,
    [UserId] int  NOT NULL,
    [ActionId] int  NOT NULL
);
GO

-- Creating table 'WorkFlowModelSet'
CREATE TABLE [dbo].[WorkFlowModelSet] (
    [ModelId] int IDENTITY(1,1) NOT NULL,
    [ModelTitle] nvarchar(50)  NOT NULL,
    [ControllerName] varchar(50)  NOT NULL,
    [ActionName] nvarchar(50)  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [SubBy] int  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'WorkFlowInstanceSet'
CREATE TABLE [dbo].[WorkFlowInstanceSet] (
    [InstanceId] int IDENTITY(1,1) NOT NULL,
    [InstantTitle] nvarchar(50)  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [InstanceGuid] nvarchar(max)  NOT NULL,
    [InstanceState] int  NOT NULL
);
GO

-- Creating table 'WorkFlowStepSet'
CREATE TABLE [dbo].[WorkFlowStepSet] (
    [StepId] int IDENTITY(1,1) NOT NULL,
    [NextId] int  NOT NULL,
    [SubBy] int  NOT NULL,
    [SubTime] datetime  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [InstanceId] int  NOT NULL,
    [IsOver] bit  NOT NULL,
    [Comment] bit  NOT NULL
);
GO

-- Creating table 'UserInfoRoleInfo'
CREATE TABLE [dbo].[UserInfoRoleInfo] (
    [UserInfo_UserId] int  NOT NULL,
    [RoleInfo_RoleId] int  NOT NULL
);
GO

-- Creating table 'RoleInfoActionInfo'
CREATE TABLE [dbo].[RoleInfoActionInfo] (
    [RoleInfo_RoleId] int  NOT NULL,
    [ActionInfo_ActionId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserId] in table 'UserInfoSet'
ALTER TABLE [dbo].[UserInfoSet]
ADD CONSTRAINT [PK_UserInfoSet]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'RoleInfoSet'
ALTER TABLE [dbo].[RoleInfoSet]
ADD CONSTRAINT [PK_RoleInfoSet]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [ActionId] in table 'ActionInfoSet'
ALTER TABLE [dbo].[ActionInfoSet]
ADD CONSTRAINT [PK_ActionInfoSet]
    PRIMARY KEY CLUSTERED ([ActionId] ASC);
GO

-- Creating primary key on [UserId], [ActionId] in table 'UserActionSet'
ALTER TABLE [dbo].[UserActionSet]
ADD CONSTRAINT [PK_UserActionSet]
    PRIMARY KEY CLUSTERED ([UserId], [ActionId] ASC);
GO

-- Creating primary key on [ModelId] in table 'WorkFlowModelSet'
ALTER TABLE [dbo].[WorkFlowModelSet]
ADD CONSTRAINT [PK_WorkFlowModelSet]
    PRIMARY KEY CLUSTERED ([ModelId] ASC);
GO

-- Creating primary key on [InstanceId] in table 'WorkFlowInstanceSet'
ALTER TABLE [dbo].[WorkFlowInstanceSet]
ADD CONSTRAINT [PK_WorkFlowInstanceSet]
    PRIMARY KEY CLUSTERED ([InstanceId] ASC);
GO

-- Creating primary key on [StepId] in table 'WorkFlowStepSet'
ALTER TABLE [dbo].[WorkFlowStepSet]
ADD CONSTRAINT [PK_WorkFlowStepSet]
    PRIMARY KEY CLUSTERED ([StepId] ASC);
GO

-- Creating primary key on [UserInfo_UserId], [RoleInfo_RoleId] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [PK_UserInfoRoleInfo]
    PRIMARY KEY CLUSTERED ([UserInfo_UserId], [RoleInfo_RoleId] ASC);
GO

-- Creating primary key on [RoleInfo_RoleId], [ActionInfo_ActionId] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [PK_RoleInfoActionInfo]
    PRIMARY KEY CLUSTERED ([RoleInfo_RoleId], [ActionInfo_ActionId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserInfo_UserId] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_UserInfo]
    FOREIGN KEY ([UserInfo_UserId])
    REFERENCES [dbo].[UserInfoSet]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [RoleInfo_RoleId] in table 'UserInfoRoleInfo'
ALTER TABLE [dbo].[UserInfoRoleInfo]
ADD CONSTRAINT [FK_UserInfoRoleInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_RoleId])
    REFERENCES [dbo].[RoleInfoSet]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRoleInfo_RoleInfo'
CREATE INDEX [IX_FK_UserInfoRoleInfo_RoleInfo]
ON [dbo].[UserInfoRoleInfo]
    ([RoleInfo_RoleId]);
GO

-- Creating foreign key on [RoleInfo_RoleId] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_RoleInfo]
    FOREIGN KEY ([RoleInfo_RoleId])
    REFERENCES [dbo].[RoleInfoSet]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionInfo_ActionId] in table 'RoleInfoActionInfo'
ALTER TABLE [dbo].[RoleInfoActionInfo]
ADD CONSTRAINT [FK_RoleInfoActionInfo_ActionInfo]
    FOREIGN KEY ([ActionInfo_ActionId])
    REFERENCES [dbo].[ActionInfoSet]
        ([ActionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleInfoActionInfo_ActionInfo'
CREATE INDEX [IX_FK_RoleInfoActionInfo_ActionInfo]
ON [dbo].[RoleInfoActionInfo]
    ([ActionInfo_ActionId]);
GO

-- Creating foreign key on [UserId] in table 'UserActionSet'
ALTER TABLE [dbo].[UserActionSet]
ADD CONSTRAINT [FK_UserInfoUserAction]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfoSet]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ActionId] in table 'UserActionSet'
ALTER TABLE [dbo].[UserActionSet]
ADD CONSTRAINT [FK_UserActionActionInfo]
    FOREIGN KEY ([ActionId])
    REFERENCES [dbo].[ActionInfoSet]
        ([ActionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserActionActionInfo'
CREATE INDEX [IX_FK_UserActionActionInfo]
ON [dbo].[UserActionSet]
    ([ActionId]);
GO

-- Creating foreign key on [InstanceId] in table 'WorkFlowStepSet'
ALTER TABLE [dbo].[WorkFlowStepSet]
ADD CONSTRAINT [FK_WorkFlowInstanceWorkFlowStep]
    FOREIGN KEY ([InstanceId])
    REFERENCES [dbo].[WorkFlowInstanceSet]
        ([InstanceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkFlowInstanceWorkFlowStep'
CREATE INDEX [IX_FK_WorkFlowInstanceWorkFlowStep]
ON [dbo].[WorkFlowStepSet]
    ([InstanceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------