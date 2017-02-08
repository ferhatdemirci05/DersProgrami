USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_ogretimelemanibilgileri]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ogretimelemanibilgileri]
(
@kod smallint
)as
select tbl_OE.OE_KAdi, tbl_OE.OE_Adi,tbl_OE.OE_Soyadi,tbl_OE.OE_Unvan,tbl_OE.OE_DTarihi,tbl_OE.OE_STel,tbl_OE.OE_CTel,tbl_OE.OE_Mail,tbl_OE.OE_Maas 
from tbl_OE where tbl_OE.OE_Kodu=@kod

GO
