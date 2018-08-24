
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/24/2018 17:20:06
-- Generated from EDMX file: C:\Users\СидоренкоЕ\Source\Repos\MVC-server-validation\MVC-validation-on-server\Models\ValidationDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ServerValidation_Db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CallingCourier_FormOfPayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CallingCourier] DROP CONSTRAINT [FK_CallingCourier_FormOfPayment];
GO
IF OBJECT_ID(N'[dbo].[FK_CallingCourier_ToCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CallingCourier] DROP CONSTRAINT [FK_CallingCourier_ToCity];
GO
IF OBJECT_ID(N'[dbo].[FK_CallingCourier_ToCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CallingCourier] DROP CONSTRAINT [FK_CallingCourier_ToCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_CallingCourier_ToDepartureType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CallingCourier] DROP CONSTRAINT [FK_CallingCourier_ToDepartureType];
GO
IF OBJECT_ID(N'[dbo].[FK_CallingCourier_ToTariffsView]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CallingCourier] DROP CONSTRAINT [FK_CallingCourier_ToTariffsView];
GO
IF OBJECT_ID(N'[dbo].[FK_City_ToCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[City] DROP CONSTRAINT [FK_City_ToCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_DescriptionOfGoods_ToCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DescriptionOfGoods] DROP CONSTRAINT [FK_DescriptionOfGoods_ToCity];
GO
IF OBJECT_ID(N'[dbo].[FK_DescriptionOfGoods_ToCountry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DescriptionOfGoods] DROP CONSTRAINT [FK_DescriptionOfGoods_ToCountry];
GO
IF OBJECT_ID(N'[dbo].[FK_DescriptionOfGoods_ToDepartureType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DescriptionOfGoods] DROP CONSTRAINT [FK_DescriptionOfGoods_ToDepartureType];
GO
IF OBJECT_ID(N'[dbo].[FK_DescriptionOfGoods_ToTariffsView]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DescriptionOfGoods] DROP CONSTRAINT [FK_DescriptionOfGoods_ToTariffsView];
GO
IF OBJECT_ID(N'[dbo].[FK_Feedback_ToMessageTheme]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Feedback] DROP CONSTRAINT [FK_Feedback_ToMessageTheme];
GO
IF OBJECT_ID(N'[dbo].[FK_FormOfPayment_FormOfPayment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sender] DROP CONSTRAINT [FK_FormOfPayment_FormOfPayment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CallingCourier]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CallingCourier];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[dbo].[Country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Country];
GO
IF OBJECT_ID(N'[dbo].[DepartureType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DepartureType];
GO
IF OBJECT_ID(N'[dbo].[DescriptionOfGoods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DescriptionOfGoods];
GO
IF OBJECT_ID(N'[dbo].[Feedback]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Feedback];
GO
IF OBJECT_ID(N'[dbo].[FormOfPayment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormOfPayment];
GO
IF OBJECT_ID(N'[dbo].[MessageTheme]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageTheme];
GO
IF OBJECT_ID(N'[dbo].[Sender]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sender];
GO
IF OBJECT_ID(N'[dbo].[TariffsView]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TariffsView];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Feedbacks'
CREATE TABLE [dbo].[Feedbacks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NULL,
    [Email] nvarchar(100)  NOT NULL,
    [MessageThemeId] int  NOT NULL,
    [Question] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MessageThemes'
CREATE TABLE [dbo].[MessageThemes] (
    [MessageThemeId] int IDENTITY(1,1) NOT NULL,
    [ThemeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FormOfPayments'
CREATE TABLE [dbo].[FormOfPayments] (
    [FormOfPaymentId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Senders'
CREATE TABLE [dbo].[Senders] (
    [SenderId] int IDENTITY(1,1) NOT NULL,
    [BIN_IIN] char(12)  NOT NULL,
    [ContactPerson] nvarchar(150)  NOT NULL,
    [SendersAddress] nvarchar(max)  NOT NULL,
    [Email] nvarchar(150)  NOT NULL,
    [DesirableDate] datetime  NOT NULL,
    [WhenPickUpShipment] time  NOT NULL,
    [FormOfPaymentId] int  NOT NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [CityId] int IDENTITY(1,1) NOT NULL,
    [CityName] nvarchar(max)  NOT NULL,
    [CountryId] int  NOT NULL
);
GO

-- Creating table 'Countries'
CREATE TABLE [dbo].[Countries] (
    [CountryId] int IDENTITY(1,1) NOT NULL,
    [CountryName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DepartureTypes'
CREATE TABLE [dbo].[DepartureTypes] (
    [DepartureTypeId] int IDENTITY(1,1) NOT NULL,
    [DepartureTypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DescriptionOfGoods'
CREATE TABLE [dbo].[DescriptionOfGoods] (
    [DescriptionOfGoodsId] int IDENTITY(1,1) NOT NULL,
    [CountryId] int  NOT NULL,
    [CityId] int  NOT NULL,
    [DepartureTypeId] int  NOT NULL,
    [TariffsViewId] int  NOT NULL,
    [Weight] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'TariffsViews'
CREATE TABLE [dbo].[TariffsViews] (
    [TariffsViewId] int IDENTITY(1,1) NOT NULL,
    [TariffsViewName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CallingCouriers'
CREATE TABLE [dbo].[CallingCouriers] (
    [CallingCourierId] int IDENTITY(1,1) NOT NULL,
    [BIN_IIN] char(12)  NOT NULL,
    [ContactPerson] nvarchar(150)  NOT NULL,
    [SendersAddress] nvarchar(max)  NOT NULL,
    [Email] nvarchar(150)  NOT NULL,
    [DesirableDate] datetime  NOT NULL,
    [WhenPickUpShipment] time  NOT NULL,
    [FormOfPaymentId] int  NOT NULL,
    [CountryId] int  NOT NULL,
    [CityId] int  NOT NULL,
    [DepartureTypeId] int  NOT NULL,
    [TariffsViewId] int  NOT NULL,
    [Weight] decimal(18,0)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [PK_Feedbacks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MessageThemeId] in table 'MessageThemes'
ALTER TABLE [dbo].[MessageThemes]
ADD CONSTRAINT [PK_MessageThemes]
    PRIMARY KEY CLUSTERED ([MessageThemeId] ASC);
GO

-- Creating primary key on [FormOfPaymentId] in table 'FormOfPayments'
ALTER TABLE [dbo].[FormOfPayments]
ADD CONSTRAINT [PK_FormOfPayments]
    PRIMARY KEY CLUSTERED ([FormOfPaymentId] ASC);
GO

-- Creating primary key on [SenderId] in table 'Senders'
ALTER TABLE [dbo].[Senders]
ADD CONSTRAINT [PK_Senders]
    PRIMARY KEY CLUSTERED ([SenderId] ASC);
GO

-- Creating primary key on [CityId] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([CityId] ASC);
GO

-- Creating primary key on [CountryId] in table 'Countries'
ALTER TABLE [dbo].[Countries]
ADD CONSTRAINT [PK_Countries]
    PRIMARY KEY CLUSTERED ([CountryId] ASC);
GO

-- Creating primary key on [DepartureTypeId] in table 'DepartureTypes'
ALTER TABLE [dbo].[DepartureTypes]
ADD CONSTRAINT [PK_DepartureTypes]
    PRIMARY KEY CLUSTERED ([DepartureTypeId] ASC);
GO

-- Creating primary key on [DescriptionOfGoodsId] in table 'DescriptionOfGoods'
ALTER TABLE [dbo].[DescriptionOfGoods]
ADD CONSTRAINT [PK_DescriptionOfGoods]
    PRIMARY KEY CLUSTERED ([DescriptionOfGoodsId] ASC);
GO

-- Creating primary key on [TariffsViewId] in table 'TariffsViews'
ALTER TABLE [dbo].[TariffsViews]
ADD CONSTRAINT [PK_TariffsViews]
    PRIMARY KEY CLUSTERED ([TariffsViewId] ASC);
GO

-- Creating primary key on [CallingCourierId] in table 'CallingCouriers'
ALTER TABLE [dbo].[CallingCouriers]
ADD CONSTRAINT [PK_CallingCouriers]
    PRIMARY KEY CLUSTERED ([CallingCourierId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MessageThemeId] in table 'Feedbacks'
ALTER TABLE [dbo].[Feedbacks]
ADD CONSTRAINT [FK_Feedback_ToMessageTheme]
    FOREIGN KEY ([MessageThemeId])
    REFERENCES [dbo].[MessageThemes]
        ([MessageThemeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Feedback_ToMessageTheme'
CREATE INDEX [IX_FK_Feedback_ToMessageTheme]
ON [dbo].[Feedbacks]
    ([MessageThemeId]);
GO

-- Creating foreign key on [FormOfPaymentId] in table 'Senders'
ALTER TABLE [dbo].[Senders]
ADD CONSTRAINT [FK_FormOfPayment_FormOfPayment]
    FOREIGN KEY ([FormOfPaymentId])
    REFERENCES [dbo].[FormOfPayments]
        ([FormOfPaymentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FormOfPayment_FormOfPayment'
CREATE INDEX [IX_FK_FormOfPayment_FormOfPayment]
ON [dbo].[Senders]
    ([FormOfPaymentId]);
GO

-- Creating foreign key on [CountryId] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_City_ToCountry]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Countries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_City_ToCountry'
CREATE INDEX [IX_FK_City_ToCountry]
ON [dbo].[Cities]
    ([CountryId]);
GO

-- Creating foreign key on [CityId] in table 'DescriptionOfGoods'
ALTER TABLE [dbo].[DescriptionOfGoods]
ADD CONSTRAINT [FK_DescriptionOfGoods_ToCity]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Cities]
        ([CityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DescriptionOfGoods_ToCity'
CREATE INDEX [IX_FK_DescriptionOfGoods_ToCity]
ON [dbo].[DescriptionOfGoods]
    ([CityId]);
GO

-- Creating foreign key on [CountryId] in table 'DescriptionOfGoods'
ALTER TABLE [dbo].[DescriptionOfGoods]
ADD CONSTRAINT [FK_DescriptionOfGoods_ToCountry]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Countries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DescriptionOfGoods_ToCountry'
CREATE INDEX [IX_FK_DescriptionOfGoods_ToCountry]
ON [dbo].[DescriptionOfGoods]
    ([CountryId]);
GO

-- Creating foreign key on [DepartureTypeId] in table 'DescriptionOfGoods'
ALTER TABLE [dbo].[DescriptionOfGoods]
ADD CONSTRAINT [FK_DescriptionOfGoods_ToDepartureType]
    FOREIGN KEY ([DepartureTypeId])
    REFERENCES [dbo].[DepartureTypes]
        ([DepartureTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DescriptionOfGoods_ToDepartureType'
CREATE INDEX [IX_FK_DescriptionOfGoods_ToDepartureType]
ON [dbo].[DescriptionOfGoods]
    ([DepartureTypeId]);
GO

-- Creating foreign key on [TariffsViewId] in table 'DescriptionOfGoods'
ALTER TABLE [dbo].[DescriptionOfGoods]
ADD CONSTRAINT [FK_DescriptionOfGoods_ToTariffsView]
    FOREIGN KEY ([TariffsViewId])
    REFERENCES [dbo].[TariffsViews]
        ([TariffsViewId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DescriptionOfGoods_ToTariffsView'
CREATE INDEX [IX_FK_DescriptionOfGoods_ToTariffsView]
ON [dbo].[DescriptionOfGoods]
    ([TariffsViewId]);
GO

-- Creating foreign key on [FormOfPaymentId] in table 'CallingCouriers'
ALTER TABLE [dbo].[CallingCouriers]
ADD CONSTRAINT [FK_CallingCourier_FormOfPayment]
    FOREIGN KEY ([FormOfPaymentId])
    REFERENCES [dbo].[FormOfPayments]
        ([FormOfPaymentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CallingCourier_FormOfPayment'
CREATE INDEX [IX_FK_CallingCourier_FormOfPayment]
ON [dbo].[CallingCouriers]
    ([FormOfPaymentId]);
GO

-- Creating foreign key on [CityId] in table 'CallingCouriers'
ALTER TABLE [dbo].[CallingCouriers]
ADD CONSTRAINT [FK_CallingCourier_ToCity]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Cities]
        ([CityId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CallingCourier_ToCity'
CREATE INDEX [IX_FK_CallingCourier_ToCity]
ON [dbo].[CallingCouriers]
    ([CityId]);
GO

-- Creating foreign key on [CountryId] in table 'CallingCouriers'
ALTER TABLE [dbo].[CallingCouriers]
ADD CONSTRAINT [FK_CallingCourier_ToCountry]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Countries]
        ([CountryId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CallingCourier_ToCountry'
CREATE INDEX [IX_FK_CallingCourier_ToCountry]
ON [dbo].[CallingCouriers]
    ([CountryId]);
GO

-- Creating foreign key on [DepartureTypeId] in table 'CallingCouriers'
ALTER TABLE [dbo].[CallingCouriers]
ADD CONSTRAINT [FK_CallingCourier_ToDepartureType]
    FOREIGN KEY ([DepartureTypeId])
    REFERENCES [dbo].[DepartureTypes]
        ([DepartureTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CallingCourier_ToDepartureType'
CREATE INDEX [IX_FK_CallingCourier_ToDepartureType]
ON [dbo].[CallingCouriers]
    ([DepartureTypeId]);
GO

-- Creating foreign key on [TariffsViewId] in table 'CallingCouriers'
ALTER TABLE [dbo].[CallingCouriers]
ADD CONSTRAINT [FK_CallingCourier_ToTariffsView]
    FOREIGN KEY ([TariffsViewId])
    REFERENCES [dbo].[TariffsViews]
        ([TariffsViewId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CallingCourier_ToTariffsView'
CREATE INDEX [IX_FK_CallingCourier_ToTariffsView]
ON [dbo].[CallingCouriers]
    ([TariffsViewId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------