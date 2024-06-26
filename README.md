## Art Gallery
# Мобильное приложение для системы картинной галереи


1. BaseEntity:
  - ID - уникальный идентификатор, который присваивается каждому объекту в системе для однозначной идентификации.

2. PersonalInfo:
- FirstName -  Имя пользователя.
- LastName - Фамилия пользователя.
- EmailAddress - Адрес электронной почты пользователя.
- PhoneNumber - Номер телефона пользователя.
- ChangeInfo() - Метод для изменения информации о пользователе.

3. Category:
- Name -  Наименование категории.
- Description - Краткое описание, например, на основании каких условий, вы относитесь к той или иной категории пользователей.
- Price - Цена, формируемая для каждой категории.

4. Painting:
- Наследуется от класса BaseEntity
- Name - Название картины.
- Artist - Художник картины.
- YearOfCreation - Год создания картины.
- Image - Изображение картины.
- ChangeInfo() - Метод для изменения информации о картине.
- ChangeImage() - Метод для изменения изображения картины.

5. Exhibition:
Наследуется от класса BaseEntity
- Name - Название выставки.
- Paintings - Список картин, представленных на выставке.
- Date - Дата проведения выставки.
- ChangeInfo() - Метод, позволяющий изменить информацию о выставке.
- AddPainting() - Метод, который добавляет новую картину в список представленных на выставке.
- RemovePainting() - Метод, который удаляет картину из списка представленных на выставке.

6. Ticket:
Наследуется от класса BaseEntity
- NameOfExhibition - Название выставки, на которую действует данный билет.
- Time - Время начала доступа к выставке для держателя билета..
- Date - Дата, на которую действителен данный билет.
- CategoryOfTicket - Свойство, указывающее на категорию билета (например, взрослый, студенческий, детский и т. д.), определяющее стоимость.

7. Order:
Наследуется от класса BaseEntity
- Tickets - билеты, добавленные в заказ.
- OrderDate - Дата заказа.
- Status - Статус заказа.
- TotalPrice - Общая сумма заказа.
- GiveInfoAboutOrder() - Метод для получения информации о заказе.
- AddTicket() - Метод для добавления билета в заказ.
- RemoveTicket() - Метод для удаления билета из заказа.
- CalculateTotalPrice() - Метод для расчета общей суммы заказа.

8. BankCard:
- Number -  Номер карты.
- Expires - Дата истечения срока действия банковской карты.
- CVV - Код безопасности.
- ChangeInfo() - Метод для изменения информации о карте.

9. Membership:
- CategoryOfMembership - Свойство, которое указывает на категорию или уровень членства (например, стандартное, премиум и т. д.).
- RegistrationDate - Свойство, определяющее дату регистрации членства.
- ExpirationDate - Свойство, указывающее на дату истечения срока членства.
- QRCode - Позволяет пользователям с членством получить привилегированный доступ к выставке, показывая его при входе в галерею и демонстрируя их право на ранний доступ.
- CheckAvailability() - Метод, который может быть использован для проверки текущего статуса членства, включая его активность и дату истечения.

10. ArtGalleryInfo:
- Name - Свойство, содержащее название картинной галереи.
- Address - Свойство, определяющее местоположение картинной галереи.
- Schedule - Свойство, содержащее информацию о часах работы галереи.
- CollectionOfPaintings - Свойство, которое содержит информацию о коллекции картины, представленных в галерее.
- Exhibitions - Свойство, содержащее информацию о текущих и предстоящих выставках в галерее.
- CategoriesOfTickets - Свойство, определяющее доступные категории билетов для посещения выставок.
- CategoriesOfMemberships - Свойство, содержащее информацию о доступных категориях членства в галерее.
- AvailableTickets - Свойство, которое содержит информацию о доступных для приобретения билетах на выставки.

