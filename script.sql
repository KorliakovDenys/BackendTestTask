CREATE DATABASE SomeDatabase;

USE SomeDatabase;

CREATE TABLE Client
(
    DeviceToken NVARCHAR(255) PRIMARY KEY,
    Color       NVARCHAR(255) NOT NULL,
    Price       INT           NOT NULL
);

-- для перевірки кількості клієнтів з тими, чи іншими кольорами, або цінами
SELECT C.Color, COUNT(*)
FROM Client AS C
GROUP BY C.Color

SELECT C.Price, COUNT(*)
FROM Client AS C
GROUP BY C.Price