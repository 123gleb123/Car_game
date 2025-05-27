using UnityEngine;
using UnityEngine.UI;

public class UzvarasLogs : MonoBehaviour
{
    // Statiskā instance (Singleton), lai piekļūtu šim objektam no citiem skriptiem
    public static UzvarasLogs instance;

    // Atsauce uz taimeri, kas mēra spēles ilgumu
    public TimerScript timerScript;

    // Uzvaras logs/panels, kas tiek aktivizēts pēc uzvaras
    public GameObject winPanel;

    // Teksts, kurā tiks parādīts pabeigšanas laiks
    public Text timeResultText;

    // Masīvs ar zvaigžņu objektiem, ko aktivizē atkarībā no rezultāta
    public GameObject[] stars;

    // Skaita, cik transportlīdzekļu ir pareizi novietoti
    private int placedCount = 0;

    // Kopējais nepieciešamo transportlīdzekļu skaits
    private int totalVehicles = 12;

    // Tiek izsaukts, kad objekts tiek ielādēts (instancē Singleton)
    void Awake()
    {
        instance = this;
    }

    // Tiek izsaukta katru reizi, kad transportlīdzeklis tiek pareizi novietots
    public void VehiclePlaced()
    {
        placedCount++;

        // Ja visi transportlīdzekļi ir novietoti, tiek izsaukta uzvaras metode
        if (placedCount >= totalVehicles)
        {
            WinGame();
        }
    }

    // Metode, kas tiek izsaukta, kad spēle ir pabeigta
    void WinGame()
    {
        // Apstādina taimeri
        timerScript.isRunning = false;

        // Aktivizē uzvaras paneli un noliek to priekšplānā
        winPanel.SetActive(true);
        winPanel.transform.SetAsLastSibling();

        // Iegūst un attēlo pabeigšanas laiku
        float time = timerScript.elapsedTime;
        timeResultText.text = $"Laiks: {FormatTime(time)}";

        // Aprēķina, cik zvaigžņu piešķirt, un attiecīgi aktivizē tās
        int starCount = CalculateStars(time);
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(i < starCount);
        }
    }

    // Aprēķina zvaigžņu skaitu atkarībā no pabeigšanas laika
    int CalculateStars(float time)
    {
        if (time <= 80) return 3;
        else if (time <= 120) return 2;
        else if (time <= 160) return 1;
        else return 0;
    }

    // Formatē laiku kā "hh:mm:ss"
    string FormatTime(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
