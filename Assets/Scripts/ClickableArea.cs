using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableArea : MonoBehaviour, IPointerDownHandler
{

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        EventBus<MoneyEvent>.Raise(new MoneyEvent
        {
            amount = 1
        });
    }
}
