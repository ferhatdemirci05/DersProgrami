USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_bolumekle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_bolumekle]
(
@kodu smallint,
@kadi nvarchar(15),
@adi nvarchar(75),
@baskani int
)as
insert into tbl_B(B_Adi,B_KAdi,B_Kodu,B_Baskani)values(@adi,@kadi,@kodu,@baskani)

GO
