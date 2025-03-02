-- Tạo database
CREATE DATABASE LoEng;
GO

-- Sử dụng database
USE LoEng;
GO

-- Bảng Topics (Chủ đề)
CREATE TABLE Topics (
    TopicId INT PRIMARY KEY IDENTITY,
    TopicName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Bảng WordTypes (Loại từ)
CREATE TABLE WordTypes (
    WordTypeId INT PRIMARY KEY IDENTITY,
    TypeName NVARCHAR(50) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Bảng Levels (Cấp độ từ vựng)
CREATE TABLE Levels (
    LevelId INT PRIMARY KEY IDENTITY,
    LevelName NVARCHAR(50) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Bảng Words (Từ vựng)
CREATE TABLE Words (
    WordId INT PRIMARY KEY IDENTITY,
    EnglishWord NVARCHAR(100) NOT NULL,
    VietnameseMeaning NVARCHAR(200) NOT NULL,
    Pronunciation NVARCHAR(200),
    ImageUrl NVARCHAR(500),
    Description NVARCHAR(500),
    TopicId INT FOREIGN KEY REFERENCES Topics(TopicId),
    WordTypeId INT FOREIGN KEY REFERENCES WordTypes(WordTypeId),
    LevelId INT FOREIGN KEY REFERENCES Levels(LevelId), -- Liên kết với bảng Levels
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Bảng Synonyms (Từ đồng nghĩa)
CREATE TABLE Synonyms (
    SynonymId INT PRIMARY KEY IDENTITY,
    WordId INT FOREIGN KEY REFERENCES Words(WordId),
    SynonymWord NVARCHAR(100) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Bảng Examples (Ví dụ)
CREATE TABLE Examples (
    ExampleId INT PRIMARY KEY IDENTITY,
    WordId INT FOREIGN KEY REFERENCES Words(WordId),
    EnglishExample NVARCHAR(500) NOT NULL,
    VietnameseMeaning NVARCHAR(500) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Bảng Users (Người dùng)
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(200) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Bảng UserWords (Từ vựng của người dùng)
CREATE TABLE UserWords (
    UserWordId INT PRIMARY KEY IDENTITY,
    UserId INT FOREIGN KEY REFERENCES Users(UserId),
    WordId INT FOREIGN KEY REFERENCES Words(WordId),
    IsLearned BIT DEFAULT 0,
    LastReviewedDate DATETIME,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Bảng Tags (Nhãn)
CREATE TABLE Tags (
    TagId INT PRIMARY KEY IDENTITY,
    TagName NVARCHAR(50) NOT NULL,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Bảng WordTags (Liên kết từ vựng và nhãn)
CREATE TABLE WordTags (
    WordTagId INT PRIMARY KEY IDENTITY,
    WordId INT FOREIGN KEY REFERENCES Words(WordId),
    TagId INT FOREIGN KEY REFERENCES Tags(TagId),
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE(),
    DelFlg BIT DEFAULT 0
);
GO

-- Thêm ràng buộc duy nhất (Unique Constraints)
ALTER TABLE Words ADD CONSTRAINT UQ_EnglishWord UNIQUE (EnglishWord);
ALTER TABLE Topics ADD CONSTRAINT UQ_TopicName UNIQUE (TopicName);
ALTER TABLE WordTypes ADD CONSTRAINT UQ_TypeName UNIQUE (TypeName);
ALTER TABLE Tags ADD CONSTRAINT UQ_TagName UNIQUE (TagName);
ALTER TABLE Levels ADD CONSTRAINT UQ_LevelName UNIQUE (LevelName);
GO

-- Thêm ràng buộc khóa ngoại (Foreign Key Constraints)
ALTER TABLE Words ADD CONSTRAINT FK_Words_Topics FOREIGN KEY (TopicId) REFERENCES Topics(TopicId);
ALTER TABLE Words ADD CONSTRAINT FK_Words_WordTypes FOREIGN KEY (WordTypeId) REFERENCES WordTypes(WordTypeId);
ALTER TABLE Words ADD CONSTRAINT FK_Words_Levels FOREIGN KEY (LevelId) REFERENCES Levels(LevelId);
ALTER TABLE Synonyms ADD CONSTRAINT FK_Synonyms_Words FOREIGN KEY (WordId) REFERENCES Words(WordId);
ALTER TABLE Examples ADD CONSTRAINT FK_Examples_Words FOREIGN KEY (WordId) REFERENCES Words(WordId);
ALTER TABLE UserWords ADD CONSTRAINT FK_UserWords_Users FOREIGN KEY (UserId) REFERENCES Users(UserId);
ALTER TABLE UserWords ADD CONSTRAINT FK_UserWords_Words FOREIGN KEY (WordId) REFERENCES Words(WordId);
ALTER TABLE WordTags ADD CONSTRAINT FK_WordTags_Words FOREIGN KEY (WordId) REFERENCES Words(WordId);
ALTER TABLE WordTags ADD CONSTRAINT FK_WordTags_Tags FOREIGN KEY (TagId) REFERENCES Tags(TagId);
GO