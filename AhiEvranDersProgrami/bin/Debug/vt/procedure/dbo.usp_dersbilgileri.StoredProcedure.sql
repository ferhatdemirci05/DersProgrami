USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_dersbilgileri]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_dersbilgileri]
(
@kod int
)
as
select tbl_D.D_Adi,tbl_D.D_AKTS,tbl_D.D_K,tbl_D.D_Kodu,tbl_D.D_T,tbl_D.D_U 
from tbl_D where tbl_D.D_Kodu=@kod

GO
