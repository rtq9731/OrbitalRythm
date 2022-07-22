using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] Transform[] obstaclePoints = null;
    [SerializeField] ObstacleScript obstaclePrefab = null;

    GenericPool<ObstacleScript> obstaclePool = null;

    [SerializeField] float upgradeTime = 40f;
    [SerializeField] float spawnTime = 10f;
    [SerializeField] float obstacleInitVelo = 7.5f;

    float upgradeTimer = 0f;
    float spawnTimer = 0f;

    int curObstacleTier = 1;

    private void Start()
    {
        obstaclePool = GenericPoolManager.CratePool<ObstacleScript>("obstacle", obstaclePrefab, GameObject.Find("PoolParent").transform, 5);
    }

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
            SpawnObstacle(curObstacleTier);
            spawnTimer = 0f;
        }
    }

    public void UpgradeObstacle()
    {
        curObstacleTier++;
        Debug.Log(curObstacleTier);
    }

    public void SpawnObstacle(int tier)
    {
        Vector2 spawnPoint = obstaclePoints[Random.Range(0, obstaclePoints.Length)].position;

        obstaclePool.GetPoolObject().InitObstacle(tier, tier * 10, 7.5f, GetRandomDir(), spawnPoint);
    }

    public void SpawnObstacle(int tier, Vector3 point)
    {
        obstaclePool.GetPoolObject().InitObstacle(tier, tier * 10, 7.5f, GetRandomDir(), point);
    }

    private Vector2 GetRandomDir()
    {
        Vector2 result = Vector2.zero;

        do
        {
            result = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        while (result == Vector2.zero);

        return result;
    }

}
