 SET @ret=( select COUNT(*) from MOCHATRIHOMON  m
  join  PACIENTPPC p on  m.pacient_id=p.pacient_id
  join  OTD o  on p.otd_id=o.otd_id
  where (o.otd_id=43 OR o.otd_id=44) 
   AND m.data >= '06/01/2011 00:00:00' AND m.data<=  ' 06/30/2011 23:59:59')



 insert into @pacientfpmp
    select p.pacient_id, p.noomer,p.fio,o.name_otdsokr,m.Общий анализ мочи (ОАМ) as analzname   from MOCHAOBCH  m
  join  PACIENTPPC p on  m.pacient_id=p.pacient_id
  join  OTD o  on p.otd_id=o.otd_id
  where  (o.otd_id=43 OR o.otd_id=44)
  AND  m.data >= '06/01/2011 00:00:00' AND m.data<=  ' 06/30/2011 23:59:59'


insert into @pacientfpmp
    select p.pacient_id, p.noomer,p.fio,o.name_otdsokr,'Общий анализ мочи (ОАМ)'  from MOCHAOBCH  m
  join  PACIENTPPC p on  m.pacient_id=p.pacient_id
  join  OTD o  on p.otd_id=o.otd_id
  where  (o.otd_id=43 OR o.otd_id=44)
  AND  m.data >= '06/01/2011 00:00:00' AND m.data<=  ' 06/30/2011 23:59:59'