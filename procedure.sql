CREATE OR REPLACE PROCEDURE public.insertdata(name1 text, lastname text, postcode text, city text, phonenumber text)
 LANGUAGE plpgsql
AS $procedure$
DECLARE
-- NOTHING
begin
	if not exists (
	SELECT * FROM "Data" WHERE "Name" = name1
	AND "LastName" = lastname
	AND "PostCode" = postcode
	AND "City" = city
	AND "PhoneNumber" = phonenumber)
	then 
		INSERT INTO public."Data" ("Name", "LastName", "PostCode", "City", "PhoneNumber")
		VALUES (name1, lastName, postcode, city, phonenumber);
	end IF ;
end;
$procedure$
;
