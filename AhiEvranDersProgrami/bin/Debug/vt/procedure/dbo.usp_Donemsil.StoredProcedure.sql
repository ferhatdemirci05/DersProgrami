USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_Donemsil]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_Donemsil]
(
@DonemKodu smallint
)as
delete from tbl_Dnm where tbl_Dnm.Dnm_Kodu=@DonemKodu

GO
