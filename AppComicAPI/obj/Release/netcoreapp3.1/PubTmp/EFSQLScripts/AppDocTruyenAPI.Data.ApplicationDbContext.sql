IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200510103824_ThemBangTaiKhoan')
BEGIN
    CREATE TABLE [TaiKhoans] (
        [Id] int NOT NULL IDENTITY,
        [TenTaiKhoan] nvarchar(max) NOT NULL,
        [MatKhau] nvarchar(max) NOT NULL,
        [TenHienThi] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TaiKhoans] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200510103824_ThemBangTaiKhoan')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200510103824_ThemBangTaiKhoan', N'3.1.3');
END;

GO

