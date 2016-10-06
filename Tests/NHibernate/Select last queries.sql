select 
	convert(varchar(max), stats.sql_handle, 2) as handle,
	stats.last_execution_time as time, 
	text.text, 
	stats.execution_count as count
from sys.dm_exec_query_stats as stats 
	cross apply  sys.dm_exec_sql_text(stats.sql_handle) as text
where 
	text.text like '%{search}%' and stats.last_execution_time >= '{time}'
	and text.text not like '%sys.dm_exec_query_stats%' 
--order by
--	stats.last_execution_time desc
