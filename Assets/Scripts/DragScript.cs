using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,
    IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;  // UI objekta transformācijas komponents
    public Canvas canva;                  // Atsauce uz Canvas, kur atrodas objekts
    private CanvasGroup canvasGroup;      // Kontrolē UI objekta caurspīdīgumu un raycast uzvedību
    public ObjectScript objectScript;     // Atsauce uz galveno skriptu ar kopīgām vērtībām

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Inicializē UI pozicionēšanas komponenti
        canvasGroup = GetComponent<CanvasGroup>();     // Inicializē caurspīdīguma kontrolieri
    }

    // Kad lietotājs uzklikšķina uz objekta
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(2) == false)
        {
            Debug.Log("Pointer Down: " + gameObject.name); // Ziņa konsolē, kurš objekts tika nospiests
            objectScript.audioSource.PlayOneShot(objectScript.audioClips[0]); // Atskaņo klikšķa skaņu
        }
    }

    // Kad lietotājs sāk vilkt objektu
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(2) == false)
        {
            objectScript.lastDragged = null; // Izdzēš iepriekšējo vilkto objektu
            Debug.Log("Begin Drag: " + gameObject.name);
            canvasGroup.alpha = 0.6f; // Padara objektu puscaurspīdīgu
            canvasGroup.blocksRaycasts = false; // Neļauj šim objektam bloķēt citus
            rectTransform.SetSiblingIndex(50); // Paceļ priekšplānā
        }
    }

    // Vilkšanas laikā atjaunina objekta pozīciju
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;

        // Pārveido peles pozīciju no ekrāna koordinātēm uz Canvas lokālajām koordinātēm
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canva.transform as RectTransform,
            Input.mousePosition,
            canva.renderMode == RenderMode.ScreenSpaceOverlay ? null : canva.worldCamera,
            out localPoint))
        {
            rectTransform.localPosition = localPoint; // Uzstāda jauno pozīciju
        }
    }

    // Kad lietotājs atlaiž peles pogu
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Dragging ended: " + gameObject.name);
            objectScript.lastDragged = eventData.pointerDrag; // Saglabā vilkto objektu
            canvasGroup.alpha = 1f; // Atgriež objektu pilnīgā redzamībā

            if (objectScript.rightPlace == false)
            {
                canvasGroup.blocksRaycasts = true; // Atkal ļauj šim objektam reaģēt uz raycast
                objectScript.audioSource.PlayOneShot(objectScript.audioClips[1]); // Atskaņo skaņu par nepareizu novietojumu
            }
            else
            {
                objectScript.lastDragged = null;
                // Šeit vari pievienot pārbaudi, vai visi objekti ir pareizajās vietās
            }

            objectScript.rightPlace = false; // Atiestata karodziņu
        }
    }
}
