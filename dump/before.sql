drop user counters cascade
--  ~46 sec

create user counters
identified by counters
default tablespace users
temporary tablespace temp
quota unlimited on users
-- ~0,063sec 

grant connect, dba, resource
to counters
-- ~0,047sec
/*******************************************
repear invalid objects after database import
View TAB_COL_COMMENT has references to 
SYS.COL$
SYS.COM$
SYS.OBJ$

create or replace view tab_col_comment as
select o.name tablename, c.name coln, co.comment$ cdesc
from sys.obj$ o, sys.col$ c, sys.com$ co
where o.owner# = userenv('SCHEMAID')
  and o.type# in (2, 4)
  and o.obj# = c.obj#
  and c.obj# = co.obj#(+)
  and c.intcol# = co.col#(+)
  and bitand(c.property, 32) = 0 /* not hidden column */
/*******************************************/
--select * from user_objects where status = 'IVALID'
--select * from dba_objects a where a.status='INVALID'

select * from all_errors where name = 'TAB_COL_COMMENT' and OWNER  = 'COUNTERS'

--ORA-01031: insufficient privileges
-- login as system AS SYSDBA
grant select on SYS.obj$ to counters;
grant select on SYS.col$ to counters;
grant select on SYS.com$ to counters;

/*******************************************
repear invalid objects after database import
View V$USER has references to SYS.V_$SESSION

create or replace view v$user as
select machine,terminal,program,osuser
    from sys.v_$session where audsid=userenv('SESSIONID')
*******************************************************/
--select * from sys.v_$session
grant select on SYS.V_$SESSION to counters
-- прежде создать directory
-- 2011.12.24
-- В Oracle версий 10.x.x, 11.x.x предлагается работать 
-- с параметром DIRECTORY вместо UTL_FILE_DIR

-- Создание переменной utl_file_dir, в этом случае нет 
-- необходимости создавать DIRECTORY

/*
В файловой структуре ОС должен быть определен соответствующий каталог.
*/
-- create or replace directory mydir as 'd:\database\mydir';
create or replace directory utl_file_dir as 'd:\database\utl';

-- 2011.12.24
-- ? Oracle версий 10.x.x, 11.x.x предлагает работать
-- с параметром DIRECTORY вместо UTL_FILE_DIR

-- создание переменной utl_file_dir, в этом случае нет 
-- необходимости создавать DIRECTORY
alter system set utl_file_dir='D:\database\utl' scope=SPFILE
commit

----------------------------------------------
select directory_path from dba_directories

grant read on directory SYS.UTL_FILE_DIR to COUNTERS with grant option





