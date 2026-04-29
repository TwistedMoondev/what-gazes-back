using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnrangeX = 12;
    private float spawnposz = 20;
    private float startDelay = 2;
    private float interval = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal() {
            Vector3 spawnPos = new Vector3 (Random.Range(-spawnrangeX, spawnrangeX),
             0, spawnposz);
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], spawnPos,
             animalPrefabs[animalIndex].transform.rotation);

    }
}
