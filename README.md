*[Latest release v1.1.0](https://github.com/Ssnake707/DOTween-helper/releases)*
# DOTween-helper
#### Инструмент который позволяет легко создавать и настраивать последовательности анимаций [DOTween](https://dotween.demigiant.com/) через editor

___

# Содержание
- [Как установить](#как-установить)
- [Как использовать](#как-использовать)
- [Interface для работы с DOTweenAnimationController](#idotweenanimationcontroller)
___

## Как установить

### Внимание! <br>
Для успешной установки пакета необходимо, чтобы ***DOTween*** находился в папке по умолчанию ***Assets/Plugins/Demigiant/DOTween*** <br><br>
Также необходимо создать ASMDEF файл сборки для ***DOTween***<br> 
Для этого необходимо открыть ***DOTween Utility Panel*** и нажать на ***Create ASMDEF***

![Create ASMDEF DOTween](https://github.com/Ssnake707/DOTween-helper/blob/main/Images/DOTween%20ASMDEF.jpg)

### Установка пакета

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
- **Is Auto Kill** - Если включить, то анимация будет автоматически удалена, после завершения
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

___

## IDOTweenAnimationController

- **event Action OnComplete** - Устанавливает обратный вызов, который будет запущен в момент завершения анимации движения, включая все циклы
- **event Action OnKill** - Устанавливает обратный вызов, который будет запущен в момент уничтожения твина
- **event Action OnPlay** - Устанавливает обратный вызов, который будет запускаться, когда анимация движения устанавливается в состояние воспроизведения, после любой возможной задержки. Также вызывается каждый раз, когда анимация движения возобновляет воспроизведение из состояния паузы
- **event Action OnPause** - Задает обратный вызов, который будет запущен, когда состояние анимации изменится с воспроизведения на паузу. Если для анимации движения значение ***autoKill*** равно ***FALSE***, это также вызывается, когда анимация достигает завершения
- **event Action OnRewind** - Задает обратный вызов, который будет запускаться, когда анимация движения будет перематываться назад либо путем вызова, Rewind либо при достижении начальной позиции при воспроизведении в обратном направлении
- **event Action OnStart** - Устанавливает обратный вызов, который будет запущен один раз при запуске анимации движения (имеется в виду, когда анимация движения устанавливается в состояние воспроизведения в первый раз после любой возможной задержки)
- **event Action OnStepComplete** - Устанавливает обратный вызов, который будет запускаться каждый раз, когда анимация завершает один цикл (это означает, что если вы установите количество циклов на 3, вызов ***OnStepComplete*** будет выполнен 3 раза, в отличие от того, ***OnComplete*** что будет вызываться только один раз в самом конце)
- **event Action OnUpdate** - Задает обратный вызов, который будет запускаться при каждом обновлении анимации
- **bool IsPlaying { get; }** - Вернет ***true***, если анимация проигрывается
- **void Play()** - Воспроизводит анимацию. Если анимация уже была завершена, необходимо использовать ***void Restart()***
- **void Restart()** - Перезапускает анимацию
- **void Pause()** - Ставит анимацию на паузу
- **void GoTo(float to, bool andPlay)** - Отправить анимацию к времени ***to***. ***andPlay*** 
- **void Complete(bool withCallback)** - Отправляет анимацию в конечное положение (не влияет на анимацию с бесконечными циклами) если ***withCollback*** = ***true***, тогда анимация завершится с событием ***OnComplete***
