using UnityEngine;

[CreateAssetMenu(menuName ="Data/TurretData")]
public class TurretData : ScriptableObject
{
    public GameObject TurretPrefab;
    public Sprite TurretSprite;
    public int TurretID;
    public float Damage;
    public float AttackRange;
    public float AttackSpeed;
    public int Cost;
    public TurretUpgradeData UpgradeData;
}