alter TABLE dbo.Chuyen ADD NgayKhoiHanh DATE

-- Quản lý tuyến
alter PROC sp_FillTuyenXe
@ID int
AS
BEGIN
	SELECT ID_Tuyen,KhoangCach,ThoiGianChay,(SELECT t1.TenTram FROM dbo.Tram t1 WHERE t1.ID_Tram = Tram_ID_Tram1) AS TenTram1,(SELECT t2.TenTram FROM dbo.Tram t2 WHERE t2.ID_Tram = Tram_ID_Tram) AS TenTram2  FROM dbo.Tuyen WHERE Tram_ID_Tram1 = @ID
END
GO
alter PROC sp_FindKMByTuyen
@ID INT
AS
BEGIN
	SELECT KhoangCach FROM dbo.Tuyen WHERE ID_Tuyen = @ID
END
GO
alter PROC sp_ThemTuyen
@ID INT, @KhoangCach INT, @ThoiGianChay INT, @IdTram1 INT, @IdTram2 INT
AS
BEGIN
	INSERT INTO dbo.Tuyen
	        ( ID_Tuyen ,
	          KhoangCach ,
	          ThoiGianChay ,
	          Tram_ID_Tram1 ,
	          Tram_ID_Tram
	        )
	VALUES  ( @ID , -- ID_Tuyen - int
	          @KhoangCach , -- KhoangCach - int
	          @ThoiGianChay , -- ThoiGianChay - int
	          @IdTram1 , -- Tram_ID_Tram1 - int
	          @IdTram2  -- Tram_ID_Tram - int
	        )
END
GO
alter PROC sp_FillIDTuyen
AS
BEGIN
	SELECT * FROM dbo.Tuyen
END
GO
alter PROC sp_FillCbbTramDen
@ID int
AS
	SELECT * FROM tram WHERE ID_Tram NOT IN (SELECT Tram_ID_Tram FROM dbo.Tuyen WHERE Tram_ID_Tram1 = @ID) AND ID_Tram != @ID
GO
alter  PROC sp_FillCbbTramDenVe
@ID int
AS
	SELECT * FROM tram WHERE ID_Tram IN (SELECT Tram_ID_Tram FROM dbo.Tuyen WHERE Tram_ID_Tram1 = @ID) AND ID_Tram != @ID
GO
select * from tram
alter PROC sp_FillCbbTramCuaTuyen
AS
BEGIN
	SELECT DISTINCT (SELECT t.TenTram FROM dbo.Tram t WHERE t.ID_Tram = Tram_ID_Tram1) AS TenTram FROM dbo.Tuyen
END
GO
alter PROC sp_DeleteTuyen
@ID INT
AS
BEGIN
	UPDATE dbo.Ve SET KhachHang_ID_KhachHang = NULL WHERE Chuyen_ID_Chuyen = (SELECT ID_Chuyen FROM dbo.Chuyen WHERE Tuyen_ID_Tuyen = @ID)
	DELETE dbo.Ve WHERE Chuyen_ID_Chuyen = (SELECT ID_Chuyen FROM dbo.Chuyen WHERE Tuyen_ID_Tuyen = @ID)
	DELETE dbo.Chuyen WHERE Tuyen_ID_Tuyen = @ID
	DELETE dbo.Tuyen WHERE ID_Tuyen = @ID
END
GO
alter PROC sp_UpdateTuyen
@ID INT, @KhoangCach INT, @ThoiGianChay INT, @IdTram1 INT, @IdTram2 INT
AS
BEGIN
	UPDATE dbo.Tuyen SET
	          KhoangCach = @KhoangCach,
	          ThoiGianChay = @ThoiGianChay,
	          Tram_ID_Tram1 =@IdTram1,
	          Tram_ID_Tram = @IdTram2
			  WHERE ID_Tuyen = @ID
END
GO
alter PROC sp_UpdateTuyenNotTram2
@ID INT, @KhoangCach INT, @ThoiGianChay INT, @IdTram1 INT
AS
BEGIN
	UPDATE dbo.Tuyen SET
	          KhoangCach = @KhoangCach,
	          ThoiGianChay = @ThoiGianChay,
	          Tram_ID_Tram1 =@IdTram1
			  WHERE ID_Tuyen = @ID
END
GO
alter PROC sp_FindTuyenByTram
@ID1 INT , @ID2 INT
AS
BEGIN
	SELECT ID_Tuyen FROM dbo.Tuyen WHERE Tram_ID_Tram1 = @ID1 AND Tram_ID_Tram = @ID2
