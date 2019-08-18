using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IInputHandle
{
    void Execute(GameObject go, EventSystem eventSystem, PointerEventData pointerEventData);
}

public interface IInputHandle<T> : IInputHandle where T : BaseEventData
{
    T GetSpecificEventData(EventSystem eventSystem, PointerEventData pointerEventData);
}