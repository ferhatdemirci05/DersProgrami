USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_GunveSaateGoreDersListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GunveSaateGoreDersListele]
(
@BolumKodu smallint,
@SinifKodu smallint,
@SubeKodu smallint,
@Donemi smallint
)
as
select tbl_D.D_Adi,tbl_D.D_Kodu from 
tbl_BDDnm inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu
inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu 
where tbl_Dnm.Sb_Kodu=@SubeKodu and tbl_Dnm.Sf_Kodu=@SinifKodu and tbl_Dnm.Dn_Kodu=@Donemi and tbl_BDDnm.B_Kodu=@BolumKodu
GO
