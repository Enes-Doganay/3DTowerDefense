using UnityEngine;

public class UpgradeManager : AbstractSingleton<UpgradeManager>
{
    [SerializeField] private TurretUpgradePanel turretUpgradePanel;
    private TurretPlace selectedPlace;

    public void Upgrade()
    {
        float upgradeCost = CalculateUpgradeCost();
        if (CurrencyManager.Instance.Money >= upgradeCost)
        {
            selectedPlace.Turret.ApplyUpgradeValue();
            CurrencyManager.Instance.RemoveMoney(upgradeCost);
            SetUpgradePanel();
        }
    }
    private float CalculateUpgradeCost()
    {
        float baseCost = selectedPlace.Turret.Data.UpgradeData.UpgradeCost;
        float costMultiplier = selectedPlace.Turret.Data.UpgradeData.UpgradeCostMultiplier;
        int turretLevel = selectedPlace.Turret.Level;

        float upgradeCost = baseCost * Mathf.Pow(costMultiplier, turretLevel);

        return upgradeCost;
    }
    public void SelectNode(TurretPlace selectedUpgradeNode)
    {
        selectedPlace = selectedUpgradeNode;
        SetUpgradePanel();
    }
    private void SetUpgradePanel()
    {
        turretUpgradePanel.SetUpgradePanel(selectedPlace, CalculateUpgradeCost());
    }
}