﻿WITH CTE AS (
	SELECT DISTINCT
			DP_REQUEST.REQUEST_ID,
			DP_REQUEST.LOT_YEAR,
			DP_REQUEST.LOT_ID,
			DP_REQUEST.DATE_REQUEST,
			DP_REQUEST.DIET_NAME,
			DP_REQUEST.REQUEST_AMOUNT,
			DP_REQUEST.REQUEST_UOM,
			DP_CUSTOMER.LAST_NAME,
			DP_CUSTOMER.FIRST_NAME,
			DP_CUSTOMER.FIRST_NAME + ' ' + DP_CUSTOMER.LAST_NAME as REQUESTOR,
			COUNT(*) OVER () AS TotalItems,
			(CONVERT(varchar,DP_REQUEST.LOT_YEAR) + ' ' + CONVERT(varchar,DP_REQUEST.LOT_ID)) AS LOT
		FROM 
		DP_REQUEST 
			LEFT JOIN DP_CUSTOMER 
			ON DP_REQUEST.REQUESTOR_ID = DP_CUSTOMER.CUSTOMER_ID 
		WHERE ((DP_REQUEST.LOCK = 0)  
				OR  (DP_REQUEST.REQUEST_ID IN 
			(SELECT DISTINCT DP_PWO.REQUEST_ID 
				FROM DP_PWO WHERE PWOS_PRINTED = 0)))
			AND DP_REQUEST.ISDELETED = 'N'
			AND DP_REQUEST.LOT_YEAR  > (SELECT TOP 1 Value FROM DP_APP_SETUP)
	)
	SELECT 
		REQUEST_ID,
		LOT,
		LOT_YEAR,
		LOT_ID,
		DATE_REQUEST,
		DIET_NAME,
		REQUEST_AMOUNT,
		REQUEST_UOM,
		LAST_NAME,
		FIRST_NAME,
		REQUESTOR,
		TotalItems	
	FROM CTE
	@orderBy
	OFFSET (@page - 1) * @pageSize ROWS
	FETCH NEXT @pageSize ROWS ONLY;