END
GO
alter PROC sp_DeleteTuyenByMaTram
@MaTram INT
AS
BEGIN
	DELETE dbo.Tuyen WHERE Tram_ID_Tram1 = @MaTram OR Tram_ID_Tram = @MaTram
END
GO
alter proc sp_FillReportTuyenTrongChuyen
@MaTuyen int, @Thang int
as
begin
	SELECT ID_Chuyen,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram1 FROM dbo.Tuyen t WHERE t.ID_Tuyen = Tuyen_ID_Tuyen)) AS TemTramDi,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram FROM dbo.Tuyen t WHERE t.ID_Tuyen = Tuyen_ID_Tuyen)) AS TenTramDen,
	NgayKhoiHanh,
	GioKhoiHanh,
	(SELECT x.TenXe FROM xe x WHERE x.XeID = Xe_XeID) AS TenXe,
	(SELECT TenTaiXe FROM dbo.TaiXe WHERE ID_TaiXe = Tai_xe_ID_TaiXe) AS TenTaiXe,
	TinhTrang,
	Ghi_Chu
	FROM dbo.Chuyen where Tuyen_ID_Tuyen = @MaTuyen and MONTH(NgayKhoiHanh) = @Thang
	
end
go
select 	* from Chuyen
-- Quản lý trạm
alter PROC sp_FillTram
AS
BEGIN
	SELECT * FROM dbo.Tram
END
GO
alter PROC sp_ThemTram
@ID INT,@TenTram NVARCHAR(255),@DiaDanh NVARCHAR(255)
AS
BEGIN
	INSERT INTO dbo.Tram
	        ( ID_Tram, TenTram, Dia_Danh )
	VALUES	 (@ID, -- ID_Tram - int
	          @TenTram, -- TenTram - nvarchar(400)
	          @DiaDanh  -- Dia_Danh - varchar(400)
	          )
END
GO
alter PROC sp_XoaTram
@ID INT
AS
BEGIN
	UPDATE dbo.Ve SET KhachHang_ID_KhachHang = NULL WHERE Chuyen_ID_Chuyen = (SELECT ID_Chuyen FROM dbo.Chuyen WHERE Tuyen_ID_Tuyen = (SELECT ID_Tuyen FROM dbo.Tuyen WHERE Tram_ID_Tram = @ID))
	DELETE dbo.Ve WHERE Chuyen_ID_Chuyen = (SELECT ID_Chuyen FROM dbo.Chuyen WHERE Tuyen_ID_Tuyen = (SELECT ID_Tuyen FROM dbo.Tuyen WHERE Tram_ID_Tram = @ID))
	DELETE dbo.Chuyen WHERE Tuyen_ID_Tuyen = (SELECT ID_Tuyen FROM dbo.Tuyen WHERE Tram_ID_Tram = @ID)
	DELETE dbo.Tuyen WHERE Tram_ID_Tram = @ID
	DELETE dbo.Tram WHERE ID_Tram = @ID
END
GO
alter PROC sp_SuaTram
@ID INT,@TenTram NVARCHAR(255),@DiaDanh NVARCHAR(255)
AS
BEGIN
	UPDATE dbo.Tram SET TenTram = @TenTram, Dia_Danh = @DiaDanh WHERE ID_Tram = @ID
END
GO
alter PROC sp_FillCBB_Tram
AS
BEGIN
	SELECT TenTram FROM dbo.Tram
END
GO 
alter PROC sp_Find_IDTramByName
@TenTram NVARCHAR(255)
AS
BEGIN
	SELECT ID_Tram FROM dbo.Tram WHERE TenTram = @TenTram
END
GO
select * from chuyen
select * from tuyen
select * from tram
--Loai Xe
alter PROC sp_FillCBBLoaiXe
AS
BEGIN
	SELECT * FROM dbo.LoaiXe
END
GO
-- Xe
alter PROC sp_FillXe
@IdLoai int
AS
BEGIN
	SELECT XeID,TenXe,So_dang_ky,(SELECT TenLoai FROM dbo.LoaiXe LX WHERE LX.ID_LoaiXe = LoaiXe_ID_LoaiXe) AS TenLoai FROM dbo.Xe WHERE LoaiXe_ID_LoaiXe = @IdLoai
END
GO
alter PROC sp_FillAllXe
AS
	SELECT * FROM dbo.Xe
