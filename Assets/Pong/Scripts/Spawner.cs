using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pickUp;
    public GameObject pickUp2;
    public float spawnTime;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    public void Spawn()
    {
        float spawnPointX = Random.Range(-5f, 5f);
        float spawnPointY = 0.5f;
        float spawnPointZ = Random.Range(-3f, 3f);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        //Double this to add new power up, (Random number to pick)
        int rand = Random.Range(1, 3);
        if (rand == 1)
        {
            Instantiate(pickUp, spawnPosition, Quaternion.identity);
        }
        if (rand == 2)
        {
            Instantiate(pickUp2, spawnPosition, Quaternion.identity);
        }        
    }
}
