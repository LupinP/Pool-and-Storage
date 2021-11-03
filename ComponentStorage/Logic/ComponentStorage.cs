namespace LP.ComponentStorage
{
   using System;
   using System.Collections.Generic;
   using UnityEngine;
   using Saver;

   /// <summary>
   /// A class that stores all the components that you give it. Needed in order to get rid of GetComponent 
   /// </summary>
   public static class ComponentStorage
   {
      private static Dictionary<Type, BaseComponentSaver> storage = new Dictionary<Type, BaseComponentSaver>();

      /// <summary>
      /// Add created component
      /// </summary>
      /// <param name="element">Component</param>
      /// <typeparam name="T">Type at componente (MonoBeh)</typeparam>
      public static void Add<T>(T element) where T : Component
      {
         var type = typeof(T);
         if (storage.TryGetValue(type, out var saver))
         {
            (saver as ComponentSaver<T>).Add(element);
         }
         else
         {
            storage.Add(type, new ComponentSaver<T>());
            (storage[type] as ComponentSaver<T>).Add(element);
         }
      }

      /// <summary>
      /// return GameObject ID
      /// </summary>
      /// <param name="go">GameObject</param>
      /// <returns>GameObject ID</returns>
      private static int GetId(GameObject go) => go.GetInstanceID();
      
      /// <summary>
      /// Get saved component
      /// </summary>
      /// <param name="go">GameObject</param>
      /// <typeparam name="T">Component type</typeparam>
      /// <returns>Component</returns>
      public static T GetElement<T>(GameObject go) where T : Component => GetElement<T>(GetId(go));
      
      /// <summary>
      /// Get saved component
      /// </summary>
      /// <param name="go">GameObject component</param>
      /// <typeparam name="T">Component type</typeparam>
      /// <returns>Component</returns>
      public static T GetElement<T>(Component go) where T : Component => GetElement<T>(GetId(go.gameObject));
      
      /// <summary>
      /// Get saved component
      /// </summary>
      /// <param name="id">GameObject ID</param>
      /// <typeparam name="T">Component type</typeparam>
      /// <returns>Component</returns>
      public static T GetElement<T>(int id) where T : Component
      {
         var type = typeof(T);
         if (storage.TryGetValue(type, out var saver))
         {
            return (saver as ComponentSaver<T>).GetElement(id);
         }

         return null;
      }

      /// <summary>
      /// Remove saved component
      /// </summary>
      /// <param name="go">Component</param>
      /// <typeparam name="T">Component type</typeparam>
      public static void Remove<T>(T go) where T : MonoBehaviour => Remove<T>(GetId(go.gameObject));
      
      /// <summary>
      /// Remove saved component
      /// </summary>
      /// <param name="go">GameObject component</param>
      /// <typeparam name="T">Component type</typeparam>
      public static void Remove<T>(GameObject go) where T : MonoBehaviour => Remove<T>(GetId(go));
      
      /// <summary>
      /// Remove saved component
      /// </summary>
      /// <param name="go">Other component</param>
      /// <typeparam name="T">Component type</typeparam>
      public static void Remove<T>(Component go) where T : MonoBehaviour => Remove<T>(GetId(go.gameObject));
      
      /// <summary>
      /// Remove saved component
      /// </summary>
      /// <param name="id">Component ID</param>
      /// <typeparam name="T">Component type</typeparam>
      public static void Remove<T>(int id) where T : MonoBehaviour
      {
         var type = typeof(T);
         if (storage.TryGetValue(type, out var saver))
         {
            (saver as ComponentSaver<T>).Remove(id);
         }
      }
      
   }
}
