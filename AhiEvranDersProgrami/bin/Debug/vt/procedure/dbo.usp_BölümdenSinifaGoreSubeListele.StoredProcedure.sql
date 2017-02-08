USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_BölümdenSinifaGoreSubeListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_BölümdenSinifaGoreSubeListele]
(
@Bolum smallint,
@Sinif smallint
)
as
Select distinct tbl_Sb.Sb_Adi,tbl_Sb.Sb_Kodu from tbl_Sb inner join tbl_Dnm on tbl_Sb.Sb_Kodu=tbl_Dnm.Sb_Kodu
inner join tbl_BDDnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu
where  tbl_BDDnm.B_Kodu=@Bolum and tbl_Dnm.Sf_Kodu=@Sinif
GO
