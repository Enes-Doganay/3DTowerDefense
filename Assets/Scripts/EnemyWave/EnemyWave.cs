using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : AbstractSingleton<EnemyWave>
{
    public GameManager gameManager; // GameManager script reference
    public Wave[] waves; // Array of Wave objects
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;

    private List<EnemyHealth> enemies = new List<EnemyHealth>();
    private float countdown = 2f;
    private int waveIndex = 0;
    private bool spawningWave = false;

    private void Update()
    {
        if (spawningWave)
            return;

        if (waveIndex == waves.Length && enemies.Count == 0)
        {
            gameManager.GameWin();
            enabled = false;
        }

        if (countdown <= 0f && waveIndex != waves.Length)
        {
            StartCoroutine(SpawnWave(waves[waveIndex]));
            countdown = timeBetweenWaves;
            waveIndex++;
        }

        countdown -= Time.deltaTime;
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        spawningWave = true;
        UIManager.Instance.UpdateWaveUI(waveIndex + 1);
        yield return new WaitForSeconds(2f); // Delay before starting the wave

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        spawningWave = false;
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        AddEnemyToList(enemy.GetComponent<EnemyHealth>());
    }
    private void AddEnemyToList(EnemyHealth enemy)
    {
        enemies.Add(enemy);
    }
    public void RemoveEnemyFromList(EnemyHealth enemy)
    {
        enemies.Remove(enemy);
    }
    public List<EnemyHealth> GetEnemies()
    {
        return enemies;
    }
}