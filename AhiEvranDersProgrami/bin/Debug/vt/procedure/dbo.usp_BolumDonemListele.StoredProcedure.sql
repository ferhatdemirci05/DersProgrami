USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_BolumDonemListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_BolumDonemListele]
(
@kod smallint
)
as
select tbl_Sf.Sf_Adi as Sinif,tbl_Sb.Sb_Adi as Sube,tbl_Dm.Dm_Adi as Donem
from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu 
inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu
inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu
where tbl_Dnm.Dnm_Kodu=@kod

GO
