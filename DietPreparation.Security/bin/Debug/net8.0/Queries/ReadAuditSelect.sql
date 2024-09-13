WITH CTE AS (
		SELECT 
			AuditLogNumber, 
			CHANGE_TYPE, 
			CHANGE_TIMESTAMP, 
			LOT_YEAR, 
			LOT_ID,
			DIET_NAME,
			COUNT(*) OVER () AS TotalItems
		FROM DP_AUDIT_MAIN 
		WHERE 1=1
		@filter
		)
		SELECT 
			AuditLogNumber, 
			CHANGE_TYPE, 
			CHANGE_TIMESTAMP, 
			LOT_YEAR, 
			LOT_ID,
			DIET_NAME,
			TotalItems	
		FROM CTE
		@orderBy
		OFFSET (@page - 1) * @pageSize ROWS
		FETCH NEXT @pageSize ROWS ONLY;