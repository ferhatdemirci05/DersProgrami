USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_dersguncelle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_dersguncelle]
(
@adi nvarchar(75),
@akts smallint,
@kodu int,
@k smallint,
@t smallint,
@u smallint
)
as
update tbl_D set D_Adi=@adi,D_AKTS=@akts,D_K=@k,D_T=@t,D_U=@u where tbl_D.D_Kodu=@kodu

GO
