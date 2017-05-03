CREATE DATABASE WorkerManager
GO

USE [WorkerManager]

CREATE TABLE [dbo].[Company] (
    [CompanyId]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (50) NOT NULL,
    [SizeCompany ]        NVARCHAR (50) NOT NULL,
    [OrganizationalForm ] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CompanyId] ASC)
);

CREATE TABLE [dbo].[Worker] (
    [WorkerId]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50) NOT NULL,
    [Surname]         NVARCHAR (50) NOT NULL,
    [Patronymic]      NVARCHAR (50) NOT NULL,
    [DateRecruitment] NVARCHAR (50) NOT NULL,
    [Position]        NVARCHAR (50) NOT NULL,
    [CompanyId]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([WorkerId] ASC),
    CONSTRAINT [FK_Worker_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([CompanyId])
);