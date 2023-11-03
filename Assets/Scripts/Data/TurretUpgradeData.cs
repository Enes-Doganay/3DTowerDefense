using UnityEngine;

[CreateAssetMenu(menuName ="Data/TurretUpgradeData")]
public class TurretUpgradeData : ScriptableObject
{
    public int UpgradeCost;
    public float UpgradeCostMultiplier;
    public float DamageMultiplier;
    public float AttackRangeMultiplier;
    public float AttackSpeedMultiplier;
}
