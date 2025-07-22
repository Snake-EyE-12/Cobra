using UnityEngine;

namespace Cobra.DesignPattern.Observer
{
    public static class EventStationDefault
    {
        public static EventBusWeak stationWeak = new EventBusWeak();
        public static EventBusWeakDictionary stationDictionary = new EventBusWeakDictionary();
        public static EventBusNoParams stationNoParams = new EventBusNoParams();
        public static EventBusNoParamsDictionary stationNoParamsDictionary = new EventBusNoParamsDictionary();
        
        public static EventBus<int> stationGenericInt = new EventBus<int>();
        public static EventBus<float> stationGenericFloat = new EventBus<float>();
        public static EventBus<Vector2> stationGenericVector2 = new EventBus<Vector2>();
        public static EventBus<Vector3> stationGenericVector3 = new EventBus<Vector3>();
        public static EventBus<string> stationGenericString = new EventBus<string>();
        public static EventBus<bool> stationGenericBool = new EventBus<bool>();
        public static EventBus<GameObject> stationGenericGameObject = new EventBus<GameObject>();
        
        public static EventBusDictionary<int> stationGenericIntDictionary = new EventBusDictionary<int>();
        public static EventBusDictionary<float> stationGenericFloatDictionary = new EventBusDictionary<float>();
        public static EventBusDictionary<Vector2> stationGenericVector2Dictionary = new EventBusDictionary<Vector2>();
        public static EventBusDictionary<Vector3> stationGenericVector3Dictionary = new EventBusDictionary<Vector3>();
        public static EventBusDictionary<string> stationGenericStringDictionary = new EventBusDictionary<string>();
        public static EventBusDictionary<bool> stationGenericBoolDictionary = new EventBusDictionary<bool>();
        public static EventBusDictionary<GameObject> stationGenericGameObjectDictionary = new EventBusDictionary<GameObject>();
    }
}