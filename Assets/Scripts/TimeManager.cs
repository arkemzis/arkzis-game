using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [Header("Сколько реальных секунд = 1 игровой час")]
    public float realSecondsPerGameHour = 50f;

    [Header("Ссылка на текст на экране")]
    public TextMeshProUGUI timeTextUI;

    [HideInInspector] public float gameSecondsLeft = 24f * 3600f;
    private bool isRunning = true;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (!isRunning) return;

        float gameSecondsPerRealSecond = 3600f / realSecondsPerGameHour;
        gameSecondsLeft -= gameSecondsPerRealSecond * Time.deltaTime;

        if (gameSecondsLeft <= 0f)
        {
            gameSecondsLeft = 0f;
            isRunning = false;
            Debug.Log("=== ВРЕМЯ ВЫШЛО ===");
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timeTextUI != null)
            timeTextUI.text = GetTimeString();
    }

    public string GetTimeString()
    {
        int total = Mathf.FloorToInt(gameSecondsLeft);
        int hours = total / 3600;
        int minutes = (total % 3600) / 60;
        int seconds = total % 60;
        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}