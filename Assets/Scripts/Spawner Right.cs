using System;
using System.Collections;
using UnityEngine;

public class SpawnerRight : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 1f; 
    public float birdSpeed = 3f;
    public float scaleMultiplier = 1.5f;
    public int birdsPerSpawn = 10; // 10 con chim mỗi lần spawn

    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider == null)
            return;

        StartCoroutine(SpawnBirds());
    }

    IEnumerator SpawnBirds()
    {
        while (true)
        {
            for (int i = 0; i < birdsPerSpawn; i++)
            {
                SpawnBird();
                yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.3f)); // Độ trễ ngẫu nhiên giúp chim không xuất hiện cùng lúc
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBird()
    {
        if (boxCollider == null) return;

        float spawnX = transform.position.x;
        float minY = boxCollider.bounds.min.y;
        float maxY = boxCollider.bounds.max.y;
        float spawnY = UnityEngine.Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        GameObject newBird = Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
        newBird.transform.position = spawnPosition;
        newBird.transform.localScale = new Vector3(-scaleMultiplier, scaleMultiplier, 1);

        Rigidbody2D rb = newBird.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(-birdSpeed, 0);
        }
    }
}
