CREATE DATABASE project_DBMS
GO

USE project_DBMS
GO
---------------------------------------------TẠO DATABASE----------------------------------------------
--NhanVien(MaNV, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, ChucVu, NgayTuyenDung)
CREATE TABLE NhanVien (
	MaNV int CONSTRAINT pk_NhanVien PRIMARY KEY IDENTITY,
	HoTen nvarchar(50) NOT NULL,
	NgaySinh date NOT NULL CONSTRAINT ck_NgaySinhNV CHECK(DATEDIFF(year, NgaySinh, GETDATE())>=18),
	GioiTinh nvarchar(5),
	DiaChi nvarchar(50),
	SDT nvarchar(11) NOT NULL UNIQUE CONSTRAINT ck_lenSTD_NV CHECK(LEN(SDT)=10),
	ChucVu nvarchar(20) NOT NULL,
	NgayTuyenDung date default GETDATE(),
	TrangThai bit default 1,
	Anh image 
	)

GO

CREATE TABLE TaiKhoan (
	MaTaiKhoan int CONSTRAINT pk_TK PRIMARY KEY IDENTITY,
	MaNV int CONSTRAINT fk_TaiKhoan_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	TenDangNhap nvarchar(20) UNIQUE,
	MatKhau nvarchar(32) NOT NULL CONSTRAINT ck_lenMatKhau CHECK(LEN(MatKhau)>=8),
)
GO
--NhaCungCap(MaNCC, TenNCC, DiaChi, SDT, Email)
CREATE TABLE NhaCungCap (
	MaNCC int CONSTRAINT pk_NCC PRIMARY KEY IDENTITY,
	TenNCC nvarchar(50) NOT NULL,
	DiaChi nvarchar(50) NOT NULL,
	SDT nvarchar(11) NOT NULL UNIQUE CONSTRAINT ck_lenSDT_KH CHECK(LEN(SDT)=10),
	Email nvarchar(50) NOT NULL UNIQUE CONSTRAINT ck_email_NCC CHECK(Email like '%_@__%.__%'),
	TrangThai bit  default 1
)
GO

--CapBac(MaCapBac, TenCapBac, DieuKien, UuDai)
CREATE TABLE CapBac (
	MaCapBac int CONSTRAINT pk_CapBac PRIMARY KEY IDENTITY,
	TenCapBac nvarchar(50) NOT NULL UNIQUE,
	DieuKien int CHECK(DieuKien>=0),
	UuDai int NOT NULL CONSTRAINT ck_UuDai CHECK(UuDai BETWEEN 0 AND 100)
)
GO
--KhachHang(MaKH, HoTen, SDT, DiaChi, MaCapBac)
CREATE TABLE KhachHang (
	MaKH int CONSTRAINT pk_KhachHang PRIMARY KEY IDENTITY,
	HoTen nvarchar(50) NOT NULL,
	SDT nvarchar(11) UNIQUE,
	DiaChi nvarchar(50),
	MaCapBac int DEFAULT 1,
	CONSTRAINT fk_KH_MaCapBac FOREIGN KEY (MaCapBac) REFERENCES CapBac(MaCapBac)
	ON DELETE SET NULL
	ON UPDATE CASCADE
)
GO
--LoaiHang(MaLoai, TenLoai)
CREATE TABLE LoaiHang (
    MaLoai int CONSTRAINT pk_LoaiHang PRIMARY KEY IDENTITY,
    TenLoai nvarchar(50) NOT NULL
)
GO
--MatHang(MaHang, TenHang, MaNCC, MaLoai, DonGia, BaoHanh, XuatXu)
CREATE TABLE MatHang (
	MaHang int CONSTRAINT pk_MatHang PRIMARY KEY IDENTITY,
	TenHang nvarchar(50) NOT NULL,
	MaNCC int,
	MaLoai int,
	GiaNhap int CHECK(GiaNhap>0),
	DonGia int CHECK(DonGia>0),
	BaoHanh int,
	XuatXu nvarchar(50),
	TrangThai bit default 1,
	SoLuong int NOT NULL  default 0 CONSTRAINT ck_SL_KhoHang CHECK(SoLuong>=0),
	CONSTRAINT fk_MatHang_NCC FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
	ON DELETE SET NULL
	ON UPDATE  CASCADE,
	CONSTRAINT fk_MatHang_LoaiHang FOREIGN KEY (MaLoai) REFERENCES LoaiHang(MaLoai)
	ON DELETE SET NULL
	ON UPDATE  CASCADE,
	Anh image 
)
GO

CREATE TABLE DonNhap (
	MaDon int CONSTRAINT pk_DonNhap PRIMARY KEY IDENTITY,
	NgayNhap date DEFAULT GETDATE() NOT NULL,
	TongGT int DEFAULT 0,
	TrangThai nvarchar(50) default N'Chưa thanh toán',
	MaNV int NOT NULL,
	CONSTRAINT fk_DonNhap_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE  CASCADE
)
GO

--CTDonNhap(MaChiTiet, MaDon, MaHang, SoLuong, DonGia, ThanhTien)
CREATE TABLE CTDonNhap (
	MaChiTiet int CONSTRAINT pk_ChiTietDonNhap PRIMARY KEY IDENTITY,
	MaDon int NOT NULL,
	MaHang int NOT NULL,
	SoLuong int CONSTRAINT ck_SL_ChiTietDonNhap CHECK(SoLuong>0),
	DonGia int CONSTRAINT ck_DonGia CHECK(DonGia>0),
	ThanhTien int default 0,
	CONSTRAINT fk_ChiTietDonNhap_DonNhap FOREIGN KEY (MaDon) REFERENCES DonNhap(MaDon),
	CONSTRAINT fk_ChiTietDonNhap_MatHang FOREIGN KEY (MaHang) REFERENCES MatHang(MaHang)
)
GO

CREATE TABLE Voucher (
	MaVoucher int CONSTRAINT pk_Voucher PRIMARY KEY IDENTITY,
	TenVoucher nvarchar(50) NOT NULL,
	NgayBatDau date NOT NULL,
	NgayKetThuc date NOT NULL,
	KhuyenMai int NOT NULL CONSTRAINT ck_KhuyenMai CHECK(KhuyenMai BETWEEN 0 and 100),
	GiamToiDa int NOT NULL CHECK(GiamToiDa>0),
	SoLuong int NOT NULL CHECK(SoLuong>=0),
)
GO

