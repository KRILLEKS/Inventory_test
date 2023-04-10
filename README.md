# ENG
## About project in general
Items data saved as scriptableObject. Path: "Resources/ScriptableObjects".
Here you have InventoryData and differentItems data
I used Odin to make the objects comfortable to edit

Inventory saved and loaded automatically. Data saved as json in %AppData%
You can delete all data in the Tools (unity top menu)
## About code
I almost didn't use MonoBehaviour at all. (Couple classes)
### Architecture
This project was focused around architecture for this particular case. So there is no Game state machine, for example.
It's a bit messy because of it. Cause save and load we want to see in SaveDataState and LoadDataState accordingly.
Also, we want to have bootstrap state where some services will be registered, and some classes (like fabrics or itemProvider) will be initialized.
I didn't add state machine or any advanced architecture because there is no point to make such for just one inventory.
Everything scales well and any features can be added easily. Also, any architecture features can be made from scratched or added in future if needed.

### Inspector
I worked a lot with Odin, a lot with UI. Made custom tools and custom inspectors.
So I can make very nice looking inspector (I can do it not only with odin but write custom inspectors as well for something complex), tools or architecture.
You can see example of it in "Resources/ScriptableObjects/Items". Looks convenient to me

# RUS
## О проекте в целом
Предметы сохранены, как scriptableObjects. Путь: "Resources/ScriptableObjects".
Тут содержится Данные об инвентаре и данные о разных предметах.
Я использовал Odin чтобы можно было комфортно редактировать объекты

Инвентарь сохраняется и загружается автоматически. Данные сохраняются, как json файл в %AppData%
Вы можете удалить все файлы сохранения в меню "Tools" (меню сверху в юнити)
## О коде
### Архитектура
Этот проект был ориентирован на разработку архитектуры для данной конкретной задачи. То есть тут нет, например, машины состояний
Из-за этого код может выглядеть слегка неаккуратно. Так как сохранение и загрузку мы хотим видеть в отдельных состояниях (SaveDataState and LoadDataState).
Так же у нас должно быть bootstrap состояние, где мы будем регистрировать сервисы и инициализировать некоторые классы, как фабрики или itemProvider.
Я не добавлял машину состояний или какие-либо продвинутые архитектурные решения, ибо в этом нет смысла при создании лишь одного инвентаря.
Все хорошо масштабируется и любые механики могут быть легко добавлены. Любые архитектурные решения могут быть сделаны с нуля или добавлены в будущем, при необходимости.

### Inspector
У меня много опыта работы с Odin, много с UI. Я создавал кастомные инструменты и инспекторы.
Так что я могу сделать хорошо выглядевший инспектор (Не только с помощью одина, но и могу написать свой кастомный инспектор для чего-то сложного), инструменты или архитектуру.
Вы можете посмотреть пример в "Resources/ScriptableObjects/Items". По мне, выглядит удобно