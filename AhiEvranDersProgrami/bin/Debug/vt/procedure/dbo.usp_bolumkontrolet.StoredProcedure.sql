USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_bolumkontrolet]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_bolumkontrolet]
(@kadi nvarchar(15), @sonuc bit output)as if exists (select tbl_B.B_Kodu from tbl_B where tbl_B.B_KAdi=@kadi) begin set @sonuc=1 return @sonuc end else begin set @sonuc=0 return @sonuc end


GO
