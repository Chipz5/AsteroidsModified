using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnRate = 7.0f;
    public int spawnAmount = 1;
    public float spawnRadius = 5.0f;
    public float timeToLive = 10.0f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnPos = Random.insideUnitCircle * spawnRadius;
            GameObject pickup = Instantiate(this.pickupPrefab, spawnPos, Quaternion.identity);
            Destroy(pickup,timeToLive);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, spawnRadius);
    }
}
