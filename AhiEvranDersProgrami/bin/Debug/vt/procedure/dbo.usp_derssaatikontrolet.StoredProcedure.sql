USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_derssaatikontrolet]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_derssaatikontrolet]
(
@Bolum smallint,
@Ders int,
@Donem smallint,
@Sinif smallint,
@Sube smallint,
@Sonuc bit output
)
as
declare @toplamsaat int
declare @DSD int
set @DSD = (select tbl_BDDnm.BDDnm_DSD from tbl_BDDnm where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.D_Kodu=@Ders and tbl_BDDnm.Dnm_Kodu=(select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif))
set @toplamsaat =(select (tbl_D.D_T+tbl_D.D_U) from tbl_D where tbl_D.D_Kodu=@Ders)
if (@DSD<@toplamsaat)
begin
set @Sonuc=1
return @Sonuc
end
else
begin
set @Sonuc=0
return @Sonuc
end

GO
