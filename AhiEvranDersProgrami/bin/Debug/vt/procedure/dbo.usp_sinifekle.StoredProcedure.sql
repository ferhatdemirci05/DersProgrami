USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_sinifekle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_sinifekle]
(
@adi nvarchar(10)
)as
insert into tbl_Sf(Sf_Adi) values(@adi)

GO
