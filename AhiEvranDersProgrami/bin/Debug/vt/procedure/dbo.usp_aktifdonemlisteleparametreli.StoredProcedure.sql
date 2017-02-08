USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_aktifdonemlisteleparametreli]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_aktifdonemlisteleparametreli]
(
@sinif char(1),
@sube nvarchar(3),
@donemi nvarchar(10),
@sinifid smallint,
@donemid smallint,
@subeid smallint 
)
as
if (@sube!='')
begin
set @subeid=(select tbl_Sb.Sb_Kodu from tbl_Sb where tbl_Sb.Sb_Adi=@sube)
select tbl_Dnm.Dnm_Kodu, tbl_Sf.Sf_Adi+'. Sınıf'as Sinif,tbl_Sb.Sb_Adi,tbl_Dm.Dm_Adi
from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu 
inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu
inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu
where tbl_Dnm.Sb_Kodu=@subeid
order by tbl_Dnm.Sf_Kodu asc,tbl_Sb.Sb_Kodu asc,tbl_Dm.Dm_Adi desc
end
else if (@sinif!='')
begin
set @sinifid =(select tbl_Sf.Sf_Kodu from tbl_Sf where tbl_Sf.Sf_Adi=@sinif)
select tbl_Dnm.Dnm_Kodu, tbl_Sf.Sf_Adi+'. Sınıf'as Sinif,tbl_Sb.Sb_Adi,tbl_Dm.Dm_Adi
from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu 
inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu
inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu
where tbl_Dnm.Sf_Kodu=@sinifid
order by tbl_Dnm.Sf_Kodu asc,tbl_Sb.Sb_Kodu asc,tbl_Dm.Dm_Adi desc
end
else if (@donemi!='')
begin
set @donemid =(select tbl_Dm.Dm_Kodu from tbl_Dm where tbl_Dm.Dm_Adi=@donemi)
select tbl_Dnm.Dnm_Kodu, tbl_Sf.Sf_Adi+'. Sınıf'as Sinif,tbl_Sb.Sb_Adi,tbl_Dm.Dm_Adi
from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu 
inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu
inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu
where tbl_Dnm.Dn_Kodu=@donemid
order by tbl_Dnm.Sf_Kodu asc,tbl_Sb.Sb_Kodu asc,tbl_Dm.Dm_Adi desc
end

GO
