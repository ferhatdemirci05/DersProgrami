USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_SubeListele]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_SubeListele]
as
Select tbl_Sb.Sb_Adi,tbl_Sb.Sb_Kodu 
from tbl_Sb

GO