CREATE TABLE DonBan (
	MaDon int CONSTRAINT pk_DonBan PRIMARY KEY IDENTITY,
	NgayTao date DEFAULT GETDATE() NOT NULL,
	MaKH int NOT NULL,
	MaNV int NOT NULL,
	MaVoucher int,
	TrangThai nvarchar(20) DEFAULT N'Chưa thanh toán' NOT NULL,
	TongGT int DEFAULT 0 CONSTRAINT ck_TongGT_DonBan CHECK (TongGT>=0),
	ChietKhau int DEFAULT 0,
	VAT int DEFAULT 0,
	ThanhTien int DEFAULT 0 CONSTRAINT ck_ThanhTien_DonBan CHECK (ThanhTien>=0),											
	CONSTRAINT fk_DonBan_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	CONSTRAINT fk_DonBan_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	CONSTRAINT fk_DonBan_Voucher FOREIGN KEY (MaVoucher) REFERENCES Voucher(MaVoucher)
	ON DELETE SET NULL
	ON UPDATE  CASCADE
)
GO

CREATE TABLE CTDonBan (
	MaChiTiet int CONSTRAINT pk_ChiTietDonBan PRIMARY KEY IDENTITY,
	MaDon int NOT NULL,
	MaHang int NOT NULL,
	SoLuong int CONSTRAINT ck_SL CHECK(SoLuong>0),
	ThanhTien int CONSTRAINT ck_ThanhTien_CTDonBan CHECK (ThanhTien>=0),
	CONSTRAINT fk_ChiTietDonBan_DonBan FOREIGN KEY (MaDon) REFERENCES DonBan(MaDon),
	CONSTRAINT fk_ChiTietDonBan_MatHang FOREIGN KEY (MaHang) REFERENCES MatHang(MaHang)
)
GO


------------------------------------------------------------------------------------------------------
------------------------------------------------VIEWS---------------------------------------
CREATE VIEW MatHang_SL 
AS
SELECT MaHang,TenHang,SoLuong FROM MatHang
GO

CREATE VIEW KH_CapBac_UuDai 
AS
SELECT MaKH,HoTen,c.MaCapBac,TenCapBac,UuDai FROM KhachHang k JOIN CapBac c ON K.MaCapBac = c.MaCapBac
GO


CREATE VIEW NV_TK
AS
SELECT n.MaNV,HoTen,TenDangNhap,MatKhau FROM NhanVien n JOIN TaiKhoan t ON n.MaNV = t.MaNV
GO
--cac nha vien hien dang lam viec
Create VIEW NV_LamViec
AS
SELECT * FROM NhanVien WHERE TrangThai = 1
GO
--Cac mat hang dang ban
CREATE VIEW MatHang_DangBan
AS
SELECT * FROM MatHang WHERE TrangThai = 1
GO


------------------------------------------------TRIGGERS-------------------------------------\
-- TRIGGER Kiểm tra DỮ LIỆU----------------------------
--Xoa nhan vien
CREATE TRIGGER deleteNhanVien on NhanVien INSTEAD OF DELETE
AS
BEGIN
	UPDATE NhanVien SET TrangThai = 0 WHERE MaNV = (SELECT MaNV FROM deleted)
END
GO
--xoa mat hang
CREATE TRIGGER deleteMatHang on MatHang INSTEAD OF DELETE
AS
BEGIN
	UPDATE MatHang SET TrangThai = 0 WHERE MaHang = (SELECT MaHang FROM deleted)
END
GO
--mật khẩu phải có kí tự đặc biệt--

CREATE TRIGGER checkMatKhau ON TaiKhoan FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @mk nvarchar(32) = (SELECT MatKhau FROM inserted)
	IF (@mk LIKE '%[^a-zA-Z0-9 ]%') 
		print('Mat khau hop le')
	ELSE
	BEGIN
		RAISERROR('Mat khau phai chua it nhat 1 ki tu dac biet',16,1)
		ROLLBACK
	END
END
GO

--Kiểm tra không được update đơn bán đã thanh toán
CREATE TRIGGER checkTrangThaiDonBan on DonBan FOR UPDATE
AS
BEGIN
	DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM deleted)
	IF @TrangThai = N'Đã thanh toán'
	BEGIN
		RAISERROR('Khong duoc sua khi don da thanh toan',16,1)
		ROLLBACK
	END
END
GO

--check số lượng hàng xem có đủ sau khi thêm một đơn trong CTDonBan không--
--nếu đủ thì update số lượng trong view MatHang_SL--
CREATE TRIGGER checkSLHang_insert ON CTDonBan FOR INSERT
AS
BEGIN
	DECLARE @MaHang int, @SL int
	DECLARE @SLKho int
	SELECT @MaHang = i.MaHang, @SL = i.SoLuong FROM inserted i

	SELECT @SLKho = SoLuong FROM MatHang_SL WHERE MaHang = @MaHang
	IF (@SLKho<@SL)
		BEGIN
			RAISERROR('Khong co du hang',16,1)
			ROLLBACK --Không đủ hàng--
		END
	ELSE
		BEGIN
			UPDATE MatHang_SL
			SET SoLuong = @SLKho - @SL
			WHERE MaHang = @MaHang
		END
END
GO

--check số lượng hàng xem có đủ sau khi sửa số lượng hàng của một đơn bất kì trong CTDonBan không--
--nếu đủ thì update số lượng hàng trong view MatHang_SL--
CREATE TRIGGER checkSLHang_update ON CTDonBan AFTER UPDATE
AS
BEGIN
	DECLARE @MaHang int, @SL int, @olSL int
	DECLARE @SLKho int
	SELECT @MaHang = i.MaHang, @SL = i.SoLuong FROM inserted i
	SELECT @olSL = SoLuong FROM deleted
	IF (@SL != @olSL)
	BEGIN
		--print('CHAY')
		SELECT @SLKho = SoLuong FROM MatHang_SL WHERE MaHang = @MaHang
		IF (@SLKho+@olSL<@SL)
			BEGIN
				RAISERROR('kHONG DU HANG',16,1)
				ROLLBACK --Không đủ hàng
			END
		ELSE
			BEGIN
				UPDATE MatHang_SL
				SET SoLuong = @SLKho + @olSL - @SL
				WHERE MaHang = @MaHang
			END
	END
END
GO


