using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,
    IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    public Canvas canva;
    private CanvasGroup canvasGroup;
    public ObjectScript objectScript;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(2) == false)
        {
            Debug.Log("Pointer Down: " + gameObject.name);
            objectScript.audioSource.PlayOneShot(objectScript.audioClips[0]);

        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(2) == false)
        {
            objectScript.lastDragged = null;
            Debug.Log("Begin Drag: " + gameObject.name);
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
            rectTransform.SetSiblingIndex(50);

        }
    }

    public void OnDrag(PointerEventData eventData)
{
    Vector2 localPoint;

    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
        canva.transform as RectTransform,
        Input.mousePosition,
        canva.renderMode == RenderMode.ScreenSpaceOverlay ? null : canva.worldCamera,
        out localPoint))
    {
        rectTransform.localPosition = localPoint;
    }
}


    public void OnEndDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Dragging ended: " + gameObject.name);
            objectScript.lastDragged = eventData.pointerDrag;
            canvasGroup.alpha = 1f;

            if (objectScript.rightPlace == false)
            {
                canvasGroup.blocksRaycasts = true;
                objectScript.audioSource.PlayOneShot(objectScript.audioClips[1]);

            }
            else
            {
                objectScript.lastDragged = null;
                // Varētu tālāk pārbaudīt vai visas mašīnas ir savā vietā
            }

            objectScript.rightPlace = false;
        }
    }
}