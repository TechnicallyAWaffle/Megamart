using PurrNet;
using Unity.VisualScripting;
using UnityEngine;

public class ScrapManager : NetworkBehaviour
{
    [SerializeField] private NetworkIdentity scrapPrefab;

    [SerializeField] private float timeBetweenSpawns;
    private float currentSpawnTimer;
    [SerializeField] float maxSpawnX;
    [SerializeField] float minSpawnY;
    [SerializeField] float maxSpawnZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpawnTimer <= 0)
        {
            currentSpawnTimer = timeBetweenSpawns;
            SpawnScrap();
        }
        else
            currentSpawnTimer -= Time.deltaTime;
    }

    private void SpawnScrap()
    {
        if (!isServer)
        {
            return;
        }

        float spawnX = Random.Range(-maxSpawnX, maxSpawnX);
        float spawnY = Random.Range(minSpawnY, 0);
        float spawnZ = Random.Range(-maxSpawnZ, maxSpawnZ);

        Instantiate(scrapPrefab, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }


    protected override void OnSpawned()
    {
        base.OnSpawned();

        if (!isServer)
        {
            return;
        }

        currentSpawnTimer = timeBetweenSpawns;
    }

}
