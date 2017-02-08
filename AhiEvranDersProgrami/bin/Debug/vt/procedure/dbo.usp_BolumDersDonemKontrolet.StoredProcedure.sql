USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_BolumDersDonemKontrolet]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_BolumDersDonemKontrolet]
(
@bolum smallint,
@ders int,
@donem smallint,
@oe int,
@Sonuc bit output
)
as
if exists(select tbl_BDDnm.BDDnm_Kodu from tbl_BDDnm 
			where tbl_BDDnm.B_Kodu=@bolum and tbl_BDDnm.D_Kodu=@ders and 
			tbl_BDDnm.Dnm_Kodu=@donem and tbl_BDDnm.OE_Kodu=@oe)
	begin
		set @Sonuc=1 
		return @sonuc
	end
else
		begin
		set @Sonuc=0
		return @sonuc
	end

GO
