USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_SaatListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_SaatListele]
as
Select tbl_St.St_Araligi,tbl_St.St_Kodu from tbl_St
GO