11. User:
Наследуется от класса BaseEntity
- Username - Имя пользователя.
- Password - Пароль пользователя.
- PersonalInfo - Информация о пользователе.
- ChangeUsername() - Метод для изменения имени пользователя.
- ChangePassword() - Метод для изменения пароля пользователя.
- UpdatePersonalInfo() - Метод для обновления информации о пользователе.


12. Admin:
 Наследует все свойства и методы класса User.
- Status - Свойство, которое указывает на текущий статус администратора (например, админы с особым статусом имеют доступ к некоторым расширенным функциям).
- AddPaintingToCollection() - Метод, который позволяет администратору добавить новую картину в коллекцию галереи.
- RemovePaintingFromCollection() - Метод, который позволяет администратору удалить картину из коллекции галереи.
- ChangeInfoAboutPainting() - Метод, который позволяет администратору изменить информацию о конкретной картины в коллекции галереи.
- ChangeImageForPainting() - Метод, который позволяет администратору заменить изображение для определенной картины в коллекции галереи.
- AddExhibition() - Метод, который позволяет администратору добавить новую выставку в галерею.
- RemoveExhibition() - Метод, который позволяет администратору удалить выставку из галереи.
- ChangeInfoAboutExhibition() - Метод, который позволяет администратору изменить информацию о конкретной выставке в галереи.
- AddPaintingToExhibition() - Метод, который позволяет администратору добавить картину на определенную выставку в галерее.
- RemovePaintingFromExhibition() - Метод, который позволяет администратору удалить картину с определенной выставки в галерее.
- ViewAdmins() - Метод, который позволяет администратору просматривать список всех администраторов в системе.
- AddAdmin() - Метод, который позволяет администратору добавить нового администратора в систему.
- RemoveAdmin() - Метод, который позволяет администратору удалить существующего администратора из системы.
- SetAvailableTickets() - Метод, который позволяет администратору устанавливать доступные категории билетов и их количество для посетителей выставок.
- ConfirmOrder() - Метод, который позволяет администратору подтверждать заказы, сделанные посетителями, например, на покупку билетов или membership.
- GenerateQRCode() - Метод, который позволяет администратору генерировать QR-коды для пользователей с membership.
- CheckQRCode() - Метод, который позволяет администратору проверять QR-коды, предъявленные посетителями с членством. Администратор использует этот метод для аутентификации пользователя и проверки его членства в галерее. Если QR-код действителен и соответствует данным в системе, администратор подтверждает доступ пользователя к привилегиям, предусмотренным его членством, например, предоставляет доступ к выставкам или другим объектам в галерее.

13. Customer:
Наследует все свойства и методы класса User.
- BankCard - Свойство, которое содержит информацию о банковской карте клиента.
- Orders - Свойство, содержащее информацию о заказах.
- Membership - Свойство, указывающее на членство клиента в галерее, если таковое имеется.
- ChangeInfoAboutBankCard() - Метод, позволяющий клиенту изменить информацию о своей банковской карте.
- AddTicketToOrder() - Метод, который добавляет билет на выставку в заказ клиента.
- RemoveTicketFromOrder() - Метод, который удаляет билет из текущего заказа клиента.
- ViewCurrentOrder() - Метод, позволяющий клиенту просмотреть информацию о текущем заказе.
- ReplaceOrder() (Заменить заказ): Метод, который позволяет клиенту разместить свой заказ, в последующим для потверждения его админом.
- AddMembership() - Метод, который позволяет клиенту приобрести членство в галерее.
- CheckMembership() - Метод, который позволяет клиенту проверить текущее состояние своего членства в галерее.
- SearchInTheCollection() - Метод, позволяющий клиенту выполнять поиск интересующих его картин в коллекции галереи.

14. AuthenticationSystem:
- Customers - Список клиентов.
- Admins - Список администраторов.
- Register() - Метод для регистрации нового пользователя.
- LogIn() - Метод для входа в систему.
- LogOut() - Метод для выхода из системы.
