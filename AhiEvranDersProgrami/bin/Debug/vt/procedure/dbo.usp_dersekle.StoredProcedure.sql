USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_dersekle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_dersekle]
(
@kod int,
@adi nvarchar(75),
@k smallint,
@u smallint,
@t smallint,
@akts smallint
)
as
insert into tbl_D (D_Kodu,D_Adi,D_K,D_T,D_U,D_AKTS)
			values(@kod,@adi,@k,@t,@u,@akts)

GO
