USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_donemekle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_donemekle]
(
@adi nvarchar(10)
)as
insert into tbl_Dm(Dm_Adi) values(@adi)

GO