GO 
alter PROC sp_ThemXe
@ID INT, @TenXe NVARCHAR(100), @SoDangKy VARCHAR(20),@IDLoai int
AS
BEGIN
INSERT INTO dbo.Xe
        ( XeID ,
          TenXe ,
          So_dang_ky ,
          LoaiXe_ID_LoaiXe
        )
VALUES  ( @ID , -- XeID - int
          @TenXe , -- TenXe - nvarchar(400)
          @SoDangKy, -- So_dang_ky - nvarchar(400)
          @IDLoai  -- LoaiXe_ID_LoaiXe - int
        )
END
GO
alter PROC sp_FindIDByTenXe
@TenLoai NVARCHAR(100)
AS
BEGIN
	SELECT ID_LoaiXe FROM dbo.LoaiXe WHERE TenLoai= @TenLoai
END
GO
alter PROC sp_XoaXe
@ID INT
AS
BEGIN
	UPDATE dbo.Chuyen SET Xe_XeID = NULL WHERE Xe_XeID = @ID
	DELETE dbo.Ghe WHERE Xe_XeId = @ID
	DELETE xe WHERE XeID = @ID
END
GO
alter PROC sp_SuaXe
@ID INT, @TenXe NVARCHAR(100), @SoDangKy VARCHAR(20)
AS
BEGIN
 UPDATE dbo.Xe SET 
          TenXe = @TenXe,
          So_dang_ky =@SoDangKy
		  WHERE XeID = @ID
END
GO
--Ghe
alter proc sp_FillAllGhe
as
begin
	select ID_Ghe from Ghe
end
go
alter PROC InsertGhe
@IDGhe int,@Dong INT, @Cot INT, @Tang INT, @SoGhe INT, @IdXe INT
AS
BEGIN
	INSERT INTO dbo.Ghe
	        (
			ID_Ghe,
	          Dong ,
	          Cot ,
	          Tang ,
	          So_Ghe ,
	          Xe_XeId
	        )
	VALUES  ( @IDGhe,
	          @Dong , -- Dong - int
	          @Cot , -- Cot - int
	          @Tang , -- Tang - int
	          @SoGhe , -- So_Ghe - int
	          @IdXe  -- Xe_XeId - int
	        )
END
GO
alter PROC sp_XoaGhe
@ID INT 
AS
BEGIN
	DELETE dbo.Ghe WHERE Xe_XeId = @ID
END
GO
alter PROC sp_FillDgvGhe
@ID int
AS
BEGIN
	SELECT ID_Ghe,Dong,Cot,Tang,So_Ghe,(SELECT x.TenXe FROM dbo.Xe x WHERE x.XeID = Xe_XeId) AS TenXe  FROM dbo.Ghe WHERE Xe_XeId = @ID
END
GO
alter PROC sp_FillCbbTenXe
@IDLoai int
AS
BEGIN
	SELECT TenXe from Xe where LoaiXe_ID_LoaiXe = @IDLoai
END
GO
alter PROC sp_FindIdXeyName
@TenXe NVARCHAR(100)
AS
BEGIN
	SELECT XeID FROM xe WHERE TenXe = @TenXe
END
GO
alter PROC sp_FindGheByXe
@IDXe INT
AS
BEGIN
	SELECT * FROM ghe WHERE Xe_XeId = @IDXe
END
GO
-- Tai Xe
alter PROC sp_LoadTaiXe
AS
BEGIN
	SELECT * FROM dbo.TaiXe
END
GO
alter PROC sp_TimKiemTaiXe
@TenTaiXe NVARCHAR(100)
AS
BEGIN
	SELECT * FROM dbo.TaiXe WHERE TenTaiXe = @TenTaiXe
END
GO
alter PROC sp_ThemTaiXe
@ID INT, @TenTaiXe NVARCHAR(100), @BangLai NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.TaiXe
	        ( ID_TaiXe, TenTaiXe, BangLai )
	VALUES  ( @ID, -- ID_TaiXe - int
	          @TenTaiXe, -- TenTaiXe - nvarchar(400)
	          @BangLai  -- BangLai - varchar(400)
	          )	
END
GO
alter PROC sp_XoaTaiXe
@ID INT
AS
BEGIN
	UPDATE dbo.Chuyen SET Tai_xe_ID_TaiXe = NULL WHERE Tai_xe_ID_TaiXe = @ID
	DELETE dbo.TaiXe WHERE ID_TaiXe = @ID
END
GO
alter PROC sp_SuaTaiXe
@ID INT, @TenTaiXe NVARCHAR(100), @BangLai NVARCHAR(100)
AS
BEGIN
	UPDATE  dbo.TaiXe
	        SET  TenTaiXe = TenTaiXe, BangLai =@BangLai WHERE ID_TaiXe = @ID
