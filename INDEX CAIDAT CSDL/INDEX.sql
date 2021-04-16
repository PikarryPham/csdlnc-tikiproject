IF EXISTS(SELECT * FROM sys.indexes WHERE name = 'nonclus_nhabanhang' AND object_id = OBJECT_ID('NHABANHANG')) 
    BEGIN
       DROP INDEX nonclus_nhabanhang ON NHABANHANG
    END

CREATE NONCLUSTERED INDEX nonclus_nhabanhang ON NHABANHANG(USERNAMENBH, PASSNBH)
----------------------------------------------------------------------------------------------------------

IF EXISTS(SELECT * FROM sys.indexes WHERE name = 'nhanvien_idex' AND object_id = OBJECT_ID('nhanvien')) 
    BEGIN
       DROP INDEX nhanvien_idex ON nhanvien
    END

create nonclustered index nhanvien_idex ON nhanvien(username_nv,pass_nv) 
----------------------------------------------------------------------------------------------------------
IF EXISTS(SELECT * FROM sys.indexes WHERE name = 'DONHANG1' AND object_id = OBJECT_ID('DONHANG')) 
    BEGIN
       DROP INDEX DONHANG1 ON DONHANG
    END
create nonclustered index DONHANG1 ON DONHANG(TRANGTHAI,ID_NV,THOIGIANGIAO)
----------------------------------------------------------------------------------------------------------
IF EXISTS(SELECT * FROM sys.indexes WHERE name = 'DONHANG3' AND object_id = OBJECT_ID('DONHANG')) 
    BEGIN
       DROP INDEX DONHANG3 ON DONHANG
    END
create nonclustered index DONHANG3 ON DONHANG(TRANGTHAI,ID_NV,THOIGIANdat) include (tongcong)
----------------------------------------------------------------------------------------------------------
IF EXISTS(SELECT * FROM sys.indexes WHERE name = 'nonclus_SP' AND object_id = OBJECT_ID('SANPHAM')) 
    BEGIN
       DROP INDEX nonclus_SP ON SANPHAM
    END
CREATE NONCLUSTERED INDEX nonclus_SP ON sanpham (id_dmn,id_th) include (ten_spham,motachitiet_sp,gianiemyet,giakhuyenmai,thoigiankm,ghichuspham,hansudungsp)
----------------------------------------------------------------------------------------------------------

----------------------------------------------------------------------------------------------------------
IF EXISTS(SELECT * FROM sys.indexes WHERE name = 'nonclus_khachhang1' AND object_id = OBJECT_ID('KHACHHANG'))
    BEGIN
       DROP INDEX nonclus_khachhang1 ON KHACHHANG
    END
CREATE NONCLUSTERED INDEX nonclus_khachhang1 ON KHACHHANG(USERNAME_KH, PASS_KH)