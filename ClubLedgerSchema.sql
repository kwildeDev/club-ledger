CREATE TABLE [AccountType] (
  [AccountTypeID] int PRIMARY KEY,
  [AccountTypeName] varchar(50) UNIQUE NOT NULL,
  [NormalBalance] char(6) NOT NULL
)
GO

CREATE TABLE [Account] (
  [AccountID] int PRIMARY KEY,
  [AccountCode] varchar(10) UNIQUE,
  [AccountName] varchar(100) NOT NULL,
  [AccountTypeID] int
)
GO

CREATE TABLE [ContactType] (
  [ContactTypeID] int PRIMARY KEY,
  [ContactTypeName] varchar(50) UNIQUE NOT NULL
)
GO

CREATE TABLE [Contact] (
  [ContactID] int PRIMARY KEY,
  [ContactName] varchar(255),
  [ContactTypeID] int
)
GO

CREATE TABLE [JournalEntry] (
  [EntryID] int PRIMARY KEY,
  [EntryDate] datetime2 NOT NULL,
  [Description] varchar(255),
  [ReferenceNum] varchar(50),
  [ContactID] int
)
GO

CREATE TABLE [LedgerLine] (
  [LineID] int PRIMARY KEY,
  [EntryID] int,
  [AccountID] int,
  [DebitAmount] money NOT NULL,
  [CreditAmount] money NOT NULL,
  [LineDescription] varchar(255)
)
GO

ALTER TABLE [Account] ADD FOREIGN KEY ([AccountTypeID]) REFERENCES [AccountType] ([AccountTypeID])
GO

ALTER TABLE [Contact] ADD FOREIGN KEY ([ContactTypeID]) REFERENCES [ContactType] ([ContactTypeID])
GO

ALTER TABLE [JournalEntry] ADD FOREIGN KEY ([ContactID]) REFERENCES [Contact] ([ContactID])
GO

ALTER TABLE [LedgerLine] ADD FOREIGN KEY ([AccountID]) REFERENCES [Account] ([AccountID])
GO

ALTER TABLE [LedgerLine] ADD FOREIGN KEY ([EntryID]) REFERENCES [JournalEntry] ([EntryID])
GO
