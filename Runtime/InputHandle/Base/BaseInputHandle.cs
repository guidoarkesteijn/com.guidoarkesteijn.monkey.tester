using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseInputHandle<T> : IInputHandle<T> where T : BaseEventData
{
    public abstract void Execute(GameObject go, EventSystem eventSystem, PointerEventData pointerEventData);
    public abstract T GetSpecificEventData(EventSystem eventSystem, PointerEventData pointerEventData);

    protected bool CanExecute<Event>(GameObject go) where Event : IEventSystemHandler
    {
        return ExecuteEvents.CanHandleEvent<Event>(go);
    }

    protected void ExecuteEvent<Type, EventData>(GameObject go, EventData baseEventData, ExecuteEvents.EventFunction<Type> eventFunction) where Type : IEventSystemHandler where EventData : BaseEventData
    {
        ExecuteEvents.ExecuteHierarchy(go, baseEventData, eventFunction);
    }
}
