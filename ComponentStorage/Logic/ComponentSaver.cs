namespace LP.ComponentStorage.Saver
{
    using System.Collections.Generic;
    using UnityEngine;

    public class ComponentSaver<T> : BaseComponentSaver where T: Component 
    {
        public Dictionary<int, T> components = new Dictionary<int, T>();

        public void Add(T element)
        {
            var id = element.gameObject.GetInstanceID();
            if (!components.ContainsKey(id))
            {
                components.Add(id, element);
            }
        }

        public T GetElement(int ID)
        {
            if (components.TryGetValue(ID, out T element))
            {
                return element;
            }

            return null;
        }

        public void Remove(int ID)
        {
            if (components.ContainsKey(ID))
            {
                components.Remove(ID);
            }
        }
    }

    public class BaseComponentSaver { }

}