--check ngày bắt đầu và ngày kết thúc của voucher--
CREATE TRIGGER checkVoucher ON Voucher FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @NgayBatDau date, @NgayKetThuc date
	SELECT @NgayBatDau = i.NgayBatDau, @NgayKetThuc = i.NgayKetThuc FROM inserted i
	IF (@NgayBatDau>@NgayKetThuc) 
		BEGIN
			RAISERROR('Ngay bat dau va ngay ket thuc khong hop le',16,1)
			ROLLBACK
		END	
END
GO
--TRIGGER TINH TOAN----------------------------------------------
--Xử lí liên quan đến nhập hàng------------------------
CREATE TRIGGER handleInsertCTDonNhap ON CTDonNhap AFTER INSERT
AS
BEGIN
	DECLARE @MaDon int = (SELECT MaDon FROM inserted)
	DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM DonNhap WHERE MaDon = @MaDon)
	IF @TrangThai != N'Đã thanh toán' -- Don chua thanh toan moi dc Them chi tiet don
	BEGIN
		IF (UPDATE(SoLuong))
		BEGIN
			DECLARE @maHang int = (SELECT MaHang FROM inserted);

			--UPDATE Thành tiền của chi tiết đó
			DECLARE @ThanhTien int;
			SET @ThanhTien =  (SELECT SoLuong From inserted)*(SELECT GiaNhap FROM MatHang WHERE MaHang = @maHang);
			UPDATE CTDonNhap
			SET ThanhTien = @ThanhTien
			WHERE MaChiTiet = (SELECT MaChiTiet FROM inserted) 


			--UPDATE Tong gia tri don nhap--
			UPDATE DonNhap
			SET	TongGT = TongGT+ @ThanhTien
			WHERE MaDon = (SELECT MaDon From inserted)
		END
	END
	ELSE
	BEGIN
		RAISERROR('don da thanh toan',16,1)
		ROLLBACK
	END
END
GO
CREATE TRIGGER handleUpdateCTDonNhap ON CTDonNhap AFTER UPDATE
AS
BEGIN
	DECLARE @MaDon int = (SELECT MaDon FROM inserted)
	DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM DonNhap WHERE MaDon = @MaDon)
	IF @TrangThai != N'Đã thanh toán' -- Don chua thanh toan moi dc Them chi tiet don
	BEGIN
		IF (UPDATE(SoLuong))
		BEGIN
			DECLARE @maHang int = (SELECT MaHang FROM inserted);
		
			--UPDATE Thành tiền của chi tiết đó
			DECLARE @ThanhTien int;
			SET @ThanhTien =  (SELECT SoLuong From inserted)*(SELECT GiaNhap FROM MatHang WHERE MaHang = @maHang);
			UPDATE CTDonNhap
			SET ThanhTien = @ThanhTien
			WHERE MaChiTiet = (SELECT MaChiTiet FROM inserted) 

			--UPDATE Tong gia tri don nhap--
			UPDATE DonNhap
			SET	TongGT = TongGT + @ThanhTien - (SELECT ThanhTien FROM deleted)
			WHERE MaDon = (SELECT MaDon From inserted)
		END
	END
	ELSE
	BEGIN
		RAISERROR('don da thanh toan',16,1)
		ROLLBACK
	END
END
GO
CREATE TRIGGER handleDeleteCTDonNhap ON CTDonNhap AFTER Delete
AS
BEGIN
	DECLARE @MaDon int = (SELECT MaDon FROM deleted)
	DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM DonNhap WHERE MaDon = @MaDon)
	IF @TrangThai != N'Đã thanh toán' -- Don chua thanh toan moi dc Them chi tiet don
	BEGIN
		--UPDATE TONG GIA TRI DON NHAP--
		UPDATE DonNhap
		SET	TongGT = TongGT - (SELECT ThanhTien FROM deleted)
		WHERE MaDon = (SELECT MaDon From deleted)
	END
	ELSE
	BEGIN
		RAISERROR('don da thanh toan',16,1)
		ROLLBACK
	END
END
GO
CREATE TRIGGER handlThanhToanDonNhap ON DonNhap AFTER UPDATE
AS
BEGIN
	DECLARE @TrangThai nvarchar(50) = (select TrangThai From inserted)
	if (UPDATE(TrangThai) and @TrangThai = N'Đã thanh toán')
	BEGIN
		DECLARE @MaDon int = (SELECT MaDon FROM inserted)
		-- Cập nhật số lượng hàng trong kho dựa trên thông tin chi tiết đơn nhập
        UPDATE MatHang
        SET SoLuong = SoLuong + (SELECT SoLuong FROM CTDonNhap WHERE MaDon = @MaDon AND MaHang = MatHang.MaHang)
        WHERE MaHang IN (SELECT DISTINCT MaHang FROM CTDonNhap WHERE MaDon = @MaDon);
	END
END
GO
--Xử lí liên quan đến bán hàng-------------------
CREATE TRIGGER check_nv_DonBan ON DonBan For INSERT 
AS
BEGIN
	DECLARE @ChucVu nvarchar(20) = (SELECT CHUCVU FROM NhanVien WHERE MaNV = (SELECT MaNV FROM inserted))
	IF (@ChucVu LIKE N'Nhân viên kĩ thuật')
	BEGIN
		RAISERROR('Nhan vien ki thuat khong duoc tao don ban',16,1)
		ROLLBACK
	END
END
GO
CREATE TRIGGER checkUseVoucher_insert ON DonBan FOR INSERT
AS
BEGIN
	DECLARE @MaVoucher int = (SELECT MaVoucher FROM inserted)
	IF @MaVoucher IS NOT NULL
	BEGIN
		DECLARE @NgayBD date, @NgayKT date, @NgaySD date
		SELECT @NgayBD = NgayBatDau, @NgayKT = NgayKetThuc FROM Voucher WHERE MaVoucher = @MaVoucher
		SELECT @NgaySD = NgayTao FROM inserted
		DECLARE @SL int = (SELECT SoLuong FROM Voucher WHERE MaVoucher = @MaVoucher)
		IF (@NgaySD<@NgayBD or @NgaySD>@NgayKT or @SL<=0)
		BEGIN
			RAISERROR('Khong su dung duoc voucher nay',16,1)
			ROLLBACK
		END
		ELSE
		BEGIN
			--Voucher sử dụng được thì cập nhật lại số lượng
			UPDATE Voucher SET SoLuong = @SL - 1 WHERE MaVoucher = @MaVoucher
		END
	END
