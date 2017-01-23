

delete from analizer_hist where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from analizer where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from analizer_cfg where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from bmodems where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from chartsettings where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from datacurr where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from datawork where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from hcmessages where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from logcall where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from missingarch where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));


delete from missingpass where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from plancall where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from qlist where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));


delete from rcw where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from valuebounds where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from webreport where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from webreqest where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from webtemplate where id_bd in 
(select id_bd from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41));

delete from bdevices where id_bu in (select id_bu from bbuildings where id_grp !=41);

delete from bbuildings where id_grp !=41;
delete from bgroups where id_grp!=41;
commit;
