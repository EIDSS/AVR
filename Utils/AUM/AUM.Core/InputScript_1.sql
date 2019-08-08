SET NOCOUNT ON;
SELECT
	REPLACE(
	REPLACE(
	REPLACE(
	REPLACE(
				CAST(
						(
							SELECT
								src.definition + ''
							FROM (
								SELECT
									ROW_NUMBER() OVER(ORDER BY s.crdate) rn
									, '/************************************************************'
									+ CHAR(10)
									+ s.NAME
									+ CHAR(10)
									+ '************************************************************/'
									+ CHAR(10)
									+ 'SET QUOTED_IDENTIFIER OFF'
									+ CHAR(10)
									+ 'GO'
									+ CHAR(10)
									+ 'SET ANSI_NULLS OFF'
									+ CHAR(10)
									+ 'GO'
									+ CHAR(10)
									+ CHAR(10)
									+ 'if exists (select *	from dbo.sysobjects	where id = object_id(N' + '''' + s.NAME + '''' + ')	and xtype in (N''V'', N''IF'', N''FN'', N''TF'', N''P''))'
									+ CHAR(10)
									+ 'drop '
									+ case
										when xtype in (N'V')
											then 'View'
										when xtype in (N'IF', N'FN', N'TF')
											then 'Function'
										else 'Procedure'
									end
									+ ' [dbo].[' + s.NAME + ']'							
									+ CHAR(10)
									+ 'GO'
									+ CHAR(10)
									+ CHAR(10)
									+ sm.definition
									+ CHAR(10)
									+ CHAR(10)
									+ 'GO'
									+ CHAR(10)
									+ CHAR(10)
									+ 'SET QUOTED_IDENTIFIER OFF'
									+ CHAR(10)
									+ 'GO'
									+ CHAR(10)
									+ CHAR(10)
									+ 'SET ANSI_NULLS ON'
									+ CHAR(10)
									+ 'GO'
									+ CHAR(10)
									+ CHAR(10)
									+ 'GO'
									+ CHAR(10)
									+ CHAR(10)
									+ CHAR(10) AS definition
								FROM dbo.sysobjects s
								JOIN sys.sql_modules sm ON
									sm.[object_id] = s.id
								WHERE xtype in (N'V', N'IF', N'FN', N'TF', N'P')
									AND category = 0
									AND s.name <> 'fnSiteID'
									AND s.name <> 'fnGetContext'
									AND s.name <> 'fnSiteOption'
								) src
							WHERE rn <= 300
							FOR XML PATH('')
						)
						AS NVARCHAR(MAX)
					)
			, '&#x0D;'
			, ''
			)
			, '&gt;'
			, '>'
			)
			, '&lt;'
			, '<'
			)
			, '&amp;'
			, '&'
			)
SET NOCOUNT OFF