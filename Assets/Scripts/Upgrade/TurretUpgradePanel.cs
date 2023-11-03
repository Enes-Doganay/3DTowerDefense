using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretUpgradePanel : MonoBehaviour
{
    [SerializeField] private Image turretImage;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI attackRangeText;
    [SerializeField] private TextMeshProUGUI attackSpeedText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Button upgradeButton;

    public void SetUpgradePanel(TurretPlace selectedNode, float upgradeCost)
    {
        TurretData turretData = selectedNode.Turret.Data;
        turretImage.sprite = turretData.TurretSprite;
        levelText.text = "Turret Level " + selectedNode.Turret.Level;
        damageText.text = selectedNode.Turret.Damage.ToString("F2") + " >> " + (selectedNode.Turret.Damage * turretData.UpgradeData.DamageMultiplier).ToString("F2");
        damageText.text = selectedNode.Turret.AttackRange.ToString("F2") + " >> " + (selectedNode.Turret.Damage * turretData.UpgradeData.AttackRangeMultiplier).ToString("F2");
        damageText.text = selectedNode.Turret.AttackSpeed.ToString("F2") + " >> " + (selectedNode.Turret.Damage * turretData.UpgradeData.AttackSpeedMultiplier).ToString("F2");
        costText.text = "Cost : " + upgradeCost.ToString("F2");
        upgradeButton.onClick.RemoveAllListeners();
        upgradeButton.onClick.AddListener(() => UpgradeManager.Instance.Upgrade());
        gameObject.SetActive(true);
    }
}