END
GO
CREATE TRIGGER checkUseVoucher_update ON DonBan AFTER UPDATE
AS
BEGIN
	IF UPDATE(MaVoucher)
	BEGIN
		DECLARE @MaVoucher int = (SELECT MaVoucher FROM inserted)
		IF @MaVoucher IS NOT NULL
		BEGIN
			DECLARE @NgayBD date, @NgayKT date, @NgaySD date
			SELECT @NgayBD = NgayBatDau, @NgayKT = NgayKetThuc FROM Voucher WHERE MaVoucher = @MaVoucher
			SELECT @NgaySD = NgayTao FROM inserted
			DECLARE @SL int = (SELECT SoLuong FROM Voucher WHERE MaVoucher = @MaVoucher)
			IF (@NgaySD<@NgayBD or @NgaySD>@NgayKT or @SL<=0)
			BEGIN
				RAISERROR('Khong su dung duoc voucher nay',16,1)
				ROLLBACK
			END
			ELSE
			BEGIN
				--Voucher sử dụng được thì cập nhật lại số lượng
				UPDATE Voucher SET SoLuong = @SL - 1 WHERE MaVoucher = @MaVoucher
				UPDATE Voucher SET SoLuong = SoLuong+1 WHERE MaVoucher = (SELECT MaVoucher FROM deleted)
				
				--UPDATE CHIETKHAU, THANHTIEN
				DECLARE @TongGT int = (SELECT TongGT FROM inserted)
				DECLARE @ChietKhauVoucher int = 0
				DECLARE @ChietKhauCapBac int = 0
				SET @ChietKhauCapBac = (SELECT UuDai FROM KH_CapBac_UuDai WHERE MaKH = (SELECT MaKH FROM inserted))/100*@TongGT
				SET @ChietKhauVoucher = @TongGT*(SELECT KhuyenMai FROM Voucher WHERE MaVoucher = @MaVoucher)/100
				UPDATE DonBan
				SET ChietKhau = @ChietKhauCapBac + @ChietKhauVoucher,
					ThanhTien = @TongGT + (@TongGT * 0.1) - (@ChietKhauCapBac + @ChietKhauVoucher)
				WHERE MaDon = (SELECT MaDon FROM inserted)	
			END
		END
	END
END
GO
CREATE TRIGGER handleInsertCTDonBan ON CTDonBan AFTER INSERT
AS
BEGIN
	DECLARE @MaDon int = (SELECT MaDon FROM inserted)
	DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM DonBan WHERE MaDon = @MaDon)
	IF @TrangThai != N'Đã thanh toán' -- Don chua thanh toan moi dc Them chi tiet don
	BEGIN
		--UPDATE THANH TIEN CUA CT
		--print('update TT   ')
		DEClARE @MaCT int= (SELECT MaChiTiet FROM inserted)
		UPDATE CTDonBan
		SET ThanhTien = (SELECT SoLuong FROM inserted)*(SELECT DonGia FROM MatHang WHERE MaHang = (SELECT MaHang FROM inserted))
		WHERE MaChiTiet = @MaCT
		--UPDATE TONGGT DON BAN
		UPDATE DonBan SET TongGT = TongGT + (SELECT ThanhTien FROM CTDonBan WHERE MaChiTiet = @MaCT)
		WHERE MaDon = @MaDon
	END
	ELSE 
	BEGIN
		RAISERROR('Khong duoc them san pham khi don da thanh toan',16,1)
		ROLLBACK
	END
END
GO
CREATE TRIGGER handleUpdateCTDonBan ON CTDonBan AFTER UPDATE
AS
BEGIN
	DECLARE @MaDon int = (SELECT MaDon FROM inserted)
	DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM DonBan WHERE MaDon = @MaDon)
	IF @TrangThai != N'Đã thanh toán' -- Don chua thanh toan moi dc Xoa chi tiet don
	BEGIN
		IF (UPDATE(SoLuong)) --Kiem tra xem có update số lượng hàng không, nếu có thì tính lại giống trên trigger insertCTDonBan
		BEGIN
			--UPDATE THANH TIEN CUA CT
			DEClARE @MaCT int= (SELECT MaChiTiet FROM inserted)
			UPDATE CTDonBan
			SET ThanhTien = (SELECT SoLuong FROM inserted)*(SELECT DonGia FROM MatHang WHERE MaHang = (SELECT MaHang FROM inserted))
			WHERE MaChiTiet = @MaCT
			--UPDATE TONGGT DON BAN
			--print('update TGT   ')
			UPDATE DonBan SET TongGT = TongGT + (SELECT ThanhTien FROM CTDonBan WHERE MaChiTiet = @MaCT) - (SELECT ThanhTien FROM deleted)
			WHERE MaDon = @MaDon
		END
	END
	ELSE 
	BEGIN
		RAISERROR('Khong duoc thay doi khi don da thanh toan',16,1)
		ROLLBACK
	END
END
GO
CREATE TRIGGER handleDeleteCTDonBan ON CTDonBan AFTER DELETE
AS
BEGIN
	DECLARE @MaDon int = (SELECT MaDon FROM deleted)
	DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM DonBan WHERE MaDon = @MaDon)
	IF @TrangThai != N'Đã thanh toán' -- Don chua thanh toan moi dc Xoa chi tiet don
	BEGIN
		--UPDATE SL hàng (trả hàng về kho)
		UPDATE MatHang set SoLuong = SoLuong + (SELECT SoLuong FROM deleted)
		WHERE MaHang = (SELECT MaHang From deleted)
		--UPDATE TONGGT DON BAN
		--print('update TGT   ')
		UPDATE DonBan SET TongGT = TongGT - (SELECT ThanhTien FROM deleted)
		WHERE MaDon = @MaDon
	END
	ELSE 
	BEGIN
		RAISERROR('Khong duoc xoa san pham khi don da thanh toan',16,1)
		ROLLBACK
	END
END
GO

