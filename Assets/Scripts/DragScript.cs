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
        Debug.Log("Dragging: " + gameObject.name);
        Vector2 mousePosition =
            new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition.x = Mathf.Clamp(
            mousePosition.x, 0 + rectTransform.rect.width / 2,
            Screen.width - rectTransform.rect.width / 2);

        mousePosition.y = Mathf.Clamp(
            mousePosition.y, 0 + rectTransform.rect.height / 2,
            Screen.height - rectTransform.rect.height / 2);

        transform.position = mousePosition;
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