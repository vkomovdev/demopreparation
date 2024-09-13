WITH CTE AS (		
		SELECT 
			[BASAL_DIET_ID],
			[BASAL_DIET_CODE],
			[BASAL_DIET_NAME],
			COUNT(*) OVER () AS TotalItems
		FROM DP_BASAL_DIET
		)
		SELECT
			[BASAL_DIET_ID],
			[BASAL_DIET_CODE],
			[BASAL_DIET_NAME],
			TotalItems
		FROM CTE
		@orderBy
		OFFSET (@page - 1) * @pageSize ROWS
		FETCH NEXT @pageSize ROWS ONLY;