
/**************************************************************
| 作成者 : ***** ***
| 作成日 : 2022/06/10
| 作成目的 : ●●の課題により[DesignationMaster]テーブルを新しく作る必要があったため
**************************************************************/
CREATE TABLE [dbo].[DesignationMaster](
	[DesignationId] [tinyint] IDENTITY(1,1) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_DesignationMaster_CreatedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_MemberShipType] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO