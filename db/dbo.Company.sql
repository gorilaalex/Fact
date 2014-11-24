﻿CREATE TABLE [dbo].[Table]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ContractorName] NVARCHAR(50) NOT NULL, 
    [SerialNumber] NVARCHAR(50) NOT NULL, 
    [CIF] NVARCHAR(50) NULL, 
    [CUI] NVARCHAR(50) NULL, 
    [IBAN] NVARCHAR(50) NULL, 
    [Bank] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [SocialCapital] NUMERIC NOT NULL, 
    [TVARate] SMALLINT NULL
)
