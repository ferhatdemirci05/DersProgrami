USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_derslikekle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[usp_derslikekle]
(
@adi nvarchar(5)
)as
insert into tbl_Dk (Dk_Adi) values(@adi)

GO
