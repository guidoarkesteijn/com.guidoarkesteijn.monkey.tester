using UnityEngine;
using UnityEngine.EventSystems;

public class BaseInputHandle : BaseInputHandle<BaseEventData>
{
    public override void Execute(GameObject go, EventSystem eventSystem, PointerEventData pointerEventData)
    {
        BaseEventData baseEventData = GetSpecificEventData(eventSystem, pointerEventData);

        ExecuteEvent(go, baseEventData, ExecuteEvents.selectHandler);
        ExecuteEvent(go, baseEventData, ExecuteEvents.updateSelectedHandler);
        ExecuteEvent(go, baseEventData, ExecuteEvents.deselectHandler);
        ExecuteEvent(go, baseEventData, ExecuteEvents.cancelHandler);
    }

    public override BaseEventData GetSpecificEventData(EventSystem eventSystem, PointerEventData pointerEventData)
    {
        return pointerEventData;
    }
}