END
GO
-- Chuyến
alter PROC sp_FillDgvChuyen
AS
BEGIN
	SELECT ID_Chuyen,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram1 FROM dbo.Tuyen t WHERE t.ID_Tuyen = Tuyen_ID_Tuyen)) AS TramDi,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram FROM dbo.Tuyen t WHERE t.ID_Tuyen = Tuyen_ID_Tuyen)) AS TramDen,
	NgayKhoiHanh,
	GioKhoiHanh,
	(SELECT x.TenXe FROM xe x WHERE x.XeID = Xe_XeID) AS TenXe,
	(SELECT TenTaiXe FROM dbo.TaiXe WHERE ID_TaiXe = Tai_xe_ID_TaiXe) AS TenTaiXe,
	TinhTrang,
	Ghi_Chu
	FROM dbo.Chuyen
END
GO
alter table Chuyen add TinhTrang nvarchar(30)
GO
alter PROC sp_ThemChuyen
@ID INT, @IdTuyen INT,@NgayKhoiHanh date, @GioKhoiHanh VARCHAR(10),@GhiChu NVARCHAR(255),@IdXe INT, @IDTaiXe INT
AS
BEGIN
	INSERT INTO dbo.Chuyen
	        ( ID_Chuyen ,
	          Tuyen_ID_Tuyen ,
			  NgayKhoiHanh,
	          GioKhoiHanh ,
	          Ghi_Chu ,
	          Xe_XeID ,
	          Tai_xe_ID_TaiXe ,
	          TinhTrang
	        )
	VALUES  ( @ID , -- ID_Chuyen - int
	          @IdTuyen , -- Tuyen_ID_Tuyen - int
			  @NgayKhoiHanh,
	          @GioKhoiHanh , -- GioKhoiHanh - date
	          @GhiChu , -- Ghi_Chu - nvarchar(4000)
	          @IdXe , -- Xe_XeID - int
	          @IDTaiXe , -- Tai_xe_ID_TaiXe - int
	          N'Đỗ bến' -- TinhTrang - nvarchar(30)
	        )
END
GO 
alter PROC sp_XoaChuyen
@ID INT
AS
BEGIN
	UPDATE dbo.Ve SET KhachHang_ID_KhachHang = NULL WHERE Chuyen_ID_Chuyen = @ID
	DELETE dbo.Ve WHERE Chuyen_ID_Chuyen = @ID
	DELETE dbo.Chuyen WHERE ID_Chuyen = @ID
END
GO
alter PROC sp_UpdateChuyen
@ID INT, @IdTuyen INT,@NgayKhoiHanh DATE, @GioKhoiHanh VARCHAR(10),@GhiChu NVARCHAR(255),@IdXe INT, @IDTaiXe INT
AS
BEGIN
	UPDATE dbo.Chuyen SET 
	          Tuyen_ID_Tuyen = @IdTuyen,
			  NgayKhoiHanh = @NgayKhoiHanh,
	          GioKhoiHanh = @GioKhoiHanh,
	          Ghi_Chu  = @GhiChu,
	          Xe_XeID = @IdXe,
	          Tai_xe_ID_TaiXe = @IDTaiXe
			  WHERE ID_Chuyen = @ID
END
GO 
alter PROC sp_FindIdChuyen
@IdTuyen int, @gioKhoiHanh VARCHAR(10),@NgayKhoiHanh DATE
AS
BEGIN
	SELECT ID_Chuyen FROM dbo.Chuyen WHERE Tuyen_ID_Tuyen = @IdTuyen AND GioKhoiHanh =@gioKhoiHanh AND NgayKhoiHanh = @NgayKhoiHanh
END
GO
alter PROC sp_FillTramDiVe
AS
BEGIN
	SELECT TenTram FROM tram WHERE ID_Tram in (SELECT t.Tram_ID_Tram1 FROM dbo.Tuyen t WHERE t.ID_Tuyen in (SELECT Tuyen_ID_Tuyen FROM dbo.Chuyen WHERE ID_Chuyen in (SELECT DISTINCT Chuyen_ID_Chuyen FROM ve)))
END
GO
alter PROC sp_XoaChuyenByMaTuyen
@MaTuyen INT
AS
BEGIN
	DELETE dbo.Chuyen WHERE Tuyen_ID_Tuyen = @MaTuyen
END
GO
create function f_DemSoLuongVeChuyen(@MaChuyen int)
returns int
as
begin
	return (select count(*) from Ve where Chuyen_ID_Chuyen = @MaChuyen)
