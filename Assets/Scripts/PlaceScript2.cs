using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D.IK;

public class PlaceScript2 : MonoBehaviour, IDropHandler
{
    // Mainīgie priekš salīdzināšanas: rotācija, izmēri
    private float placeZRotation, carZRotation, difZRotation;
    private Vector2 placeSize, carSize;
    private float xSizeDif, ySizeDif;

    // Atsauce uz citu skriptu, kas satur objektu pozīcijas un skaņas
    public ObjectScript2 objectScript;

    // Šī metode tiek izsaukta, kad objekts tiek nomests uz šo vietu (drop area)
    public void OnDrop(PointerEventData eventData)
    {
        // Pārbauda vai objekts tiek vilkts un pele ir atlesta (un netiek spiesta vidējā poga)
        if ((eventData.pointerDrag != null) && Input.GetMouseButtonUp(0)
           && Input.GetMouseButton(2) == false) { }

        // Ja objekta tags sakrīt ar šīs vietas tagu (pareizais objekts uz pareizās vietas)
        if (eventData.pointerDrag.tag.Equals(tag))
        {
            // Salīdzina rotācijas leņķus
            placeZRotation = eventData.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
            carZRotation = GetComponent<RectTransform>().transform.eulerAngles.z;
            difZRotation = Mathf.Abs(placeZRotation - carZRotation);

            // Salīdzina izmērus (mērogu)
            placeSize = eventData.pointerDrag.GetComponent<RectTransform>().localScale;
            carSize = GetComponent<RectTransform>().localScale;
            xSizeDif = Mathf.Abs(placeSize.x - carSize.x);
            ySizeDif = Mathf.Abs(placeSize.y - carSize.y);

            // Ja rotācija un izmērs ir pietiekami tuvi, uzskata, ka ir pareiza vieta
            if ((difZRotation <= 10 || (difZRotation >= 350 && difZRotation <= 360)) && (xSizeDif <= 0.3 && ySizeDif <= 0.3))
            {
                Debug.Log("Right Place");
                objectScript.rightPlace = true;

                // Pielāgo pozīciju, rotāciju un izmēru, lai perfekti ievietotos
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localRotation;
                eventData.pointerDrag.GetComponent<RectTransform>().localScale = GetComponent<RectTransform>().localScale;

                // Informē sistēmu, ka transportlīdzeklis ir pareizi novietots
                UzvarasLogs2.instance.VehiclePlaced();

                // Atskaņo atbilstošo skaņu atkarībā no objekta taga
                switch (eventData.pointerDrag.tag)
                {
                    case "mcquen":
                        objectScript.audioSource.PlayOneShot(objectScript.audioClips[0]);
                        break;
                    case "lamba":
                        objectScript.audioSource.PlayOneShot(objectScript.audioClips[1]);
                        break;
                    case "cls":
                        objectScript.audioSource.PlayOneShot(objectScript.audioClips[2]);
                        break;
                    case "jetski":
                        objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]);
                        break;
                    case "jet":
                        objectScript.audioSource.PlayOneShot(objectScript.audioClips[4]);
                        break;
                    case "priora":
                        objectScript.audioSource.PlayOneShot(objectScript.audioClips[5]);
                        break;
                }
            }
        }
        else
        {
            // Ja nomests objekts nav pareizais – iestata, ka tas nav pareizā vieta
            objectScript.rightPlace = false;

            // Atskaņo kļūdas skaņu
            objectScript.audioSource.PlayOneShot(objectScript.audioClips[7]);

            // Atgriež objektu atpakaļ uz tā sākotnējo pozīciju
            switch (eventData.pointerDrag.tag)
            {
                case "mcquen":
                    objectScript.mcquen.GetComponent<RectTransform>().localPosition = objectScript.mcquenPos;
                    break;
                case "lamba":
                    objectScript.lamba.GetComponent<RectTransform>().localPosition = objectScript.lambaPos;
                    break;
                case "cls":
                    objectScript.cls.GetComponent<RectTransform>().localPosition = objectScript.clsPos;
                    break;
                case "jetski":
                    objectScript.jetski.GetComponent<RectTransform>().localPosition = objectScript.jetskiPos;
                    break;
                case "jet":
                    objectScript.jet.GetComponent<RectTransform>().localPosition = objectScript.jetPos;
                    break;
                case "priora":
                    objectScript.priora.GetComponent<RectTransform>().localPosition = objectScript.prioraPos;
                    break;
                default:
                    Debug.LogError("Unknown tag!");
                    break;
            }
        }
    }
}
