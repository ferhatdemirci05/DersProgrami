USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_derskontrolet]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_derskontrolet]
(
@kod int,
@Sonuc bit output
)
as
if exists (select tbl_D.D_Adi from tbl_D where tbl_D.D_Kodu=@kod)
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
