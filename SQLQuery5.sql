select * from Vehicles order by  AvailableOn desc;

select * from Vehicles a join Cars b on a.RegNumber like b.RegNumber;