use UrlShortner;

create table Urls(
	url_id uniqueidentifier not null,
	url_long nvarchar(max) not null,
	url_short nvarchar(max) not null,
	created_date datetime not null

	constraint pk_url_id primary key (url_id)
)