using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text timerText;      // Teksta UI elements, kurā tiks rādīts taimeris
    public float elapsedTime = 0f;  // Uzkrātais laiks sekundēs
    public bool isRunning = true;   // Vai taimeris ir aktīvs un skaita laiku

    void Update()
    {
        if (isRunning)  // Ja taimeris darbojas
        {
            elapsedTime += Time.deltaTime;  // Pieskaita laiku kopējam skaitlim (sekundēs)
            UpdateTimerDisplay();            // Atjauno taimeris tekstā
        }
    }

    // Funkcija, kas aprēķina minūtes un sekundes un atjauno tekstu UI
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);  // Aprēķina pilnas minūtes
        int seconds = Mathf.FloorToInt(elapsedTime % 60);  // Aprēķina atlikušās sekundes
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);  // Formatē un izvada tekstā MM:SS formātā
    }
}
