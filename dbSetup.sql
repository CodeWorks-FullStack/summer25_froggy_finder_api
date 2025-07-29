-- TODO run this sql out in lab!
CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
  ) DEFAULT charset utf8mb4 COMMENT '';

CREATE TABLE
  frogs (
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

ALTER TABLE frogs
ADD COLUMN is_single BOOLEAN DEFAULT TRUE NOT NULL;

DROP TABLE frogs;

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

UPDATE frogs
SET
  color = 'green'
WHERE
  id = 6;

SELECT
  *
FROM
  frogs;

SELECT
  name,
  color
FROM
  frogs;

SELECT
  name AS cool_frog_name
FROM
  frogs
WHERE
  number_of_toes > 10
ORDER BY
  name DESC;

DELETE FROM frogs
WHERE
  id = 5;

SELECT
  *
FROM
  frogs
WHERE
  id = 4;