end
go
create function f_DemSoLuongVeDaBanChuyen(@MaChuyen int)
returns int
as
begin
	return (select count(*) from Ve where Chuyen_ID_Chuyen = @MaChuyen and TinhTrang = N'Đã thanh toán')
end
go
create function f_DoanhThuChuyen(@MaChuyen int)
returns int
as
begin
	return (select SUM(GiaTien) from Ve  where Chuyen_ID_Chuyen = @MaChuyen  and TinhTrang = N'Đã thanh toán')
end
go
create proc sp_FillReportChuyenTrongVe
 @Thang int
as
begin
	  Select ID_Chuyen,
	  dbo.f_DemSoLuongVeChuyen(ID_Chuyen) as SoLuong,
	  (CAST(dbo.f_DemSoLuongVeDaBanChuyen(ID_Chuyen) AS float) / CAST(dbo.f_DemSoLuongVeChuyen(ID_Chuyen) AS float))*100 as TiLeBanRa,
	  dbo.f_DoanhThuChuyen(ID_Chuyen) as DoanhThu
	  from Chuyen
	  where ID_Chuyen in (select Chuyen_ID_Chuyen from ve where MONTH(NgayXuatVe) = @Thang)
	  group by ID_Chuyen
end
go
-- Vé
alter PROC sp_DeleteVeByMaChuyen
@Machuyen INT
AS
BEGIN
END
GO
alter PROC sp_FindIdVeMax
AS
BEGIN
SELECT * FROM dbo.Ve
END
go
alter PROC  sp_ThemVe
@ID int, @IDGhe INT, @IdChuyen INT,@GiaTien INT, @NgayXuat DATETIME
AS
BEGIN
INSERT INTO dbo.Ve
        ( ID_Ve ,
          Ghe_ID_Ghe ,
          Chuyen_ID_Chuyen ,
          TinhTrang ,
          GiaTien ,
          KhachHang_ID_KhachHang ,
          NgayXuatVe ,
          GhiChu
        )
VALUES  ( @ID , -- ID_Ve - int
          @IDGhe , -- Ghe_ID_Ghe - int
          @IdChuyen , -- Chuyen_ID_Chuyen - int
          N'Chưa đặt' , -- TinhTrang - int
          @GiaTien , -- GiaTien - int
          NULL , -- KhachHang_ID_KhachHang - int
          @NgayXuat , -- NgayXuatVe - date
		  NULL -- GhiChu - nvarchar(4000)
        )
END
GO
alter PROC sp_FillDGVVe
@MaChuyen int
AS
BEGIN
	SELECT ID_Ve,
	(SELECT Tang FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe) AS Tang,
	(SELECT cot FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe) AS Cot,
	(SELECT dong FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe) AS Dong,
	(SELECT So_Ghe FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe) AS SoGhe,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram1 FROM dbo.Tuyen t WHERE t.ID_Tuyen = (SELECT Tuyen_ID_Tuyen FROM chuyen WHERE ID_Chuyen = chuyen_ID_Chuyen ))) AS TramDi,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram FROM dbo.Tuyen t WHERE t.ID_Tuyen = (SELECT Tuyen_ID_Tuyen FROM chuyen WHERE ID_Chuyen = chuyen_ID_Chuyen ))) AS TramDen,
	(SELECT TenXe FROM dbo.Xe WHERE XeID = (SELECT Xe_XeId FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe)) AS TenXe,
	(SELECT TenLoai FROM dbo.LoaiXe WHERE ID_LoaiXe = (SELECT LoaiXe_ID_LoaiXe FROM dbo.Xe WHERE XeID = (SELECT Xe_XeId FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe))) AS TenLoai,
	 TinhTrang
	 FROM dbo.Ve WHERE TinhTrang = N'Chưa đặt' and Chuyen_ID_Chuyen = @MaChuyen 
END
GO
alter proc sp_FillGioKhoiHah
@NgayKhoiHanh char(30)
as
begin
	select * from Chuyen WHERE NgayKhoiHanh = cast(@NgayKhoiHanh as date)
end
GO
create proc sp_FillNgayKhoiHanh
@IdTuyen int
as
begin
	select DISTINCT NgayKhoiHanh from Chuyen where Tuyen_ID_Tuyen = @IdTuyen
end
go
alter proc sp_ThemTempVe
@IdVe int
as
begin
	update Ve set KhachHang_ID_KhachHang = 1, TinhTrang = N'Đã đặt' where ID_Ve = @IdVe
