USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_BolumDersDonemEkle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_BolumDersDonemEkle]
(
@bolum smallint,
@ders int,
@donem smallint,
@oe int
)
as
if exists (select tbl_BDDnm.BDDnm_Kodu from tbl_BDDnm where tbl_BDDnm.B_Kodu=@bolum and tbl_BDDnm.Dnm_Kodu=@donem and tbl_BDDnm.D_Kodu=@ders)
	begin
		update tbl_BDDnm set tbl_BDDnm.OE_Kodu=@oe where tbl_BDDnm.B_Kodu=@bolum and tbl_BDDnm.Dnm_Kodu=@donem and tbl_BDDnm.D_Kodu=@ders
	end
else
	begin
		insert into tbl_BDDnm (B_Kodu,D_Kodu,Dnm_Kodu,OE_Kodu)
			values (@bolum,@ders,@donem,@oe)
	end


GO
