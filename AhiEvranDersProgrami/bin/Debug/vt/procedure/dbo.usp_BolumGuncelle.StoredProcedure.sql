USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_BolumGuncelle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_BolumGuncelle]
(
@adi nvarchar(75),
@kadi nvarchar(15),
@baskani int,
@kodu smallint
)
as
update tbl_B set B_Adi=@adi,B_Baskani=@baskani,B_KAdi=@kadi where B_Kodu=@kodu
GO
