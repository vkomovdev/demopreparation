﻿WITH CTE AS (
	SELECT DISTINCT
			DP_REQUEST.REQUEST_ID,
			(CONVERT(varchar,DP_REQUEST.LOT_YEAR) + '-' + CONVERT(varchar,DP_PWO.[SEQUENCE])) as LOT,
			DP_REQUEST.LOT_YEAR,
			DP_REQUEST.LOT_ID,
			DP_REQUEST.DATE_REQUEST,
			DP_REQUEST.DIET_NAME,
			DP_REQUEST.REQUEST_AMOUNT,
			DP_REQUEST.REQUEST_UOM,
			DP_CUSTOMER.LAST_NAME,
			DP_CUSTOMER.FIRST_NAME,
			DP_PWO.PWO_CLOSED,
			DP_PWO.PWOS_PRINTED,
			DP_PWO.[SEQUENCE],
			DP_CUSTOMER.FIRST_NAME + ' ' + DP_CUSTOMER.LAST_NAME as REQUESTOR,
			COUNT(*) OVER () AS TotalItems
		FROM 
			DP_REQUEST
			INNER JOIN DP_PWO
			ON DP_REQUEST.REQUEST_ID = DP_PWO.REQUEST_ID
			INNER JOIN DP_CUSTOMER
			ON DP_REQUEST.REQUESTOR_ID = DP_CUSTOMER.CUSTOMER_ID
		WHERE 
			(DP_PWO.COMPLETED_DATE IS NULL
			OR DP_PWO.COMPLETED_BY IS NULL
			OR DP_PWO.MIXER IS NULL)
			@searchText
			@filter
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
		PWO_CLOSED,
		PWOS_PRINTED,
		[SEQUENCE],
		REQUESTOR,
		TotalItems
	FROM CTE
	@orderBy
	OFFSET (@page - 1) * @pageSize ROWS
	FETCH NEXT @pageSize ROWS ONLY;