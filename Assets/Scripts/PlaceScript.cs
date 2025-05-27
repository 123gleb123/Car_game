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
            && Input.GetMouseButton(2) == false) { }

        if (eventData.pointerDrag.tag.Equals(tag))
        {
            placeZRotation = eventData.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
            carZRotation = GetComponent<RectTransform>().transform.eulerAngles.z;
            difZRotation = Mathf.Abs(placeZRotation - carZRotation);

            placeSize = eventData.pointerDrag.GetComponent<RectTransform>().localScale;
            carSize = GetComponent<RectTransform>().localScale;
            xSizeDif = Mathf.Abs(placeSize.x - carSize.x);
            ySizeDif = Mathf.Abs(placeSize.y - carSize.y);

            if ((difZRotation <= 10 || (difZRotation >= 350 && difZRotation <= 360)) && (xSizeDif <= 0.3 && ySizeDif <= 0.3))
            {
                    Debug.Log("Right Place");
                    objectScript.rightPlace = true;
                    //Izcentre poziciju
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    //Pielago rotaciju
                    eventData.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;
                    //Pielago izmeru
                    eventData.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;


                    UzvarasLogs.instance.VehiclePlaced();
                    
                    switch (eventData.pointerDrag.tag)
                    {
                        case "Garbage":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[2]);
                            break;
                        case "School":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;
                        case "Medic":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[4]);
                            break;
                        case "CementaMasina":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[5]);
                            break;
                        case "Police":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[7]);
                            break;
                        case "e61":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[6]);
                            break;
                        case "b2":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                            break;
                        case "Ekskavator":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[9]);
                            break;
                        case "Traktors1":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[8]);
                            break;
                        case "Traktos5":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[11]);
                            break;
                        case "UgunsdzeSeji":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[12]);
                            break;
                        case "e46":
                            objectScript.audioSource.PlayOneShot(objectScript.audioClips[13]);
                            break;
                    }
                }
            }
            else
            {
                objectScript.rightPlace = false;
                objectScript.audioSource.PlayOneShot(objectScript.audioClips[1]);

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
