
## Лабораторная работа 2
Создание модели предметной области
![Модель предметной области](/images/%D0%A1%D0%BD%D0%B8%D0%BC%D0%BE%D0%BA%20%D1%8D%D0%BA%D1%80%D0%B0%D0%BD%D0%B0%202024-04-02%20131522.png)

При запуске системы начинается Игра, Игроки регистрируются и выбирают количество раундов. 

У каждого игорка записана его очередность хода.

Игра содержит количество раундов, дату и время начала игры. 

Несколько раундов принадлежат одной игре. У каждого раунда есть свой номер и количество очков.

Ходы совершаются игроками. Каждый игрок во время каждого раунда делает несколько ходов.

Чтобы сделать ход, игрок делает один или два броска и получет по одому значению каждый бросок(от 1 до 6). Каждый бросок является частью хода и имеет номер.

Исходя из значений бросков закрываются сектора(от 1 до 9).

По исходу всех ходов в раунде, у игрока меняется значение количества очков в завершенном раунде.

По исходу каждого раунда у игрока записывается общее количество очков.

