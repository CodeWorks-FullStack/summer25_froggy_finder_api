-- run this sql out in lab!
CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
  ) DEFAULT charset utf8mb4 COMMENT '';

-- creates a table of data in your database (collection)
CREATE TABLE
  frogs (
    -- ids will be auto-generated, with the first row inerted into the database defaulting to 1, the second 2, etc.
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    color VARCHAR(255),
    species ENUM (
      'bullfrog',
      'treefrog',
      'dartfrog',
      'glass',
      'pacman',
      'toad',
      'frog'
    ) NOT NULL,
    is_poisonous BOOLEAN NOT NULL DEFAULT FALSE,
    number_of_toes TINYINT (25) UNSIGNED,
    is_single BOOLEAN DEFAULT TRUE NOT NULL
  );

-- you can add/alter columns after the table has been created
ALTER TABLE frogs
ADD COLUMN is_single BOOLEAN DEFAULT TRUE NOT NULL;

-- removes table from database and all rows within it
DROP TABLE frogs;

-- adds a row to a table
INSERT INTO
  frogs (
    name,
    color,
    is_poisonous,
    is_single,
    number_of_toes,
    species
  )
VALUES
  ('mick', 'brown', FALSE, TRUE, 19, 'bullfrog');

-- updates a row in a table (DON'T FORGET THE WHERE CLAUSE)
UPDATE frogs
SET
  color = 'green'
WHERE
  id = 6;

-- selects all columns and rows out of a table
SELECT
  *
FROM
  frogs;

-- selects all rows but only the name and color columns
SELECT
  name,
  color
FROM
  frogs;

-- selects all columns and a single row
SELECT
  *
FROM
  frogs
WHERE
  id = 4;

-- delete a single row (DON'T FORGET WHERE CLAUSE)
DELETE FROM frogs
WHERE
  id = 5;

-- goofy stuff
SELECT
  name AS cool_frog_name,
  number_of_toes AS toes
FROM
  frogs
WHERE
  number_of_toes > 10
ORDER BY
  name DESC;