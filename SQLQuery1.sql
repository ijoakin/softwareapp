USE [Software]
GO

SELECT [id]
      ,[typeid]
      ,[locationid]
      ,[platformid]
      ,[unc]
      ,[softwareDescription]
      ,[softwareName]
  FROM [dbo].[Software]
GO

USE [Software]
GO

INSERT INTO [dbo].[Software]
           ([typeid]
           ,[locationid]
           ,[platformid]
           ,[unc]
           ,[softwareDescription]
           ,[softwareName])
     VALUES
           (1
           ,1
           ,1
           ,'R:\SoftwareUNLP'
           ,'en_sql_server_2016_developer_x64_dvd_8777069'
           ,'en_sql_server_2016_developer_x64_dvd_8777069')
GO

