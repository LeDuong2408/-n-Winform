go
-------------- Tạo các role --------------------------
CREATE ROLE role_LimitedAccess;
CREATE ROLE role_FullAccess;
GRANT SELECT, INSERT, DELETE ON TaiKhoan TO role_FullAccess
go
-- Gán các quyền cho role_LimitedAccess
GRANT SELECT ON OBJECT::dbo.NhanVien TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.CapBac TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.CTDonBan TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.CTDonDV TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.CTDonNhap TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.DonBan TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.DonDV TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.DonNhap TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.KhachHang TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.LoaiHang TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.MatHang TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.NhaCungCap TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.Voucher TO role_LimitedAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.DichVu TO role_LimitedAccess;
go
GRANT EXECUTE to role_LimitedAccess
go
deny exec on object::dbo.proc_themNV to role_LimitedAccess
deny exec on object::dbo.proc_updateNV to role_LimitedAccess
deny exec on object::dbo.proc_XoaNV to role_LimitedAccess
deny exec on object::dbo.proc_themNCC to role_LimitedAccess
deny exec on object::dbo.proc_UpdateNCC to role_LimitedAccess
deny exec on object::dbo.proc_DeleteNCC to role_LimitedAccess
deny exec on object::dbo.proc_CapQuyenQL to role_LimitedAccess



-----------------------------------------------------
go
-- Gán quyền tất cả các quyền cho role_FullAccess
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.CapBac TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.CTDonBan TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.CTDonDV TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.CTDonNhap TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.DonBan TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.DonDV TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.DonNhap TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.KhachHang TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.LoaiHang TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.MatHang TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.NhaCungCap TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.Voucher TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.DichVu TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.TaiKhoan TO role_FullAccess;
GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.NhanVien TO role_FullAccess;
go

GRANT EXECUTE to role_FullAccess
--GRANT EXECUTE TO role_FullAccess 
--GRANT SELECT, INSERT, UPDATE, DELETE, REFERENCES ON OBJECT::dbo.TaiKhoan TO role_FullAccess;
--------------------------TRIGGER-------------------------------
------------Trigger kiểm tra và cập nhật role cho các user khi có hành động update liên quan đến cột chức vụ----------------------------
go
ALTER TRIGGER trg_ChangeChucVu
ON NhanVien
AFTER UPDATE
AS
BEGIN
	PRINT('Da vo');
    SET NOCOUNT ON;

    IF UPDATE(ChucVu)
    BEGIN
        DECLARE @ChucVu NVARCHAR(100);
        DECLARE @MaNV INT;
        DECLARE @user VARCHAR(100);

        SELECT @ChucVu = i.ChucVu, @MaNV = i.MaNV
        FROM Inserted i;

        SELECT @user = t.TenDangNhap
        FROM TaiKhoan t
        WHERE t.MaNV = @MaNV;
		PRINT(@ChucVu);

        IF @ChucVu = N'Quản lí' or @ChucVu = N'Qu?n lí'
        BEGIN
			PRINT('Da vo admin');
			DECLARE @sqlAddToSysadmin NVARCHAR(MAX);
			SET @sqlAddToSysadmin = 'ALTER SERVER ROLE [sysadmin] ADD MEMBER ' + QUOTENAME(@user);
			EXEC sp_executesql @sqlAddToSysadmin;
            EXEC sp_droprolemember 'role_LimitedAccess', @user;
            EXEC sp_addrolemember 'role_FullAccess', @user;
        END
        ELSE
        BEGIN
			PRINT('Da vo xoa admin');
            IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = @user AND IS_MEMBER('role_LimitedAccess') = 1)
            BEGIN
				DECLARE @sqlAddToSysadmin1 NVARCHAR(MAX);
				SET @sqlAddToSysadmin1 = 'ALTER SERVER ROLE [sysadmin] DROP MEMBER ' + QUOTENAME(@user);
				EXEC sp_executesql @sqlAddToSysadmin1;
                EXEC sp_droprolemember 'role_FullAccess', @user;
                EXEC sp_addrolemember 'role_LimitedAccess', @user;
            END
        END
    END
END;
GO
CREATE TRIGGER trg_DeleteSQLAccount
ON TaiKhoan
AFTER DELETE
AS
BEGIN
    DECLARE @userName nvarchar(30);

    -- Retrieve the deleted UserName
    SELECT @userName = TenDangNhap
    FROM deleted;

    IF @userName IS NOT NULL
    BEGIN
        DECLARE @sqlString nvarchar(2000);

        -- Drop the login associated with the deleted account
        SET @sqlString = 'DROP LOGIN [' + @userName + ']';
        EXEC (@sqlString);

        -- Remove the user associated with the deleted account
        SET @sqlString = 'USE project_DBMS; DROP USER ' + @userName;
        EXEC (@sqlString);
    END
