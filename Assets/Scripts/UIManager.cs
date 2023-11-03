using TMPro;
using UnityEngine;

public class UIManager : AbstractSingleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI waveText;

    public void UpdateWaveUI(int waveCount)
    {
        waveText.text = "Stage : " + waveCount;
    }
    public void UpdateLivesUI(int liveCount)
    {
        livesText.text = "Lives : " + liveCount;
    }
    public void UpdateMoneyUI(float money)
    {
        moneyText.text = "Money : " + money.ToString("F0");
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}