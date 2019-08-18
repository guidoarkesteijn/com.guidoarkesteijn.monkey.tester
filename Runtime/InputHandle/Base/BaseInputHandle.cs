using System.Collections;
using System.Collections.Generic;
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

    protected void ExecuteEvent<T, EventData>(GameObject go, EventData baseEventData, ExecuteEvents.EventFunction<T> eventFunction) where T : IEventSystemHandler where EventData : BaseEventData
    {
        ExecuteEvents.ExecuteHierarchy(go, baseEventData, eventFunction);
    }
}
