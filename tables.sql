
CREATE TABLE public.logs (
	id serial NOT NULL DEFAULT nextval('logs_id_seq'::regclass),
	application varchar(100) NULL,
	"logged" text NULL,
	"level" varchar(100) NULL,
	message varchar(8000) NULL,
	logger varchar(8000) NULL,
	callsite varchar(8000) NULL,
	"exception" varchar(8000) NULL,
	CONSTRAINT logs_pkey PRIMARY KEY (id)
);


CREATE TABLE public."Data" (
	"Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	"Name" text NOT NULL,
	"LastName" text NOT NULL,
	"PostCode" text NOT NULL,
	"City" text NOT NULL,
	"PhoneNumber" text NOT NULL,
	CONSTRAINT "PK_Data" PRIMARY KEY ("Id")
);

-- NOTE: in code is ensure database created executed fot table Data