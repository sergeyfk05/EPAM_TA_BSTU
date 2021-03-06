https://www.dell.com/en-us/
1
**1. Добавление товара в корзину**
  - Ввести в поиск "New XPS 15 Laptop"
  - В результатах поиска должно быть несколько модификаций данного ноута
  - Нажать "Add to cart" на первом в списке товаре
  - Перейти в корзину. (Вверху страницы "Cart" -> "Go to Cart")
  - В теге section с аттрибутом data-testid="CartItems" должен быть один элемент с классом "cart-item" (необходимо проверять по этому условию и ниже по дереву DOM, товары могу объединяться в блоки)
  - При нажатии на div с аттрибутом data-testid="itemTitle" пользователя должно перенаправить на сайт добавляемого товара<br/>
__*Ожидаемый результат: в корзину должен добавиться товар*__
  
**2. Удаление из корзины**
  - Ввести в поиск "New XPS 15 Laptop"
  - В результатах поиска должно быть несколько модификаций данного ноута
  - Нажать "Add to cart" на первом в списке товаре
  - Перейти в корзину. (Вверху страницы "Cart" -> "Go to Cart")
  - В теге section с аттрибутом data-testid="CartItems" должен быть один элемент с классом "cart-item" (необходимо проверять по этому условию и ниже по дереву DOM, товары могу объединяться в блоки)
  - В секции описанной выше должен быть тег а с аттрибутом data-testid="cartRemoveItemAction". После клика на данный тег корзина должна очитститься, т.е. на странице должен быть тег section c id="emptyCart"<br/>
__*Ожидаемый результат: в корзину должен добавиться товар, а затем удалиться*__
  
**3. Добавление сразу нескольких товаров**
  - Ввести в поиск "New XPS 15 Laptop"
  - В результатах поиска должно быть несколько модификаций данного ноута
  - Нажать "Add to cart" на первом в списке товаре
  - Ввести в поиск "Dell UltraSharp 49 Curved Monitor - U4919DW"
  - В результатах поиска должен быть товар с данным названием
  - Нажать "Add to cart" на первом в списке товаре
  - Перейти в корзину. (Вверху страницы "Cart" -> "Go to Cart")
  - В теге section с аттрибутом data-testid="CartItems" должно быть два элемента с классом "cart-item" (необходимо проверять по этому условию и ниже по дереву DOM, товары могу объединяться в блоки)
  - При нажатии на div с аттрибутом data-testid="itemTitle" пользователя должно перенаправить на сайт добавляемого товара<br/>
__*Ожидаемый результат: в корзину должены добавиться два указанных выше товара*__

**4. Проверка изменения стоимости при изменении конфигурации товара**
  - Ввести в поиск "New XPS 15 Laptop"
  - Перейти на страницу данного товара
  - На странице должен быть div с id="techspecs_section" с некоторым количеством div'ов с классом "ux-cell-wrapper", далее внутри должен быть один div с классом "ux-cell-options", внутри которого должен быть div с классом "ux-options-wrap". Этот тег содержит модификации определенног компонента, в каждом из которых есть div с классом "ux-cell-delta-price", который сожержит его стоимость
  - Проверить корректность изменения цены для всех возможных конфигураций ноута. Цену можно найти в dic с классом "cf-price"<br/>
__*Ожидаемый результат: стоимость ноута должно изменяться с заявленным в UI значении*__
  
**5. Ввод однозначно некорректных данных о клиенте**
  - Ввести в поиск "New XPS 15 Laptop"
  - В результатах поиска должно быть несколько модификаций данного ноута
  - Нажать "Add to cart" на первом в списке товаре
  - Перейти в корзину. (Вверху страницы "Cart" -> "Go to Cart")
  - Нажать кнопку "checkout"
  - Нажать кнопку "Continue as a guest"
  - Попробовать ввести однозначно некорректные данные такие как фамилия, имя, город, страна, почтовый индекс (например: имя начинающиеся или состоящее только из цифр и т.д.)<br/>
