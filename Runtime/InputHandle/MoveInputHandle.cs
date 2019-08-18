using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveInputHandle : BaseInputHandle<AxisEventData>
{
    public override void Execute(GameObject go, EventSystem eventSystem, PointerEventData pointerEventData)
    {
        AxisEventData axisEventData = GetSpecificEventData(eventSystem, pointerEventData);

        ExecuteEvent(go, axisEventData, ExecuteEvents.moveHandler);
    }

    public override AxisEventData GetSpecificEventData(EventSystem eventSystem, PointerEventData pointerEventData)
    {
        AxisEventData axisEventData = new AxisEventData(eventSystem);
        axisEventData.moveDir = GetRandomMoveDirection();
        axisEventData.moveVector = GetVectorFromMoveDirection(axisEventData.moveDir);

        return axisEventData;
    }

    private MoveDirection GetRandomMoveDirection()
    {
        return (MoveDirection)Random.Range((int)MoveDirection.Left, (int)MoveDirection.None);
    }

    private Vector2 GetVectorFromMoveDirection(MoveDirection moveDirection)
    {
        switch (moveDirection)
        {
            case MoveDirection.Left:
                return Vector2.left;
            case MoveDirection.Up:
                return Vector2.up;
            case MoveDirection.Right:
                return Vector2.right;
            case MoveDirection.Down:
                return Vector2.down;
            case MoveDirection.None:
            default:
                return Vector2.zero;
        }
    }
}
