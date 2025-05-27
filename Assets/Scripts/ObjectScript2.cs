using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript2 : MonoBehaviour
{
    // Atsauces uz objektiem (mašīnām, lidmašīnām utt.)
    public GameObject mcquen;
    public GameObject lamba;
    public GameObject cls;
    public GameObject jetski;
    public GameObject jet;
    public GameObject priora;

    // Sākotnējās pozīcijas katram objektam (glabājas startā)
    [HideInInspector] public Vector2 mcquenPos;
    [HideInInspector] public Vector2 lambaPos;
    [HideInInspector] public Vector2 clsPos;
    [HideInInspector] public Vector2 jetskiPos;
    [HideInInspector] public Vector2 jetPos;
    [HideInInspector] public Vector2 prioraPos;

    // Atskaņotājs skaņas efektiem
    public AudioSource audioSource;
    // Saraksts ar skaņu klipiem, kurus var atskaņot
    public AudioClip[] audioClips;

    // Karodziņš, kas norāda, vai objekts ir novietots pareizajā vietā
    [HideInInspector] public bool rightPlace = false;

    // Atsauce uz pēdējo pārvilkto objektu (piemēram, vilkšanas loģikai)
    public GameObject lastDragged = null;

    void Start()
    {
        // Saglabā sākotnējo pozīciju katram objektam, lai varētu to atjaunot, ja nepieciešams
        mcquenPos = mcquen.GetComponent<RectTransform>().localPosition;
        lambaPos = lamba.GetComponent<RectTransform>().localPosition;
        clsPos = cls.GetComponent<RectTransform>().localPosition;
        jetskiPos = jetski.GetComponent<RectTransform>().localPosition;
        jetPos = jet.GetComponent<RectTransform>().localPosition;
        prioraPos = priora.GetComponent<RectTransform>().localPosition;
    }
}
