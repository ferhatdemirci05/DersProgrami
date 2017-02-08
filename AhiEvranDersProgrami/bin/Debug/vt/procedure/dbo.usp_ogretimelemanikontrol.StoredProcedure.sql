USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_ogretimelemanikontrol]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_ogretimelemanikontrol]
(
@adi nvarchar(50),
@unvan nvarchar(50),
@sonuc bit output
)as

if exists (select tbl_OE.OE_Kodu from tbl_OE where tbl_OE.OE_Unvan = (select tbl_U.U_Kodu from tbl_U where tbl_U.U_Adi=@unvan) and tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi=@adi )
begin
set @sonuc=1
return @sonuc
end
else
begin
set @sonuc=0
return @sonuc
end

GO
