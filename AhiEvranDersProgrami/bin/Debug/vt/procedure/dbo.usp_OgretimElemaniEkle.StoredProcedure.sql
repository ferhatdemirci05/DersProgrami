USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_OgretimElemaniEkle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_OgretimElemaniEkle]
(
@kadi nvarchar(15),
@adi nvarchar(50),
@soyadi nvarchar(50),
@unav smallint,
@dtarih date,
@stel nchar(15),
@ctel nchar(15),
@mail nvarchar(50),
@maas smallint
)as
insert into tbl_OE (OE_KAdi,OE_Adi,OE_Soyadi,OE_Unvan,OE_DTarihi,OE_STel,OE_CTel,OE_Mail,OE_Maas) values (@kadi,@adi,@soyadi,@unav,@dtarih,@stel,@ctel,@mail,@maas)

GO
