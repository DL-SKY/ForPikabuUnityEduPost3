using Example.SingletonAndServiceLocator;
using UnityEngine;

namespace Example.UI
{
    public class ExampleButton : MonoBehaviour
    {
        public void OnClick()
        {
            //Через Локатор пытаемся получить ссылку на Счетчик
            //И если ссылка существует (не NULL), используем метод изменения счетчика
            Locator.Instance.Resolve<Counter>()?.OnIncrement();
        }
    }
}
