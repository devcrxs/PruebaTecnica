using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Vector2 startParent;
    private CanvasGroup canvasGroup;
    private Canvas graphicRaycaster;
    private bool isLocation;
    private float minAlphaCanvas = 0.5f;
    private float maxAlphaCanvas = 1f;
    public bool IsLocation
    { set => isLocation = value; }
    private void Start()
    {
        startParent = transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
        graphicRaycaster = GetComponent<Canvas>();
        graphicRaycaster.overrideSorting = false;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha  = minAlphaCanvas;
        graphicRaycaster.overrideSorting = true;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startParent = transform.position;
        isLocation = !isLocation ? isLocation : false;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = maxAlphaCanvas;
        graphicRaycaster.overrideSorting = false;
        transform.position = !isLocation ? startParent : (Vector2)transform.position;
    }

}
