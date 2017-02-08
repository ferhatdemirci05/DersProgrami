USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_BölümdenSinifListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_BölümdenSinifListele]
(
@Bolum smallint
)
as
Select distinct tbl_Sf.Sf_Adi,tbl_Sf.Sf_Kodu from tbl_Sf inner join tbl_Dnm on tbl_Sf.Sf_Kodu=tbl_Dnm.Sf_Kodu
inner join tbl_BDDnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu
where  tbl_BDDnm.B_Kodu=@Bolum 
GO
