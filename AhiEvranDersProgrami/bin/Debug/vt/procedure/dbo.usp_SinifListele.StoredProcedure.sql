USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_SinifListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_SinifListele]
as
Select tbl_Sf.Sf_Adi,tbl_Sf.Sf_Kodu 
from tbl_Sf

GO
