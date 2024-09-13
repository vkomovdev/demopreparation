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
		)
		SELECT
			REQUEST_ID, 
			DIET_NAME,
			LOT_YEAR,
			LOT_ID
		FROM CTE