CREATE TRIGGER handelUpdateDonBan ON DonBan AFTER UPDATE
AS
BEGIN
	IF (UPDATE(TongGT))
	BEGIN
		DECLARE @neTongGT int = (SELECT TongGT FROM inserted)
		--UPDATE CHIETKHAU, THANHTIEN
		DECLARE @ChietKhauVoucher int = 0
		DECLARE @ChietKhauCapBac int = 0
		SET @ChietKhauCapBac = @neTongGT*(SELECT UuDai FROM KH_CapBac_UuDai WHERE MaKH = (SELECT MaKH FROM inserted))/100
		DECLARE @MaVoucher int = (SELECT MaVoucher FROM inserted)
		IF @MaVoucher IS NOT NULL
			SET @ChietKhauVoucher = @neTongGT*(SELECT KhuyenMai FROM Voucher WHERE MaVoucher = @MaVoucher)/100
		UPDATE DonBan
		SET VAT = @neTongGT * 0.1, 
			ChietKhau = @ChietKhauCapBac + @ChietKhauVoucher,
			ThanhTien = @neTongGT + (@neTongGT * 0.1) - (@ChietKhauCapBac + @ChietKhauVoucher)
		WHERE MaDon = (SELECT MaDon FROM inserted)	
	END
END
GO
CREATE TRIGGER handelUpdateTrangThaiDonBan ON DonBan AFTER UPDATE
AS
BEGIN
	--khi khách hàng thanh toán đơn, tính tổng tất cả các đơn của khách đó xem đã lên cấp được chưa
	DECLARE @MaKH int = (SELECT MaKH From inserted)
	DECLARE @MaCapBac int = (SELECT MaCapBac FROM KH_CapBac_UuDai WHERE MaKH = @MaKH)
	IF (UPDATE(TrangThai) and @MaCapBac < 4)
	BEGIN
	-- KT Trang Thai Thanh Toan
		DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM inserted)
		IF @TrangThai = N'Đã thanh toán'
		BEGIN
			DECLARE @TongTienMua int = 0, @TongTienDV int = 0
			SELECT @TongTienMua =  SUM(ThanhTien) FROM DonBan WHERE MaKH = @MaKH GROUP BY MaKH,TrangThai HAVING TrangThai = N'Đã thanh toán'
			SELECT @TongTienDV = SUM(ThanhTien) FROM DonDV WHERE MaKH = @MaKH GROUP BY MaKH,TrangThai HAVING TrangThai = N'Đã thanh toán'
			DECLARE @TongTien int = @TongTienMua + @TongTienDV
			WHILE (@TongTien >= (SELECT DieuKien FROM CapBac WHERE MaCapBac = @MaCapBac) and @MaCapBac <= 4)
				BEGIN
					Set @MaCapBac = @MaCapBac +1 
				END
			SET @MaCapBac = @MaCapBac - 1
			UPDATE KhachHang SET MaCapBac = @MaCapBac
			WHERE MaKH = @MaKH
		END
	END
END
GO
--Xử lí liên quan đến đơn dịch vụ-------------------
CREATE TRIGGER check_nv_CTDonDV ON CTDonDV FOR INSERT 
AS
BEGIN
	DECLARE @ChucVu nvarchar(20) = (SELECT CHUCVU FROM NhanVien WHERE MaNV = (SELECT MaNV FROM inserted))
	IF (@ChucVu NOT LIKE N'Nhân viên kĩ thuật')
	BEGIN
		RAISERROR('Don dich vu phai do nhan vien ki thuat phu trach',16,1)
		ROLLBACK
	END
END
GO

CREATE TRIGGER handleInsertCTDonDV ON CTDonDV AFTER INSERT
AS
BEGIN
	DECLARE @MaDon int = (SELECT MaDon FROM inserted)
	DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM DonDV WHERE MaDon = @MaDon)
	IF @TrangThai != N'Đã thanh toán' -- Don chua thanh toan moi dc them chi tiet don
	BEGIN
		--UPDATE TONGGT DON BAN
		--print('update TGT   ')
		UPDATE DonDV SET TongGT = TongGT + (SELECT DonGia FROM inserted)
		WHERE MaDon = @MaDon
	END
	ELSE 
	BEGIN
		RAISERROR('Khong them dich vu khi don da thanh toan',16,1)
		ROLLBACK
	END
END
GO
CREATE TRIGGER handleDeleteCTDonDV ON CTDonDV AFTER DELETE
AS
BEGIN
	DECLARE @MaDon int = (SELECT MaDon FROM deleted)
	DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM DonDV WHERE MaDon = @MaDon)
	IF @TrangThai != N'Đã thanh toán' -- Don chua thanh toan moi dc Xoa chi tiet don
	BEGIN
		--UPDATE TONGGT DON DV
		UPDATE DonDV SET TongGT = TongGT - (SELECT DonGia FROM deleted)
		WHERE MaDon = @MaDon
	END
	ELSE 
	BEGIN
		RAISERROR('Khong duoc xoa dich vu khi don da thanh toan',16,1)
		ROLLBACK
	END
END
GO
CREATE TRIGGER handelUpdateDonDV ON DonDV AFTER UPDATE
AS
BEGIN
	IF (UPDATE(TongGT))
	BEGIN
		DECLARE @neTongGT int = (SELECT TongGT FROM inserted)
		--UPDATE CHIETKHAU, THANHTIEN
		UPDATE DonDV
		SET VAT = @neTongGT * 0.1, 
			--ChietKhau = @ChietKhauCapBac + @ChietKhauVoucher,
			ThanhTien = @neTongGT + (@neTongGT * 0.1)
		WHERE MaDon = (SELECT MaDon FROM inserted)	
	END
END
GO
CREATE TRIGGER handelUpdateTrangThaiDonDV ON DonDV AFTER UPDATE
AS
BEGIN
	--khi khách hàng thanh toán đơn, tính tổng tất cả các đơn của khách đó xem đã lên cấp được chưa
	DECLARE @MaKH int = (SELECT MaKH From inserted)
	DECLARE @MaCapBac int = (SELECT MaCapBac FROM KH_CapBac_UuDai WHERE MaKH = @MaKH)
	IF (UPDATE(TrangThai) and @MaCapBac < 4)
	BEGIN
		-- KT Trang Thai Thanh Toan
		DECLARE @TrangThai nvarchar(20) = (SELECT TrangThai FROM inserted)
		IF @TrangThai = N'Đã thanh toán'
		BEGIN
			DECLARE @TongTienMua int = 0, @TongTienDV int = 0
			SELECT @TongTienMua =  SUM(ThanhTien) FROM DonBan WHERE MaKH = @MaKH GROUP BY MaKH,TrangThai HAVING TrangThai = N'Đã thanh toán'
			SELECT @TongTienDV = SUM(ThanhTien) FROM DonDV WHERE MaKH = @MaKH GROUP BY MaKH,TrangThai HAVING TrangThai = N'Đã thanh toán'
			DECLARE @TongTien int = @TongTienMua + @TongTienDV
			WHILE (@TongTien >= (SELECT DieuKien FROM CapBac WHERE MaCapBac = @MaCapBac) and @MaCapBac <= 4)
				BEGIN
					Set @MaCapBac = @MaCapBac +1 
					print(@MaCapBac)
				END
			SET @MaCapBac = @MaCapBac - 1
			UPDATE KhachHang SET MaCapBac = @MaCapBac
			WHERE MaKH = @MaKH
		END
	END
