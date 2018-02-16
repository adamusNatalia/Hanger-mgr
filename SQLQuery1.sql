CREATE TABLE [dbo].[Favourite] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [AdId] int NOT NULL
);
GO

ALTER TABLE [dbo].[Favourite]
ADD CONSTRAINT [PK_Favourite]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating foreign key on [UserId] in table 'Ad'
ALTER TABLE [dbo].[Favourite]
ADD CONSTRAINT [FK_FKAd513542]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd515014'
CREATE INDEX [IX_FK_FKAd513542]
ON [dbo].[Favourite]
    ([UserId]);
GO

-- Creating foreign key on [ConditionId] in table 'Ad'
ALTER TABLE [dbo].[Favourite]
ADD CONSTRAINT [FK_FKAd308596]
    FOREIGN KEY ([AdId])
    REFERENCES [dbo].[Ad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FKAd307749'
CREATE INDEX [IX_FK_FKAd308596]
ON [dbo].[Favourite]
    ([AdId]);
GO