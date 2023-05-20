select @@VERSION
select @@SERVERNAME


SELECT [media_set_id]
   ,[family_sequence_number]
   ,[media_family_id]
   ,[media_count]
   ,[logical_device_name]
   ,[physical_device_name]
   ,[device_type]
   ,[physical_block_size]
   ,[mirror]
 FROM [msdb].[dbo].[backupmediafamily]
 
BACKUP DATABASE [shortpoet] 
TO DISK = N'/var/opt/mssql/backup/shortpoet.bak' 
WITH NOFORMAT, NOINIT,  NAME = N'shortpoet-Full Database Backup', 
SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO


Restore FilelistOnly from disk = N'/usr/config/ShortpoetDb.bacpac'
RESTORE DATABASE [shortpoet]
FROM DISK = N'/usr/config/ShortpoetDb.bacpac'
WITH REPLACE

select @@VERSION
select @@SERVERNAME

RESTORE HEADERONLY
FROM DISK = N'/usr/config/ShortpoetDb-2023-5-20-15-21.dacpac'
GO