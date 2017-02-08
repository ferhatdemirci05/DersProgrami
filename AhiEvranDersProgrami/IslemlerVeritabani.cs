﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace AhiEvranDersProgrami
{
    class IslemlerVeritabani:TemelVeritabani
    {
        public override void Ekle(IVarlik varlik)
        {
            throw new NotImplementedException();
        }

        public override void Sil(IVarlik varlik)
        {
            throw new NotImplementedException();
        }

        public override void Guncelle(IVarlik varlik)
        {
            throw new NotImplementedException();
        }

        public override DataTable Listele(IVarlik varlik)
        {
            throw new NotImplementedException();
        }

        public override DataTable Listele()
        {
            throw new NotImplementedException();
        }

        internal void YedekAl(string p)
        {
            p += "programmycourses";
            p += ".pmc";
            string baglan = "";
            SqlConnection conn;
            baglan = "Data Source=.;Integrated Security=True";
            conn = new SqlConnection(baglan);
            conn.Open();
            komut = new SqlCommand("backup database dp to disk=@yedekal", conn);
            komut.Parameters.AddWithValue("@yedekal",p);
            komut.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        internal void yedekekle(string p) 
        {
            string baglan="";
            SqlConnection conn;
            baglan="Data Source=.;Integrated Security=True";
            conn = new SqlConnection(baglan);
            conn.Open();
            komut = new SqlCommand("alter database dp set single_user with rollback immediate; RESTORE database dp from disk=@yedekal with replace;", conn);
            komut.Parameters.AddWithValue("@yedekal", p);
            komut.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        internal object Listele(string TabloAdi)
        {
            throw new NotImplementedException();
        }

        internal void vtOlustur()
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Integrated security=true");
            SqlCommand cmd = new SqlCommand("if not exists(select * from sys.databases where name = 'dp') begin CREATE DATABASE dp end", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            //Şimdi de veritabanımız içerisinde tablomuzun olup olmadığına bakalım ve eğer tablomuz yoksa tablomuzu oluşturalım ve verilerimizi atalım.
            conn.ConnectionString = "Data Source=.;Initial Catalog=dp;Integrated security=true";
            //Aşağıdaki sorgu Kullanicilar tablosunun olup olmadığına bakmakta ve eğer yoksa oluşturarak içerisine kayıtları eklemektedir.
            List<string> Tablolar = new List<string>();
            List<string> Prosedur = new List<string>();
            // Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_') begin  end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_B') begin       CREATE TABLE [dbo].[tbl_B]( [B_Kodu] [smallint] NOT NULL, [B_KAdi] [nvarchar](15) NULL, [B_Adi] [nvarchar](75) NULL, [B_Baskani] [int] NULL, CONSTRAINT [PK_B] PRIMARY KEY CLUSTERED ([B_Kodu] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]  end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_BDDnm') begin   CREATE TABLE [dbo].[tbl_BDDnm]( [BDDnm_Kodu] [int] IDENTITY(1,1) NOT NULL, [B_Kodu] [smallint] NULL, [D_Kodu] [int] NULL, [Dnm_Kodu] [smallint] NULL, [OE_Kodu] [int] NULL, [BDDnm_DSD] [int] NULL, CONSTRAINT [PK_tbl_BDDnm] PRIMARY KEY CLUSTERED ( [BDDnm_Kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] ALTER TABLE [dbo].[tbl_BDDnm] ADD  CONSTRAINT [DF_tbl_BDDnm_BDDnm_DSD]  DEFAULT ((0)) FOR [BDDnm_DSD]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_D') begin       CREATE TABLE [dbo].[tbl_D]( [D_Kodu] [int] NOT NULL, [D_Adi] [nvarchar](75) NULL, [D_T] [smallint] NULL, [D_U] [smallint] NULL,[D_K] [smallint] NULL, [D_AKTS] [smallint] NULL, CONSTRAINT [PK_D] PRIMARY KEY CLUSTERED ( [D_Kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_DD') begin      CREATE TABLE [dbo].[tbl_DD]( [DD_kodu] [int] IDENTITY(1,1) NOT NULL, [G_Kodu] [smallint] NULL, [St_Kodu] [smallint] NULL, [BDDnm_Kodu] [int] NULL, [Dk_Kodu] [smallint] NULL, [B_Kodu] [smallint] NULL, [Dnm_Kodu] [smallint] NULL, CONSTRAINT [PK_tbl_DD] PRIMARY KEY CLUSTERED ( [DD_kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_Dk') begin      CREATE TABLE [dbo].[tbl_Dk]( [Dk_Kodu] [smallint] IDENTITY(1,1) NOT NULL, [Dk_Adi] [nvarchar](5) NULL, CONSTRAINT [PK_tbl_Dk] PRIMARY KEY CLUSTERED ( [Dk_Kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_Dm') begin      CREATE TABLE [dbo].[tbl_Dm]( [Dm_Kodu] [smallint] IDENTITY(1,1) NOT NULL, [Dm_Adi] [nvarchar](10) NULL, CONSTRAINT [PK_tbl_Dm] PRIMARY KEY CLUSTERED ([Dm_Kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_Dnm') begin     CREATE TABLE [dbo].[tbl_Dnm]( [Dnm_Kodu] [smallint] IDENTITY(1,1) NOT NULL, [Sf_Kodu] [smallint] NULL, [Sb_Kodu] [smallint] NULL, [Dn_Kodu] [smallint] NULL, CONSTRAINT [PK_Dnm] PRIMARY KEY CLUSTERED ([Dnm_Kodu] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_G') begin       CREATE TABLE [dbo].[tbl_G]( [G_Kodu] [smallint] IDENTITY(1,1) NOT NULL, [G_Adi] [nvarchar](10) NULL, CONSTRAINT [PK_tbl_G] PRIMARY KEY CLUSTERED ( [G_Kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_OE') begin      CREATE TABLE [dbo].[tbl_OE]( [OE_Kodu] [int] IDENTITY(1,1) NOT NULL, [OE_KAdi] [nvarchar](15) NULL, [OE_Adi] [nvarchar](50) NULL, [OE_Soyadi] [nvarchar](50) NULL, [OE_Unvan] [smallint] NULL, [OE_DTarihi] [date] NULL, [OE_STel] [nchar](15) NULL, [OE_CTel] [nchar](15) NULL, [OE_Mail] [nvarchar](50) NULL, [OE_Maas] [smallint] NULL,  CONSTRAINT [PK_OE] PRIMARY KEY CLUSTERED ( [OE_Kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_Sb') begin      CREATE TABLE [dbo].[tbl_Sb]( [Sb_Kodu] [smallint] IDENTITY(1,1) NOT NULL, [Sb_Adi] [nvarchar](3) NULL, CONSTRAINT [PK_tbl_Sb] PRIMARY KEY CLUSTERED ( [Sb_Kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_Sf') begin      CREATE TABLE [dbo].[tbl_Sf]( [Sf_Kodu] [smallint] IDENTITY(1,1) NOT NULL, [Sf_Adi] [char](1) NULL, CONSTRAINT [PK_Sf] PRIMARY KEY CLUSTERED ( [Sf_Kodu] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_St') begin      CREATE TABLE [dbo].[tbl_St]( [St_Kodu] [smallint] IDENTITY(1,1) NOT NULL, [St_Araligi] [nvarchar](11) NULL, [St_OgrenimTuru] [bit] NULL, CONSTRAINT [PK_tbl_Sr] PRIMARY KEY CLUSTERED ( [St_Kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]   end");
            Tablolar.Add("USE [dp] if not exists(select * from sys.tables where name = 'tbl_U') begin       CREATE TABLE [dbo].[tbl_U]( [U_Kodu] [smallint] IDENTITY(1,1) NOT NULL, [U_Adi] [nvarchar](50) NULL, CONSTRAINT [PK_U] PRIMARY KEY CLUSTERED ( [U_Kodu] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY]   end");
            Prosedur.Add("create proc [dbo].[usp_aktifdonemekle] (@donemi smallint, @sinif smallint, @sube smallint) as insert into tbl_Dnm (Dn_Kodu,Sf_Kodu,Sb_Kodu) values (@donemi,@sinif,@sube)");
            Prosedur.Add("CREATE proc [dbo].[usp_aktifdonemilistele] as select tbl_Dnm.Dnm_Kodu,(tbl_Sf.Sf_Adi+'/'+tbl_Sb.Sb_Adi+' Sınıfı '+tbl_Dm.Dm_Adi+' Dönemi') as Donem from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu order by tbl_Dnm.Sf_Kodu asc,tbl_Sb.Sb_Kodu asc,tbl_Dm.Dm_Adi desc");
            Prosedur.Add("CREATE proc [dbo].[usp_aktifdonemlistele] as select tbl_Dnm.Dnm_Kodu, tbl_Sf.Sf_Adi+'. Sınıf'as Sinif,tbl_Sb.Sb_Adi,tbl_Dm.Dm_Adi from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu order by tbl_Dnm.Sf_Kodu asc,tbl_Sb.Sb_Kodu asc,tbl_Dm.Dm_Adi desc");
            Prosedur.Add("CREATE proc [dbo].[usp_aktifdonemlisteleparametreli] (@sinif char(1), @sube nvarchar(3), @donemi nvarchar(10), @sinifid smallint, @donemid smallint, @subeid smallint) as if (@sube!='') begin set @subeid=(select tbl_Sb.Sb_Kodu from tbl_Sb where tbl_Sb.Sb_Adi= @sube) select tbl_Dnm.Dnm_Kodu, tbl_Sf.Sf_Adi+'. Sınıf'as Sinif,tbl_Sb.Sb_Adi,tbl_Dm.Dm_Adi from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu  inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu where tbl_Dnm.Sb_Kodu=@subeid order by tbl_Dnm.Sf_Kodu asc,tbl_Sb.Sb_Kodu asc,tbl_Dm.Dm_Adi desc end else if (@sinif!='') begin set @sinifid =(select tbl_Sf.Sf_Kodu from tbl_Sf where tbl_Sf.Sf_Adi=@sinif) select tbl_Dnm.Dnm_Kodu, tbl_Sf.Sf_Adi+'. Sınıf'as Sinif,tbl_Sb.Sb_Adi,tbl_Dm.Dm_Adi from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu where tbl_Dnm.Sf_Kodu=@sinifid order by tbl_Dnm.Sf_Kodu asc,tbl_Sb.Sb_Kodu asc,tbl_Dm.Dm_Adi desc end else if (@donemi!='') begin set @donemid =(select tbl_Dm.Dm_Kodu from tbl_Dm where tbl_Dm.Dm_Adi=@donemi) select tbl_Dnm.Dnm_Kodu, tbl_Sf.Sf_Adi+'. Sınıf'as Sinif,tbl_Sb.Sb_Adi,tbl_Dm.Dm_Adi from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu  inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu where tbl_Dnm.Dn_Kodu=@donemid order by tbl_Dnm.Sf_Kodu asc,tbl_Sb.Sb_Kodu asc,tbl_Dm.Dm_Adi desc end");
            Prosedur.Add("create proc [dbo].[usp_BolumAra]( @Ad nvarchar(75) ) as select tbl_B.B_Kodu,tbl_B.B_KAdi,tbl_B.B_Adi,tbl_U.U_Adi+' '+ tbl_OE.OE_Adi +' '+tbl_OE.OE_Soyadi as 'OE' from tbl_B,tbl_OE,tbl_U where tbl_OE.OE_Kodu=tbl_B.B_Baskani and tbl_OE.OE_Unvan=tbl_U.U_Kodu and tbl_B.B_Adi like '%'+@Ad+'%'");
            Prosedur.Add("CREATE proc [dbo].[usp_bolumbilgilistele] (@kod smallint) as select tbl_B.B_KAdi,tbl_B.B_Adi,B_Baskani from tbl_B where tbl_B.B_Kodu=@kod");
            Prosedur.Add("create proc [dbo].[usp_BolumdenDersListele] (@Bolum smallint, @Sinif smallint, @Sube smallint, @Donem smallint) as select tbl_D.D_Adi,tbl_D.D_Kodu from tbl_BDDnm inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu = tbl_Dnm.Dnm_Kodu where tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif and tbl_Dnm.Dn_Kodu=@Donem and tbl_BDDnm.B_Kodu=@Bolum");
            Prosedur.Add("CREATE proc [dbo].[usp_BolumDersDonemEkle] (@bolum smallint, @ders int, @donem smallint, @oe int) as if exists (select tbl_BDDnm.BDDnm_Kodu from tbl_BDDnm where tbl_BDDnm.B_Kodu=@bolum and tbl_BDDnm.Dnm_Kodu=@donem and tbl_BDDnm.D_Kodu=@ders) begin update tbl_BDDnm set tbl_BDDnm.OE_Kodu=@oe where tbl_BDDnm.B_Kodu=@bolum and tbl_BDDnm.Dnm_Kodu=@donem and tbl_BDDnm.D_Kodu=@ders end else begin insert into tbl_BDDnm (B_Kodu,D_Kodu,Dnm_Kodu,OE_Kodu) values (@bolum,@ders,@donem,@oe) end");
            Prosedur.Add("create proc [dbo].[usp_BolumDersDonemKontrolet] (@bolum smallint, @ders int, @donem smallint, @oe int, @Sonuc bit output ) as if exists(select tbl_BDDnm.BDDnm_Kodu from tbl_BDDnm where tbl_BDDnm.B_Kodu=@bolum and tbl_BDDnm.D_Kodu=@ders and tbl_BDDnm.Dnm_Kodu=@donem and tbl_BDDnm.OE_Kodu=@oe) begin set @Sonuc=1 return @sonuc end else begin set @Sonuc=0 return @sonuc end");
            Prosedur.Add("create proc [dbo].[usp_BolumDersDonemKriteregöreListele](@Bolum smallint, @Ders int, @Donem Smallint, @OE int) as if (@Bolum!=0) begin Select tbl_BDDnm.BDDnm_Kodu,tbl_B.B_KAdi as Bölüm, (tbl_Sf.Sf_Adi+'/'+tbl_Sb.Sb_Adi+' '+tbl_Dm.Dm_Adi) as Dönem, tbl_D.D_Adi as Ders, (tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi) as ÖğretimElemanı from tbl_BDDnm inner join tbl_B on tbl_BDDnm.B_Kodu=tbl_B.B_Kodu inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu inner join tbl_OE on tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu,tbl_Dm,tbl_Sf,tbl_Sb where tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu and tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu and tbl_Dnm.Sf_Kodu = tbl_Sf.Sf_Kodu and tbl_BDDnm.B_Kodu=@Bolum order by tbl_B.B_Adi asc, Dönem asc, Ders asc,ÖğretimElemanı asc end else if (@Donem!=0) begin Select tbl_BDDnm.BDDnm_Kodu,tbl_B.B_KAdi as Bölüm, (tbl_Sf.Sf_Adi+'/'+tbl_Sb.Sb_Adi+' '+tbl_Dm.Dm_Adi) as Dönem, tbl_D.D_Adi as Ders, (tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi) as ÖğretimElemanı from tbl_BDDnm inner join tbl_B on tbl_BDDnm.B_Kodu=tbl_B.B_Kodu inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu inner join tbl_OE on tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu,tbl_Dm,tbl_Sf,tbl_Sb where tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu and tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu and tbl_Dnm.Sf_Kodu = tbl_Sf.Sf_Kodu and tbl_BDDnm.Dnm_Kodu=@Donem order by tbl_B.B_Adi asc, Dönem asc, Ders asc,ÖğretimElemanı asc end else if (@Ders!=0) begin Select tbl_BDDnm.BDDnm_Kodu,tbl_B.B_KAdi as Bölüm, (tbl_Sf.Sf_Adi+'/'+tbl_Sb.Sb_Adi+' '+tbl_Dm.Dm_Adi) as Dönem, tbl_D.D_Adi as Ders, (tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi) as ÖğretimElemanı from tbl_BDDnm inner join tbl_B on tbl_BDDnm.B_Kodu=tbl_B.B_Kodu inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu inner join tbl_OE on tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu,tbl_Dm,tbl_Sf,tbl_Sb where tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu and tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu and tbl_Dnm.Sf_Kodu = tbl_Sf.Sf_Kodu and tbl_BDDnm.D_Kodu=@Ders order by tbl_B.B_Adi asc, Dönem asc, Ders asc,ÖğretimElemanı asc end else if (@OE!=0) begin Select tbl_BDDnm.BDDnm_Kodu,tbl_B.B_KAdi as Bölüm, (tbl_Sf.Sf_Adi+'/'+tbl_Sb.Sb_Adi+' '+tbl_Dm.Dm_Adi) as Dönem, tbl_D.D_Adi as Ders, (tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi) as ÖğretimElemanı from tbl_BDDnm inner join tbl_B on tbl_BDDnm.B_Kodu=tbl_B.B_Kodu inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu inner join tbl_OE on tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu,tbl_Dm,tbl_Sf,tbl_Sb where tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu and tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu and tbl_Dnm.Sf_Kodu = tbl_Sf.Sf_Kodu and tbl_BDDnm.OE_Kodu=@OE order by tbl_B.B_Adi asc, Dönem asc, Ders asc,ÖğretimElemanı asc end");
            Prosedur.Add(" CREATE proc [dbo].[usp_BolumDersDonemListele] as Select tbl_BDDnm.BDDnm_Kodu,tbl_B.B_KAdi as Bölüm, (tbl_Sf.Sf_Adi+'/'+tbl_Sb.Sb_Adi+' '+tbl_Dm.Dm_Adi) as Dönem, tbl_D.D_Adi as Ders, (tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi) as ÖğretimElemanı from tbl_BDDnm inner join tbl_B on tbl_BDDnm.B_Kodu=tbl_B.B_Kodu inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu inner join tbl_OE on tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu,tbl_Dm,tbl_Sf,tbl_Sb where tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu and tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu and tbl_Dnm.Sf_Kodu = tbl_Sf.Sf_Kodu order by tbl_B.B_Adi asc, Dönem asc, Ders asc,ÖğretimElemanı asc");
            Prosedur.Add(" create proc [dbo].[usp_BolumDersDonemSil] ( @Kod int) as delete from tbl_BDDnm where tbl_BDDnm.BDDnm_Kodu=@Kod");
            Prosedur.Add(" create proc [dbo].[usp_BolumDonemListele](@kod smallint) as select tbl_Sf.Sf_Adi as Sinif,tbl_Sb.Sb_Adi as Sube,tbl_Dm.Dm_Adi as Donem from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu where tbl_Dnm.Dnm_Kodu=@kod");
            Prosedur.Add(" CREATE proc [dbo].[usp_bolumekle] (@kodu smallint, @kadi nvarchar(15), @adi nvarchar(75), @baskani int)as insert into tbl_B(B_Adi,B_KAdi,B_Kodu,B_Baskani)values(@adi,@kadi,@kodu,@baskani)");
            Prosedur.Add(" create proc [dbo].[usp_BolumGuncelle] (@adi nvarchar(75), @kadi nvarchar(15), @baskani int, @kodu smallint) as update tbl_B set B_Adi=@adi,B_Baskani=@baskani,B_KAdi=@kadi where B_Kodu=@kodu");
            Prosedur.Add(" create proc [dbo].[usp_bolumkontrolet] (@kadi nvarchar(15), @sonuc bit output)as if exists (select tbl_B.B_Kodu from tbl_B where tbl_B.B_KAdi=@kadi) begin set @sonuc=1 return @sonuc end else begin set @sonuc=0 return @sonuc end");
            Prosedur.Add(" CREATE proc [dbo].[usp_bolumlistele] as select tbl_B.B_Kodu,tbl_B.B_KAdi,tbl_B.B_Adi,tbl_U.U_Adi+' '+ tbl_OE.OE_Adi +' '+tbl_OE.OE_Soyadi as 'OE' from tbl_B,tbl_OE,tbl_U where tbl_OE.OE_Kodu=tbl_B.B_Baskani and tbl_OE.OE_Unvan=tbl_U.U_Kodu");
            Prosedur.Add(" create proc [dbo].[usp_BölümdenSinifaGoreSubeListele](@Bolum smallint, @Sinif smallint) as Select distinct tbl_Sb.Sb_Adi,tbl_Sb.Sb_Kodu from tbl_Sb inner join tbl_Dnm on tbl_Sb.Sb_Kodu=tbl_Dnm.Sb_Kodu inner join tbl_BDDnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu where  tbl_BDDnm.B_Kodu=@Bolum and tbl_Dnm.Sf_Kodu=@Sinif");
            Prosedur.Add(" create proc [dbo].[usp_BölümdenSinifaveSubeyeGoreDonemListele] (@Bolum smallint, @Sinif smallint, @Sube smallint) as Select distinct tbl_Dm.Dm_Adi,tbl_Dm.Dm_Kodu from tbl_Dm inner join tbl_Dnm on tbl_Dm.Dm_Kodu=tbl_Dnm.Dn_Kodu inner join tbl_BDDnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu where  tbl_BDDnm.B_Kodu=@Bolum and tbl_Dnm.Sf_Kodu=@Sinif and tbl_Dnm.Sb_Kodu=@Sube");
            Prosedur.Add(" create proc [dbo].[usp_BölümdenSinifListele] ( @Bolum smallint) as Select distinct tbl_Sf.Sf_Adi,tbl_Sf.Sf_Kodu from tbl_Sf inner join tbl_Dnm on tbl_Sf.Sf_Kodu=tbl_Dnm.Sf_Kodu inner join tbl_BDDnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu where  tbl_BDDnm.B_Kodu=@Bolum");
            Prosedur.Add(" create proc [dbo].[usp_dersbilgileri] (@kod int) as select tbl_D.D_Adi,tbl_D.D_AKTS,tbl_D.D_K,tbl_D.D_Kodu,tbl_D.D_T,tbl_D.D_U from tbl_D where tbl_D.D_Kodu=@kod");
            Prosedur.Add("  CREATE proc [dbo].[usp_DersDagilimiEkle](  @Gun smallint,   @Saat smallint,   @Bolum smallint,   @DersAdi nvarchar(75),   @Sinif smallint,   @Sube smallint,   @Donem smallint,   @DerslikAdi nvarchar(5)  ) as   declare @DersId int   declare @DerslikId smallint   declare @DonemId smallint   declare @BolumId int   set @DerslikId=(select tbl_Dk.Dk_Kodu from tbl_Dk where tbl_Dk.Dk_Adi=@DerslikAdi)   set @DersId = (select tbl_D.D_Kodu from tbl_D where tbl_D.D_Adi=@DersAdi)   set @DonemId =(select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif)   set @BolumId =(select tbl_BDDnm.BDDnm_Kodu from tbl_BDDnm where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.D_Kodu=@DersId and tbl_BDDnm.Dnm_Kodu=@DonemId)   if exists (select tbl_DD.DD_kodu from tbl_DD where tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat and tbl_DD.B_Kodu=@Bolum and tbl_DD.Dnm_Kodu=@DonemId) Begin if exists (select tbl_D.D_Kodu from tbl_D where tbl_D.D_Adi=@DersAdi) begin if exists (select tbl_Dk.Dk_Kodu from tbl_Dk where tbl_Dk.Dk_Adi=@DerslikAdi) begin update tbl_DD set BDDnm_Kodu=@BolumId,Dk_Kodu=@DerslikId where G_Kodu=@Gun and St_Kodu=@Saat and B_Kodu=@Bolum and Dnm_Kodu=@DonemId end else begin update tbl_DD set BDDnm_Kodu=@BolumId where G_Kodu=@Gun and St_Kodu=@Saat and B_Kodu=@Bolum and Dnm_Kodu=@DonemId end end else begin update tbl_DD set BDDnm_Kodu=0,Dk_Kodu=0 where G_Kodu=@Gun and St_Kodu=@Saat and B_Kodu=@Bolum and Dnm_Kodu=@DonemId end end else begin if exists (select tbl_D.D_Kodu from tbl_D where tbl_D.D_Adi=@DersAdi)  begin if exists (select tbl_Dk.Dk_Kodu from tbl_Dk where tbl_Dk.Dk_Adi=@DerslikAdi) begin insert into tbl_DD (G_Kodu,St_Kodu,BDDnm_Kodu,Dk_Kodu,B_Kodu,Dnm_Kodu) values (@Gun,@Saat,@BolumId,@DerslikId,@Bolum,@DonemId) end else begin insert into tbl_DD (G_Kodu,St_Kodu,BDDnm_Kodu,Dk_Kodu,B_Kodu,Dnm_Kodu) values (@Gun,@Saat,@BolumId,0,@Bolum,@DonemId) end end else begin insert into tbl_DD (G_Kodu,St_Kodu,BDDnm_Kodu,Dk_Kodu,B_Kodu,Dnm_Kodu) values (@Gun,@Saat,0,0,@Bolum,@DonemId) end end");
            Prosedur.Add("CREATE proc [dbo].[usp_DersDagilimiGetir] ( @Bolum smallint,  @Sinif smallint,  @Sube smallint,  @Donem smallint,  @Gun smallint,  @Saat smallint ) as  declare @Donemi smallint  set @Donemi=(select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif)  declare @derslik smallint  declare @bosderslik nvarchar(15)  set @bosderslik='' declare @sayac int =1 declare @dizi1 table (id int, id2 int identity(1,1)); insert into @dizi1 select tbl_BDDnm.BDDnm_Kodu from tbl_BDDnm where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.Dnm_Kodu=@Donemi while (@sayac<=(select count(*) from tbl_BDDnm where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.Dnm_Kodu=@Donemi)) begin declare @bddnm smallint set @bddnm = (select id from @dizi1 where id2=@sayac) if exists (select tbl_DD.DD_kodu from tbl_DD where tbl_DD.BDDnm_Kodu=@bddnm and tbl_DD.Dnm_Kodu=@Donemi and tbl_DD.B_Kodu=@Bolum and tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat) begin set @derslik=(select tbl_DD.Dk_Kodu from tbl_DD,tbl_BDDnm where tbl_DD.BDDnm_Kodu=tbl_BDDnm.BDDnm_Kodu and tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat and tbl_DD.Dnm_Kodu=@Donemi and tbl_DD.B_Kodu=@Bolum and tbl_DD.BDDnm_Kodu=@bddnm )  if @derslik !=0 begin  select  tbl_OE.OE_KAdi as OE, tbl_D.D_Adi as DERS, tbl_Dk.Dk_Adi as DERSLIK,tbl_D.D_Kodu,tbl_Dk.Dk_Kodu from tbl_DD , tbl_BDDnm ,tbl_D , tbl_OE ,tbl_Dk where tbl_DD.BDDnm_Kodu=tbl_BDDnm.BDDnm_Kodu and tbl_BDDnm.D_Kodu=tbl_D.D_Kodu and tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu and tbl_DD.Dk_Kodu=tbl_Dk.Dk_Kodu and tbl_BDDnm.Dnm_Kodu=@Donemi and tbl_DD.B_Kodu=@Bolum and tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat and  tbl_DD.BDDnm_Kodu=@bddnm break end  else begin  select  tbl_OE.OE_KAdi as OE, tbl_D.D_Adi as DERS, @bosderslik as DERSLIK,tbl_D.D_Kodu,tbl_Dk.Dk_Kodu from tbl_DD , tbl_BDDnm ,tbl_D , tbl_OE,tbl_Dk where  tbl_DD.BDDnm_Kodu=tbl_BDDnm.BDDnm_Kodu and tbl_BDDnm.D_Kodu=tbl_D.D_Kodu   and tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu and tbl_DD.Dk_Kodu=0			   and tbl_BDDnm.Dnm_Kodu=@Donemi and tbl_DD.B_Kodu=@Bolum and tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat and tbl_DD.BDDnm_Kodu=@bddnm break end end  set @sayac= @sayac+1 end");
            Prosedur.Add("create proc [dbo].[usp_DersDagilimiKaldir] (@Bolum smallint, @Sinif smallint, @Sube smallint, @Donem Smallint)as delete from tbl_DD where tbl_DD.B_Kodu=@Bolum and tbl_DD.Dnm_Kodu=(select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif)");
            Prosedur.Add(" create proc [dbo].[usp_dersekle] (@kod int, @adi nvarchar(75), @k smallint, @u smallint, @t smallint, @akts smallint) as insert into tbl_D (D_Kodu,D_Adi,D_K,D_T,D_U,D_AKTS) values(@kod,@adi,@k,@t,@u,@akts)");
            Prosedur.Add(" create proc [dbo].[usp_dersguncelle]( @adi nvarchar(75), @akts smallint, @kodu int, @k smallint, @t smallint, @u smallint) as update tbl_D set D_Adi=@adi,D_AKTS=@akts,D_K=@k,D_T=@t,D_U=@u where tbl_D.D_Kodu=@kodu");
            Prosedur.Add(" CREATE proc [dbo].[usp_derskontrolet] (@kod int, @Sonuc bit output)as if exists (select tbl_D.D_Adi from tbl_D where tbl_D.D_Kodu=@kod) begin set @Sonuc=1 return @Sonuc end else begin set @Sonuc=0 return @Sonuc end");
            Prosedur.Add("create proc [dbo].[usp_DerslikDagilimiListele] (@Gun smallint, @Saat smallint,@Derslik smallint) as select tbl_D.D_Adi,tbl_B.B_KAdi,tbl_Sf.Sf_Adi,tbl_Sb.Sb_Adi,tbl_OE.OE_KAdi from tbl_DD inner join tbl_BDDnm on (tbl_DD.BDDnm_Kodu=tbl_BDDnm.BDDnm_Kodu) inner join tbl_D on (tbl_BDDnm.D_Kodu=tbl_D.D_Kodu) inner join tbl_B on (tbl_BDDnm.B_Kodu=tbl_B.B_Kodu) inner join tbl_Dnm on (tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu) inner join tbl_Sf on (tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu) inner join tbl_Sb on (tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu) inner join tbl_OE on (tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu) where tbl_DD.G_Kodu=@Gun and tbl_DD.St_Kodu=@Saat and tbl_DD.Dk_Kodu=@Derslik");
            Prosedur.Add(" create proc [dbo].[usp_derslikekle] (@adi nvarchar(5))as insert into tbl_Dk (Dk_Adi) values(@adi)");
            Prosedur.Add(" create proc [dbo].[usp_DerslikListele] as select tbl_Dk.Dk_Adi,tbl_Dk.Dk_Kodu from tbl_Dk");
            Prosedur.Add("create proc [dbo].[usp_DerslikListeleParametre]( @Ad nvarchar(5))as select tbl_Dk.Dk_Adi,tbl_Dk.Dk_Kodu from tbl_Dk where tbl_Dk.Dk_Adi like '%'+@Ad+'%'");
            Prosedur.Add("  CREATE proc [dbo].[usp_derslistele] as select tbl_D.D_Kodu as ID, (CONVERT(nvarchar,tbl_D.D_Kodu)+' - '+tbl_D.D_Adi) as Ders,tbl_D.D_T,tbl_D.D_U,tbl_D.D_K,tbl_D.D_AKTS from tbl_D order by tbl_D.D_Adi asc");
            Prosedur.Add("create proc [dbo].[usp_DersListeleParametre]( @Ad nvarchar(75) )as select tbl_D.D_Kodu as ID, (CONVERT(nvarchar,tbl_D.D_Kodu)+' - '+tbl_D.D_Adi) as Ders,tbl_D.D_T,tbl_D.D_U,tbl_D.D_K,tbl_D.D_AKTS from tbl_D where tbl_D.D_Adi like '%'+@Ad+'%' order by tbl_D.D_Adi asc");
            Prosedur.Add("create proc [dbo].[usp_DersprogramiKontrolu] (@Bolum smallint, @Sinif smallint, @Sube smallint, @Donem smallint, @Sonuc bit output) as if exists (select tbl_DD.DD_kodu from tbl_DD inner join tbl_BDDnm on(tbl_DD.BDDnm_Kodu=tbl_BDDnm.BDDnm_Kodu) inner join tbl_Dnm on tbl_Dnm.Dnm_Kodu=tbl_BDDnm.Dnm_Kodu where tbl_BDDnm.B_Kodu=@Bolum and tbl_Dnm.Sf_Kodu=@Sinif and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Dn_Kodu=@Donem) begin set @Sonuc=1 return @Sonuc end else begin set @Sonuc=0 return @Sonuc end");
            Prosedur.Add(" create proc [dbo].[usp_derssaatiarttir](@Bolum smallint, @Ders int, @Donem smallint, @Sinif smallint, @Sube smallint)as update tbl_BDDnm set BDDnm_DSD=BDDnm_DSD+1 where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.D_Kodu=@Ders and tbl_BDDnm.Dnm_Kodu=(select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif)");
            Prosedur.Add("  create proc [dbo].[usp_derssaatiazalt](@Bolum smallint, @Ders int, @Donem smallint, @Sinif smallint, @Sube smallint ) as declare @Donemi int set @Donemi=( select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif) if 0<(select tbl_BDDnm.BDDnm_DSD from tbl_BDDnm where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.D_Kodu=@Ders and tbl_BDDnm.Dnm_Kodu=@Donemi) begin update tbl_BDDnm set BDDnm_DSD=BDDnm_DSD-1 where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.D_Kodu=@Ders and tbl_BDDnm.Dnm_Kodu=@Donemi end");
            Prosedur.Add(" create proc [dbo].[usp_derssaatikontrolet] ( @Bolum smallint, @Ders int, @Donem smallint, @Sinif smallint, @Sube smallint, @Sonuc bit output) as declare @toplamsaat int declare @DSD int set @DSD = (select tbl_BDDnm.BDDnm_DSD from tbl_BDDnm where tbl_BDDnm.B_Kodu=@Bolum and tbl_BDDnm.D_Kodu=@Ders and tbl_BDDnm.Dnm_Kodu=(select tbl_Dnm.Dnm_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@Donem and tbl_Dnm.Sb_Kodu=@Sube and tbl_Dnm.Sf_Kodu=@Sinif)) set @toplamsaat =(select (tbl_D.D_T+tbl_D.D_U) from tbl_D where tbl_D.D_Kodu=@Ders) if (@DSD<@toplamsaat) begin set @Sonuc=1 return @Sonuc end else begin set @Sonuc=0 return @Sonuc end");
            Prosedur.Add(" create proc [dbo].[usp_donemekle] ( @adi nvarchar(10) )as insert into tbl_Dm(Dm_Adi) values(@adi)");
            Prosedur.Add("  create proc [dbo].[usp_DonemiListele] as Select tbl_Dm.Dm_Adi,tbl_Dm.Dm_Kodu  from tbl_Dm");
            Prosedur.Add("create proc [dbo].[usp_DonemiListeleParametre](@Ad nvarchar(10))as Select tbl_Dm.Dm_Adi,tbl_Dm.Dm_Kodu  from tbl_Dm where tbl_Dm.Dm_Adi like '%'+@Ad+'%'");
            Prosedur.Add(" create proc [dbo].[usp_Donemkontrolet] ( @donemi smallint, @sinif smallint, @sube smallint, @Sonuc bit output) as if exists (select tbl_Dnm.Dn_Kodu from tbl_Dnm where tbl_Dnm.Dn_Kodu=@donemi and tbl_Dnm.Sb_Kodu=@sube and tbl_Dnm.Sf_Kodu=@sinif) begin  set @Sonuc=1  return @Sonuc end else begin  set @Sonuc=0 return @Sonuc end");
            Prosedur.Add(" create proc [dbo].[usp_Donemsil] ( @DonemKodu smallint )as delete from tbl_Dnm where tbl_Dnm.Dnm_Kodu=@DonemKodu");
            Prosedur.Add("create proc [dbo].[usp_DSDSifirla] as update tbl_BDDnm set BDDnm_DSD=0");
            Prosedur.Add("create proc [dbo].[usp_ElProgramDagitim] (@Gun smallint, @Saat smallint, @OE int ) as select tbl_D.D_Adi, tbl_B.B_KAdi, tbl_Sf.Sf_Adi, tbl_Sb.Sb_Adi, tbl_Dk.Dk_Adi, tbl_OE.OE_Maas from tbl_DD inner join tbl_BDDnm on (tbl_DD.BDDnm_Kodu=tbl_BDDnm.BDDnm_Kodu) inner join tbl_Dk on (tbl_DD.Dk_Kodu=tbl_Dk.Dk_Kodu) inner join tbl_OE on (tbl_BDDnm.OE_Kodu=tbl_OE.OE_Kodu) inner join tbl_B on (tbl_BDDnm.B_Kodu=tbl_B.B_Kodu) inner join tbl_Dnm on (tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu) inner join tbl_Sb on (tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu) inner join tbl_Sf on (tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu) inner join tbl_D on (tbl_BDDnm.D_Kodu=tbl_D.D_Kodu) WHERE tbl_DD.G_Kodu=@Gun AND tbl_DD.St_Kodu=@Saat AND tbl_BDDnm.OE_Kodu=@OE");
            Prosedur.Add(" CREATE proc [dbo].[usp_gunekle] (@adi nvarchar(12))as insert into tbl_G(G_Adi) values(@adi)");
            Prosedur.Add(" create proc [dbo].[usp_GunListele] as select tbl_G.G_Adi,tbl_G.G_Kodu from tbl_G");
            Prosedur.Add("create proc [dbo].[usp_GunListeleParametre] (@Ad nvarchar(10)) as select tbl_G.G_Adi,tbl_G.G_Kodu from tbl_G where tbl_G.G_Adi like '%'+@Ad+'%'");
            Prosedur.Add(" CREATE proc [dbo].[usp_GunveSaateGoreDerslikListele] (@GunKodu smallint, @SaatKodu smallint ) as select tbl_Dk.Dk_Adi,tbl_Dk.Dk_Kodu from tbl_Dk where tbl_Dk.Dk_Kodu not in( Select tbl_DD.Dk_Kodu from tbl_DD inner join tbl_Dk on(tbl_DD.Dk_Kodu=tbl_Dk.Dk_Kodu)  where tbl_DD.G_Kodu=@GunKodu and tbl_DD.St_Kodu=@SaatKodu)");
            Prosedur.Add(" CREATE proc [dbo].[usp_GunveSaateGoreDersListele] ( @BolumKodu smallint, @SinifKodu smallint, @SubeKodu smallint, @Donemi smallint) as select tbl_D.D_Adi,tbl_D.D_Kodu from  tbl_BDDnm inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu  where tbl_Dnm.Sb_Kodu=@SubeKodu and tbl_Dnm.Sf_Kodu=@SinifKodu and tbl_Dnm.Dn_Kodu=@Donemi and tbl_BDDnm.B_Kodu=@BolumKodu");
            Prosedur.Add(" create proc [dbo].[usp_KayitliBolumSiniflariListele] (@Bolum smallint, @Sube smallint, @Donemi smallint ) as select distinct tbl_Sf.Sf_Adi,tbl_Sf.Sf_Kodu from tbl_Sf inner join tbl_Dnm on  tbl_Sf.Sf_Kodu=tbl_Dnm.Sf_Kodu inner join tbl_BDDnm on tbl_Dnm.Dnm_Kodu=tbl_BDDnm.Dnm_Kodu where tbl_BDDnm.B_Kodu=@Bolum and tbl_Dnm.Dn_Kodu=@Donemi and tbl_Dnm.Sb_Kodu=@Sube");
            Prosedur.Add(" CREATE proc [dbo].[usp_ogreimelemanilisteleParametre](@Ad nvarchar(75))as select tbl_OE.OE_Kodu as kodu, (tbl_U.U_Adi+' '+tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi) as 'OE',tbl_OE.OE_Mail,tbl_OE.OE_CTel,tbl_OE.OE_STel,tbl_OE.OE_DTarihi from tbl_U,tbl_OE where tbl_OE.OE_Unvan=tbl_U.U_Kodu and tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi like '%'+@Ad+'%'");
            Prosedur.Add("  CREATE proc [dbo].[usp_ogretimelemanibilgileri] (@kod smallint)as select tbl_OE.OE_KAdi, tbl_OE.OE_Adi,tbl_OE.OE_Soyadi,tbl_OE.OE_Unvan,tbl_OE.OE_DTarihi,tbl_OE.OE_STel,tbl_OE.OE_CTel,tbl_OE.OE_Mail,tbl_OE.OE_Maas from tbl_OE where tbl_OE.OE_Kodu=@kod");
            Prosedur.Add("CREATE proc [dbo].[usp_OgretimElemaniEkle] (@kadi nvarchar(15), @adi nvarchar(50), @soyadi nvarchar(50), @unav smallint, @dtarih date, @stel nchar(15), @ctel nchar(15), @mail nvarchar(50), @maas smallint )as insert into tbl_OE (OE_KAdi,OE_Adi,OE_Soyadi,OE_Unvan,OE_DTarihi,OE_STel,OE_CTel,OE_Mail,OE_Maas) values (@kadi,@adi,@soyadi,@unav,@dtarih,@stel,@ctel,@mail,@maas)");
            Prosedur.Add(" CREATE proc [dbo].[usp_ogretimelemaniguncelle] ( @kodu smallint, @kadi nvarchar(15), @adi nvarchar(50), @soyadi nvarchar(50), @unvan smallint, @dtarih date, @stel nchar(15), @ctel nchar(15), @mail nvarchar(50), @maas smallint )as update tbl_OE set OE_Adi=@adi, OE_CTel=@ctel,OE_DTarihi=@dtarih, OE_KAdi=@kadi,OE_Maas=@maas,OE_Mail=@mail,OE_Soyadi=@soyadi,OE_STel=@stel,OE_Unvan=@unvan where OE_Kodu=@kodu");
            Prosedur.Add(" CREATE proc [dbo].[usp_ogretimelemanikontrol] (@adi nvarchar(50), @unvan nvarchar(50), @sonuc bit output )as if exists (select tbl_OE.OE_Kodu from tbl_OE where tbl_OE.OE_Unvan = (select tbl_U.U_Kodu from tbl_U where tbl_U.U_Adi=@unvan) and tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi=@adi ) begin set @sonuc=1 return @sonuc end else begin set @sonuc=0 return @sonuc end");
            Prosedur.Add("  CREATE proc [dbo].[usp_ogretimelemanilistele] as select tbl_OE.OE_Kodu as kodu, (tbl_U.U_Adi+' '+tbl_OE.OE_Adi+' '+tbl_OE.OE_Soyadi) as 'OE',tbl_OE.OE_Mail,tbl_OE.OE_CTel,tbl_OE.OE_STel,tbl_OE.OE_DTarihi from tbl_U,tbl_OE where tbl_OE.OE_Unvan=tbl_U.U_Kodu");
            Prosedur.Add(" create proc [dbo].[usp_ProgramKaydet] (@Bolum smallint, @Sinif smallint, @Sube smallint, @Donem smallint, @Gunid smallint, @Saatid smallint, @Derslikid smallint, @Dersid int) as declare @donemi int declare @Bolumu int set @donemi =(select tbl_Dnm.Dnm_Kodu from tbl_Dnm inner join tbl_Sb on tbl_Dnm.Sb_Kodu=tbl_Sb.Sb_Kodu inner join tbl_Sf on tbl_Dnm.Sf_Kodu=tbl_Sf.Sf_Kodu inner join tbl_Dm on tbl_Dnm.Dn_Kodu=tbl_Dm.Dm_Kodu where tbl_Dm.Dm_Kodu=@Donem and tbl_Sb.Sb_Kodu=@Sube and tbl_Sf.Sf_Kodu=@Sinif) set @Bolumu=(select tbl_BDDnm.BDDnm_Kodu from tbl_BDDnm inner join tbl_D on tbl_BDDnm.D_Kodu=tbl_D.D_Kodu inner join tbl_Dnm on tbl_BDDnm.Dnm_Kodu=tbl_Dnm.Dnm_Kodu inner join tbl_B on tbl_BDDnm.B_Kodu=tbl_B.B_Kodu where tbl_B.B_Kodu=@Bolum and tbl_D.D_Kodu=@Dersid and tbl_Dnm.Dnm_Kodu=@donemi) insert into tbl_DD  (G_Kodu,St_Kodu,BDDnm_Kodu,Dk_Kodu) values (@Gunid,@Saatid,@Bolumu,@Derslikid)");
            Prosedur.Add(" CREATE proc [dbo].[usp_saatekle] (@araligi nvarchar(15), @ogrenimTuru bit)as insert into tbl_St(St_Araligi,St_OgrenimTuru) values(@araligi,@ogrenimTuru)");
            Prosedur.Add(" CREATE proc [dbo].[usp_SaatListele] as Select tbl_St.St_Araligi,tbl_St.St_Kodu,tbl_St.St_OgrenimTuru as 'Öğrenim Türü' from tbl_St ORDER BY tbl_St.St_Araligi asc");
            Prosedur.Add(" CREATE proc [dbo].[usp_SaatListeleOgrenimTuru] (@ogrenimTuru bit) as Select tbl_St.St_Araligi,tbl_St.St_Kodu,tbl_St.St_OgrenimTuru as 'Öğrenim Türü' from tbl_St where tbl_St.St_OgrenimTuru=@ogrenimTuru order by tbl_St.St_Araligi asc");
            Prosedur.Add(" CREATE proc [dbo].[usp_SaatListeleParametre] (@Araligi nvarchar(11)) as Select tbl_St.St_Araligi,tbl_St.St_Kodu,tbl_St.St_OgrenimTuru as 'Öğrenim Türü' from tbl_St where tbl_St.St_Araligi like '%'+@Araligi+'%'");
            Prosedur.Add(" create proc [dbo].[usp_sinifekle](@adi nvarchar(10))as insert into tbl_Sf(Sf_Adi) values(@adi)");
            Prosedur.Add(" create proc [dbo].[usp_SinifListele] as Select tbl_Sf.Sf_Adi,tbl_Sf.Sf_Kodu from tbl_Sf");
            Prosedur.Add(" create proc [dbo].[usp_SinifListeleParametre] (@Ad char(1))as Select tbl_Sf.Sf_Adi,tbl_Sf.Sf_Kodu from tbl_Sf where tbl_Sf.Sf_Adi like '%'+@Ad+'%'");
            Prosedur.Add(" create proc [dbo].[usp_subeekle] (@adi nvarchar(3))as insert into tbl_Sb(Sb_Adi) values(@adi)");
            Prosedur.Add(" create proc [dbo].[usp_SubeListele] as Select tbl_Sb.Sb_Adi,tbl_Sb.Sb_Kodu from tbl_Sb");
            Prosedur.Add(" create proc [dbo].[usp_SubeListeleParametre] (@Ad nvarchar(3)) as Select tbl_Sb.Sb_Adi,tbl_Sb.Sb_Kodu from tbl_Sb where tbl_Sb.Sb_Adi like '%'+@Ad+'%'");
            Prosedur.Add(" CREATE proc [dbo].[usp_tabloDDSifirla] as delete from tbl_DD DBCC CHECKIDENT ('tbl_DD',RESEED,0)");
            Prosedur.Add(" create proc [dbo].[usp_unvankontrol](@unvan nvarchar(50), @sonuc bit output) as if exists (select tbl_U.U_Kodu from tbl_U where tbl_U.U_Adi=@unvan) begin set @sonuc=1 return @sonuc end else begin set @sonuc=0 return @sonuc end");
            Prosedur.Add(" CREATE proc [dbo].[usp_UnvanListele] as select tbl_U.U_Kodu,tbl_U.U_Adi from tbl_U");
            for (int i = 0; i < Tablolar.Count; i++)
            {
                createsql(Tablolar[i], conn, cmd);
            }
            for (int i = 0; i < Prosedur.Count; i++)
            {
                createsql(Prosedur[i], conn, cmd);
            }
            cmd.CommandText = "insert into tbl_U (U_Adi) values ('Prof.Dr.'),('Doc.Dr.'),('Yrd.Doc.Dr.'),('Dr.'),('Okutman'),('Araş.Gör.'),('Öğrt.Gör')";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        private void createsql(string p, SqlConnection conn, SqlCommand cmd)
        {
            cmd.CommandText = p;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}