SELECT
     name, object_id, create_date, modify_date
FROM
     sys.tables
	 order by create_date desc