using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerInputHandle : BaseInputHandle<PointerEventData>
{
    public override void Execute(GameObject go, EventSystem eventSystem, PointerEventData pointerEventData)
    {
        pointerEventData = GetSpecificEventData(eventSystem, pointerEventData);

        ExecuteEvent(go, pointerEventData, ExecuteEvents.initializePotentialDrag);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.beginDragHandler);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.dragHandler);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.endDragHandler);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.pointerEnterHandler);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.pointerDownHandler);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.pointerClickHandler);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.pointerUpHandler);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.pointerExitHandler);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.scrollHandler);
        ExecuteEvent(go, pointerEventData, ExecuteEvents.dropHandler);
    }

    public override PointerEventData GetSpecificEventData(EventSystem baseEventData, PointerEventData pointerEventData)
    {
        return pointerEventData;
    }
}
