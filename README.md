Цель библиотеки - строгая типизация идентификаторов сущностей и скрытие типа
идентификатора применяемого при хранении сущности.

Тип идентификатора (например int) заменяется типом UserId и нигде не должен 
встречаться базовый тип (int). Этот тип ипользуется при работе с БД (Dapper)

Пример создания типа в тестах.

Также существует универсальный идентификатор с типом Uid в него тоже можно 
конвертировать любой свой тип идентифкатора (типа UserId). Он служит для 
внешних связей относительно микросервиса хранения данных.

Особенность Uid что он все идентифкаторы хранит в виде строк и чтобы понять что 
за обьект в этом идентификаторе использует префикс в строке. Так преобразования 
из Uid в UserId делаются с проверкой по типу и не смогут быть преобразованы из 
другого идентифкатора (не UserId).

Префиксы для типов задаются при инициализации.