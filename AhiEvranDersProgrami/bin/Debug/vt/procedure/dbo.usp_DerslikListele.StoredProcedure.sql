USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_DerslikListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_DerslikListele]
as
select tbl_Dk.Dk_Adi,tbl_Dk.Dk_Kodu from tbl_Dk
GO
