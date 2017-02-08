USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_derssaatiazalt]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_derssaatiazalt]
(
@Bolum smallint,
@Ders int,
@Donem smallint,
@Sinif smallint,
@Sube smallint
)
as
declare @Donemi int
set @Donemi=( select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif)
if 0<(select tbl_BDDnm.BDDnm_DSD from tbl_BDDnm where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.D_Kodu=@Ders and tbl_BDDnm.Dnm_Kodu=@Donemi)
begin
update tbl_BDDnm set BDDnm_DSD=BDDnm_DSD-1 where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.D_Kodu=@Ders and
tbl_BDDnm.Dnm_Kodu=@Donemi
end
GO
