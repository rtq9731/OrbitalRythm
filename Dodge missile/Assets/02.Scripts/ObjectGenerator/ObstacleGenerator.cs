using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : ObjectGenerator<ObstacleScript>
{
    [SerializeField] Transform[] obstaclePoints = null;

    [SerializeField] float upgradeTime = 40f;
    [SerializeField] float spawnTime = 10f;
    [SerializeField] float obstacleInitVelo = 7.5f;

    float upgradeTimer = 0f;
    float spawnTimer = 0f;

    int maxObstacleTier = 1;

    private void Update()
    {
        upgradeTimer += Time.deltaTime * GameManager.Instance.timeScale;
        spawnTimer += Time.deltaTime * GameManager.Instance.timeScale;

        if(upgradeTimer >= upgradeTime)
        {
            UpgradeObstacle();
            upgradeTimer = 0f;
        }

        if(spawnTimer >= spawnTime)
        {
            SpawnObstacle(Random.Range(1, maxObstacleTier));
            SpawnObstacle(Random.Range(1, maxObstacleTier));
            SpawnObstacle(Random.Range(1, maxObstacleTier));
            spawnTimer = 0f;
        }
    }

    public void UpgradeObstacle()
    {
        maxObstacleTier++;
    }

    public void SpawnObstacle(int tier)
    {
        Vector2 spawnPoint = obstaclePoints[Random.Range(0, obstaclePoints.Length)].position;

        objectPool.GetPoolObject().InitObstacle(tier, tier * 10, 7.5f, Utill.GetRandomDir(), spawnPoint);
    }

    public void SpawnObstacle(int tier, Vector3 point)
    {
        objectPool.GetPoolObject().InitObstacle(tier, tier * 10, 7.5f, Utill.GetRandomDir(), point);
    }

}
