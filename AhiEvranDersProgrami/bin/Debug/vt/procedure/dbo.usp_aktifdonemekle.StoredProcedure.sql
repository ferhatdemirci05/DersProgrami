USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_aktifdonemekle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_aktifdonemekle]
(
@donemi smallint,
@sinif smallint,
@sube smallint
)
as
insert into tbl_Dnm (Dn_Kodu,Sf_Kodu,Sb_Kodu)
			values (@donemi,@sinif,@sube)

GO
