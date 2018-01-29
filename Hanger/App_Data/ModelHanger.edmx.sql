
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/28/2017 14:07:00
-- Generated from EDMX file: C:\Users\Krzysiek\Source\ReposFinal\Hanger-ASP.NET\Hanger\Models\ModelHanger.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HangerDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FKAd307749]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ad] DROP CONSTRAINT [FK_FKAd307749];
GO
IF OBJECT_ID(N'[dbo].[FK_FKAd464028]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ad] DROP CONSTRAINT [FK_FKAd464028];
GO
IF OBJECT_ID(N'[dbo].[FK_FKAd475152]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ad] DROP CONSTRAINT [FK_FKAd475152];
GO
IF OBJECT_ID(N'[dbo].[FK_FKAd515014]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ad] DROP CONSTRAINT [FK_FKAd515014];
GO
IF OBJECT_ID(N'[dbo].[FK_FKAd584267]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ad] DROP CONSTRAINT [FK_FKAd584267];
GO
IF OBJECT_ID(N'[dbo].[FK_FKAd594180]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ad] DROP CONSTRAINT [FK_FKAd594180];
GO
IF OBJECT_ID(N'[dbo].[FK_FKForumPosts217238]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumPosts] DROP CONSTRAINT [FK_FKForumPosts217238];
GO
IF OBJECT_ID(N'[dbo].[FK_FKForumPosts909218]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumPosts] DROP CONSTRAINT [FK_FKForumPosts909218];
GO
IF OBJECT_ID(N'[dbo].[FK_FKForumTopic340069]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumTopic] DROP CONSTRAINT [FK_FKForumTopic340069];
GO
IF OBJECT_ID(N'[dbo].[FK_FKForumTopic789626]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ForumTopic] DROP CONSTRAINT [FK_FKForumTopic789626];
GO
IF OBJECT_ID(N'[dbo].[FK_FKMessage241730]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_FKMessage241730];
GO
IF OBJECT_ID(N'[dbo].[FK_FKMessage63833]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Message] DROP CONSTRAINT [FK_FKMessage63833];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPhotos129746]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Photos] DROP CONSTRAINT [FK_FKPhotos129746];
GO
IF OBJECT_ID(N'[dbo].[FK_FKPhotos982370]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Photos] DROP CONSTRAINT [FK_FKPhotos982370];
GO
IF OBJECT_ID(N'[dbo].[FK_FKSubcategor437486]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subcategory] DROP CONSTRAINT [FK_FKSubcategor437486];
GO
IF OBJECT_ID(N'[dbo].[FK_FKSubsubcate564795]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubSubcategory] DROP CONSTRAINT [FK_FKSubsubcate564795];
GO
IF OBJECT_ID(N'[dbo].[FK_FKTags638329]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [FK_FKTags638329];
GO
IF OBJECT_ID(N'[dbo].[FK_FKUser322553]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_FKUser322553];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Ad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ad];
GO
IF OBJECT_ID(N'[dbo].[Brand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brand];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Color]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Color];
GO
IF OBJECT_ID(N'[dbo].[Condition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Condition];
GO
IF OBJECT_ID(N'[dbo].[ForumCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForumCategories];
GO
IF OBJECT_ID(N'[dbo].[ForumPosts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForumPosts];
GO
IF OBJECT_ID(N'[dbo].[ForumTopic]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ForumTopic];
GO
IF OBJECT_ID(N'[dbo].[Message]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Message];
GO
IF OBJECT_ID(N'[dbo].[Photos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Photos];
GO
IF OBJECT_ID(N'[dbo].[PhotoSite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhotoSite];
GO
IF OBJECT_ID(N'[dbo].[Size]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Size];
GO
IF OBJECT_ID(N'[dbo].[Subcategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subcategory];
GO
IF OBJECT_ID(N'[dbo].[SubSubcategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubSubcategory];
GO
IF OBJECT_ID(N'[dbo].[Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tags];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[UserPhoto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserPhoto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Ad'
CREATE TABLE [dbo].[Ad] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Price] real  NOT NULL,
    [Title] varchar(255)  NOT NULL,
    [Description] varchar(255)  NULL,
    [Date_start] datetime  NULL,
    [SizeId] int  NOT NULL,
    [ColorId] int  NOT NULL,
    [SubcategoryId] int  NOT NULL,
    [ConditionId] int  NOT NULL,
    [Swap] bit  NULL,
    [BrandId] int  NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL
);
GO

-- Creating table 'Color'
CREATE TABLE [dbo].[Color] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL
);
GO

-- Creating table 'Condition'
CREATE TABLE [dbo].[Condition] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Description] varchar(255)  NULL
);
GO

-- Creating table 'ForumCategories'
CREATE TABLE [dbo].[ForumCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Description] varchar(255)  NULL
);
GO

-- Creating table 'ForumPosts'
CREATE TABLE [dbo].[ForumPosts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ForumTopicId] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Content] varchar(255)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Title] varchar(255)  NULL
);
GO

-- Creating table 'ForumTopic'
CREATE TABLE [dbo].[ForumTopic] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [ForumCategoriesId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Subject] varchar(255)  NOT NULL
);
GO

-- Creating table 'Message'
CREATE TABLE [dbo].[Message] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId2] int  NOT NULL,
    [UserId] int  NOT NULL,
    [Title] varchar(255)  NOT NULL,
    [Context] varchar(255)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Mail] varchar(50)  NULL
);
GO

-- Creating table 'Photos'
CREATE TABLE [dbo].[Photos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [AdId] int  NOT NULL,
    [FIle_name] varchar(255)  NULL,
    [Main_photo] bit  NULL,
    [PhotoSiteId] int  NULL,
    [Type] varchar(50)  NULL
);
GO

-- Creating table 'PhotoSite'
CREATE TABLE [dbo].[PhotoSite] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Site_name] varchar(255)  NULL
);
GO

-- Creating table 'Size'
CREATE TABLE [dbo].[Size] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Description] varchar(255)  NULL,
    [Uk_size] varchar(50)  NULL,
    [Nuber_size] varchar(50)  NULL
);
GO

-- Creating table 'Subcategory'
CREATE TABLE [dbo].[Subcategory] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Description] varchar(255)  NULL,
    [CategoryId] int  NOT NULL
);
GO

-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [AdId] int  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Profil_name] varchar(255)  NOT NULL,
    [Mail] varchar(255)  NULL,
    [Password] varchar(255)  NOT NULL,
    [Date_access] datetime  NOT NULL,
    [Description] varchar(255)  NULL,
    [UserPhotoId] int  NULL
);
GO

-- Creating table 'UserPhoto'
CREATE TABLE [dbo].[UserPhoto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Photo] varbinary(max)  NULL
);
GO

-- Creating table 'SubSubcategory'
CREATE TABLE [dbo].[SubSubcategory] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL,
    [Description] varchar(255)  NULL,
    [SubcategoryId] int  NOT NULL
);
GO

-- Creating table 'Brand'
CREATE TABLE [dbo].[Brand] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(255)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Ad'
ALTER TABLE [dbo].[Ad]
ADD CONSTRAINT [PK_Ad]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Color'
ALTER TABLE [dbo].[Color]
ADD CONSTRAINT [PK_Color]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Condition'
ALTER TABLE [dbo].[Condition]
ADD CONSTRAINT [PK_Condition]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ForumCategories'
ALTER TABLE [dbo].[ForumCategories]
ADD CONSTRAINT [PK_ForumCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ForumPosts'
ALTER TABLE [dbo].[ForumPosts]
ADD CONSTRAINT [PK_ForumPosts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ForumTopic'
ALTER TABLE [dbo].[ForumTopic]
ADD CONSTRAINT [PK_ForumTopic]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [PK_Message]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [PK_Photos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhotoSite'
ALTER TABLE [dbo].[PhotoSite]
ADD CONSTRAINT [PK_PhotoSite]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Size'
ALTER TABLE [dbo].[Size]
ADD CONSTRAINT [PK_Size]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Subcategory'
ALTER TABLE [dbo].[Subcategory]
ADD CONSTRAINT [PK_Subcategory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserPhoto'
ALTER TABLE [dbo].[UserPhoto]
ADD CONSTRAINT [PK_UserPhoto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubSubcategory'
ALTER TABLE [dbo].[SubSubcategory]
ADD CONSTRAINT [PK_SubSubcategory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Brand'
ALTER TABLE [dbo].[Brand]
ADD CONSTRAINT [PK_Brand]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ConditionId] in table 'Ad'
ALTER TABLE [dbo].[Ad]
ADD CONSTRAINT [FK_FKAd307749]
    FOREIGN KEY ([ConditionId])
    REFERENCES [dbo].[Condition]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd307749'
CREATE INDEX [IX_FK_FKAd307749]
ON [dbo].[Ad]
    ([ConditionId]);
GO

-- Creating foreign key on [SizeId] in table 'Ad'
ALTER TABLE [dbo].[Ad]
ADD CONSTRAINT [FK_FKAd464028]
    FOREIGN KEY ([SizeId])
    REFERENCES [dbo].[Size]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd464028'
CREATE INDEX [IX_FK_FKAd464028]
ON [dbo].[Ad]
    ([SizeId]);
GO

-- Creating foreign key on [ColorId] in table 'Ad'
ALTER TABLE [dbo].[Ad]
ADD CONSTRAINT [FK_FKAd475152]
    FOREIGN KEY ([ColorId])
    REFERENCES [dbo].[Color]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd475152'
CREATE INDEX [IX_FK_FKAd475152]
ON [dbo].[Ad]
    ([ColorId]);
GO

-- Creating foreign key on [UserId] in table 'Ad'
ALTER TABLE [dbo].[Ad]
ADD CONSTRAINT [FK_FKAd515014]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd515014'
CREATE INDEX [IX_FK_FKAd515014]
ON [dbo].[Ad]
    ([UserId]);
GO

-- Creating foreign key on [SubcategoryId] in table 'Ad'
ALTER TABLE [dbo].[Ad]
ADD CONSTRAINT [FK_FKAd594180]
    FOREIGN KEY ([SubcategoryId])
    REFERENCES [dbo].[Subcategory]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd594180'
CREATE INDEX [IX_FK_FKAd594180]
ON [dbo].[Ad]
    ([SubcategoryId]);
GO

-- Creating foreign key on [AdId] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [FK_FKPhotos129746]
    FOREIGN KEY ([AdId])
    REFERENCES [dbo].[Ad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPhotos129746'
CREATE INDEX [IX_FK_FKPhotos129746]
ON [dbo].[Photos]
    ([AdId]);
GO

-- Creating foreign key on [AdId] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [FK_FKTags638329]
    FOREIGN KEY ([AdId])
    REFERENCES [dbo].[Ad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKTags638329'
CREATE INDEX [IX_FK_FKTags638329]
ON [dbo].[Tags]
    ([AdId]);
GO

-- Creating foreign key on [CategoryId] in table 'Subcategory'
ALTER TABLE [dbo].[Subcategory]
ADD CONSTRAINT [FK_FKSubcategor437486]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKSubcategor437486'
CREATE INDEX [IX_FK_FKSubcategor437486]
ON [dbo].[Subcategory]
    ([CategoryId]);
GO

-- Creating foreign key on [ForumCategoriesId] in table 'ForumTopic'
ALTER TABLE [dbo].[ForumTopic]
ADD CONSTRAINT [FK_FKForumTopic789626]
    FOREIGN KEY ([ForumCategoriesId])
    REFERENCES [dbo].[ForumCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKForumTopic789626'
CREATE INDEX [IX_FK_FKForumTopic789626]
ON [dbo].[ForumTopic]
    ([ForumCategoriesId]);
GO

-- Creating foreign key on [UserId] in table 'ForumPosts'
ALTER TABLE [dbo].[ForumPosts]
ADD CONSTRAINT [FK_FKForumPosts217238]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKForumPosts217238'
CREATE INDEX [IX_FK_FKForumPosts217238]
ON [dbo].[ForumPosts]
    ([UserId]);
GO

-- Creating foreign key on [ForumTopicId] in table 'ForumPosts'
ALTER TABLE [dbo].[ForumPosts]
ADD CONSTRAINT [FK_FKForumPosts909218]
    FOREIGN KEY ([ForumTopicId])
    REFERENCES [dbo].[ForumTopic]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKForumPosts909218'
CREATE INDEX [IX_FK_FKForumPosts909218]
ON [dbo].[ForumPosts]
    ([ForumTopicId]);
GO

-- Creating foreign key on [UserId] in table 'ForumTopic'
ALTER TABLE [dbo].[ForumTopic]
ADD CONSTRAINT [FK_FKForumTopic340069]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKForumTopic340069'
CREATE INDEX [IX_FK_FKForumTopic340069]
ON [dbo].[ForumTopic]
    ([UserId]);
GO

-- Creating foreign key on [UserId2] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [FK_FKMessage241730]
    FOREIGN KEY ([UserId2])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKMessage241730'
CREATE INDEX [IX_FK_FKMessage241730]
ON [dbo].[Message]
    ([UserId2]);
GO

-- Creating foreign key on [UserId] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [FK_FKMessage63833]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKMessage63833'
CREATE INDEX [IX_FK_FKMessage63833]
ON [dbo].[Message]
    ([UserId]);
GO

-- Creating foreign key on [PhotoSiteId] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [FK_FKPhotos982370]
    FOREIGN KEY ([PhotoSiteId])
    REFERENCES [dbo].[PhotoSite]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKPhotos982370'
CREATE INDEX [IX_FK_FKPhotos982370]
ON [dbo].[Photos]
    ([PhotoSiteId]);
GO

-- Creating foreign key on [UserPhotoId] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_FKUser322553]
    FOREIGN KEY ([UserPhotoId])
    REFERENCES [dbo].[UserPhoto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKUser322553'
CREATE INDEX [IX_FK_FKUser322553]
ON [dbo].[User]
    ([UserPhotoId]);
GO

-- Creating foreign key on [SubcategoryId] in table 'SubSubcategory'
ALTER TABLE [dbo].[SubSubcategory]
ADD CONSTRAINT [FK_FKSubsubcate564795]
    FOREIGN KEY ([SubcategoryId])
    REFERENCES [dbo].[Subcategory]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKSubsubcate564795'
CREATE INDEX [IX_FK_FKSubsubcate564795]
ON [dbo].[SubSubcategory]
    ([SubcategoryId]);
GO

-- Creating foreign key on [BrandId] in table 'Ad'
ALTER TABLE [dbo].[Ad]
ADD CONSTRAINT [FK_FKAd584267]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[Brand]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd584267'
CREATE INDEX [IX_FK_FKAd584267]
ON [dbo].[Ad]
    ([BrandId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------