USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_UnvanListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_UnvanListele]
as
select tbl_U.U_Kodu,tbl_U.U_Adi from tbl_U

GO
