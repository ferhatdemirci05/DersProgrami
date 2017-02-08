USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_ProgramKaydet]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_ProgramKaydet]
(
@Bolum smallint,
@Sinif smallint,
@Sube smallint,
@Donem smallint,
@Gunid smallint,
@Saatid smallint,
@Derslikid smallint,
@Dersid int
)
as
declare @donemi int
declare @Bolumu int
set @donemi =(select tbl_Dnm.Dnm_Kodu from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu where tbl_Dm.Dm_Kodu=@Donem and tbl_Sb.Sb_Kodu=@Sube and tbl_Sf.Sf_Kodu=@Sinif)
set @Bolumu=(select tbl_BDDnm.BDDnm_Kodu from tbl_BDDnm inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu inner join tbl_B on tbl_BDDnm.B_Kodu=tbl_B.B_Kodu where tbl_B.B_Kodu=@Bolum and tbl_D.D_Kodu=@Dersid and tbl_Dnm.Dnm_Kodu=@donemi)
insert into tbl_DD  (G_Kodu,St_Kodu,BDDnm_Kodu,Dk_Kodu) values (@Gunid,@Saatid,@Bolumu,@Derslikid)
GO
