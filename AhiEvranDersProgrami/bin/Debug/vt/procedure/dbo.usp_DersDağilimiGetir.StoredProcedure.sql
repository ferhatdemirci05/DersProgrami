USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_DersDağilimiGetir]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_DersDağilimiGetir]
(
@Bolum smallint,
@Sinif smallint,
@Sube smallint,
@Donem smallint,
@Gun smallint,
@Saat smallint
)
as
declare @Donemi smallint
set @Donemi=(select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif)
declare @derslik smallint
declare @bosderslik nvarchar(15)
set @bosderslik=''
set @derslik=(select tbl_DD.Dk_Kodu from tbl_DD,tbl_BDDnm where tbl_DD.BDDnm_Kodu=tbl_BDDnm.BDDnm_Kodu and tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat)
if @derslik !=0
begin
select distinct tbl_OE.OE_KAdi as OE, tbl_D.D_Adi as DERS, tbl_Dk.Dk_Adi as DERSLIK 
from tbl_DD , tbl_BDDnm ,tbl_D , tbl_OE ,tbl_Dk 
where 
tbl_DD.BDDnm_Kodu=tbl_BDDnm.BDDnm_Kodu and tbl_BDDnm.D_Kodu=tbl_D.D_Kodu  and tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu and (tbl_DD.Dk_Kodu=tbl_Dk.Dk_Kodu or tbl_DD.Dk_Kodu=0) and
tbl_BDDnm.Dnm_Kodu=@Donemi and tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat
end
else
begin
select distinct tbl_OE.OE_KAdi as OE, tbl_D.D_Adi as DERS, @bosderslik as DERSLIK 
from tbl_DD , tbl_BDDnm ,tbl_D , tbl_OE
where 
tbl_DD.BDDnm_Kodu=tbl_BDDnm.BDDnm_Kodu and tbl_BDDnm.D_Kodu=tbl_D.D_Kodu  and tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu  and
tbl_BDDnm.Dnm_Kodu=@Donemi and tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat
end
GO
