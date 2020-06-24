USE [master]
GO
/****** Object:  Database [BDPERMISOS]    Script Date: 24/06/2020 10:35:14 ******/
CREATE DATABASE [BDPERMISOS]
GO
USE [BDPERMISOS]
GO
/****** Object:  Table [dbo].[usuarios_BF]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios_BF](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[nom_user] [nchar](30) NOT NULL,
	[ape_user] [nchar](40) NOT NULL,
	[login_user] [nchar](12) NOT NULL,
	[passw_user] [varchar](max) NOT NULL,
	[fech_user] [datetime] NOT NULL,
	[fechup_user] [datetime] NULL,
 CONSTRAINT [PK_usuarios_BF] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios_rol_BF]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios_rol_BF](
	[id_rol] [int] NOT NULL,
	[id_user] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles_BF]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles_BF](
	[id_Rol] [int] IDENTITY(1,1) NOT NULL,
	[nom_Rol] [nchar](20) NOT NULL,
	[permisos_Rol] [nvarchar](max) NULL,
 CONSTRAINT [PK_roles_BF] PRIMARY KEY CLUSTERED 
(
	[id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[PERMISOS]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PERMISOS]
AS
SELECT        dbo.usuarios_BF.id_user
FROM            dbo.usuarios_rol_BF INNER JOIN
                         dbo.usuarios_BF ON dbo.usuarios_rol_BF.id_user = dbo.usuarios_BF.id_user INNER JOIN
                         dbo.roles_BF ON dbo.usuarios_rol_BF.id_rol = dbo.roles_BF.id_Rol
GO
SET IDENTITY_INSERT [dbo].[roles_BF] ON 
GO
INSERT [dbo].[roles_BF] ([id_Rol], [nom_Rol], [permisos_Rol]) VALUES (1, N'Administrador       ', N'Àe£Á­¹{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž¿®°¾tuv§À¸ª{gˆÁ»¶½ÇÀ½g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“™ªÐ§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue£Ç®ÊÈwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´šÁ¦§¾Äk€{­¬²¾ue–Cª¸ÂÑmq{©¦¯Ê·kŽÍÑÀªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…¹ËÈªÀ²~k½…g¨Ãª±©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk•»Ñ´·{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¶²ÈºÑmq{¡¦°ºtƒvžÃ´¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{¹µÊ·Æ±…”©{g–¶È®¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“’ººÅ©¤Çtuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv¬ÀÁªšÆ™²Ä¾œÈËÈ»’¾ÁºŒÉ·¶v…™¦Æ¸g}w™¾µËÃ¬·y¶´°Ätuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv©Ñ´³Í§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾uež¿¹ÆÂÌ´·{g™¶¾¾¹{™¿·Î¸Â t’¸{™m‹Â¿ªºÀ¾v…™¦Æ¸g}w“»·ÁÈÁ´{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¶²ÈºÑmq{¡¦°ºtƒvžÃ´¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{¹µÊ·Æ±…”©{g˜Ã¶¸¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“ªÌ»¦¦ºÄk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“º¨q{œ©et·¸È ¹¦½¼·et—µÆÄm{”6¤¹»»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î©ÂÇ¦µw~k¢ºÌ°g“uŠ§¾ÆªÆ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠÅ¼²¬w~k¢ºÌ°g“uŠ¯¾¿²ÂºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{±°©È§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue§·±µ¼Ä½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{ ¾w¥¾¶§Î¯´{  t’¸{™m³½Â†±¶¶²Æ{‹m“ºÀªetŠEºÃ´·{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©Èuž²~k½…gÇ·´ˆ¹»½µËwg§´²¨wŒk™½È¿¦Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¾²ÁÂwg§´²¨wŒk™ÅÈ¸®Ç´·etŸµÅÔ°g“Ç·¸ºÏ¦€{¨¯g“uˆ¸É¦¸ÃÅ²¿·ÂÃ’¨ÃÇ’È¾Ìmq{¡¦°ºtƒvœÎ½¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä“·µ½È½g…u“¤Â·kŽ{ <¦½¼·etŸµÅÔ°g“Ç·¸ºÏuÏ{²À§§Â©²wŒ¤±…”©{g±¹ÁŽ¸ÂÓ¬·{g‘¶¿®v“©ÂÇ¦µw~kªºËÀª{¹µÊ·Æ€Ôžº»¡´§Ätƒ¯¶‹mŽ½ueÃ¶¸™ÅÈ¸®{g‘¶¿®v“±ÂÀ®±¶Äk€{µ¬±Î¸g}ÉÄ¾¹Ö¼wg¢·g}w•¸ÄÒ³º´Å¦¹µ¾Â–¹ÇÔ”¹¾Àgow ªÁ¾…gœÂµ¬¶Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“º¨q{œ©et·¸È ¹¦½¼·et—µÆÄm{”6¤¹»»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î©ÂÇ¦µw~k¢ºÌ°g“uŠ§¾ÆªÆ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠÅ¼²¬w~k¢ºÌ°g“uŠ¯¾¿²ÂºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{¯¬¸Í¸™²Ä¾œÈËÈ»’¾ÁºŒÉ·¶v…™¦Æ¸g}w¢®»ºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{¤¯®Í ª±Êtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´šÁ¦§¾Äk€{­¬²¾ue–Cª¸ÂÑmq{©¦¯Ê·kŽÍÑÀªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…¹ËÈªÀ²~k½…g®Æº¤Ç»¸Ç­Îº±¬Ç·¬ÅŸ®ÂÎ¨¿ªÆuqe£³¶¹{™mšÌÈ¦µ¾Á¼v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž¿®°¾tuv§À¸ª{gˆÁ»¶½ÇÀ½g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“´Å¸¸—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªet›ÃÅÄ¾g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“Ž´Ç¹®ª¢··É{‹m“ºÀªetŒÃÇÅ´¬ÎÅ¦¦¾E·v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒk¢¾Ö¢®Ç·´º©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk¢ÎÄÁ¦y©ª±É³·µ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvœÀ¾¨º·ª—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªetŒµÌÂ¬©ºuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{§®¯º¨®ÆÍÈ®¦Å§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue¢Á¼µÂÂºe¯¸··¾µªÀ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒv­È·ª¡Â·¬ÏÁ·ÈºËŸ´È¿˜·Ç»¹¡¾ÍÀŽÍ¸²et—µÆÄm{ ´¶¶»¬Ãy§º·ÂÍ´±É³µv…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒk—ÅÎ¾ªš¿±—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªetŒ¹ËÑ¬·y§´§Ätuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}w“»ÆºÍ²ª¢¶´±È¦¸ÃÅ²¿·ÂÃ’¨ÃÇ’È¾Ìmq{¡¦°ºtƒv¨Ñ²¦Ç¼¿¤Çr’·ÈÍº¸{g™¶¾¾¹{™¿·Î¸Â t’¸{™mœÂÁ©²ÌÅ–¹ÇÔmq{¡¦°ºtƒv¯Ä¹¹ºÁ¦¶w~kªºËÀª{¹µÊ·Æ±…”©{³¸Á¾uv§À¸ª{³¸Á¾uv¯À·º¾u©¶¾¼¹Ö')
GO
INSERT [dbo].[roles_BF] ([id_Rol], [nom_Rol], [permisos_Rol]) VALUES (2, N'Supervisor          ', N'Àe£Á­¹{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž¿®°¾tuv§À¸ª{gˆÁ»¶½ÇÀ½g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“™ªÐ§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue£Ç®ÊÈwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´šÁ¦§¾Äk€{­¬²¾ue–Cª¸ÂÑmq{©¦¯Ê·kŽÍÑÀªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…¹ËÈªÀ²~k½…g¨Ãª±©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk•»Ñ´·{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¶²ÈºÑmq{¡¦°ºtƒvžÃ´¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{¹µÊ·Æ±…”©{g–¶È®¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“’ººÅ©¤Çtuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv¬ÀÁªšÆ™²Ä¾œÈËÈ»’¾ÁºŒÉ·¶v…™¦Æ¸g}w™¾µËÃ¬·y¶´°Ätuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv©Ñ´³Í§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾uež¿¹ÆÂÌ´·{g™¶¾¾¹{™¿·Î¸Â t’¸{™m‹Â¿ªºÀ¾v…™¦Æ¸g}w“»·ÁÈÁ´{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¶²ÈºÑmq{¡¦°ºtƒvžÃ´¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{¹µÊ·Æ±…”©{g˜Ã¶¸¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“ªÌ»¦¦ºÄk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“º¨q{œ©et·¸È ¹¦½¼·et—µÆÄm{”6¤¹»»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î©ÂÇ¦µw~k¢ºÌ°g“uŠ§¾ÆªÆ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠÅ¼²¬w~k¢ºÌ°g“uŠ¯¾¿²ÂºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{±°©È§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue§·±µ¼Ä½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{ ¾w¥¾¶§Î¯´{  t’¸{™m³½Â†±¶¶²Æ{‹m“ºÀªetŠEºÃ´·{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©Èuž²~k½…gÇ·´ˆ¹»½µËwg§´²¨wŒk™½È¿¦Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¾²ÁÂwg§´²¨wŒk™ÅÈ¸®Ç´·etŸµÅÔ°g“Ç·¸ºÏ¦€{¨¯g“uˆ¸É¦¸ÃÅ²¿·ÂÃ’¨ÃÇ’È¾Ìmq{¡¦°ºtƒvœÎ½¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä“·µ½È½g…u“¤Â·kŽ{ <¦½¼·etŸµÅÔ°g“Ç·¸ºÏuÏ{²À§§Â©²wŒ¤±…”©{g±¹ÁŽ¸ÂÓ¬·{g‘¶¿®v“©ÂÇ¦µw~kªºËÀª{¹µÊ·Æ€Ôžº»¡´§Ätƒ¯¶‹mŽ½ueÃ¶¸™ÅÈ¸®{g‘¶¿®v“±ÂÀ®±¶Äk€{µ¬±Î¸g}ÉÄ¾¹Ö¼wg¢·g}w•¸ÄÒ³º´Å¦¹µ¾Â–¹ÇÔ”¹¾Àgow ªÁ¾…gœÂµ¬¶Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“º¨q{œ©et·¸È ¹¦½¼·et—µÆÄm{”6¤¹»»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î©ÂÇ¦µw~k¢ºÌ°g“uŠ§¾ÆªÆ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠÅ¼²¬w~k¢ºÌ°g“uŠ¯¾¿²ÂºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{¯¬¸Í¸™²Ä¾œÈËÈ»’¾ÁºŒÉ·¶v…™¦Æ¸g}w¢®»ºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{¤¯®Í ª±Êtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´šÁ¦§¾Äk€{­¬²¾ue–Cª¸ÂÑmq{©¦¯Ê·kŽÍÑÀªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…¹ËÈªÀ²~k½…g®Æº¤Ç»¸Ç­Îº±¬Ç·¬ÅŸ®ÂÎ¨¿ªÆuqe£³¶¹{™mšÌÈ¦µ¾Á¼v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž¿®°¾tuv§À¸ª{gˆÁ»¶½ÇÀ½g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“´Å¸¸—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªet›ÃÅÄ¾g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“Ž´Ç¹®ª¢··É{‹m“ºÀªetŒÃÇÅ´¬ÎÅ¦¦¾E·v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒk¢¾Ö¢®Ç·´º©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk¢ÎÄÁ¦y©ª±É³·µ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvœÀ¾¨º·ª—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªetŒµÌÂ¬©ºuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{§®¯º¨®ÆÍÈ®¦Å§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue¢Á¼µÂÂºe¯¸··¾µªÀ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒv­È·ª¡Â·¬ÏÁ·ÈºËŸ´È¿˜·Ç»¹¡¾ÍÀŽÍ¸²et—µÆÄm{ ´¶¶»¬Ãy§º·ÂÍ´±É³µv…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒk—ÅÎ¾ªš¿±—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªetŒ¹ËÑ¬·y§´§Ätuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}w“»ÆºÍ²ª¢¶´±È¦¸ÃÅ²¿·ÂÃ’¨ÃÇ’È¾Ìmq{¡¦°ºtƒv¨Ñ²¦Ç¼¿¤Çr’·ÈÍº¸{g™¶¾¾¹{™¿·Î¸Â t’¸{™mœÂÁ©²ÌÅ–¹ÇÔmq{¡¦°ºtƒv¯Ä¹¹ºÁ¦¶w~kªºËÀª{¹µÊ·Æ±…”©{³¸Á¾uv§À¸ª{³¸Á¾uv¯À·º¾u©¶¾¼¹Ö')
GO
INSERT [dbo].[roles_BF] ([id_Rol], [nom_Rol], [permisos_Rol]) VALUES (3, N'Cajero              ', N'Àe£Á­¹{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž¿®°¾tuv§À¸ª{gˆÁ»¶½ÇÀ½g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“™ªÐ§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue£Ç®ÊÈwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´šÁ¦§¾Äk€{­¬²¾ue–Cª¸ÂÑmq{©¦¯Ê·kŽÍÑÀªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…¹ËÈªÀ²~k½…g¨Ãª±©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk•»Ñ´·{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¶²ÈºÑmq{¡¦°ºtƒvžÃ´¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{¹µÊ·Æ±…”©{g–¶È®¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“’ººÅ©¤Çtuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv¬ÀÁªšÆ™²Ä¾œÈËÈ»’¾ÁºŒÉ·¶v…™¦Æ¸g}w™¾µËÃ¬·y¶´°Ätuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv©Ñ´³Í§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾uež¿¹ÆÂÌ´·{g™¶¾¾¹{™¿·Î¸Â t’¸{™m‹Â¿ªºÀ¾v…™¦Æ¸g}w“»·ÁÈÁ´{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¶²ÈºÑmq{¡¦°ºtƒvžÃ´¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{¹µÊ·Æ±…”©{g˜Ã¶¸¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“ªÌ»¦¦ºÄk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“º¨q{œ©et·¸È ¹¦½¼·et—µÆÄm{”6¤¹»»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î©ÂÇ¦µw~k¢ºÌ°g“uŠ§¾ÆªÆ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠÅ¼²¬w~k¢ºÌ°g“uŠ¯¾¿²ÂºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{±°©È§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue§·±µ¼Ä½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{ ¾w¥¾¶§Î¯´{  t’¸{™m³½Â†±¶¶²Æ{‹m“ºÀªetŠEºÃ´·{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©Èuž²~k½…gÇ·´ˆ¹»½µËwg§´²¨wŒk™½È¿¦Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¾²ÁÂwg§´²¨wŒk™ÅÈ¸®Ç´·etŸµÅÔ°g“Ç·¸ºÏ¦€{¨¯g“uˆ¸É¦¸ÃÅ²¿·ÂÃ’¨ÃÇ’È¾Ìmq{¡¦°ºtƒvœÎ½¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä“·µ½È½g…u“¤Â·kŽ{ <¦½¼·etŸµÅÔ°g“Ç·¸ºÏuÏ{²À§§Â©²wŒ¤±…”©{g±¹ÁŽ¸ÂÓ¬·{g‘¶¿®v“©ÂÇ¦µw~kªºËÀª{¹µÊ·Æ€Ôžº»¡´§Ätƒ¯¶‹mŽ½ueÃ¶¸™ÅÈ¸®{g‘¶¿®v“±ÂÀ®±¶Äk€{µ¬±Î¸g}ÉÄ¾¹Ö¼wg¢·g}w•¸ÄÒ³º´Å¦¹µ¾Â–¹ÇÔ”¹¾Àgow ªÁ¾…gœÂµ¬¶Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“º¨q{œ©et·¸È ¹¦½¼·et—µÆÄm{”6¤¹»»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î©ÂÇ¦µw~k¢ºÌ°g“uŠ§¾ÆªÆ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠÅ¼²¬w~k¢ºÌ°g“uŠ¯¾¿²ÂºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{¯¬¸Í¸™²Ä¾œÈËÈ»’¾ÁºŒÉ·¶v…™¦Æ¸g}w¢®»ºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{¤¯®Í ª±Êtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´šÁ¦§¾Äk€{­¬²¾ue–Cª¸ÂÑmq{©¦¯Ê·kŽÍÑÀªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…¹ËÈªÀ²~k½…g®Æº¤Ç»¸Ç­Îº±¬Ç·¬ÅŸ®ÂÎ¨¿ªÆuqe£³¶¹{™mšÌÈ¦µ¾Á¼v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž¿®°¾tuv§À¸ª{gˆÁ»¶½ÇÀ½g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“´Å¸¸—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªet›ÃÅÄ¾g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“Ž´Ç¹®ª¢··É{‹m“ºÀªetŒÃÇÅ´¬ÎÅ¦¦¾E·v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒk¢¾Ö¢®Ç·´º©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk¢ÎÄÁ¦y©ª±É³·µ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvœÀ¾¨º·ª—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªetŒµÌÂ¬©ºuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{§®¯º¨®ÆÍÈ®¦Å§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue¢Á¼µÂÂºe¯¸··¾µªÀ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒv­È·ª¡Â·¬ÏÁ·ÈºËŸ´È¿˜·Ç»¹¡¾ÍÀŽÍ¸²et—µÆÄm{ ´¶¶»¬Ãy§º·ÂÍ´±É³µv…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒk—ÅÎ¾ªš¿±—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªetŒ¹ËÑ¬·y§´§Ätuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}w“»ÆºÍ²ª¢¶´±È¦¸ÃÅ²¿·ÂÃ’¨ÃÇ’È¾Ìmq{¡¦°ºtƒv¨Ñ²¦Ç¼¿¤Çr’·ÈÍº¸{g™¶¾¾¹{™¿·Î¸Â t’¸{™mœÂÁ©²ÌÅ–¹ÇÔmq{¡¦°ºtƒv¯Ä¹¹ºÁ¦¶w~kªºËÀª{¹µÊ·Æ±…”©{³¸Á¾uv§À¸ª{³¸Á¾uv¯À·º¾u©¶¾¼¹Ö')
GO
INSERT [dbo].[roles_BF] ([id_Rol], [nom_Rol], [permisos_Rol]) VALUES (4, N'Vendedor            ', N'Àe£Á­¹{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž¿®°¾tuv§À¸ª{gˆÁ»¶½ÇÀ½g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“™ªÐ§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue£Ç®ÊÈwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´šÁ¦§¾Äk€{­¬²¾ue–Cª¸ÂÑmq{©¦¯Ê·kŽÍÑÀªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…¹ËÈªÀ²~k½…g¨Ãª±©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk•»Ñ´·{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¶²ÈºÑmq{¡¦°ºtƒvžÃ´¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{¹µÊ·Æ±…”©{g–¶È®¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“’ººÅ©¤Çtuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv¬ÀÁªšÆ™²Ä¾œÈËÈ»’¾ÁºŒÉ·¶v…™¦Æ¸g}w™¾µËÃ¬·y¶´°Ätuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv©Ñ´³Í§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾uež¿¹ÆÂÌ´·{g™¶¾¾¹{™¿·Î¸Â t’¸{™m‹Â¿ªºÀ¾v…™¦Æ¸g}w“»·ÁÈÁ´{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¶²ÈºÑmq{¡¦°ºtƒvžÃ´¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{¹µÊ·Æ±…”©{g˜Ã¶¸¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“ªÌ»¦¦ºÄk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“º¨q{œ©et·¸È ¹¦½¼·et—µÆÄm{”6¤¹»»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î©ÂÇ¦µw~k¢ºÌ°g“uŠ§¾ÆªÆ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠÅ¼²¬w~k¢ºÌ°g“uŠ¯¾¿²ÂºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{±°©È§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue§·±µ¼Ä½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{ ¾w¥¾¶§Î¯´{  t’¸{™m³½Â†±¶¶²Æ{‹m“ºÀªetŠEºÃ´·{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©Èuž²~k½…gÇ·´ˆ¹»½µËwg§´²¨wŒk™½È¿¦Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¾²ÁÂwg§´²¨wŒk™ÅÈ¸®Ç´·etŸµÅÔ°g“Ç·¸ºÏ¦€{¨¯g“uˆ¸É¦¸ÃÅ²¿·ÂÃ’¨ÃÇ’È¾Ìmq{¡¦°ºtƒvœÎ½¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä“·µ½È½g…u“¤Â·kŽ{ <¦½¼·etŸµÅÔ°g“Ç·¸ºÏuÏ{²À§§Â©²wŒ¤±…”©{g±¹ÁŽ¸ÂÓ¬·{g‘¶¿®v“©ÂÇ¦µw~kªºËÀª{¹µÊ·Æ€Ôžº»¡´§Ätƒ¯¶‹mŽ½ueÃ¶¸™ÅÈ¸®{g‘¶¿®v“±ÂÀ®±¶Äk€{µ¬±Î¸g}ÉÄ¾¹Ö¼wg¢·g}w•¸ÄÒ³º´Å¦¹µ¾Â–¹ÇÔ”¹¾Àgow ªÁ¾…gœÂµ¬¶Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“º¨q{œ©et·¸È ¹¦½¼·et—µÆÄm{”6¤¹»»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î©ÂÇ¦µw~k¢ºÌ°g“uŠ§¾ÆªÆ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠÅ¼²¬w~k¢ºÌ°g“uŠ¯¾¿²ÂºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{¯¬¸Í¸™²Ä¾œÈËÈ»’¾ÁºŒÉ·¶v…™¦Æ¸g}w¢®»ºÑmq{©¦¯Ê·kŽÍÑÀªÖ°qež¶kŽ{¤¯®Í ª±Êtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´šÁ¦§¾Äk€{­¬²¾ue–Cª¸ÂÑmq{©¦¯Ê·kŽÍÑÀªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…¹ËÈªÀ²~k½…g®Æº¤Ç»¸Ç­Îº±¬Ç·¬ÅŸ®ÂÎ¨¿ªÆuqe£³¶¹{™mšÌÈ¦µ¾Á¼v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž¿®°¾tuv§À¸ª{gˆÁ»¶½ÇÀ½g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“´Å¸¸—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªet›ÃÅÄ¾g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“Ž´Ç¹®ª¢··É{‹m“ºÀªetŒÃÇÅ´¬ÎÅ¦¦¾E·v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒk¢¾Ö¢®Ç·´º©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk¢ÎÄÁ¦y©ª±É³·µ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvœÀ¾¨º·ª—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªetŒµÌÂ¬©ºuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{§®¯º¨®ÆÍÈ®¦Å§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue¢Á¼µÂÂºe¯¸··¾µªÀ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒv­È·ª¡Â·¬ÏÁ·ÈºËŸ´È¿˜·Ç»¹¡¾ÍÀŽÍ¸²et—µÆÄm{ ´¶¶»¬Ãy§º·ÂÍ´±É³µv…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒk—ÅÎ¾ªš¿±—ÄÁµ§ÍÑ´µ¦¸³¸žÆ®Á{‹m“ºÀªetŒ¹ËÑ¬·y§´§Ätuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}w“»ÆºÍ²ª¢¶´±È¦¸ÃÅ²¿·ÂÃ’¨ÃÇ’È¾Ìmq{¡¦°ºtƒv¨Ñ²¦Ç¼¿¤Çr’·ÈÍº¸{g™¶¾¾¹{™¿·Î¸Â t’¸{™mœÂÁ©²ÌÅ–¹ÇÔmq{¡¦°ºtƒv¯Ä¹¹ºÁ¦¶w~kªºËÀª{¹µÊ·Æ±…”©{³¸Á¾uv§À¸ª{³¸Á¾uv¯À·º¾u©¶¾¼¹Ö')
GO
INSERT [dbo].[roles_BF] ([id_Rol], [nom_Rol], [permisos_Rol]) VALUES (6, N'Despachador         ', N'Àe£Á­¹{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ½ÆÎÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž¿®°¾tuv§À¸ª{gˆÁ»¶½ÇÀ½g…u›¤ÁÇ®v“Ó½º¾Ð¢ow›­v“™ªÐ§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue£Ç®ÊÈwg¯´±¸ºtƒÈËÔ°Â…Îg–Ê´—Ã½Îm´Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´šÁ¦§¾Äk€{­¬²¾ue–Cª¸ÂÑmq{©¦¯Ê·kŽÍÑÀªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Ó½º¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…¹ËÈªÀ²~k½…g¨Ãª±©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk•»Ñ´·{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…¹ËÈªÀÍk§ÎÁ™´½Âg}°¯uv¢Ãm{Á©²š¶²ÈºÑmq{¡¦°ºtƒvžÃ´¹ºÅgow¨ªÀÎÄmÍÅº¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{¹µÊ·Æ±…”©{g–¶È®¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“’ººÅ©¤Çtuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv¬ÀÁªšÆ™²Ä¾œÈËÈ»’¾ÁºŒÉ·¶v…™¦Æ¸g}w™¾µËÃ¬·y¶´°Ätuv¯À·º¾u·ÇÇ®Ñ…Úm˜Îµ“²¹ÁkŽ´Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}wÀ­ÃšÍ¬©ÂÅgow ªÁ¾…gšD¦§¾Äk€{µ¬±Î¸g}ÉÄ¾¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤¯®Í´·et—µÆÄm{˜©¬É³»v…¡¦ÅÈªeÆ»É¾ÜwÀ{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½Î±ÂÀ®et—µÆÄm{˜±¬Â»·µËwg¯´±¸ºtƒÈËÔ°Â¶gŒ¹tƒv©Ñ´³Í§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾uež¿¹ÆÂÌ´·{g™¶¾¾¹{™¿·Î¸Â t’¸{™m‹Â¿ªºÀ¾v…™¦Æ¸g}w“»·ÁÈÁ´{g™¶¾¾¹{™¿·Î¸ÂoÐtœÉ»­º©ÈužÐtœÉ»­º©ÈužÐtœÉ»­º©Èuž²~k½…gÇ·´„Ã³­½Ëwg§´²¨wŒk•JÀ¯®Ëuqe«³µÉ¾…«º¿¸¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—­½ÍÀ½g…u“¤Â·kŽ{¤¯®Í´·etŸµÅÔ°g“¹¦¯È·Æ€Ôžº»¡´§Ätƒ¯¶‹mŽ½ueÃ¶¸™ÅÈ¸®{g‘¶¿®v“±ÂÀ®±¶Äk€{µ¬±Î¸g}»³µÇ¾Ü¨q{œ©etžÂ½ÎŸ´È¿˜·Ç»¹¡¾ÍÀŽÍ¸²et—µÆÄm{—ª¶½³¬¹Ëwg¯´±¸ºtƒººË¾ªÖÀe¨Ç«¢ÈÃºg“®Àe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È”³¤¹»»v…™¦Æ¸g}w“:µ½È½g…u›¤ÁÇ®v“Å¬±Ì¸ÂoÐtœÉ»­º©Èuž²~k½…gÇ·´ˆ¹»½µËwg§´²¨wŒk™½È¿¦Ëuqe«³µÉ¾…«º¿¸¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{«¤ÁÅ®Ñ¶‹mŽ½ue§·­Ã­Îº±¬Ç·¬ÅŸ®ÂÎ¨¿ªÆuqe£³¶¹{™m—¾»¦¦ºÄk€{µ¬±Î¸g}»³µÇ¾ÜwÀ{¦º¥£Á­Ã{™¦À{¦º¥£Á­Ã{™¦¢…uŽ§wŒkÂ½ÎŒ³º·®µw~k¢ºÌ°g“u†4¶¶²Æ{‹m›º¿º¨wŒ¯µÅÒ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{Í¯´ž·®·¶Äk€{­¬²¾ueš¶²ÈºÑmq{©¦¯Ê·kŽ¿À·¸¾Ðq¾w¥¾¶§Î¯´{  t’¸{™m³½ÂŠ¯¾¿²v…™¦Æ¸g}w—µ½ÆÈ¹¦Ëuqe«³µÉ¾…«º¿¸¨Ò¯uv¢Ãm{–º·©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk—ÈÑ¿¦Ëuqe«³µÉ¾…«º¿¸¨Ò~Äv¬Ô­“È·´e­Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä“·µ½È½g…u“¤Â·kŽ{ <¦½¼·etŸµÅÔ°g“¹¦¯È·Æ€Ôžº»¡´§Ätƒ¯¶‹mŽ½ueÃ¶¸™½È¿¦Ëuqe£³¶¹{™mŠ½¼¹¤Çtuv¯À·º¾u©¶¾¼¹Ö‹Æg¬È§‘Ä¶¸v“º¨q{œ©et·¸È¤·®Æ¼gow ªÁ¾…gž¿®°¾ÀªÆ{‹m›º¿º¨wŒ¯µÅÒ°Â¶gŒ¹tƒvœÎ»¾­Â´¯¨Æ»½É¬°³Îœ¹¨Âtuv§À¸ª{g†ÄÂ²µËwg¯´±¸ºtƒººË¾ªÖÀe¨Ç«¢ÈÃºg“®Àe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È”³¤¹»»v…™¦Æ¸g}w“:µ½È½g…u›¤ÁÇ®v“Å¬±Ì¸ÂoÐtœÉ»­º©Èuž²~k½…gÇ·´ˆ¹»½µËwg§´²¨wŒk™½È¿¦Ëuqe«³µÉ¾…«º¿¸¨Ò~Äv¬Ô­“È·´e­¦€{¨¯g“u³§Ä—µ½ÆÈmq{¡¦°ºtƒvžË´²ÂÁ¦µw~kªºËÀª{«¤ÁÅ®Ñ¶‹mŽ½ue¥³¼È¾³º´Å¦¹µ¾Â–¹ÇÔ”¹¾Àgow ªÁ¾…g©¸¬¤Çtuv¯À·º¾u©¶¾¼¹Ö¼wg¢·g}w—­½Í¬°³Îuqe£³¶¹{™mŠ½¼¹¤Çtuv¯À·º¾u©¶¾¼¹Ö‹Æg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“ºÆg¬È§‘Ä¶¸v“º¨q{œ©et·¸È ¹¦½¼·et—µÆÄm{”6¤¹»»v…¡¦ÅÈªe¸ªÀÌÄÈqÔu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃºŠ½¼¹¤Çtuv§À¸ª{gˆ¹»½µËwg¯´±¸ºtƒººË¾ªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜±¬Â»k€{­¬²¾ueš¾²ÁÂÍ¬·{g™¶¾¾¹{™±¦ÅÆªÀ²~k½…g®Æº¤Ç»¸Ç­Îº±¬Ç·¬ÅŸ®ÂÎ¨¿ªÆuqe£³¶¹{™mšÌÈ¦µ¾Á¼v…¡¦ÅÈªe¸ªÀÌÄÈqÔu˜¸· ¸¸È… Ôu˜¸· ¸¸È… ¶gŒ¹tƒvÇÃº†Ç´©¬Çtuv§À¸ª{g„F³­½Ëwg¯´±¸ºtƒººË¾ªÖÀe¨Ç«¢ÈÃºg“®¢ow›­v“¹©È˜©¬É³»v…™¦Æ¸g}w—­½ÍÀ½g…u›¤ÁÇ®v“Å¬±Ì¸ÂoÐtœÉ»­º©Èuž²~k½…gÇ·´ˆÁ»¶½{‹m“ºÀªetŽÀÂÌ´³ºÅgow¨ªÀÎÄm¿´±¶ºÏ¦€{¨¯g“u—²Á·¼¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“´Å¸¸etŸµÅÔ°g“¹¦¯È·Æ±…”©{g†ÄÀ¯½À¬°³Îuqe£³¶¹{™mˆÈÁ«¬¼Ç»µ¼È>³{g™¶¾¾¹{™±¦ÅÆªÀÍk§ÎÁ™´½Âg}°Ík§ÎÁ™´½Âg}°¯uv¢Ãm{¡ªº¬»·¸ÈÖŸ´È¿˜·Ç»¹¡¾ÍÀŽÍ¸²et—µÆÄm{¡º¨Ë³iª¾Í¿¦Ç´gow¨ªÀÎÄm¿´±¶ºÏuÏ{²À§§Â©²wŒ¤±…”©{g†¶Å¬µ½ÄŸ´È¿˜·Ç»¹¡¾ÍÀŽÍ¸²et—µÆÄm{–¦¶¸³­µ{‹m›º¿º¨wŒ¯µÅÒ°Â…Îg–Ê´—Ã½Îm´°qež¶kŽ{³´±¾©ªµÉ»¬µÅ³º´Å¦¹µ¾Â–¹ÇÔ”¹¾Àgow ªÁ¾…g¦Â¸¤¾µ¸t¯Ä½¹Â¶¦¯w~kªºËÀª{«¤ÁÅ®Ñ…Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}w¦²À¾§º·ÂÍ´±É³µ¨ÈÎ·˜ÍÅ®³¢··É¢Ó°²{g‘¶¿®v“˜´Ì´®¦Är‘ÃËÈÅ´ÇÇ¦¯w~kªºËÀª{«¤ÁÅ®Ñ…Úm˜Îµ“²¹ÁkŽ´¼wg¢·g}w•µÃÌÄŒ±Å§´²Á¥½ÆÂÏ˜ªÇÈŽ·º¿k€{­¬²¾ue˜·»ÆºÑk™È·´etŸµÅÔ°g“¹¦¯È·Æ€Ôžº»¡´§Ätƒ¯¶‹mŽ½ue–Ä»µÇÆ°Ž¼Â³¶©Á¸À¬Ó½®É ª±Ê›½¹Æwg§´²¨wŒk£ËÆ¬³ÂÍ¦µu›¬ÃÇÎ¾g…u›¤ÁÇ®v“Å¬±Ì¸Â t’¸{™mœÂÁ©²ÌÅ–¹ÇÔmq{¡¦°ºtƒv¯Ä¹¹ºÁ¦¶w~kªºËÀª{«¤ÁÅ®Ñ¶‹mŽ½u±Ê¾µ€{­¬²¾u±Ê¾µ€{µ¬±Î¸g}»³µÇ¾Ü')
GO
SET IDENTITY_INSERT [dbo].[roles_BF] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios_BF] ON 
GO
INSERT [dbo].[usuarios_BF] ([id_user], [nom_user], [ape_user], [login_user], [passw_user], [fech_user], [fechup_user]) VALUES (1, N'USUARIO 3                     ', N'USER 3                                  ', N'usuario3    ', N'e10adc3949ba59abbe56e057f20f883e', CAST(N'2020-03-22T09:37:24.420' AS DateTime), CAST(N'2020-05-31T19:07:34.127' AS DateTime))
GO
INSERT [dbo].[usuarios_BF] ([id_user], [nom_user], [ape_user], [login_user], [passw_user], [fech_user], [fechup_user]) VALUES (10, N'USUARIO 2                     ', N'USER 2                                  ', N'usuario2    ', N'e10adc3949ba59abbe56e057f20f883e', CAST(N'2020-04-05T19:51:31.147' AS DateTime), CAST(N'2020-05-31T19:07:14.377' AS DateTime))
GO
INSERT [dbo].[usuarios_BF] ([id_user], [nom_user], [ape_user], [login_user], [passw_user], [fech_user], [fechup_user]) VALUES (11, N'USUARIO 1                     ', N'USER 1                                  ', N'usuario1    ', N'25f9e794323b453885f5181f1b624d0b', CAST(N'2020-04-05T19:53:53.270' AS DateTime), CAST(N'2020-05-31T19:06:56.587' AS DateTime))
GO
INSERT [dbo].[usuarios_BF] ([id_user], [nom_user], [ape_user], [login_user], [passw_user], [fech_user], [fechup_user]) VALUES (14, N'USUARIO 4                     ', N'USER 4                                  ', N'usuario4    ', N'e10adc3949ba59abbe56e057f20f883e', CAST(N'2020-04-05T20:01:37.127' AS DateTime), CAST(N'2020-05-31T19:07:49.577' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[usuarios_BF] OFF
GO
INSERT [dbo].[usuarios_rol_BF] ([id_rol], [id_user]) VALUES (1, 10)
GO
INSERT [dbo].[usuarios_rol_BF] ([id_rol], [id_user]) VALUES (1, 1)
GO
INSERT [dbo].[usuarios_rol_BF] ([id_rol], [id_user]) VALUES (3, 11)
GO
INSERT [dbo].[usuarios_rol_BF] ([id_rol], [id_user]) VALUES (1, 12)
GO
INSERT [dbo].[usuarios_rol_BF] ([id_rol], [id_user]) VALUES (1, 13)
GO
INSERT [dbo].[usuarios_rol_BF] ([id_rol], [id_user]) VALUES (2, 14)
GO
/****** Object:  StoredProcedure [dbo].[SP_USU_INSERT]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_USU_INSERT]
@LOG NCHAR(12),
@NOM NCHAR(30),
@APE NCHAR(40),
@PASS VARCHAR(MAX),
@IDROL INT,
@RESULT INT OUTPUT -- 0=YA EXISTE USUARIO  1=SE INSERTO   2=ERROR SQL
AS
BEGIN TRAN
	DECLARE @COUNTUSU INT, @IDUSER INT
		SET @COUNTUSU = (SELECT COUNT(login_user) FROM [dbo].usuarios_BF WHERE login_user=@LOG)
		IF @COUNTUSU = 0
		BEGIN
			INSERT INTO usuarios_BF (login_user
				   ,nom_user
				   ,ape_user
				   ,passw_user
				   ,fech_user)
			VALUES ( @LOG, @NOM,@APE, @PASS,GETDATE())
			-- EN CASO DE ERROR 
			 IF @@ERROR <> 0 
			  BEGIN
				ROLLBACK TRAN
				RETURN 2
			  END
			SET @IDUSER = (SELECT id_user FROM [dbo].usuarios_BF WHERE login_user=@LOG)
			INSERT INTO [dbo].usuarios_rol_BF(id_user,id_rol) VALUES (@IDUSER, @IDROL)
			IF @@ERROR <> 0 
			  BEGIN
				ROLLBACK TRAN
				RETURN 2
			  END
			SET @RESULT = 1
		END
		ELSE
		BEGIN
			SET @RESULT = 0
		END
COMMIT TRAN

GO
/****** Object:  StoredProcedure [dbo].[SP_USU_INSERT_ROL]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_USU_INSERT_ROL]
@NOMROL AS NCHAR(20),
@RESULT INT OUTPUT
AS
BEGIN TRAN
	DECLARE @COUNT INT
	SET @COUNT = (SELECT COUNT(nom_Rol) FROM roles_BF WHERE nom_Rol=@NOMROL)
	IF @COUNT = 0
	BEGIN
		INSERT INTO [dbo].[roles_BF]
				   ([nom_Rol]
				   ,[permisos_Rol])
			 VALUES
				   (@NOMROL
				   ,'')
		-- EN CASO DE ERROR 
			 IF @@ERROR <> 0 
			  BEGIN
				ROLLBACK TRAN
				RETURN 2
			  END
		SET @RESULT = 1

	END
	ELSE
	BEGIN
		SET @RESULT = 0
	END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[SP_USU_LIST]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_USU_LIST] 

AS
	SELECT        dbo.usuarios_BF.id_user,RTRIM(dbo.usuarios_BF.ape_user) as ape_user, RTRIM(dbo.usuarios_BF.nom_user) as nom_user, RTRIM(dbo.usuarios_BF.login_user) as login_user, dbo.usuarios_BF.fech_user, dbo.usuarios_BF.fechup_user, RTRIM(dbo.roles_BF.nom_Rol) as nom_Rol
	FROM            dbo.usuarios_BF INNER JOIN
								dbo.usuarios_rol_BF ON dbo.usuarios_BF.id_user = dbo.usuarios_rol_BF.id_user INNER JOIN
								dbo.roles_BF ON dbo.usuarios_rol_BF.id_rol = dbo.roles_BF.id_Rol
	  ORDER BY dbo.usuarios_BF.ape_user
GO
/****** Object:  StoredProcedure [dbo].[SP_USU_LISTROL]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_USU_LISTROL] 

AS
	SELECT        id_Rol, RTRIM(nom_Rol) as nom_Rol
	FROM            dbo.roles_bf
	  ORDER BY nom_Rol

GO
/****** Object:  StoredProcedure [dbo].[SP_USU_LOGIN]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_USU_LOGIN]
@LOGIN Nchar(15),
@PASS NVARCHAR(MAX),
@RESULT varchar(20) OUTPUT
AS
	DECLARE @IDUSUS INT,@IDUSU VARCHAR(10)
	SET @IDUSUS = (SELECT COUNT([id_user]) FROM [usuarios_BF] WHERE [login_user] = @LOGIN AND [passw_user] =@PASS)
	IF (@IDUSUS = 0)
		BEGIN
			SET @RESULT = '0'
		END
	ELSE
		BEGIN
			SET @RESULT = '1'
		END
GO
/****** Object:  StoredProcedure [dbo].[SP_USU_UPDATE]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------
create PROCEDURE [dbo].[SP_USU_UPDATE]
@IDUSU INT,
@NOM NCHAR(30),
@APE NCHAR(40),
@PASS VARCHAR(MAX)=NULL,
@TIPOUSU INT,
@RESULT INT OUTPUT -- 0=YA EXISTE USUARIO  1=SE INSERTO   2=ERROR SQL
AS
BEGIN TRAN
IF @PASS = ''
BEGIN
	UPDATE [dbo].[usuarios_BF]
	   SET 
		  [nom_user] = @NOM
		  ,ape_user = @APE
		  ,[fechup_user] = GETDATE()
	 WHERE id_user = @IDUSU
END
ELSE
BEGIN
	UPDATE [dbo].[usuarios_BF]
	   SET 
		  [nom_user] = @nom
		  ,ape_user = @APE
		  ,[fechup_user] = GETDATE()
		  ,passw_user = @PASS
	 WHERE id_user = @IDUSU
END
	IF @@ERROR <> 0 
		BEGIN
		ROLLBACK TRAN
		SET @RESULT = 2
		END
	ELSE
		BEGIN
		SET @RESULT = 1
		END
	----------------------
	UPDATE dbo.usuarios_rol_BF
		SET
			id_rol=@TIPOUSU
		WHERE id_user=@IDUSU	
	----------------------
	IF @@ERROR <> 0 
		BEGIN
		ROLLBACK TRAN
		SET @RESULT = 2
		END
	ELSE
		BEGIN
		SET @RESULT = 1
		END

	-----------------------
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[SP_USU_UPPERMISO]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------------------------------------------------------------
CREATE PROCEDURE [dbo].[SP_USU_UPPERMISO]
@IDROL INT,
@PERMISOS NVARCHAR(MAX),
@RESULT INT OUTPUT -- 0=YA EXISTE USUARIO  1=SE INSERTO   2=ERROR SQL
AS
BEGIN TRAN

	UPDATE [dbo].[roles_BF]
		SET [permisos_Rol] = @PERMISOS
		WHERE id_Rol=@IDROL

	IF @@ERROR <> 0 
		BEGIN
		ROLLBACK TRAN
		SET @RESULT = 2	
		END
	ELSE
		BEGIN
		SET @RESULT = 1
		END
COMMIT TRAN
GO
/****** Object:  StoredProcedure [dbo].[SP_USU_VER]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_USU_VER] 
@LOGIN NCHAR(12)
AS
	SELECT        dbo.usuarios_BF.id_user, RTRIM(dbo.usuarios_BF.nom_user) + ' ' + RTRIM(dbo.usuarios_BF.ape_user) AS NomUsu, RTRIM(dbo.roles_BF.nom_Rol) AS Expr1, dbo.roles_BF.permisos_Rol
	FROM            dbo.usuarios_rol_BF INNER JOIN
                         dbo.usuarios_BF ON dbo.usuarios_rol_BF.id_user = dbo.usuarios_BF.id_user INNER JOIN
                         dbo.roles_BF ON dbo.usuarios_rol_BF.id_rol = dbo.roles_BF.id_Rol
	WHERE        (dbo.usuarios_BF.login_user = @LOGIN)
GO
/****** Object:  StoredProcedure [dbo].[SP_USU_VERPERM]    Script Date: 24/06/2020 10:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_USU_VERPERM]
@IDROL int
AS
	SELECT [permisos_Rol] FROM [dbo].[roles_BF] WHERE id_Rol=@IDROL

GO
