USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_GunListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_GunListele]
as
select tbl_G.G_Adi,tbl_G.G_Kodu from tbl_G
GO
