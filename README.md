# DOTween-helper
#### Инструмент который позволяет легко создавать и настраивать последовательности анимаций [DOTween](https://dotween.demigiant.com/) через editor

___

# Содержание
- [Как установить](#как-установить)
- [Как использовать](#как-использовать)
___

## Как установить

Link for add custom package - https://github.com/Ssnake707/DOTween-helper.git?path=/DOTween%20Helper/Assets/DOTweenHelper

Используя **Package Manager** вставьте ссылку выше в **Add package from git URL...** <br><br>
Если вам необходимо установить определенную версию, то используйте префикс **#v1.0.0** в конце ссылки<br>
*Номера версий можно посмотреть в тегах репозитория*<br><br>
Пример: *https://github.com/Ssnake707/DOTween-helper.git?path=/DOTween%20Helper/Assets/DOTweenHelper#v1.0.0*

![Package manager > add package from git](https://github.com/Ssnake707/DOTween-helper/blob/main/Images/Package%20manager.jpg)

## Как использовать

Добавьте компонент **DOTween Sequence Controller** к **GameObject**


![DOTween sequence controller](https://github.com/Ssnake707/DOTween-helper/blob/main/Images/DOTween%20sequence%20controller.jpg)

- **Link Game Object** - Root объект создаваемой sequence, при уничтожении root объекта, sequence также будет уничтожен автоматически
- **Is Play On Awake** - Если включить, то анимация автоматически будет проигрываться
- **Sequence Loops Settings**
  - **Loop Type** - Как анимация будет зацикливаться
  - **Count Loops** - Количество циклов анимации, Если указать -1, то анимация будет проигрываться бесконечно
- **Sequence Update Settings**
  - **Update Type** - Каким образом будет обновляться анимация. *На текущий момент, **Manual** не поддерживается*
  - **Ignore Time Scale** - Если включить, то анимация будет игнорировать **Time.TimeScale**
- **Tweens** - Массив твинов для создания sequence последовательности
<br><br>
Для добавления анимаций в **Tweens** необходимо нажать кнопку **Add tween** и выбрать необходимую анимацию из списка

![Add tween](https://github.com/Ssnake707/DOTween-helper/blob/main/Images/Add%20tween.jpg)

У каждой анимации есть базовые настройки **Tween Settings**
- **Tween Add Type** - Как анимация будет добавлена к sequence
- **Ease** - Тип плавности анимации. Примеры типов можно посмотреть на <a href="https://easings.net/">сайте</a>
- **Delay** - Задержка перед проигрыванием анимации

Далее у каждой анимации свой набор параметров таких как:
- **Target** - Целевой объект, к которому будет применена анимация
- **Duration** - Длительность анимации
- **Use Vector *something*** - Если включить, то для анимации будет использовать векторное значение, а не *float*

![Example tween](https://github.com/Ssnake707/DOTween-helper/blob/main/Images/Example%20tween1.jpg)

Кнопки **Play** и **Regenerate sequence** работают только в **Play mode**
- **Play** - Запускает анимацию
- **Regenerate sequence** - Необходима для пересоздания всей sequence в случае если вы в **Play mode** меняли переменные или добавляли новые анимации
