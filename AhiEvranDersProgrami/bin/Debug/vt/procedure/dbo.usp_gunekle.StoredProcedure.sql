USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_gunekle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_gunekle]
(
@adi nvarchar(12)
)as
insert into tbl_G(G_Adi) values(@adi)

GO
