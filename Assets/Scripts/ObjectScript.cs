using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public GameObject garbageTruck;
    public GameObject schoolBuss;
    public GameObject medic;
    public GameObject ekskavator;
    public GameObject e46;
    public GameObject b2;
    public GameObject e61;
    public GameObject police;
    public GameObject traktors1;
    public GameObject traktos5;
    public GameObject cementaMasina;
    public GameObject ugunsdzeSeji;


    [HideInInspector] public Vector2 gTruckPos;
    [HideInInspector] public Vector2 sBussPos;
    [HideInInspector] public Vector2 medicPos;
    [HideInInspector] public Vector2 ekskavatorPos;
    [HideInInspector] public Vector2 e46Pos;
    [HideInInspector] public Vector2 b2Pos;
    [HideInInspector] public Vector2 e61Pos;
    [HideInInspector] public Vector2 policePos;
    [HideInInspector] public Vector2 traktors1Pos;
    [HideInInspector] public Vector2 traktos5Pos;
    [HideInInspector] public Vector2 cementaMasinaPos;
    [HideInInspector] public Vector2 ugunsdzeSejiPos;

    public AudioSource audioSource;
    public AudioClip[] audioClips;
    [HideInInspector] public bool rightPlace = false;
    public GameObject lastDragged = null;

    void Start()
    {
        gTruckPos = garbageTruck.GetComponent<RectTransform>().localPosition;
        sBussPos = schoolBuss.GetComponent<RectTransform>().localPosition;
        medicPos = medic.GetComponent<RectTransform>().localPosition;
        ekskavatorPos = ekskavator.GetComponent<RectTransform>().localPosition;
        e46Pos = e46.GetComponent<RectTransform>().localPosition;
        b2Pos = b2.GetComponent<RectTransform>().localPosition;
        e61Pos = e61.GetComponent<RectTransform>().localPosition;
        policePos = police.GetComponent<RectTransform>().localPosition;
        traktors1Pos = traktors1.GetComponent<RectTransform>().localPosition;
        traktos5Pos = traktos5.GetComponent<RectTransform>().localPosition;
        cementaMasinaPos = cementaMasina.GetComponent<RectTransform>().localPosition;
        ugunsdzeSejiPos = ugunsdzeSeji.GetComponent<RectTransform>().localPosition;
    }
}
