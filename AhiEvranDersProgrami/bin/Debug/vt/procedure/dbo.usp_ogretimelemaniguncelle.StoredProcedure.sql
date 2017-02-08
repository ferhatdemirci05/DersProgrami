USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_ogretimelemaniguncelle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ogretimelemaniguncelle]
(
@kodu smallint,
@kadi nvarchar(15),
@adi nvarchar(50),
@soyadi nvarchar(50),
@unvan smallint,
@dtarih date,
@stel nchar(15),
@ctel nchar(15),
@mail nvarchar(50),
@maas smallint
)as
update tbl_OE set OE_Adi=@adi, OE_CTel=@ctel,OE_DTarihi=@dtarih, OE_KAdi=@kadi,OE_Maas=@maas,OE_Mail=@mail,OE_Soyadi=@soyadi,OE_STel=@stel,OE_Unvan=@unvan
where OE_Kodu=@kodu


GO
