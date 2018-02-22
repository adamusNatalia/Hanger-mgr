CREATE TABLE [dbo].[UserProfil] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Color1Id] int  NOT NULL,
	[Color2Id] int NULL,
    [SizeId] int NOT NULL,
	[BrandId] int NOT NULL
);
GO

ALTER TABLE [dbo].[UserProfil]
ADD CONSTRAINT [PK_UseProfil]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO



ALTER TABLE [dbo].[UserProfil]
ADD CONSTRAINT [FK_FKAd465758]
    FOREIGN KEY ([SizeId])
    REFERENCES [dbo].[Size]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd464028'
CREATE INDEX [IX_FK_FKAd465758]
ON [dbo].[UserProfil]
    ([SizeId]);
GO

-- Creating foreign key on [ColorId] in table 'Ad'
ALTER TABLE [dbo].[UserProfil]
ADD CONSTRAINT [FK_FKAd476875]
    FOREIGN KEY ([Color1Id])
    REFERENCES [dbo].[Color]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd475152'
CREATE INDEX [IX_FK_FKAd476875]
ON [dbo].[UserProfil]
    ([Color1Id]);
GO

-- Creating foreign key on [ColorId] in table 'Ad'
ALTER TABLE [dbo].[UserProfil]
ADD CONSTRAINT [FK_FKAd478957]
    FOREIGN KEY ([Color2Id])
    REFERENCES [dbo].[Color]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd475152'
CREATE INDEX [IX_FK_FKAd478957]
ON [dbo].[UserProfil]
    ([Color2Id]);
GO

-- Creating foreign key on [ColorId] in table 'Ad'
ALTER TABLE [dbo].[UserProfil]
ADD CONSTRAINT [FK_FKAd487456]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[Brand]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd475152'
CREATE INDEX [IX_FK_FKAd487456]
ON [dbo].[UserProfil]
    ([BrandId]);
GO
