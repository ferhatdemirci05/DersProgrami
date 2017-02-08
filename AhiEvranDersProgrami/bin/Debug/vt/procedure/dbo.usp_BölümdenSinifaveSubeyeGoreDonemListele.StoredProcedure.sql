USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_BölümdenSinifaveSubeyeGoreDonemListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_BölümdenSinifaveSubeyeGoreDonemListele]
(
@Bolum smallint,
@Sinif smallint,
@Sube smallint
)
as
Select distinct tbl_Dm.Dm_Adi,tbl_Dm.Dm_Kodu from tbl_Dm inner join tbl_Dnm on tbl_Dm.Dm_Kodu=tbl_Dnm.Dn_Kodu
inner join tbl_BDDnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu
where  tbl_BDDnm.B_Kodu=@Bolum and tbl_Dnm.Sf_Kodu=@Sinif and tbl_Dnm.Sb_Kodu=@Sube
GO
