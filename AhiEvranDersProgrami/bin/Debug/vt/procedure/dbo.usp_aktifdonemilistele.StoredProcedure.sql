USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_aktifdonemilistele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_aktifdonemilistele]
as
select tbl_Dnm.Dnm_Kodu,(tbl_Sf.Sf_Adi+'/'+tbl_Sb.Sb_Adi+' Sınıfı '+tbl_Dm.Dm_Adi+' Dönemi') as Donem
from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu 
inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu
inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu
order by tbl_Dnm.Sf_Kodu asc,tbl_Sb.Sb_Kodu asc,tbl_Dm.Dm_Adi desc

GO
