SET TIME ZONE 'UTC';


/*
USERS (ПОЛЬЗОВАТЕЛИ)
- uid (ID пользователя)
- first_name (имя)
- last_name (фамилия)
- username (логин)
- password_hash (хэшированный пароль)
- reg_date (дата регистрации)
- remove_state (статус удалённости пользователя)
*/


DROP TABLE IF EXISTS users CASCADE;
CREATE TABLE users(
	uid INT PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	first_name VARCHAR(32) NOT NULL,
	last_name VARCHAR(32) NOT NULL,
	username VARCHAR(32) NOT NULL UNIQUE,
	reg_date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
	remove_state BOOLEAN NOT NULL DEFAULT FALSE
);


/*
AUTH_DATA (ДАННЫЕ АВТОРИЗАЦИИ)
- uid (ID пользователя)
- password_hash (хэшированный пароль)
*/


DROP TABLE IF EXISTS auth_data CASCADE;
CREATE TABLE auth_data(
	uid INT PRIMARY KEY REFERENCES users(uid),
	password_hash VARCHAR(64) NOT NULL
);


/*
ACCESS_TOKEN (ТОКЕН ДОСТУПА)
- uid (ID пользователя)
- token (токен доступа)
*/


DROP TABLE IF EXISTS access_token CASCADE;
CREATE TABLE access_token(
	uid INT NOT NULL REFERENCES users(uid),
	token VARCHAR(64) NOT NULL
);



-- ЗАПОЛНЯЕМ ТЕСТАМИ

/*
--issstasevich:testtest
INSERT INTO users(first_name, last_name, username, password_hash)
VALUES
('Иван', 'Стасевич', 'issstasevich', '37268335dd6931045bdcdf92623ff819a64244b53d0e746d438797349d4da578');
--romkakis:testtest
INSERT INTO users(first_name, last_name, username, password_hash)
VALUES
('Роман', 'Кислицын', 'romkakis', '37268335dd6931045bdcdf92623ff819a64244b53d0e746d438797349d4da578');
--steshablizkaya:testtest
INSERT INTO users(first_name, last_name, username, password_hash)
VALUES
('Степанида', 'Красножен', 'steshablizkaya', '37268335dd6931045bdcdf92623ff819a64244b53d0e746d438797349d4da578');
--katyperrythebest:testtest
INSERT INTO users(first_name, last_name, username, password_hash)
VALUES
('Katy', 'Perry', 'katyperrythebest', '37268335dd6931045bdcdf92623ff819a64244b53d0e746d438797349d4da578');
--milashaumka:testtest
INSERT INTO users(first_name, last_name, username, password_hash)
VALUES
('Милана', 'Хаметова', 'milashaumka', '37268335dd6931045bdcdf92623ff819a64244b53d0e746d438797349d4da578');
--blendermen:testtest
INSERT INTO users(first_name, last_name, username, password_hash)
VALUES
('Вадим', 'Юсупов', 'blendermen', '37268335dd6931045bdcdf92623ff819a64244b53d0e746d438797349d4da578');
*/
