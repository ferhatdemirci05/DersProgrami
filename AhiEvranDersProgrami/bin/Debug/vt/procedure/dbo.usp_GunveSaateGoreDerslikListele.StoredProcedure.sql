USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_GunveSaateGoreDerslikListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_GunveSaateGoreDerslikListele]
(
@GunKodu smallint,
@SaatKodu smallint
)
as
select tbl_Dk.Dk_Adi,tbl_Dk.Dk_Kodu from tbl_Dk where tbl_Dk.Dk_Kodu not in(
Select tbl_DD.Dk_Kodu from tbl_DD inner join tbl_Dk on(tbl_DD.Dk_Kodu=tbl_Dk.Dk_Kodu)
 where tbl_DD.G_Kodu=@GunKodu and tbl_DD.St_Kodu=@SaatKodu)
GO
