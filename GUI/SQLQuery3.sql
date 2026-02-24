SELECT TOP (1000) [stdId]
      ,[StdName]
      ,[StdAge]
      ,[Gender]
      ,[Username]
      ,[Password]
  FROM [ExaminationManagement].[dbo].[tblStudent]

  delete from tblStudent
  where stdId = 'S002'