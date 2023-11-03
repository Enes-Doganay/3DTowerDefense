using UnityEngine;

public class TurretShop : AbstractSingleton<TurretShop>
{
    [SerializeField] private TurretDataBase turretDataBase;
    [SerializeField] private ShopTurretItem shopTurretItem;
    [SerializeField] private GameObject turretShopPanel;
    [SerializeField] private Transform content;
    private TurretPlace selectedNode;
    private void InitiliazeShop()
    {
        for(int i=0; i< content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }

        foreach (var turret in turretDataBase.TurretDatabase)
        {
            var turretItem = Instantiate(shopTurretItem, content);
            turretItem.SetShopItem(turret, selectedNode);
        }
        turretShopPanel.SetActive(true);
    }
    public void SelectNode(TurretPlace node)
    {
        selectedNode = node;
        InitiliazeShop();
    }
    public void CloseShop()
    {
        selectedNode = null;
        turretShopPanel.SetActive(false);
    }
}