using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int moneyReward = 20;
    [SerializeField] private float startHealth = 100;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject enemyDiedEffect;

    private float health;
    private bool isDead;
    public float StartHealth => startHealth;
    public float Health => health;
    void Start()
    {
        isDead = false;
        health = startHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        //healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {

        isDead = true;

        CurrencyManager.Instance.AddMoney(moneyReward);

        //GameObject diedEff = Instantiate(enemyDiedEffect, transform.position, transform.rotation);
        EnemyWave.Instance.RemoveEnemyFromList(this);
        Destroy(gameObject);
    }
}