END
GO

--store procedure------------------------------------------------------------------------------------------------------------------------
--lay danh sach toan bo nhan vien
CREATE PROC proc_select_all_NV
as 
	SELECT * FROM NV_LamViec
GO
--them nhan vien--
CREATE PROC proc_themNV
@TenNV nvarchar(20),
@NgaySinh date,
@GioiTinh nvarchar(10),
@DiaChi nvarchar(50),
@SDT nvarchar(14),
@ChucVu nvarchar(20),
@NgayTuyenDung date,
@Anh image
as 
	INSERT INTO dbo.NhanVien(HoTen,NgaySinh,GioiTinh,DiaChi,SDT,ChucVu,NgayTuyenDung,Anh) VALUES (@TenNV,@NgaySinh,@GioiTinh,@DiaChi,@SDT,@ChucVu,@NgayTuyenDung,@Anh)
GO

--update Nhan Vien
CREATE PROC proc_updateNV
@MaNV nvarchar(10),
@TenNV nvarchar(20),
@NgaySinh date,
@GioiTinh nvarchar(10),
@DiaChi nvarchar(50),
@SDT nvarchar(14),
@Anh image
as
BEGIN
 UPDATE NhanVien SET HoTen = @TenNV, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi,SDT = @SDT, Anh = @Anh
 WHERE MaNV = @MaNV
END
GO
select * from NhanVien
GO
CREATE PROC proc_XoaNV
@MaNV int
AS
BEGIN
	 UPDATE NhanVien set TrangThai = 0
	 WHERE MaNV = @MaNV	
END
GO
CREATE PROC proc_SelectAllHang
AS
BEGIN
	select * from MatHang_DangBan
END
Go
CREATE PROC proc_themHang
@TenHang nvarchar(50),
@MaNCC int,
@MaLoai int,
@GiaNhap int,
@DonGia int,
@BaoHanh int,
@XuatXu nvarchar(50),
@Anh image
AS
BEGIN
	INSERT INTO MatHang(TenHang, MaNCC, MaLoai, GiaNhap, DonGia, BaoHanh, XuatXu,Anh)
	VALUES(@TenHang, @MaNCC, @MaLoai, @GiaNhap, @DonGia, @BaoHanh, @XuatXu, @Anh)
END
GO
CREATE FUNCTION func_findNCCByID (@maNCC int)
RETURNS nvarchar(50)
BEGIN
	return (select TenNCC FROM NhaCungCap WHERE MaNCC = @maNCC)
END
GO

CREATE FUNCTION func_findLoaiByID (@maLoai int)
RETURNS nvarchar(50)
BEGIN
	return (select TenLoai FROM LoaiHang WHERE MaLoai = @maLoai)
END
GO

ALTER PROC proc_findHang 
@TenHang nvarchar(50) null,
@NCC nvarchar(50) null,
@Loai nvarchar(50) null,
@XuatXu nvarchar(50) null
AS
BEGIN
	select MaHang,TenHang,BaoHanh,SoLuong,GiaNhap,DonGia,XuatXu,h.MaNCC,TenNCC,h.MaLoai,TenLoai,TrangThai,Anh from MatHang_DangBan h join LoaiHang l on h.MaLoai = l.MaLoai
			join NhaCungCap ncc on h.MaNCC = ncc.MaNCC
	WHERE (h.TenHang LIKE '%' + @TenHang + '%' or @TenHang = '')  and (ncc.TenNCC LIKE '%' + @NCC + '%' or @NCC = '') 
			and (l.TenLoai LIKE '%' + @Loai + '%' or @Loai = '') and (h.XuatXu LIKE '%' + @XuatXu + '%' or @XuatXu = '')
END
GO

CREATE PROC proc_findHangByMaLoai 
@MaLoai int
AS
BEGIN
	select MaHang,TenHang,BaoHanh,SoLuong,GiaNhap,DonGia,XuatXu,h.MaNCC,TenNCC,h.MaLoai,TenLoai,TrangThai from MatHang_DangBan h join LoaiHang l on h.MaLoai = l.MaLoai
			join NhaCungCap ncc on h.MaNCC = ncc.MaNCC
	WHERE h.MaLoai = @MaLoai
END
GO

ALTER PROC proc_selectAllNCC
AS
BEGIN	
 SELECT * FROM NhaCungCap WHERE TrangThai = 1
END
GO
CREATE PROC proc_selectAllLoai
AS
BEGIN	
 SELECT * FROM LoaiHang
END
GO
CREATE PROC proc_selectAllXuatXu
AS
BEGIN
	SELECT XuatXu FROM MatHang
END
GO

CREATE PROC proc_suahang
@MaHang int,
@TenHang nvarchar(50),
@GiaNhap int,
@GiaBan int,
@BaoHanh int,
@MaNCC int,
@MaLoai int,
@Anh image,
@XuatXu nvarchar(50)
AS
BEGIN
	UPDATE MatHang SET
		TenHang = @TenHang,
		GiaNhap = @GiaNhap,
		DonGia = @GiaBan,
		BaoHanh = @BaoHanh,
		MaNCC = @MaNCC,
		MaLoai = @MaLoai,
		Anh = @Anh,
		XuatXu = @XuatXu
	WHERE MaHang = @MaHang
END
GO

CREATE PROC proc_themKH
@TenKH nvarchar(50),
@SDT nvarchar(11),
@DiaChi nvarchar(50),
@MaCapBac int
AS
BEGIN
	INSERT INTO KhachHang (HoTen,SDT,DiaChi,MaCapBac) VALUES (@TenKH,@SDT,@DiaChi,@MaCapBac)
END
GO

