SELECT DP_LOCATION.LOCATION_ID,
       DP_LOCATION.DELIVER_DESCRIPTION,
       DP_LOCATION.DELIVER_BUILDING,
       DP_LOCATION.DELIVER_FLOOR,
       DP_LOCATION.DELIVER_LAB,
       DP_LOCATION.BUSINESS_UNIT_NUMBER,
       DP_LOCATION.LOCK,
       COUNT(*) OVER () AS TotalItems
FROM DP_LOCATION
@orderBy
OFFSET (@page - 1) * @pageSize ROWS
FETCH NEXT @pageSize ROWS ONLY;