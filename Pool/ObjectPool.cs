namespace Pool.Container
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using Object = UnityEngine.Object;

    public class ObjectPool<T> : BasePool where T : Component
    {
        private Transform parent;
        private int count;
        private T pooledObject;
        private List<T> InGame = new List<T>();
        private Stack<T> InPool = new Stack<T>();

        public void Initialize(Transform _parent, int _count, T _pooledObject)
        {
            pooledObject = _pooledObject;
            parent = _parent;
            count = _count;
            SetPreload();
        }

        private void SetPreload()
        {
            for (int i = 0; i < count; i++)
            {
                InPool.Push(Object.Instantiate(pooledObject));
                InPool.Peek().transform.SetParent(parent);
            }
        }

        public T Get()
        {
            T value = null;
            if (InPool.Any())
            {
                value = InPool.Pop();
            }
            else
            {
                value = Object.Instantiate(pooledObject);
                value.transform.SetParent(parent);
            }

            InGame.Add(value);
            return value;
        }

        public void Return(T value)
        {
            InGame.Remove(value);
            value.transform.SetParent(parent);
            InPool.Push(value);
        }
    }

    public abstract class BasePool
    {
        public Type BaseType;
    }
}