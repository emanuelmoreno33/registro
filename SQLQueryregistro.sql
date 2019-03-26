Create database registro2
go
USE [registro2]
CREATE TABLE alumnos(
	[nocontrol] [int] PRIMARY KEY,
	[nombre] [varchar](200) NULL,
	[apepat] [varchar](200) NULL,
	[apemat] [varchar](200) NULL,
)


CREATE TABLE registrodia(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nocontrol] [int] NULL,
	[fecha] [datetime] NULL,
 CONSTRAINT [PK__registro__3213E83F1AF659F3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[registrodia]  WITH CHECK ADD  CONSTRAINT [FK_registrodia_alumnos] FOREIGN KEY([nocontrol])
REFERENCES [dbo].[alumnos] ([nocontrol])
GO

ALTER TABLE [dbo].[registrodia] CHECK CONSTRAINT [FK_registrodia_alumnos]
GO
