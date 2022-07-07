
DROP TABLE ers.Users;

DROP TABLE ers.Tickets;

DROP SCHEMA ers;



CREATE SCHEMA ers;

CREATE TABLE ers.Users (
	user_ID varchar(255) UNIQUE NOT NULL,
	username varchar(255) UNIQUE NOT NULL,
	password varchar(255) NOT NULL,
	role varchar(255) NOT NULL,
	PRIMARY KEY (user_ID)
);



CREATE TABLE ers.Tickets (
	ticket_ID varchar(255) UNIQUE NOT NULL,
	author_fk varchar(255) NOT NULL FOREIGN KEY REFERENCES ers.Users(user_ID),
	resolver_fk varchar(255) NOT NULL FOREIGN KEY REFERENCES ers.Users(user_ID),
	description varchar(255) NOT NULL,
	status varchar(255) NOT NULL,
	amount decimal NOT NULL,
	PRIMARY KEY (ticket_ID)
);

INSERT INTO ers.Users (user_ID, username, password, role) VALUES ('ManagerID', 'ManagerUser', 'ManagerPass', 'Manager');
INSERT INTO ers.Users (user_ID, username, password, role) VALUES ('EmployeeID', 'EmployeeUser', 'EmployeePass', 'Employee');




