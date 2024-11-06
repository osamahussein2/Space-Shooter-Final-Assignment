using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject bombPrefab;

    public Transform bombSpawnPoint;

    private float timer = 0.0f;

    private bool hasBombSpawned = false;

    private void Start()
    {

    }

    private void Update()
    {
        FireBomb(1.0f);
    }

    private void FireBomb(float fireDelay)
    {
        if (!hasBombSpawned)
        {
            Instantiate(bombPrefab);

            hasBombSpawned = true;
        }

        else if (hasBombSpawned)
        {
            timer += Time.deltaTime;

            if (timer > fireDelay)
            {
                hasBombSpawned = false;

                timer = 0.0f;
            }
        }
    }

}
