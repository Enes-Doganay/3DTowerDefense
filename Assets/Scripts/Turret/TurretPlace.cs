using UnityEngine;
using UnityEngine.EventSystems;

public class TurretPlace : MonoBehaviour
{
    public Color hoverColor;
    public Color insufficientFundColor;

    private Turret turret;
    private TurretData turretData;
    public Turret Turret => turret;
    public TurretData TurretData => turretData;
    private Renderer rend;
    private Color startColor;

    public Vector3 positionOffset;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Turret != null)
        {
            UpgradeManager.Instance.SelectNode(this);
            return;
        }
        else
        {
            TurretShop.Instance.SelectNode(this);
        }
    }

    public void BuildTurret(TurretData data)
    {
        if (CurrencyManager.Instance.Money < data.Cost)
        {
            Debug.Log("Insufficient fund!");
            return;
        }

        CurrencyManager.Instance.RemoveMoney(data.Cost);
        TurretShop.Instance.CloseShop();

        GameObject turretObject = Instantiate(data.TurretPrefab, GetBuildPosition(), Quaternion.identity);

        turret = turretObject.GetComponent<Turret>();
        turretData = data;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void SellTurret()
    {
        //PlayerStats.money += turretData.GetSellAmount();

        // Add any additional cleanup code if needed

        Destroy(Turret);
        turret = null;
        turretData = null;
    }
}