use "forumdb"  

go

/* Create new table "forum".*/
create table "forum" ( 
	"forum_id" int identity not null,
	"name" text null)  

go

alter table "forum"
	add constraint "forum_PK" primary key ("forum_id")   


go

/* Create new table "forum".*/
create table "forum_post" ( 
	"forum_post_id" int identity not null,
	"author" text null,
	"topic" text null,
	"body" text null,
	"date" datetime null,
	"answer" int null,
	"topic_id" int null,
	"level" int default -1 null,
	"answers" bit default 0 null,
	"forum_id" int default (1) null)  

go

alter table "forum_post"
	add constraint "forum_post_PK" primary key ("forum_post_id")   


go

/* Add foreign key constraints to table "forum_post".*/
alter table "forum_post"
	add constraint "forum_forum_post_FK1" foreign key (
		"forum_id")
	 references "forum" (
		"forum_id")  

go

/*Add forum data to forum table*/
insert into forum
(name) values ('Демонстрационный форум')