end
go
alter proc SP_ROOLBACK
as
begin
	update Ve set KhachHang_ID_KhachHang = NULL,TinhTrang = N'Chưa đặt' where KhachHang_ID_KhachHang = 1
end
GO
alter proc SP_ROOLBACKVeDat
@IDVe int
as
begin
	update Ve set KhachHang_ID_KhachHang = NULL,TinhTrang = N'Chưa đặt' where ID_Ve = @IDVe
end
go
alter proc sp_ThemVeMoi
@IDKH int
as
begin
	update Ve set KhachHang_ID_KhachHang = @IDKH, TinhTrang = N'Đã đặt' where KhachHang_ID_KhachHang = 1
end
GO
alter proc sp_ThemVeDatLai
@IDKH INT,@IDVe int
as
begin
	update Ve set KhachHang_ID_KhachHang = @IDKH, TinhTrang = N'Đã đặt' where ID_Ve =@IDVe
end
go
alter proc sp_FindKH
@HoTen nvarchar(100), @SDT char(20)
as
begin
	select ID_KhachHang from KhachHang where HoTen = @HoTen and DienThoai = @SDT
end
go
alter proc sp_ThemKhachHang
@HoTen nvarchar(100), @SDT char(20)
as
begin
	insert into KhachHang(HoTen,DienThoai) values(@HoTen,@SDT)
end
GO
alter PROC sp_XoaVe
@IDChuyen INT
AS
BEGIN
DELETE dbo.Ve WHERE Chuyen_ID_Chuyen = @IDChuyen
END
GO
alter PROC sp_FindVeByKhachHang
@IdKH int
AS
BEGIN
	SELECT ID_Ve,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram1 FROM dbo.Tuyen t WHERE t.ID_Tuyen = (SELECT Tuyen_ID_Tuyen FROM chuyen WHERE ID_Chuyen = chuyen_ID_Chuyen ))) AS TramDi,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram FROM dbo.Tuyen t WHERE t.ID_Tuyen = (SELECT Tuyen_ID_Tuyen FROM chuyen WHERE ID_Chuyen = chuyen_ID_Chuyen ))) AS TramDen,
	(SELECT So_Ghe FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe) AS SoGhe,
	GiaTien,
	(SELECT TenXe FROM dbo.Xe WHERE XeID = (SELECT Xe_XeId FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe)) AS TenXe,
	(SELECT TenLoai FROM dbo.LoaiXe WHERE ID_LoaiXe = (SELECT LoaiXe_ID_LoaiXe FROM dbo.Xe WHERE XeID = (SELECT Xe_XeId FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe))) AS TenLoai,
	 TinhTrang,
	 GhiChu
	 FROM dbo.Ve WHERE TinhTrang = N'Đã đặt' and KhachHang_ID_KhachHang = @IdKH
END
GO
alter PROC sp_FillDGvVeDat
@MaChuyen int
AS
BEGIN
	SELECT ID_Ve,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram1 FROM dbo.Tuyen t WHERE t.ID_Tuyen = (SELECT Tuyen_ID_Tuyen FROM chuyen WHERE ID_Chuyen = chuyen_ID_Chuyen ))) AS TramDi,
	(SELECT TenTram FROM tram WHERE ID_Tram = (SELECT t.Tram_ID_Tram FROM dbo.Tuyen t WHERE t.ID_Tuyen = (SELECT Tuyen_ID_Tuyen FROM chuyen WHERE ID_Chuyen = chuyen_ID_Chuyen ))) AS TramDen,
	(SELECT So_Ghe FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe) AS SoGhe,
	GiaTien,
	(SELECT TenXe FROM dbo.Xe WHERE XeID = (SELECT Xe_XeId FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe)) AS TenXe,
	(SELECT TenLoai FROM dbo.LoaiXe WHERE ID_LoaiXe = (SELECT LoaiXe_ID_LoaiXe FROM dbo.Xe WHERE XeID = (SELECT Xe_XeId FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe))) AS TenLoai,
	 TinhTrang,
	 GhiChu
	 FROM dbo.Ve WHERE TinhTrang = N'Chưa đặt' and Chuyen_ID_Chuyen = @MaChuyen 
END
GO
alter PROC sp_DemSoLuongVe
@IdKH int
AS
BEGIN
   SELECT COUNT(*) AS SoLuongVe FROM dbo.Ve WHERE TinhTrang = N'Đã đặt' and KhachHang_ID_KhachHang = @IdKH
