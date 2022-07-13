DROP TABLE ers.Users;

DROP TABLE ers.Tickets;

DROP SCHEMA ers;



CREATE SCHEMA ers;

CREATE TABLE ers.Users (
	user_ID INT IDENTITY,
	username VARCHAR(50) UNIQUE NOT NULL,
	password VARCHAR(50) NOT NULL,
	role VARCHAR(8) NOT NULL CHECK (role IN ('Manager', 'Employee')),
	PRIMARY KEY (user_ID)
);



CREATE TABLE ers.Tickets (
	ticket_ID INT IDENTITY,
	author_fk INT NOT NULL FOREIGN KEY REFERENCES ers.Users(user_ID),
	resolver_fk INT FOREIGN KEY REFERENCES ers.Users(user_ID),
	description VARCHAR(127) NOT NULL,
	status VARCHAR(8) NOT NULL CHECK (status IN ('Pending', 'Approved', 'Denied')),
	amount DECIMAL NOT NULL,
	PRIMARY KEY (ticket_ID)
);

INSERT INTO ers.Users (username, password, role) VALUES ('ManagerUser', 'ManagerPass', 'Manager');
INSERT INTO ers.Users (username, password, role) VALUES ('EmployeeUser', 'EmployeePass', 'Employee');

INSERT INTO ers.Tickets (author_fk, resolver_fk, description, status, amount) VALUES (1, 2, 'Description of Ticket', 'Pending', 120.02);

SELECT * FROM ers;
CREATE TABLE ers;

SELECT * FROM ers.Users;
SELECT * FROM ers.Tickets;