__*Ожидаемый результат: система должна "не пустить" дальше и выдать предупреждение/ошибку о некорректных данных*__

**6. Ввод однозначно некорректных платежных данных**
  - Ввести в поиск "New XPS 15 Laptop"
  - В результатах поиска должно быть несколько модификаций данного ноута
  - Нажать "Add to cart" на первом в списке товаре
  - Перейти в корзину. (Вверху страницы "Cart" -> "Go to Cart")
  - Нажать кнопку "checkout"
  - Нажать кнопку "Continue as a guest"
  - Ввести данные о клиенте и адресе доставки
  - Нажать кнопку "Payment"
  - Выбрать способ оплаты "Credit/Debit card"
  - Попробовать ввести однозначно некорректные платежные данные(номер карты, фамилия и имя владельца карты, телефон, CCV). Например телефон с несуществующим кодом или имя владельца, состоящее из цифр, спец символов и др. не валидные сценарии
  - Нажать кнопку "Next: Review"<br/>
__*Ожидаемый результат: система должна "не пустить" дальше и выдать предупреждение/ошибку о некорректных данных*__
  
**7. Проверка поданочных карт**
  - Ввести в поиск "New XPS 15 Laptop"
  - В результатах поиска должно быть несколько модификаций данного ноута
  - Нажать "Add to cart" на первом в списке товаре
  - Перейти в корзину. (Вверху страницы "Cart" -> "Go to Cart")
  - Нажать кнопку "checkout"
  - Нажать кнопку "Continue as a guest"
  - Ввести данные о клиенте и адресе доставки
  - Нажать кнопку "Payment"
  - Выбрать способ оплаты "Dell gift card"
  - Попробовать ввести несуществующий номер карты и код безопасности. П.С. неизвестен валидный формат подарочных карт
  - Нажать кнопку "Next: Review"<br/>
__*Ожидаемый результат: система должна "не пустить" дальше и выдать предупреждение/ошибку о некорректных данных*__

**8. Проверка купонов(!= подарочные карты)**
  - Ввести в поиск "New XPS 15 Laptop"
  - В результатах поиска должно быть несколько модификаций данного ноута
  - Нажать "Add to cart" на первом в списке товаре
  - Перейти в корзину. (Вверху страницы "Cart" -> "Go to Cart")
  - Справа в разделе "Coupons" будет кнопка "1 coupon(s) available". После клика на нее должно появиться диалоговое окно с кодом купона. (на момент написания этого документа на данный товар есть купон)
  - Закрыть диалоговое окна
  - Вставить код купона из диалогового окна
  - Нажать кнопку "Apply Coupon"
  - Стоимость должна снизиться на обещенную купоном сумму. На момент написания это 50$<br/>
__*Ожидаемый результат: система должна снизить стоимость на указанную сумму в купоне*__

**9. Проверка регистрации**
  - Нажать на кнопки "Sing In" -> "Create an account"
  - Пользователь должен быть перенаправлен на страницу регистрации/аутенфикации
  - В правой части ввести некорректные данные (например e-mail без @, имя/фамилия с цифрами/спецсимволами, начинается с маленькой буквы и т.д.)
  - Нажать кнопку "Create account"<br/>
__*Ожидаемый результат: система не должна зарегистрировать пользователя и выдать соотвествующее предупреждение*__

**10. Проверка аутенфикации**
  - Нажать на кнопки "Sing In" -> "Sign In"
  - Пользователь должен быть перенаправлен на страницу регистрации/аутенцикации
  - Ввести логин и пароль существующего пользователя в левой части в соответсвующие поля
  - Нажать кнопку "Sign In"<br/>
__*Ожидаемый результат: сверху на любой странице левее от кнопки корзины должно быть написано фамилия и имя данного пользователя, что указывает, что данных пользователь зашел. Попробовать этот тест с данными несуществующего пользователя. В таком случае система должна выдать ошибку/предупреждение*__
