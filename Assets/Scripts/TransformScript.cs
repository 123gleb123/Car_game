using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScript : MonoBehaviour
{
    // Atsauce uz ObjectScript, lai varētu piekļūt pēdējam vilktajam objektam
    public ObjectScript objectScript;

    void Update()
    {
        // Pārbauda, vai ir kāds objekts, kuru pēdējais vilcis lietotājs
        if (objectScript.lastDragged != null)
        {
            // Rotācija pa pulksteņrādītāja virzienu, ja tiek turēta 'Z' taustiņš
            if (Input.GetKey(KeyCode.Z))
            {
                objectScript.lastDragged.GetComponent<RectTransform>()
                    .transform.Rotate(0, 0, Time.deltaTime * 12f);
            }

            // Rotācija pret pulksteņrādītāja virzienu, ja tiek turēta 'X' taustiņš
            if (Input.GetKey(KeyCode.X))
            {
                objectScript.lastDragged.GetComponent<RectTransform>()
                    .transform.Rotate(0, 0, -Time.deltaTime * 12f);
            }

            // Mēroga palielināšana vertikālā virzienā, ja nospiesta bultiņa uz augšu
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Up Arrow Pressed");
                if (objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y < 1.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale = new Vector2(
                        objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x,
                        objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y + 0.005f);
                }
            }

            // Mēroga samazināšana vertikālā virzienā, ja nospiesta bultiņa uz leju
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y > 0.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale = new Vector2(
                        objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x,
                        objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y - 0.005f);
                }
            }

            // Mēroga samazināšana horizontālā virzienā, ja nospiesta bultiņa pa kreisi
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x > 0.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale = new Vector2(
                        objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x - 0.005f,
                        objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y);
                }
            }

            // Mēroga palielināšana horizontālā virzienā, ja nospiesta bultiņa pa labi
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x < 1.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale = new Vector2(
                        objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.x + 0.005f,
                        objectScript.lastDragged.GetComponent<RectTransform>().transform.localScale.y);
                }
            }
        }
    }
}
