/*Nhân viên đăng nhập vào hệ thống*/
/*Về phía nhân viên*/
IF OBJECT_ID('USP_LOGIN_NHANVIEN','P') IS NOT NULL
	DROP PROC USP_LOGIN_NHANVIEN
GO

CREATE PROC USP_LOGIN_NHANVIEN
@USERNAMENV CHAR(20), 
@PASSNV CHAR(20)
AS
BEGIN TRANSACTION 
	BEGIN TRY
		IF NOT EXISTS (SELECT * FROM NHANVIEN AS NV WHERE NV.USERNAME_NV = @USERNAMENV)
		BEGIN
			PRINT N'Username không tồn tại';
			ROLLBACK TRANSACTION;
			RETURN;
		END
		IF NOT EXISTS (SELECT * FROM NHANVIEN AS NV WHERE NV.USERNAME_NV = @USERNAMENV AND NV.PASS_NV = @PASSNV)
		BEGIN
			PRINT N'Sai mật khẩu';
			ROLLBACK TRANSACTION;
			RETURN;
		END
	END TRY
	BEGIN CATCH
		PRINT N'Lỗi đăng nhập'
		ROLLBACK TRANSACTION;
	END CATCH
	PRINT N'Đăng nhập thành công'
COMMIT TRANSACTION

IF EXISTS (SELECT 1
            FROM sys.indexes I
                INNER JOIN sys.tables T
                    ON I.object_id = T.object_id
                INNER JOIN sys.schemas S
                    ON S.schema_id = T.schema_id
            WHERE I.Name = 'nhanvien_idex' -- Index name
                AND T.Name = 'nhanvien' -- Table name
                AND S.Name = 'dbo') --Schema Name
BEGIN
    DROP INDEX nhanvien_idex ON nhanvien

END
GO
create nonclustered index nhanvien_idex ON nhanvien(username_nv,pass_nv) 


EXEC USP_LOGIN_NHANVIEN 'bsebyer0','G2mFvCv'

SELECT * FROM NHANVIEN WHERE NHANVIEN.ID_NV = 307
/*1 LÀ ĐẶT HÀNG THÀNH CÔNG,
2 TIKI TIEP NHAN DON HANG,
6 HUY DON HANG ,
3 DANG DONG GOI,
4 LÀ ĐANG VẬN CHUYỂN
5 LÀ GIAO HÀNG THÀNH CÔNG*/
select*From DONHANG
select count(*) From DONHANG where THOIGIANDAT between '2020-03-10' and '2020-03-24'
IF OBJECT_ID('kichban3','P') IS NOT NULL
	DROP PROC kichban3
GO
create procedure kichban3
	@startdate smalldatetime,
	@id_nv int
as
	declare @dathangthanhcong int
	set @dathangthanhcong=(select count(*) from donhang where trangthai=1 and thoigiandat between @startdate and DATEADD(day,7,@startdate) and donhang.ID_NV=@id_nv)
	print concat (N'Số đơn đang chờ xác nhận :',@dathangthanhcong)
	declare @dangxuly int
	set @dangxuly=(select count(*) from donhang where  donhang.trangthai=4 or donhang.trangthai=3 or donhang.trangthai=2  and thoigiangiao between @startdate and DATEADD(DAY,7,@STARTDATE) and donhang.ID_NV=@id_nv)
	declare @huydonhang int
	print concat (N'đang xử lý :',@dangxuly)
	set @huydonhang=(select count(*) from donhang where trangthai=6 and thoigiandat between @startdate and DATEADD(day,7,@startdate) and donhang.ID_NV=@id_nv)
	PRINT CONCAT (N'Số đơn đã hủy: ',@huydonhang)
	declare @giaohangthanhcong int
	set @giaohangthanhcong=(select count(*) from donhang where trangthai=5 and thoigiangiao between @startdate and DATEADD(day,7,@startdate)and donhang.ID_NV=@id_nv)
	PRINT CONCAT(N'Đã giao thành công;',@giaohangthanhcong)
	declare @doanhthu int
	set @doanhthu=(select sum(tongcong) from donhang where donhang.TRANGTHAI=5 and thoigiangiao between @startdate and DATEADD(day,7,@startdate)and donhang.ID_NV=@id_nv)
	PRINT CONCAT(N'Doanh thu đạt được trong 7 ngày: ',@doanhthu)
go

select*from NHANVIEN


select*From DONHANG where donhang.ID_NV = 1
--update donhang set id_nv =1  where THOIGIANDAT between '2020-03-10' and '2020-03-17'
exec kichban3 '2020-03-10', 1



---CHECK INDEXES ARE EXIST
select i.[name] as index_name,
    substring(column_names, 1, len(column_names)-1) as [columns],
    case when i.[type] = 1 then 'Clustered index'
        when i.[type] = 2 then 'Nonclustered unique index'
        when i.[type] = 3 then 'XML index'
        when i.[type] = 4 then 'Spatial index'
        when i.[type] = 5 then 'Clustered columnstore index'
        when i.[type] = 6 then 'Nonclustered columnstore index'
        when i.[type] = 7 then 'Nonclustered hash index'
        end as index_type,
    case when i.is_unique = 1 then 'Unique'
        else 'Not unique' end as [unique],
    schema_name(t.schema_id) + '.' + t.[name] as table_view, 
    case when t.[type] = 'U' then 'Table'
        when t.[type] = 'V' then 'View'
        end as [object_type]
from sys.objects t
    inner join sys.indexes i
        on t.object_id = i.object_id
    cross apply (select col.[name] + ', '
                    from sys.index_columns ic
                        inner join sys.columns col
                            on ic.object_id = col.object_id
                            and ic.column_id = col.column_id
                    where ic.object_id = t.object_id
                        and ic.index_id = i.index_id
                            order by key_ordinal
                            for xml path ('') ) D (column_names)
where t.is_ms_shipped <> 1
and index_id > 0
order by i.[name]
