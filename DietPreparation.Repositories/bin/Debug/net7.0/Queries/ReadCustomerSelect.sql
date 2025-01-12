﻿WITH CTE AS (
		SELECT 
				DP_CUSTOMER.CUSTOMER_ID, 
				TRIM(DP_CUSTOMER.FIRST_NAME) as FIRST_NAME,
				DP_CUSTOMER.MIDDLE_INITIAL, 
				DP_CUSTOMER.LAST_NAME,
				TRIM(DP_CUSTOMER.EMAIL) as EMAIL,
				DP_CUSTOMER.CUSTOMER_TYPE,
				DP_CUSTOMER.BUILDING,
				DP_CUSTOMER.UNIT,
				DP_CUSTOMER.LOCK,
				COUNT(*) OVER () AS TotalItems
			FROM 
			DP_CUSTOMER
			@customerIdFilter
		)
		SELECT 
			CUSTOMER_ID,
			FIRST_NAME,
			MIDDLE_INITIAL,
			LAST_NAME,
			EMAIL,
			CUSTOMER_TYPE,
			BUILDING,
			UNIT,
			LOCK,
			TotalItems	
		FROM CTE
		@orderBy
		OFFSET (@page - 1) * @pageSize ROWS
		FETCH NEXT @pageSize ROWS ONLY;