# SundayGameStudio

Credits: 
https://sketchfab.com/3d-models/gege-8ac7828988394a15b05b699948863fae

Задание 1
Реализовать минималистичную галерею просмотра изображений.

На сервере лежит коллекция из 66 изображений, все они доступны по следующему URL:
http://data.ikppbb.com/test-task-unity-data/pics/

Файлы пронумерованы по порядку, поэтому чтобы получить путь к каждому изображению, нужно к базовому URL добавить номер изображения и “.jpg”, например:
http://data.ikppbb.com/test-task-unity-data/pics/33.jpg

Необходимо реализовать на Unity приложение, состоящее из трех основных сцен:

Меню. На этой сцене по центру располагается только кнопка “Галерея”. При тапе на эту кнопку на 2-3 секунды появляется сцена Загрузки с прогресс-баром и процентами загрузки. После этого сцена Загрузки исчезает и появляется Галерея.
Галерея. На этом экране в две колонки отображаются первые несколько изображений из коллекции на сервере (столько, сколько помещается на экран). По мере скроллинга экрана вниз, следующие изображения подгружаются с сервера “на лету”. Постепенно, проскролив до конца, можно увидеть все 66 изображений в две колонки. При нажатии на конкретное изображение происходит переход на сцену Просмотр, можно тоже через сцену Загрузки с прогресс-баром.
Просмотр. Выбранное изображение отображается на весь экран. Кнопка “Назад” или “крестик” для возврата в Галерею. 

Первые две сцены должны быть зафиксированы только в портретной ориентации. Третья сцена (Просмотр изображения) - может менять ориентацию в зависимости от поворота устройства, на всех платформах.

Желательно, чтобы при сборке приложения под Android и iOS сохранились нативные возможности переходов между сценами: кнопка Back системной панели Android, свайп на iOS и тп.

Задание 2
3D. Выполнить один или несколько из вариантов ниже, на ваш выбор, в зависимости от того, на сколько вы хотите продемонстрировать ваши навыки 🙂

Вариант 1
Реализовать зацикленное вращение любого 3д объекта, например, монетки. При тапе на объект он меняет цвет. Все остальные детали - на ваше усмотрение.

Вариант 2
Реализовать простую 3д-модель машины. На экране есть кнопки управления (вперед, назад, влево, вправо). Машина может ездить вперед, назад и поворачивать. Все остальные детали, например, дорога и препятствия, звуки, свет фар и т.п. - по желанию.

Вариант 3
Реализовать 3д-модель гуманоида. Гуманоид может бегать, поворачивать, прыгать. Добавить анимацию стрельбы (поднимает и вытягивает вперед руки). Есть возможность стрелять во время бега. Задача со звездочкой: оставлять следы (круги) под ногами.

