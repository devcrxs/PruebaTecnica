using UnityEngine;
using UnityEngine.EventSystems;
public class SlotDrop : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;
    public ApprovedType approvedType;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        if (IsSetSlot(eventData))
        {
            SetDrop(eventData.pointerDrag.transform);
        }
    }

    protected virtual bool IsSetSlot(PointerEventData eventData)
    {
        return eventData.pointerDrag != null;
    }

    public virtual void SetDrop(Transform item)
    {
        item.GetComponent<DragDrop>().IsLocation = true;
        item.SetParent(rectTransform);
        item.GetComponent<Students>().approvedType = approvedType;
    }
}
