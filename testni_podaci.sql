use my_dictionary;

insert into word values (1,'key', "kljuc", 0, 0, 0);
insert into word values (2,'car', "auto", 0, 0, 0);
insert into word values (3,'Good call!', "Dobra ideja!", 1, 0, 0);
insert into word values (4,'Be in a pickle', "Biti u teskoj situaciji", 1, 0, 0);
insert into word values (5,'table', "sto", 0, 0, 0);
insert into word values (6,'child', "dijete", 0, 0, 0);
insert into word values (7,'flower', "cvijet", 0, 0, 0);
insert into word values (8,'tree', "drvo", 0, 0, 0);
insert into word values (9,'border', "granica", 0, 0, 0);
insert into word values (10,'sad', "tuzan", 0, 0, 0);
insert into word values (11,'happy', "srecan", 0, 0, 0);
insert into word values (12,'castle', "zamak", 0, 0, 0);
insert into word values (13,'hall', "hodnik", 0, 0, 0);
insert into word values (14,'news', "vijesti", 0, 0, 0);

insert into word values (15,'My word!', 'Used to express suprise or astonishment', 1, 0, 0,);
insert into word values (16,'spunky', 'energetic, confident, showing courage' , 1, 0, 0);
insert into word values (17,'Long shot', 'something unlikely to be successful' , 1, 0, 0);
insert into word values (18,'ditto', 'used to agree' , 1, 0, 0);
insert into word values (19,'slowpoke', 'someone who is walking or doing something too slowly' , 1, 0, 0);
insert into word values (20,'keep at bay', 'to prevent something from happening' , 1, 0, 0);
insert into word values (21,'pipe dream', 'an idea, dream or plan that is impossible to happen' , 1, 0, 0);
insert into word values (22,'kook/kooky', 'someone whose ideas or actions are eccentric or insanse' , 1, 0, 0);
insert into word values (23,'Give someone ammunition', 'to say someone something which they can use against you' , 1, 0, 0);
insert into word values (24,'You are welling up', 'You are so emotionaly moved and your eyes are filled by tears' , 1, 0, 0);


UPDATE word set `delete` = 0 WHERE id >= 1;
Select * from word;

