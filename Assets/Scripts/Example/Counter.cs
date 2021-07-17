using Example.SingletonAndServiceLocator;                       //Не забываем про использование пространства имен, в котором находится Локатор
using System;
using UnityEngine;

namespace Example
{
    public class Counter : MonoBehaviour
    {
        public event Action<int> OnChange;                      //Событие изменения счетчика, при вызове которого будем передавать актуальное значение счетчика

        private int _currentValue;                              //Непосредственно поле счетчика. Закрытое (private), что бы запретить произвольное изменение извне
        

        private void OnEnable()
        {
            Locator.Instance.Register(this);                    //OnEnable() вызывается после Awake(), а оба компонента (Локатор и Счетчик) изначально уже на сцене
                                                                //поэтому во избежание ошибки (Locator.Instance == null) при сохранении наглядности кода и сцены
                                                                //обращаемся к Локатору ("регистрируем компонент-счетчик") в методе OnEnable()
        }

        private void OnDisable()
        {
            Locator.Instance.Unregister(typeof(Counter));
        }


        public void OnIncrement()                               //Общедоступный метод изменения счетчика. 
        {                                                       //Будем вызывать этот метод по кнопке в связке Локатор -> Счетчик -> Метод
            _currentValue++;

            OnChange?.Invoke(_currentValue);                    //Если никто не подписан на событие OnChange, то попытка вызова приведет к ошибке
                                                                //поэтому проверяем на NULL перед вызовом
                                                                //данная форма записи с элвис-оператором соответствует условию
                                                                //if (OnChange != null) OnChange.Invoke(_currentValue);  
        }

        public int GetCurrentValue()                            
        {            
            return _currentValue;
        }
    }
}
