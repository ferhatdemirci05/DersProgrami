USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_BolumDersDonemListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_BolumDersDonemListele]
as
Select tbl_BDDnm.BDDnm_Kodu,tbl_B.B_KAdi as Bölüm,
		(tbl_Sf.Sf_Adi+'/'+tbl_Sb.Sb_Adi+' '+tbl_Dm.Dm_Adi) as Dönem,
		tbl_D.D_Adi as Ders, (tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi) as ÖğretimElemanı
from tbl_BDDnm inner join tbl_B on tbl_BDDnm.B_Kodu=tbl_B.B_Kodu
	inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu
	inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu
	inner join tbl_OE on tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu,tbl_Dm,tbl_Sf,tbl_Sb
where tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu and tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu and tbl_Dnm.Sf_Kodu = tbl_Sf.Sf_Kodu
order by tbl_B.B_Adi asc, Dönem asc, Ders asc,ÖğretimElemanı asc

GO
