using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript2 : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,
    IDragHandler, IEndDragHandler
{
    // UI objekta RectTransform komponents, lai varētu mainīt pozīciju
    private RectTransform rectTransform;
    // Atsauce uz kanvu, kurā atrodas šis objekts (nepieciešams koordinātu konvertēšanai)
    public Canvas canva;
    // CanvasGroup komponents, lai kontrolētu caurspīdīgumu un klikšķu iespējamību
    private CanvasGroup canvasGroup;
    // Atsauce uz galveno skriptu, kur glabājas objekta sākotnējā pozīcija un citas kopīgās vērtības
    public ObjectScript2 objectScript2;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Iegūst objekta RectTransform
        canvasGroup = GetComponent<CanvasGroup>();     // Iegūst CanvasGroup komponentu
    }

    // Izsaucas, kad lietotājs uzspiež uz objekta
    public void OnPointerDown(PointerEventData eventData)
    {
        // Pārbauda, vai tiek izmantots tikai kreisais taustiņš (ne kombinācijā ar vidējo peles taustiņu)
        if (Input.GetMouseButton(0) && Input.GetMouseButton(2) == false)
        {
            Debug.Log("Pointer Down: " + gameObject.name); // Konsolē izvada objekta nosaukumu
            objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[6]); // Atskaņo klikšķa skaņu
        }
    }

    // Izsaucas, kad sākas vilkšana
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(2) == false)
        {
            objectScript2.lastDragged = null; // Atjauno pēdējo vilkto objektu
            Debug.Log("Begin Drag: " + gameObject.name); // Konsolē izvada ziņu par sākšanu
            canvasGroup.alpha = 0.6f; // Samazina objekta caurspīdīgumu, lai vizuāli redzētu, ka tiek vilkts
            canvasGroup.blocksRaycasts = false; // Ļauj citiem UI objektiem saņemt raycast, kamēr šis tiek vilkts
            rectTransform.SetSiblingIndex(50); // Paceļ objektu virs citiem (renderēšanas kārtība)
        }
    }

    // Izsaucas katru reizi, kad objekts tiek vilkts
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;

        // Konvertē peles ekrāna pozīciju uz lokālo pozīciju kanvā
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canva.transform as RectTransform,
            Input.mousePosition,
            canva.renderMode == RenderMode.ScreenSpaceOverlay ? null : canva.worldCamera,
            out localPoint))
        {
            rectTransform.localPosition = localPoint; // Atjauno objekta pozīciju
        }
    }

    // Izsaucas, kad vilkšana tiek pārtraukta
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0)) // Ja tiek atlaists kreisais peles taustiņš
        {
            Debug.Log("Dragging ended: " + gameObject.name); // Konsolē izvada ziņu
            objectScript2.lastDragged = eventData.pointerDrag; // Saglabā vilkto objektu
            canvasGroup.alpha = 1f; // Atgriež caurspīdīgumu uz normālu

            // Ja objekts nav novietots pareizajā vietā
            if (objectScript2.rightPlace == false)
            {
                canvasGroup.blocksRaycasts = true; // Atkal ļauj objektam saņemt raycast
                objectScript2.audioSource.PlayOneShot(objectScript2.audioClips[7]); // Atskaņo "nepareizi novietots" skaņu
            }
            else
            {
                objectScript2.lastDragged = null; // Izdzēš pēdējo vilkto objektu
                // Šeit varētu pievienot loģiku, kas pārbauda, vai visi objekti ir savās vietās
            }

            objectScript2.rightPlace = false; // Atiestata karodziņu
        }
    }
}
