USE [dp]
GO
/****** Object:  StoredProcedure [dbo].[usp_saatekle]    Script Date: 8.7.2015 22:43:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[usp_saatekle]
(
@araligi nvarchar(15)
)as
insert into tbl_St(St_Araligi) values(@araligi)

GO
