USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_ogretimelemanilistele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ogretimelemanilistele]
as
select tbl_OE.OE_Kodu as kodu, (tbl_U.U_Adi+' '+tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi) as "OE" from tbl_U,tbl_OE where tbl_OE.OE_Unvan=tbl_U.U_Kodu

GO
