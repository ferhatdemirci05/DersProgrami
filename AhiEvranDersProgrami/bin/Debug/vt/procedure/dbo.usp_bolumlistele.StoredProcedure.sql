USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_bolumlistele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_bolumlistele]
as
select tbl_B.B_KAdi,tbl_B.B_Kodu,tbl_B.B_Adi from tbl_B


GO
