USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_DonemiListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_DonemiListele]
as
Select tbl_Dm.Dm_Adi,tbl_Dm.Dm_Kodu 
from tbl_Dm

GO
