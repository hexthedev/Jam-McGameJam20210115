using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;

    public float minVelocity = 0.03f;
    public float maxVelocity = 0.06f;

    public float minScale = 0.5f;
    public float maxScale = 2f;

    public float minSpawnCooldown = 5f;
    public float maxSpawnCooldown = 20f;

    public float minY = -5f;
    public float maxY = 5f;

    public void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    public void SpawnCloud()
    {
        GameObject ob = Instantiate(cloudPrefab);
        Rigidbody2D rb2 = ob.GetComponent<Rigidbody2D>();

        ob.transform.parent = transform;
        ob.transform.localPosition = new Vector3(0, Random.Range(minY, maxY), 0);

        float scale = Random.Range(minScale, maxScale);
        ob.transform.localScale = new Vector3(scale, scale, scale);

        Vector3 vec3 = new Vector3( Random.Range(minVelocity, maxVelocity), 0, 0 );
        rb2.velocity = vec3;
    }

    private IEnumerator SpawnClouds()
    {
        while (true)
        {
            SpawnCloud();
            yield return new WaitForSeconds(Random.Range(minSpawnCooldown, maxSpawnCooldown));
        }
    }
}
