using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/TurretDataBase")]
public class TurretDataBase : ScriptableObject
{
    public List<TurretData> TurretDatabase;

    public TurretData GetTurret(int id)
    {
        TurretData data = TurretDatabase.Find(turret => turret.TurretID == id);
        return data;
    }
}