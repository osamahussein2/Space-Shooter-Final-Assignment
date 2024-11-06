using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private GameObject player;
    private GameObject bombSpawnPoint;

    public float bombSpeed;
    private bool doesBombKnowItsSpeed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bombSpawnPoint = GameObject.Find("Enemy/FireBomb");

        transform.position = bombSpawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FireAtPlayer();
    }

    private void FireAtPlayer()
    {
        if (!doesBombKnowItsSpeed)
        {
            bombSpeed = Random.Range(1.0f, 4.0f);

            doesBombKnowItsSpeed = true;
        }

        else if (doesBombKnowItsSpeed)
        {
            transform.position += (player.transform.position - transform.position) * bombSpeed * Time.deltaTime;
        }

        // Destroy the bomb when it reached the player
        if (Vector2.Distance(transform.position, player.transform.position) < 0.3f)
        {
            Destroy(gameObject);
        }

        // Destroy the bomb after it left the screen
        if (transform.position.x < Camera.main.transform.position.x - 21.0f)
        {
            Destroy(gameObject);
        }

        else if (transform.position.x > Camera.main.transform.position.x + 21.0f)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < Camera.main.transform.position.y - 10.0f)
        {
            Destroy(gameObject);
        }

        else if (transform.position.y > Camera.main.transform.position.y + 10.0f)
        {
            Destroy(gameObject);
        }
    }
}
