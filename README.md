Цель библиотеки - строгая типизация идентификаторов сущностей и скрытие типа
идентификатора применяемого при хранении сущности.

Тип идентификатора (например int) заменяется типом UserUid и нигде не должен 
встречаться базовый тип (int). Этот тип также ипользуется при работе с БД (Dapper)
и конвертируется на лету. Это форма универсального идентификатора с интерфейсом
IUid. Для каждого типа нужно определять свою реализацию. 

Пример создания типа в тестах.

Особенность формата Uid что он все идентифкаторы хранит в виде строк и чтобы 
понять что за обьект в этом идентификаторе использует префикс в строке. 

Создание Uid (UserUid) из строки всегда делается с проверкой по типу обьекта и
префикса идентификатора. Если создался - значит формат валидный

Префиксы для типов задаются при инициализации.
