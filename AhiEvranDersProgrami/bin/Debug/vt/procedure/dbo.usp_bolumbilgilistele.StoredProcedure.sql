USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_bolumbilgilistele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_bolumbilgilistele]
(
@kod smallint
)as
select tbl_B.B_KAdi,tbl_B.B_Adi,B_Baskani from tbl_B where tbl_B.B_Kodu=@kod

GO
