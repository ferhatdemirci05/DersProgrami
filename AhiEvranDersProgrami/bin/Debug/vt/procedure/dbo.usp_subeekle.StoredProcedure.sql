USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_subeekle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_subeekle]
(
@adi nvarchar(3)
)as
insert into tbl_Sb(Sb_Adi) values(@adi)

GO
