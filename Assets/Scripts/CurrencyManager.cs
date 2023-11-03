using System.Collections;
using UnityEngine;

public class CurrencyManager : AbstractSingleton<CurrencyManager>
{
    private float money;
    public float Money => money;
    private void Start()
    {
        AddMoney(300);
    }
    public void AddMoney(float value)
    {
        money += value;
        UIManager.Instance.UpdateMoneyUI(money);
    }
    public void RemoveMoney(float value)
    {
        money -= value;
        UIManager.Instance.UpdateMoneyUI(money);
    }
}