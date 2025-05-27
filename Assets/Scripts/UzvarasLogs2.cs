using UnityEngine;
using UnityEngine.UI;

public class UzvarasLogs2 : MonoBehaviour
{
    // Statiskā instance, lai pie šīs klases varētu piekļūt no citām skripta vietām (singleton pattern)
    public static UzvarasLogs2 instance;

    // Atsauce uz taimeri, kas uzskaita laiku
    public TimerScript timerScript;

    // Uzvaras paneļa objekts
    public GameObject winPanel;

    // Teksta lauks, kurā tiks parādīts rezultāta laiks
    public Text timeResultText;

    // Masīvs ar zvaigžņu objektiem, kas tiks ieslēgti atkarībā no rezultāta
    public GameObject[] stars;

    // Mainīgais, lai skaitītu cik transportlīdzekļu ir pareizi novietoti
    private int placedCount = 0;

    // Kopējais transportlīdzekļu skaits, kas jānovieto
    private int totalVehicles = 6;

    // Inicializē instanci (izsaucas, kad objekts tiek ielādēts)
    void Awake()
    {
        instance = this;
    }

    // Šī metode tiek izsaukta, kad viens transportlīdzeklis tiek pareizi novietots
    public void VehiclePlaced()
    {
        placedCount++;

        // Ja visi transportlīdzekļi ir novietoti, parāda uzvaras logu
        if (placedCount >= totalVehicles)
        {
            WinGame();
        }
    }

    // Metode, kas izsaucas, kad spēle ir uzvarēta
    void WinGame()
    {
        // Apstādina taimeri
        timerScript.isRunning = false;

        // Parāda uzvaras paneli un noliek to priekšplānā
        winPanel.SetActive(true);
        winPanel.transform.SetAsLastSibling();

        // Parāda rezultāta laiku, pārveidojot to uz "hh:mm:ss" formātu
        float time = timerScript.elapsedTime;
        timeResultText.text = $"Laiks: {FormatTime(time)}";

        // Aprēķina un parāda zvaigznes atkarībā no laika
        int starCount = CalculateStars(time);
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(i < starCount);
        }
    }

    // Metode, lai aprēķinātu, cik zvaigznes dot atkarībā no laika
    int CalculateStars(float time)
    {
        if (time <= 45) return 3;
        else if (time <= 60) return 2;
        else if (time <= 75) return 1;
        else return 0;
    }

    // Formāts "hh:mm:ss", kurš tiks parādīts gala rezultātā
    string FormatTime(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
