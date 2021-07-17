using Example.SingletonAndServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace Example.UI
{
    public class ExampleCounterText : MonoBehaviour
    {
        [SerializeField] private Text _counterText;

        private Counter _counter;                                   //Ссылка на класс-счетчик


        private void Start()
        {
            _counter = Locator.Instance.Resolve<Counter>();         //Через Локатор получаем ссылку на Счетчик

            if (_counter != null)
            {
                _counter.OnChange += OnChangeHandler;               //Подписываемся. Метод, который мы привязываем к событию...
                                                                    //...должен иметь ту же сигнатуру, что и делегат события
                SetText(_counter.GetCurrentValue().ToString());
            }
        }

        private void OnDestroy()
        {
            if (_counter != null)
                _counter.OnChange -= OnChangeHandler;               //Отписываемся
        }

        private void OnChangeHandler(int value)
        {
            SetText(value.ToString());
        }

        private void SetText(string text)                           //Что бы не дублировать код " _counterText.text = ..."
        {                                                           //ывнесем этот код в отдельный метод
            _counterText.text = text;
        }
    }
}
