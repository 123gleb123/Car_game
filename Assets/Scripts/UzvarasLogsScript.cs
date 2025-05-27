using UnityEngine;
using UnityEngine.UI;

public class UzvarasLogs : MonoBehaviour
{
    public static UzvarasLogs instance;

    public TimerScript timerScript;
    public GameObject winPanel;
    public Text timeResultText;
    public GameObject[] stars;

    private int placedCount = 0;
    private int totalVehicles = 12;

    void Awake()
    {
        instance = this;
    }

    public void VehiclePlaced()
    {
        placedCount++;

        if (placedCount >= totalVehicles)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        timerScript.isRunning = false;

        winPanel.SetActive(true);

        float time = timerScript.elapsedTime;
        timeResultText.text = $"Laiks: {FormatTime(time)}";

        int starCount = CalculateStars(time);
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(i < starCount);
        }
    }

    int CalculateStars(float time)
    {
        if (time <= 80) return 3;
        else if (time <= 120) return 2;
        else if (time <= 160) return 1;
        else return 0;
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
