# Pool-and-Storage
Object pool and Component storage Unity mudle

# Component Storage
## Save your component link in static class. You get your link at this storage. 

```
ComponentStorage.Add<T>(T Component) // add

ComponentStorage.Remove<T>(T Component) // remove

ComponentStorage.Get<T>(Component or GameObject on which is E ) // get

```

# ObjectPool
## Object pool<T> where T : Unity Component

There is both a static storage pool and initialization through a component 

See Exaxmple in Pool/Example - Transform ObjectPool