CREATE PROC proc_UpdateKH
@TenKH nvarchar(50),
@SDT nvarchar(11),
@DiaChi nvarchar(50),
@MaCapBac int,
@MaKH int
AS
BEGIN
	UPDATE KhachHang SET HoTen = @TenKH, SDT = @SDT, DiaChi = @DiaChi, MaCapBac = @MaCapBac WHERE MaKH = @MaKH
END
GO

CREATE PROC proc_selectBy
@TenKH nvarchar(50),
@CapBac nvarchar(50)
AS
BEGIN
	SELECT MaKH,HoTen,SDT,DiaChi,c.MaCapBac,TenCapBac FROM KhachHang k JOIN CapBac c On k.MaCapBac = c.MaCapBac
	WHERE (TenCapBac LIKE @CapBac OR @CapBac = '') AND (HoTen LIKE '%'+@TenKH+'%')
END
GO

CREATE Proc insertDonNhap 
@MaNV int
AS
BEGIN
    INSERT INTO DonNhap (MaNV) VALUES (@MaNV);
END
GO
CREATE FUNCTION GetMaDon()
RETURNS int
AS
BEGIN
    DECLARE @MaDon INT;
    SELECT @MaDon = MAX(MaDon) FROM DonNhap;
    RETURN @MaDon;
END
GO
select * from DonNhap
GO
CREATE PROC proc_ThemCTDonNhap
@MaDon int,
@MaHang int,
@SoLuong int
AS
BEGIN
	INSERT INTO CTDonNhap(MaDon,MaHang,SoLuong) VALUES (@MaDon,@MaHang,@SoLuong)
END
GO

CREATE FUNCTION GetMaCTDonNhap()
RETURNS int
AS
BEGIN
    DECLARE @MaCT INT;
    SELECT @MaCT = MAX(MaChiTiet) FROM CTDonNhap;
    RETURN @MaCT;
END
GO
CREATE PROC proc_FindHangById
@MaHang int
AS
BEGIN
	SELECT * FROM MatHang WHERE MaHang = @MaHang
END
GO

GO
CREATE PROC proc_UpdateSoLuongCTDonNhap
@MaCT int,
@SoLuong int
AS
BEGIN
	UPDATE CTDonNhap SET SoLuong = @SoLuong WHERE MaChiTiet = @MaCT
END
GO

CREATE FUNCTION GetGTDonNhapById(@MaDon int)
RETURNS int
AS
BEGIN
	DECLARE @TongGT int = (SELECT TongGT FROM DonNhap WHERE MaDon = @MaDon);
	RETURN @TongGT
END
GO

CREATE PROC UpdateTrangThaiDonNhap
@MaDon int
AS
BEGIN
	UPDATE DonNhap SET TrangThai = N'Đã thanh toán' WHERE MaDon = @MaDon
END
GO

CREATE Proc insertDonBan
@MaNV int,
@MaKH int
AS
BEGIN
    INSERT INTO DonBan(MaNV,MaKH) VALUES (@MaNV,@MaKH);
END
GO
CREATE FUNCTION GetMaDonBan()
RETURNS int
AS
BEGIN
    DECLARE @MaDon INT;
    SELECT @MaDon = MAX(MaDon) FROM DonBan;
    RETURN @MaDon;
END
GO

CREATE Proc proc_UpdateDonBan_MaKH
@MaDon int,
@MaKH int
AS
BEGIN
    UPDATE DonBan SET MaKH = @MaKH WHERE MaDon = @MaDon
END
GO

CREATE PROC proc_ThemCTDonBan
@MaDon int,
@MaHang int,
@SoLuong int
AS
BEGIN
	INSERT INTO CTDonBan(MaDon,MaHang,SoLuong) VALUES (@MaDon,@MaHang,@SoLuong)
END
GO

CREATE FUNCTION GetMaCTDonBan()
RETURNS int
AS
BEGIN
    DECLARE @MaCT INT;
    SELECT @MaCT = MAX(MaChiTiet) FROM CTDonBan;
    RETURN @MaCT;
END
GO

CREATE FUNCTION GetGTDonBanById(@MaDon int)
RETURNS int
AS
BEGIN
	DECLARE @TongGT int = (SELECT TongGT FROM DonBan WHERE MaDon = @MaDon);
	RETURN @TongGT
END
GO

CREATE PROC UpdateTrangThaiDonBan
@MaDon int
AS
BEGIN
	UPDATE DonNhap SET TrangThai = N'Đã thanh toán' WHERE MaDon = @MaDon
END
GO
CREATE PROC proc_UpdateSoLuongCTDonBan
@MaCT int,
@SoLuong int
AS
BEGIN
	UPDATE CTDonBan SET SoLuong = @SoLuong WHERE MaChiTiet = @MaCT
END
GO

CREATE PROC proc_FindNVByName
@TenDangNhap nvarchar(20)
AS
BEGIN
	SELECT n.MaNV, HoTen, NgaySinh, DiaChi, GioiTinh, SDT, ChucVu, NgayTuyenDung, TrangThai, Anh FROM NhanVien n JOIN TaiKhoan t ON n.MaNV = t.MaNV
	WHERE TenDangNhap = @TenDangNhap
END
GO

CREATE PROC proc_login
@user nvarchar(20),
@pass nvarchar(32)
as
select * from TaiKhoan WHERE TenDangNhap = @user and MatKhau = @pass
go

select * from MatHang
GO
CREATE FUNCTION func_FindNVByName(@TenDangNhap nvarchar(20))
RETURNS Table 
AS
	RETURN (SELECT n.MaNV, HoTen, NgaySinh, DiaChi, GioiTinh, SDT, ChucVu, NgayTuyenDung, TrangThai, Anh FROM NhanVien n JOIN TaiKhoan t ON n.MaNV = t.MaNV
				WHERE TenDangNhap = @TenDangNhap)
GO

CREATE PROC proc_selectAllVoucher

AS
BEGIN
	SELECT * FROM Voucher --WHERE (NgayBatDau<=@NgaySuDung AND NgayKetThuc>=@NgaySuDung AND SoLuong>0)
END
GO

create proc proc_GetDonBanById
@MaDon int
AS
BEGIN
	select * from DonBan where MaDon = @MaDon
END
go
CREATE PROC proc_UpdateDonBan_Mavvoucher
@MaVoucher int,
@MaDon int
AS
BEGIN
	UPDATE  DonBan  SET MaVoucher = @MaVoucher WHERE MaDon = @MaDon