END
GO 
alter PROC sp_DemSoLuongVeBan
@MaChuyen int
AS
BEGIN
   SELECT COUNT(*) AS SoLuongVe FROM dbo.Ve WHERE TinhTrang = N'Chưa đặt' and Chuyen_ID_Chuyen = @MaChuyen 
END
GO 
alter PROC sp_ThanhToan
@IdKH int
AS
BEGIN
	UPDATE dbo.Ve SET TinhTrang = N'Đã thanh toán' WHERE KhachHang_ID_KhachHang = @IdKH
END
GO

alter PROC sp_FindIdChuyenByVe
@IDVe INT
AS
BEGIN
	SELECT Chuyen_ID_Chuyen FROM ve WHERE ID_Ve = @IDVe
END
GO
alter PROC sp_FillVe
@IDChuyen int
AS
BEGIN
	SELECT ID_Ve,(SELECT So_Ghe FROM dbo.Ghe WHERE ID_Ghe = Ghe_ID_Ghe) AS SoGhe,TinhTrang,GiaTien,KhachHang_ID_KhachHang,NgayXuatVe FROM dbo.Ve WHERE Chuyen_ID_Chuyen = @IDChuyen
END
GO
alter PROC sp_FillGiaTien
@IDChuyen INT
AS
BEGIN
	SELECT DISTINCT GiaTien FROM ve WHERE Chuyen_ID_Chuyen = @IDChuyen
END
GO
alter PROC sp_UpdateGiaTien
@IDChuyen INT,@giaTien int
AS
BEGIN
	UPDATE dbo.Ve SET GiaTien = @giaTien WHERE Chuyen_ID_Chuyen = @IDChuyen
END
GO
create function f_DemSoLuongVe(@MaTuyen int)
returns int
as
begin
	return (select count(*) from Ve where Chuyen_ID_Chuyen in (Select ID_Chuyen from Chuyen where Tuyen_ID_Tuyen = @MaTuyen))
end
go
create function f_DemSoLuongVeDaBan(@MaTuyen int)
returns int
as
begin
	return (select count(*) from Ve where Chuyen_ID_Chuyen in (Select ID_Chuyen from Chuyen where Tuyen_ID_Tuyen = @MaTuyen) and TinhTrang = N'Đã thanh toán')
end
go
create function f_DoanhThu(@MaTuyen int)
returns int
as
begin
	return (select SUM(GiaTien) from Ve where Chuyen_ID_Chuyen in (Select ID_Chuyen from Chuyen where Tuyen_ID_Tuyen = @MaTuyen) and TinhTrang = N'Đã thanh toán')
end
go
alter proc sp_FillReportTuyenTrongVe
 @Thang int
as
begin
	  Select ID_Tuyen ,
	  dbo.f_DemSoLuongVe(ID_Tuyen) as SoLuong,
	  (CAST(dbo.f_DemSoLuongVeDaBan(ID_Tuyen) AS float) / CAST(dbo.f_DemSoLuongVe(ID_Tuyen) AS float))*100 as TiLeBanRa,
	  dbo.f_DoanhThu(ID_Tuyen) as DoanhThu
	  from Tuyen
	  where ID_Tuyen in (Select distinct Tuyen_ID_Tuyen from Chuyen where ID_Chuyen in (select Chuyen_ID_Chuyen from ve where MONTH(NgayXuatVe) = @Thang))
	  group by ID_Tuyen
end
go
exec sp_FillReportTuyenTrongVe 12
INSERT INTO dbo.KhachHang
        ( 
          HoTen ,
          DienThoai ,
          Email ,
          Loai
        )
VALUES  ( -- ID_KhachHang - int
          N'Nguyễn Quốc Thắng' , -- HoTen - nvarchar(400)
          '01639445627' , -- DienThoai - varchar(400)
          'nkoxken65@gmail.com' , -- Email - varchar(400)
          0  -- Loai - int
        )
GO
alter TABLE Users
(
	ID INT IDENTITY PRIMARY KEY ,
	UserID VARCHAR(50),
	Password NVARCHAR(100),
	Email VARCHAR(50),
	alterDate DATE,
	Type INT
)
GO 
alter PROC sp_CheckLogin
@UserID varchar(50), @Pass nvarchar(100)
AS
BEGIN
	SELECT distinct type FROM dbo.Users WHERE UserID = @UserID AND Password =  @Pass 
END
GO
exec sp_CheckLogin 'admin',N'1' 
INSERT INTO dbo.Users 
        ( 
          UserID ,
          Password ,
          Email ,
          alterDate ,
          Type
        )
