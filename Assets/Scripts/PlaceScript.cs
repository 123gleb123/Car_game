using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceScript : MonoBehaviour, IDropHandler
{
    private float placeZRotation, carZRotation, difZRotation;
    private Vector2 placeSize, carSize;
    private float xSizeDif, ySizeDif;
    public ObjectScript objectScript;

    public void OnDrop(PointerEventData eventData)
    {
        if ((eventData.pointerDrag != null) && Input.GetMouseButtonUp(0)
            && Input.GetMouseButton(2) == false)
        {
            if (eventData.pointerDrag.tag.Equals(tag))
            {
                // Salīdzina rotāciju starp objektu un vietu
                placeZRotation = eventData.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
                carZRotation = GetComponent<RectTransform>().transform.eulerAngles.z;
                difZRotation = Mathf.Abs(placeZRotation - carZRotation);
                Debug.Log("Dif Z Rotation: " + difZRotation);

                // Salīdzina izmēru starp objektu un vietu
                placeSize = eventData.pointerDrag.GetComponent<RectTransform>().localScale;
                carSize = GetComponent<RectTransform>().localScale;
                xSizeDif = Mathf.Abs(placeSize.x - carSize.x);
                ySizeDif = Mathf.Abs(placeSize.y - carSize.y);
                Debug.Log("Dif X Size: " + xSizeDif + " Dif Y Size: " + ySizeDif);

                if ((difZRotation <= 10 || (difZRotation >= 350 && difZRotation <= 360)) &&
                    (xSizeDif <= 0.3 && ySizeDif <= 0.3))
                {
                    Debug.Log("Right Place");
                    objectScript.rightPlace = true;

                    // Objektu novieto precīzā vietā
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        GetComponent<RectTransform>().anchoredPosition;

                    // Uzliek rotāciju pēc vietas
                    eventData.pointerDrag.GetComponent<RectTransform>().localRotation =
                        GetComponent<RectTransform>().localRotation;

                    // Uzliek izmēru pēc vietas
                    eventData.pointerDrag.GetComponent<RectTransform>().localScale =
                        GetComponent<RectTransform>().localScale;

                    // Atskaņo veiksmīgas novietošanas skaņu
                    objectScript.audioSource.PlayOneShot(objectScript.audioClips[0]);
                }
            }
            else
            {
                // Ja nepareizā vietā — atgriež atpakaļ un atskaņo kļūdas skaņu
                objectScript.rightPlace = false;
                objectScript.audioSource.PlayOneShot(objectScript.audioClips[1]);

                // Atgriež objektu sākotnējā pozīcijā pēc tag
                switch (eventData.pointerDrag.tag)
                {
                    case "Garbage":
                        objectScript.garbageTruck.GetComponent<RectTransform>().localPosition = objectScript.gTruckPos;
                        break;
                    case "Medic":
                        objectScript.medic.GetComponent<RectTransform>().localPosition = objectScript.medicPos;
                        break;
                    case "School":
                        objectScript.schoolBuss.GetComponent<RectTransform>().localPosition = objectScript.sBussPos;
                        break;
                    case "Ekskavator":
                        objectScript.ekskavator.GetComponent<RectTransform>().localPosition = objectScript.ekskavatorPos;
                        break;
                    case "e46":
                        objectScript.e46.GetComponent<RectTransform>().localPosition = objectScript.e46Pos;
                        break;
                    case "b2":
                        objectScript.b2.GetComponent<RectTransform>().localPosition = objectScript.b2Pos;
                        break;
                    case "e61":
                        objectScript.e61.GetComponent<RectTransform>().localPosition = objectScript.e61Pos;
                        break;
                    case "Police":
                        objectScript.police.GetComponent<RectTransform>().localPosition = objectScript.policePos;
                        break;
                    case "Traktors1":
                        objectScript.traktors1.GetComponent<RectTransform>().localPosition = objectScript.traktors1Pos;
                        break;
                    case "Traktos5":
                        objectScript.traktos5.GetComponent<RectTransform>().localPosition = objectScript.traktos5Pos;
                        break;
                    case "CementaMasina":
                        objectScript.cementaMasina.GetComponent<RectTransform>().localPosition = objectScript.cementaMasinaPos;
                        break;
                    case "UgunsdzeSeji":
                        objectScript.ugunsdzeSeji.GetComponent<RectTransform>().localPosition = objectScript.ugunsdzeSejiPos;
                        break;
                    default:
                        Debug.LogError("Unknown tag!");
                        break;
                }
            }
        }
    }
}
