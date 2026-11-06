mysqldump : Имя "mysqldump" не распознано как имя командлета, функции, файла сценария или выполняемой программы. Проверьте п
равильность написания имени, а также наличие и правильность пути, после чего повторите попытку.
строка:1 знак:1
+ mysqldump -u root -p --databases booking --result-file=booking_backup ...
+ ~~~~~~~~~
    + CategoryInfo          : ObjectNotFound: (mysqldump:String) [], CommandNotFoundException
    + FullyQualifiedErrorId : CommandNotFoundException
