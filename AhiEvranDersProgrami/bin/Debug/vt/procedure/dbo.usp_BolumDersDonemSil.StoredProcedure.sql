USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_BolumDersDonemSil]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_BolumDersDonemSil]
(
@Kod int
)
as
delete from tbl_BDDnm where tbl_BDDnm.BDDnm_Kodu=@Kod

GO
