select 
CUSTOMER_ID as Id, 
FIRST_NAME as FirstName, 
LAST_NAME as LastName 
from DP_CUSTOMER 
where CUSTOMER_TYPE <> @customerType 
order by LAST_NAME, FIRST_NAME