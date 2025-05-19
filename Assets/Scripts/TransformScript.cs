using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScript : MonoBehaviour
{
    public ObjectScript objectScript;

    void Update()
    {
        if (objectScript.lastDragged != null)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                objectScript.lastDragged.GetComponent<RectTransform>().
                     transform.Rotate(0, 0, Time.deltaTime * 12f);
            }

            if (Input.GetKey(KeyCode.X))
            {
                objectScript.lastDragged.GetComponent<RectTransform>().
                     transform.Rotate(0, 0, -Time.deltaTime * 12f);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Up Arrow Pressed");
                if (objectScript.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.y < 1.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                         objectScript.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.x,
                         objectScript.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.y + 0.001f);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objectScript.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.y > 0.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                         objectScript.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.x,
                         objectScript.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.y - 0.001f);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (objectScript.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.x > 0.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                         objectScript.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.x - 0.001f,
                         objectScript.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.y);
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (objectScript.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.x < 1.5f)
                {
                    objectScript.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                         objectScript.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.x + 0.001f,
                         objectScript.lastDragged.GetComponent<RectTransform>().
                         transform.localScale.y);
                }
            }
        }
    }
}
