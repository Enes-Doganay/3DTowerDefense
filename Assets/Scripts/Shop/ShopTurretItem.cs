using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopTurretItem : MonoBehaviour
{
    [SerializeField] private Image turretImage;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI rangeText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Button buyButton;
    public void SetShopItem(TurretData turretData, TurretPlace buildNode)
    {
        turretImage.sprite = turretData.TurretSprite;
        damageText.text = "Damage : " + turretData.Damage.ToString("F2");
        rangeText.text = "Range : " + turretData.AttackRange.ToString("F2");
        speedText.text = "Speed : " + turretData.AttackSpeed.ToString("F2");
        costText.text = "Cost : " + turretData.Cost.ToString("F2");
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(() => buildNode.BuildTurret(turretData));
    }
}
