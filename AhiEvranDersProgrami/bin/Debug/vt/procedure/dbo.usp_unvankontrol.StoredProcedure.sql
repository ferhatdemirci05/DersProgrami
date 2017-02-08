USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_unvankontrol]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_unvankontrol]
(
@unvan nvarchar(50),
@sonuc bit output
)
as
if exists (select tbl_U.U_Kodu from tbl_U where tbl_U.U_Adi=@unvan)
	begin
		set @sonuc=1
		return @sonuc
	end
else
	begin
		set @sonuc=0
		return @sonuc
	end

GO
