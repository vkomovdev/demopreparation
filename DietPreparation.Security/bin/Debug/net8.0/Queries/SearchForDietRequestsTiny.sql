WITH CTE AS (		
		SELECT 
			REQUEST_ID, 
			DIET_NAME,
			LOT_YEAR,
			LOT_ID
		FROM DP_REQUEST
		WHERE 
			1 = 1
			@filter
			AND DP_REQUEST.LOT_YEAR >= (SELECT TOP 1 Value FROM DP_APP_SETUP)
		)
		SELECT
			REQUEST_ID, 
			DIET_NAME,
			LOT_YEAR,
			LOT_ID
		FROM CTE