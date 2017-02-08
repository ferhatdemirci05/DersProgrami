USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_Donemkontrolet]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_Donemkontrolet]
(
@donemi smallint,
@sinif smallint,
@sube smallint,
@Sonuc bit output
)
as
if exists (select tbl_Dnm.Dn_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@donemi and tbl_Dnm.Sb_Kodu=@sube and tbl_Dnm.Sf_Kodu=@sinif)
begin
 set @Sonuc=1
 return @Sonuc
end
else
begin
 set @Sonuc=0
 return @Sonuc
end

GO
