using System;
using System.Collections.Generic;
using UnityEngine;

namespace Example.SingletonAndServiceLocator        //Пространство имен, в котором будем описывать класс
{
    public class Locator : MonoBehaviour
    {
        #region Singleton                     
        public static Locator Instance;             //Статичное поле означает, что оно относится к Классу, а не к Экземпляру класса
                                                    //следовательно, для доступа к полю не обязательно создавать экземпляр
                                                    //однако для работы паттерна это поле должно ссылаться на существующий экземпляр

        private void Awake()
        {
            Instance = this;                        //Присваиваем статичному полю значение этого конкретного экземпляра
        }

        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion

        #region ServiceLocator
        //В этой коллекции "Словарь" будем хранить "сервисы", кде ключ это тип, а значение - ссылка на компонент
        //P.S. MonoBehaviour <- Behaviour <- Component
        private readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();

        //Этим методом "регистрируем" сервис-компонент, что бы в дальнейшем получать к нему доступ
        public void Register<T>(T component) where T : Component
        {
            var type = component.GetType();
            if (_components.ContainsKey(type))
                _components[type] = component;
            else
                _components.Add(type, component);
        }

        //Удаляем сервис-компонент из коллекции
        public void Unregister(Type type)
        {
            _components.Remove(type);
        }

        //Получаем зарегистрированный сервис-компонент. Если его нет - получаем NULL
        public T Resolve<T>() where T : Component
        {
            var type = typeof(T);

            if (_components.ContainsKey(type))
                return (T)_components[type];

            return null;
        }
        #endregion
    }
}