VALUES  ( 
          'admin' , -- UserID - varchar(50)
          N'1' , -- Password - nvarchar(100)
          'nkoxken65@gmail.com' , -- Email - varchar(50)
          GETDATE() , -- alterDate - date
          1  -- Type - int
        )

-- quản lý khách hàng
create proc sp_FillKhachHang
as
begin
	select * from KhachHang
end
exec sp_FillKhachHang

--Thêm Khách Hàng
alter proc Add_KhachHang
	@hoten nvarchar(400), @dienthoai varchar(11), @email varchar(400), @loai int
as 
begin
	insert into KhachHang(HoTen,DienThoai,Email,Loai) values(@hoten,@dienthoai, @email, @loai)
end

select * from KhachHang
exec Add_KhachHang  N'Nguyên Văn Quyết', '01236545111', '123haha@gmail.com', 0

--Xóa Khách Hàng
create proc Del_KhachHang
	@idKH int
as
begin
	Delete KhachHang where ID_KhachHang = @idKH
end
exec Del_KhachHang 1012

--Sửa Khách Hàng
create proc Update_KhachHang
	@idKH int, @hoten nvarchar(400), @dienthoai varchar(11), @email varchar(400), @loai int
as 
begin
	update KhachHang set HoTen = @hoten, DienThoai = @dienthoai, Email = @email, Loai = @loai where ID_KhachHang = @idKH
end
select * from KhachHang
exec Update_KhachHang 13, N'Hà Đức Tần', N'0123654123', '123mmm@gmail.com', 0

-- Users
alter TABLE Users
(
	UserID VARCHAR(50) PRIMARY KEY ,
	Password NVARCHAR(100),
	Email VARCHAR(50),
	alterDate DATE
)

GO 
create TABLE PhanQuyen
(
	PQ_UserID VARCHAR(50) PRIMARY KEY,
	RoleID INT
)
ALTER TABLE Users
ADD CONSTRAINT fk_PQ_Users
  FOREIGN KEY (UserID) 
  REFERENCES PhanQuyen (PQ_UserID);
CREATE TABLE Role
(
	ID INT IDENTITY PRIMARY KEY,
	NameRole NVARCHAR(255)
)
ALTER TABLE Role
ADD CONSTRAINT fk_PQ_Users
  FOREIGN KEY (ID) 
  REFERENCES PhanQuyen (RoleID);
  go 
alter PROC sp_CheckLogin
@UserID varchar(50), @Pass nvarchar(100)
AS
BEGIN
	SELECT COUNT(*) AS type FROM dbo.Users WHERE UserID = @UserID AND Password = @Pass 
END
GO
create PROC sp_CheckUsername
@UserID varchar(50)
AS
BEGIN
	SELECT COUNT(*) AS type FROM dbo.Users WHERE UserID = @UserID
END
GO
CREATE PROC sp_PhanQuyen
@UserID VARCHAR(50)
AS
BEGIN
	SELECT RoleID FROM dbo.PhanQuyen WHERE PQ_UserID = @UserID
END
GO
CREATE PROC FillDGvUsers
AS
BEGIN
	SELECT * FROM dbo.Users
END
GO
alter PROC AddUsers
@UserID VARCHAR(50),@Pass NVARCHAR(100), @Email VARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.Users
	        ( UserID ,
	          Password ,
	          Email ,
	          CreateDate 
	        )
	VALUES  ( @UserID , -- UserID - varchar(50)
	          @Pass, -- Password - nvarchar(100)
	          @Email , -- Email - varchar(50)
	          GETDATE()  -- CreateDate - date
	        )
END
GO
create proc AddRole
@UserID varchar(50),@ID int
as
begin
	insert into PhanQuyen(PQ_UserID,RoleID) values(@UserID,@ID)
end
go
alter PROC DeleteUsers
@UserID VARCHAR(50)
AS
BEGIN
	DELETE dbo.PhanQuyen WHERE PQ_UserID = @UserID
	DELETE dbo.Users WHERE UserID= @UserID
END
GO
alter PROC UpdateUsers
@UserID VARCHAR(50),@Pass NVARCHAR(100), @Email VARCHAR(50)
AS
BEGIN
	UPDATE dbo.Users SET Password = @Pass, Email = @Email WHERE UserID = @UserID
END
GO
alter proc FillCbbQuyen
@UserID varchar(50)
as
begin
	select RoleName from Role where ID in (select distinct RoleID from PhanQuyen where PQ_UserID = @UserID)
end
go
