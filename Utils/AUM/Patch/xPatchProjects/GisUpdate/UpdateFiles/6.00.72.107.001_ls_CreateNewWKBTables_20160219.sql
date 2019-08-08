-- Purpose: 
-- Customization package: All

-- Script version: 6.00.72.107.001
-- Script name: 6.00.72.107.001_ls_CreateNewWKBTables_20160219.sql
-- Script prerequisites: 

-- Instructions: Script should be applied on EIDSS database version 6.

-- Warning: It affects databases with all installation types.

SET ANSI_NULLS on
SET QUOTED_IDENTIFIER on
GO

ALTER	function [dbo].[fnTriggersWork] ()
returns bit
as
begin
return 0
end
GO

set nocount on
set XACT_ABORT on

BEGIN TRANSACTION;

BEGIN TRY

	-- Customization package for which specific changes should be applied
	declare	@CustomizationPackageName	nvarchar(20)
	set	@CustomizationPackageName = null

	-- Script version
	declare	@Version	nvarchar(20)
	set	@Version = '6.00.72.107.001'

	-- Verify database and script versions
	if	@Version is null
	begin
		raiserror ('Script doesn''t have version', 16, 1)
	end
	else begin


		-- Check if script has already been applied by means of database version
		IF EXISTS (SELECT * FROM tstLocalSiteOptions tlso WHERE tlso.strName = 'DBScript(' + @Version + ')' collate Cyrillic_General_CI_AS)
		begin
			print	'Script with version ' + @Version + ' has already been executed on the database ' + DB_NAME() + N' on the server ' + @@servername + N'.'
		end
		-- Check common (not country-specific) script prerequisites
		else begin

			-- Common part
			IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gisWKBDistrictReady]') AND type in (N'U'))
				AND EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gisWKBDistrict]') AND type in (N'U'))
			BEGIN 
				CREATE TABLE [dbo].[gisWKBDistrictReady](
					[oid] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
					[idfsGeoObject] bigint NOT NULL,
					[Ratio] int NOT NULL,
					[geomShape_3857] geometry NULL,	
					[geomShape_4326] geometry NULL)


				insert into [dbo].gisWKBDistrictReady ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 0 as [Ratio], [geomShape].MakeValid() as geomShape_3857
				from [dbo].[gisWKBDistrict]

				insert into [dbo].gisWKBDistrictReady ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 50 as [Ratio], [geomShape].MakeValid().Reduce(50) as geomShape_3857
				from [dbo].[gisWKBDistrict]

				insert into [dbo].gisWKBDistrictReady ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 100 as [Ratio], [geomShape].MakeValid().Reduce(100) as geomShape_3857
				from [dbo].[gisWKBDistrict]
			END


			IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gisWKBRayonReady]') AND type in (N'U'))
			BEGIN
				CREATE TABLE [dbo].[gisWKBRayonReady](
					[oid] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
					[idfsGeoObject] bigint NOT NULL,
					[Ratio] int NOT NULL,
					[geomShape_3857] geometry NULL,	
					[geomShape_4326] geometry NULL)


				insert into [dbo].gisWKBRayonReady ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 0 as [Ratio], [geomShape].MakeValid() as geomShape_3857
				from [dbo].[gisWKBRayon]

				insert into [dbo].gisWKBRayonReady ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 50 as [Ratio], [geomShape].MakeValid().Reduce(50) as geomShape_3857
				from [dbo].[gisWKBRayon]

				insert into [dbo].gisWKBRayonReady ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 100 as [Ratio], [geomShape].MakeValid().Reduce(100) as geomShape_3857
				from [dbo].[gisWKBRayon]
			END

			
			IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gisWKBRegionReady]') AND type in (N'U'))
			BEGIN
				CREATE TABLE [dbo].[gisWKBRegionReady](
					[oid] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
					[idfsGeoObject] bigint NOT NULL,
					[Ratio] int NOT NULL,
					[geomShape_3857] geometry NULL,	
					[geomShape_4326] geometry NULL)


				insert into [dbo].gisWKBRegionReady ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 0 as [Ratio], [geomShape].MakeValid() as geomShape_3857
				from [dbo].[gisWKBRegion]

				insert into [dbo].gisWKBRegionReady ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 50 as [Ratio], [geomShape].MakeValid().Reduce(50) as geomShape_3857
				from [dbo].[gisWKBRegion]

				insert into [dbo].gisWKBRegionReady ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 100 as [Ratio], [geomShape].MakeValid().Reduce(100) as geomShape_3857
				from [dbo].[gisWKBRegion]
			END


			IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gisWKBSettlementReady]') AND type in (N'U'))
			BEGIN
				CREATE TABLE [dbo].[gisWKBSettlementReady](
					[oid] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
					[idfsGeoObject] bigint NOT NULL,
					[Ratio] int NOT NULL,
					[geomShape_3857] geometry NULL,	
					[geomShape_4326] geometry NULL)
					
				insert into [dbo].[gisWKBSettlementReady] ([idfsGeoObject], [Ratio], [geomShape_3857])
				select [idfsGeoObject], 0 as [Ratio], [geomShape].MakeValid() as geomShape_3857
				from [dbo].[gisWKBSettlement]
			END


			-- Customization-specific part is not needed.

			-- Add version of the current script to the database
			if not exists (select * from tstLocalSiteOptions lso where strName = 'DBScript(' + @Version + ')' collate Cyrillic_General_CI_AS)
				insert into	tstLocalSiteOptions (strName) values ('DBScript(' + @Version + ')')

		end
	end


END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

	declare	@err_number int
	declare	@err_severity int
	declare	@err_state int
	declare	@err_line int
	declare	@err_procedure	nvarchar(200)
	declare	@err_message	nvarchar(MAX)
	
	select	@err_number = ERROR_NUMBER(),
			@err_severity = ERROR_SEVERITY(),
			@err_state = ERROR_STATE(),
			@err_line = ERROR_LINE(),
			@err_procedure = ERROR_PROCEDURE(),
			@err_message = ERROR_MESSAGE()

	set	@err_message = N'An error occurred during script execution.
' + N'Msg ' + cast(isnull(@err_number, 0) as nvarchar(20)) + 
N', Level ' + cast(isnull(@err_severity, 0) as nvarchar(20)) + 
N', State ' + cast(isnull(@err_state, 0) as nvarchar(20)) + 
N', Line ' + cast(isnull(@err_line, 0) as nvarchar(20)) + N'
' + isnull(@err_message, N'Unknown error')

	raiserror	(	@err_message,
					17,
					@err_state
				) with SETERROR

END CATCH;

        
        
IF @@TRANCOUNT > 0
    COMMIT TRANSACTION;

set XACT_ABORT off
set nocount off

SET ANSI_NULLS on
SET QUOTED_IDENTIFIER on
GO

-- Turn on triggers

ALTER	function [dbo].[fnTriggersWork] ()
returns bit
as
begin
return 1 --0
end
GO



