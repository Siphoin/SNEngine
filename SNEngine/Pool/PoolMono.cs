﻿using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace SNEngine.Polling
{
    /// <summary>
    /// Служит для пулла объектов MonoBehaviour
    /// </summary>
    /// <typeparam name="T">Тип префаба, который будет использоваться</typeparam>
    /// 

    public class PoolMono<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Коллекция пулла, в котором находятся объекты для вытаскивания, может расширяться, если включен флаг AutoExpand
        /// </summary>
        private List<T> _pool;


        /// <summary>
        /// Какой префаб создавать или включать/отключать
        /// </summary>
        public T Prefab { get; private set; }

        /// <summary>
        /// В него складываются все объекты пулла как дочерние
        /// </summary>

        public Transform Container { get; private set; }

        /// <summary>
        /// Может ли пулл расширятся, если не хватает объектов
        /// </summary>
        public bool AutoExpand { get; private set; }


        public IEnumerable<T> Objects => _pool;


        public PoolMono(T prefab, Transform container, int count, bool autoExpand = false)
        {
            if (prefab is null)
            {
                throw new NullReferenceException("prefab on pool not be null");
            }

            if (count <= 0)
            {
                throw new NullReferenceException("count of pool object not be lesser and equals 0");
            }


            Prefab = prefab;

            Container = container;

            AutoExpand = autoExpand;

            CreatePool(count);

        }

        public PoolMono(T prefab, int count, bool autoExpand = false)
        {
            if (prefab is null)
            {
                throw new NullReferenceException("prefab on pool not be null");
            }

            if (count <= 0)
            {
                throw new NullReferenceException("count of pool object not be lesser and equals 0");
            }


            Prefab = prefab;

            AutoExpand = autoExpand;

            CreatePool(count);
        }

        public PoolMono(T prefab, IEnumerable<T> objects, bool autoExpand = false)
        {

            if (prefab is null)
            {
                throw new NullReferenceException("prefab on pool not be null");
            }

            Prefab = prefab;

            AutoExpand = autoExpand;

            CreatePool(objects);
        }

        public PoolMono(T prefab, IEnumerable<T> objects, Transform container, bool autoExpand = false)
        {

            if (prefab is null)
            {
                throw new NullReferenceException("prefab on pool not be null");
            }

            Prefab = prefab;

            AutoExpand = autoExpand;

            Container = container;

            CreatePool(objects);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private void CreatePool(IEnumerable<T> objects)
        {

            _pool = new List<T>();

            var array = objects.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                MonoBehaviour monoBehaviour = array[i] as MonoBehaviour;

                GameObject gameObject = monoBehaviour.gameObject;

                if (Container != null)
                {
                    gameObject.transform.SetParent(Container);
                }

                gameObject.SetActive(false);

                _pool.Add(array[i]);
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {

            T createdObject = UnityEngine.Object.Instantiate(Prefab, Container);

            createdObject.gameObject.SetActive(isActiveByDefault);

            _pool.Add(createdObject);

            string typeName = typeof(T).Name;

            createdObject.gameObject.name = $"{typeName}{_pool.Count}";

            return createdObject;
        }

        private bool HasFreeElement(out T element)
        {
            foreach (var mono in _pool)
            {
                if (!mono.gameObject.activeInHierarchy)
                {
                    element = mono;
                    return true;
                }
            }

            element = null;

            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out T element))
            {
                return element;
            }

            if (AutoExpand)
            {
                return CreateObject(true);
            }

            throw new ArgumentOutOfRangeException($"there is no free elements in pool is type {typeof(T)}");
        }

        public T GetElementByIndex(int index)
        {
            if (index < 0 || index >= _pool.Count)
            {
                throw new ArgumentOutOfRangeException($"index argument of element in pool");
            }

            T element = _pool[index];

            return element;
        }

        public void HideAllElements ()
        {
            foreach (var item in _pool)
            {
                item.gameObject.SetActive(false);
            }
        }



    }
}