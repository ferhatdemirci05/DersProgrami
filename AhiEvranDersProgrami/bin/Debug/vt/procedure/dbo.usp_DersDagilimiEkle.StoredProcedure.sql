USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_DersDagilimiEkle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_DersDagilimiEkle]
(
@Gun smallint,
@Saat smallint,
@Bolum smallint,
@DersAdi nvarchar(75),
@Sinif smallint,
@Sube smallint,
@Donem smallint,
@DerslikAdi nvarchar(5)
)
as
declare @DersId int
declare @DerslikId smallint
declare @DonemId smallint
declare @BolumId int
set @DerslikId=(select tbl_Dk.Dk_Kodu from tbl_Dk where tbl_Dk.Dk_Adi=@DerslikAdi)
set @DersId = (select tbl_D.D_Kodu from tbl_D where tbl_D.D_Adi=@DersAdi)
set @DonemId =(select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif)
set @BolumId =(select tbl_BDDnm.BDDnm_Kodu from tbl_BDDnm where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.D_Kodu=@DersId and tbl_BDDnm.Dnm_Kodu=@DonemId)

if exists (select tbl_DD.DD_kodu from tbl_DD where tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat and tbl_DD.B_Kodu=@Bolum and tbl_DD.Dnm_Kodu=@DonemId)
	Begin
		if exists (select tbl_D.D_Kodu from tbl_D where tbl_D.D_Adi=@DersAdi) 
			begin
				if exists (select tbl_Dk.Dk_Kodu from tbl_Dk where tbl_Dk.Dk_Adi=@DerslikAdi)
					begin
						update tbl_DD set BDDnm_Kodu=@BolumId,Dk_Kodu=@DerslikId where G_Kodu=@Gun and St_Kodu=@Saat and B_Kodu=@Bolum and Dnm_Kodu=@DonemId
					end
				else
					begin
						update tbl_DD set BDDnm_Kodu=@BolumId where G_Kodu=@Gun and St_Kodu=@Saat and B_Kodu=@Bolum and Dnm_Kodu=@DonemId
					end
			end
		else
			begin
				update tbl_DD set BDDnm_Kodu=0,Dk_Kodu=0 where G_Kodu=@Gun and St_Kodu=@Saat and B_Kodu=@Bolum and Dnm_Kodu=@DonemId
			end
	end
else
	begin
		if exists (select tbl_D.D_Kodu from tbl_D where tbl_D.D_Adi=@DersAdi) 
			begin
				if exists (select tbl_Dk.Dk_Kodu from tbl_Dk where tbl_Dk.Dk_Adi=@DerslikAdi)
					begin
						insert into tbl_DD (G_Kodu,St_Kodu,BDDnm_Kodu,Dk_Kodu,B_Kodu,Dnm_Kodu) values (@Gun,@Saat,@BolumId,@DerslikId,@Bolum,@DonemId)
					end
				else
					begin
						insert into tbl_DD (G_Kodu,St_Kodu,BDDnm_Kodu,Dk_Kodu,B_Kodu,Dnm_Kodu) values (@Gun,@Saat,@BolumId,0,@Bolum,@DonemId)
					end
			end
		else
			begin
				insert into tbl_DD (G_Kodu,St_Kodu,BDDnm_Kodu,Dk_Kodu,B_Kodu,Dnm_Kodu) values (@Gun,@Saat,0,0,@Bolum,@DonemId)
			end
	end


	
GO