END;

--------------------------------------
-----Tạo procedure lấy quyền của một người dùng-----------
go 
--drop proc checkRole
go
CREATE PROCEDURE checkRole
    @tendangnhap NVARCHAR(100),
    @isQuanLi BIT OUTPUT
AS
BEGIN
    DECLARE @chucvu nvarchar(20);

	SELECT @chucvu = ChucVu
    FROM TaiKhoan t
    JOIN NhanVien n ON t.MaNV = n.MaNV
    WHERE TenDangNhap = @tendangnhap;

    IF (@chucvu LIKE '%lí%')
        SET @isQuanLi = 1;
    ELSE
        SET @isQuanLi = 0;
END;
-------------Gán người dùng vào role phù hợp------------------------------------------
go 
create proc addRoleUser
@tendangnhap nvarchar(100)
as
begin
	declare @isQuanLi BIT
	EXEC checkRole @tendangnhap, @isQuanLi OUTPUT
	if @isQuanLi = 1
		EXEC sp_addrolemember 'role_FullAccess', @tendangnhap;
	ELSE
        EXEC sp_addrolemember 'role_LimitedAccess', @tendangnhap;
end
------------Trigger tạo một user và gán quyền cho user đó sau khi tạo một tài khoản -------------
go
--drop trigger trg_createUser
CREATE TRIGGER trg_createUser ON TaiKhoan AFTER INSERT
AS
BEGIN 
    DECLARE @tendangnhap NVARCHAR(20);
    DECLARE @matkhau NVARCHAR(32);
    DECLARE @chucvu NVARCHAR(MAX);

    -- Lấy giá trị từ bảng Inserted
    SELECT @tendangnhap = TenDangNhap, @matkhau = MatKhau
    FROM inserted;

    -- Tạo login và user
    DECLARE @sqlLogin NVARCHAR(MAX);
    SET @sqlLogin = 'CREATE LOGIN ' + @tendangnhap + ' WITH PASSWORD =''' + @matkhau + '''';
    EXEC sp_executesql @sqlLogin;

    DECLARE @sqlUser NVARCHAR(MAX);
    SET @sqlUser = 'CREATE USER ' + QUOTENAME(@tendangnhap) + ' FOR LOGIN ' + QUOTENAME(@tendangnhap);
    EXEC sp_executesql @sqlUser;

	declare @isQuanLi BIT
	EXEC checkRole @tendangnhap, @isQuanLi OUTPUT
	if @isQuanLi = 1
	begin 
		EXEC sp_addrolemember 'role_FullAccess', @tendangnhap;
		DECLARE @sqlAddToSysadmin NVARCHAR(MAX);
        SET @sqlAddToSysadmin = 'ALTER SERVER ROLE [sysadmin] ADD MEMBER ' + QUOTENAME(@tendangnhap);
        EXEC sp_executesql @sqlAddToSysadmin;
	end
	ELSE
        EXEC sp_addrolemember 'role_LimitedAccess', @tendangnhap;
END;

-----------------------Chạy tới đây thôi nha -------------------------------
go
select * from TaiKhoan
select * from NhanVien
insert into TaiKhoan(MaNV, TenDangNhap, MatKhau) values (1, 'admin', 'password1.')
insert into TaiKhoan(MaNV, TenDangNhap, MatKhau) values (2, 'duo1', 'password1.')
insert into TaiKhoan(MaNV, TenDangNhap, MatKhau) values (5, 'duo2', 'hehehaha1.')
update NhanVien set ChucVu = 'Quản lí' where MaNV = 1051
insert into NhanVien(HoTen, NgaySinh, GioiTinh, DiaChi,SDT, ChucVu) values ('Le Thi Dat','1992-07-12', 'Nam','LT','0315670901', N'Quản lí')
insert into NhanVien(HoTen, NgaySinh, GioiTinh, DiaChi,SDT, ChucVu) values ('Le Thi Dai','1992-07-12', 'Nam','LT','0315678901', N'Nhân viên bán hàng')
go
delete TaiKhoan where MaNV = 1055
delete TaiKhoan where MaNV = 1052
delete TaiKhoan where MaNV = 1051
delete TaiKhoan where MaNV = 1
delete NhanVien where MaNV = 4
go
declare @isQuanli BIT
EXEC checkRole 'duong', @isQuanli OUTPUT
print @isQuanli

delete NhanVien Where ChucVu not like N'Quản lí'
create login duong with password = '123' 