END
GO

CREATE PROC ThongKeTheoNgay
    @ngaybatdau DATE,
    @ngayketthuc DATE
AS
BEGIN
    SELECT
        ROW_NUMBER() OVER (ORDER BY CONVERT(DATE, NgayTao)) AS ThuTu,
        CONVERT(DATE, NgayTao) AS Ngay,
        COUNT(*) AS SoLuong,
        SUM(ThanhTien) AS DoanhThu
    FROM
        DonBan
    WHERE
        NgayTao >= @ngaybatdau
        AND NgayTao <= @ngayketthuc
    GROUP BY
        CONVERT(DATE, NgayTao)
END
GO

CREATE PROC proc_FindDonBanByMaKH
@MaKH int
AS
BEGIN
	select MaDon,NgayTao,d.MaKH,MaNV,MaVoucher,TrangThai,TongGT,ChietKhau,VAT,ThanhTien,HoTen from DonBan d JOIN KhachHang k ON d.MaKH = k.MaKH
	WHere d.MaKH = @maKH
END
GO

CREATE PROC proc_findAllDonBan
AS
BEGIN
	select MaDon,NgayTao,d.MaKH,MaNV,MaVoucher,TrangThai,TongGT,ChietKhau,VAT,ThanhTien,HoTen from DonBan d JOIN KhachHang k ON d.MaKH = k.MaKH
END
GO

CREATE PROC proc_FindDonBanByNgay
@NgayBatDau date,
@NgayKetThuc date,
@TrangThai nvarchar(50)
AS
BEGIN
	select MaDon,NgayTao,d.MaKH,MaNV,MaVoucher,TrangThai,TongGT,ChietKhau,VAT,ThanhTien,HoTen from DonBan d JOIN KhachHang k ON d.MaKH = k.MaKH
	WHERE NgayTao>= @NgayBatDau AND NgayTao<=@NgayKetThuc AND (TrangThai = @TrangThai or @TrangThai = '')
END
GO

CREATE proc proc_findKHByTen
@TenKH nvarchar(50)
AS
BEGIN
	SELECT MaKH,HoTen,SDT,DiaChi,c.MaCapBac,TenCapBac FROM KhachHang k JOIN CapBac c On k.MaCapBac = c.MaCapBac
	WHERE HoTen LIKE '%' + @TenKH + '%'
END
GO

CREATE PROC proc_findCTDonByMaDonBan
@MaDon int
AS
BEGIN
	SELECT MaChiTiet,MaDon,c.MaHang,c.SoLuong,ThanhTien, TenHang from CTDonBan c JOIN MatHang m ON c.MaHang = m.MaHang
	WHERE MaDon = @MaDon
END
GO

CREATE FUNCTION func_findCapBacByMaKH(@MaKH int)
RETURNS nvarchar(50)
AS
BEGIN
	DECLARE @CapBac nvarchar(50)
	SET @CapBac = (Select TenCapBac from KH_CapBac_UuDai WHERE MaKH = @MaKH)
	return @CapBac
END
GO

CREATE PROC proc_findKHByMa
@MaKH int
AS
BEGIN
	select MaKH,HoTen,SDT,DiaChi,TenCapBac,k.MaCapBac from KhachHang k JOIN CapBac c on k.MaCapBac = c.MaCapBac
	WHERE MaKH = @MaKH
END
GO

CREATE PROC proc_ThanhToanDonBan
@MaDon int
AS
BEGIN
	UPDATE DonBan SET TrangThai = N'Đã thanh toán' WHERE MaDon = @MaDon	
END
GO

--them tai khoan
create proc proc_ThemTK
@MaNV int,
@TenDangNhap nvarchar(20),
@MatKhau nvarchar(32)
AS
BEGin
	insert into TaiKhoan(MaNV,TenDangNhap,MatKhau) 
	VALUES (@MaNV,@TenDangNhap,@MatKhau)
END
GO

CREATE FUNCTION GetMaNV()
RETURNS int
AS
BEGIN
    DECLARE @MaNV INT;
    SELECT @MaNV = MAX(MaNV) FROM NhanVien;
    RETURN @MaNV;
END
GO

CREATE PROC proc_selectAllKH
AS
BEGIN
	SELECT MaKH,HoTen,SDT,DiaChi,c.MaCapBac,TenCapBac FROM KhachHang k JOIN CapBac c On k.MaCapBac = c.MaCapBac
END
GO

CREATE PROC proc_xoaHang
@MaHang int
AS
BEGIN
	DELETE MatHang WHERE MaHang = @MaHang
END
GO

CREATE PROC procXoaTK
@MaNV int
AS
BEGIN
	DELETE TaiKhoan WHERE MaNV = @MaNV
END
GO
create proc proc_themNCC
@TenNCC nvarchar(50),
@DiaChi nvarchar(50),
@SDT nvarchar(20),
@Email nvarchar(50)
AS
BEGin
	insert into NhaCungCap(TenNCC,DiaChi,SDT,Email) 
	VALUES (@TenNCC,@DiaChi,@SDT,@Email)
END
GO

create proc proc_UpdateNCC
@MaNCC int,
@TenNCC nvarchar(50),
@DiaChi nvarchar(50),
@SDT nvarchar(20),
@Email nvarchar(50)
AS
BEGin
	UPDATE NhaCungCap SET
		TenNCC = @TenNCC,
		DiaChi = @DiaChi,
		SDT = @SDT,
		Email = @Email
	WHERE MaNCC = @MaNCC
END
GO

create proc proc_DeleteNCC
@MaNCC int
AS
BEGin
	UPDATE NhaCungCap SET TrangThai = 0
	WHERE MaNCC = @MaNCC
END
GO

CREATE proc proc_ThemLoai
@TenLoai nvarchar(50)
AS
BEGin
	INSERT INTO LoaiHang(TenLoai) Values (@TenLoai)
END
GO
CREATE proc proc_CapQuyenQL
@MaNV int
AS
BEGin
	UPDATE NhanVien SET ChucVu = N'Quản lí'
	WHERE MaNV = @MaNV
END
GO

CREATE proc proc_XoaQuyenQL
@MaNV int
AS
BEGin
	UPDATE NhanVien SET ChucVu = N'Nhân viên bán hàng'
	WHERE MaNV = @MaNV
END
GO






