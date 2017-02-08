USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_derslistele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_derslistele]

as

select tbl_D.D_Kodu as ID, (CONVERT(nvarchar,tbl_D.D_Kodu)+' - '+tbl_D.D_Adi) as Ders from tbl_D order by tbl_D.D_Adi asc

GO
