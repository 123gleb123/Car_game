using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScript2 : MonoBehaviour
{
    public ObjectScript2 objectScript;  // Atsauce uz objektu, kur tiek glabāts pēdējais vilktais objekts

    void Update()
    {
        // Pārbauda, vai ir kāds pēdējais vilktais objekts, ar kuru strādāt
        if (objectScript.lastDragged != null)
        {
            // Rotācija pa pulksteni, ja nospiesta taustiņš Z
            if (Input.GetKey(KeyCode.Z))
            {
                objectScript.lastDragged.GetComponent<RectTransform>().transform.Rotate(0, 0, Time.deltaTime * 12f);
            }

            // Rotācija pretēji pulksteņrādītāja virzienam, ja nospiesta taustiņš X
            if (Input.GetKey(KeyCode.X))
            {
                objectScript.lastDragged.GetComponent<RectTransform>().transform.Rotate(0, 0, -Time.deltaTime * 12f);
            }

            // Palielina augstumu (y ass skalu), ja nospiesta bultiņa uz augšu un augstums < 1.5
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Up Arrow Pressed");
                RectTransform rt = objectScript.lastDragged.GetComponent<RectTransform>();
                if (rt.transform.localScale.y < 1.5f)
                {
                    rt.transform.localScale = new Vector2(rt.transform.localScale.x, rt.transform.localScale.y + 0.005f);
                }
            }

            // Samazina augstumu (y ass skalu), ja nospiesta bultiņa uz leju un augstums > 0.5
            if (Input.GetKey(KeyCode.DownArrow))
            {
                RectTransform rt = objectScript.lastDragged.GetComponent<RectTransform>();
                if (rt.transform.localScale.y > 0.5f)
                {
                    rt.transform.localScale = new Vector2(rt.transform.localScale.x, rt.transform.localScale.y - 0.005f);
                }
            }

            // Samazina platumu (x ass skalu), ja nospiesta bultiņa pa kreisi un platums > 0.5
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                RectTransform rt = objectScript.lastDragged.GetComponent<RectTransform>();
                if (rt.transform.localScale.x > 0.5f)
                {
                    rt.transform.localScale = new Vector2(rt.transform.localScale.x - 0.005f, rt.transform.localScale.y);
                }
            }

            // Palielina platumu (x ass skalu), ja nospiesta bultiņa pa labi un platums < 1.5
            if (Input.GetKey(KeyCode.RightArrow))
            {
                RectTransform rt = objectScript.lastDragged.GetComponent<RectTransform>();
                if (rt.transform.localScale.x < 1.5f)
                {
                    rt.transform.localScale = new Vector2(rt.transform.localScale.x + 0.005f, rt.transform.localScale.y);
                }
            }
        }
    }
}
