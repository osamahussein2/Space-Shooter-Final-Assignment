using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject bombPrefab;

    public Transform bombSpawnPoint;

    private float timer = 0.0f;
    public float bombSpeed;

    private bool hasBombSpawned = false;

    private void Start()
    {
        bombPrefab.transform.position = bombSpawnPoint.transform.position;
    }

    private void Update()
    {
        FireBomb(1.0f);
    }

    private void FireBomb(float fireDelay)
    {
        if (!hasBombSpawned)
        {
            bombSpeed = 3.0f;

            bombPrefab.transform.position = bombSpawnPoint.transform.position;

            Instantiate(bombPrefab);

            hasBombSpawned = true;
        }

        else if (hasBombSpawned)
        {
            bombPrefab.transform.position += (player.transform.position - transform.position) *
                bombSpeed * Time.deltaTime;

            if (timer > fireDelay)
            {
                hasBombSpawned = false;

                timer = 0.0f;
            }
        }

        if (Vector2.Distance(bombPrefab.transform.position, player.transform.position) < 0.3f)
        {
            timer += Time.deltaTime;

            Destroy(bombPrefab);
        }
    }

}
