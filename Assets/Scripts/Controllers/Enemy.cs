using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject bombPrefab;

    private float timer = 0.0f;

    private bool hasBombSpawned = false;

    public float acceleration;

    public float maxSpeed = 7.0f;
    public float accelerationTime = 2.5f;
    public float decelerationTime = 2.5f;

    public float accelerateForHowLong;
    public float decelerateForHowLong;

    private float accelerateTimer = 0.0f;
    private float decelerateTimer = 0.0f;

    public bool doesEnemyKnowWhenToAccelerate;
    public bool doesEnemyKnowWhenToDecelerate;

    public Vector3 randomPoint;
    public bool randomPointDefined;

    private void Start()
    {
        doesEnemyKnowWhenToAccelerate = false;
        doesEnemyKnowWhenToDecelerate = false;

        randomPointDefined = false;

        randomPoint = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-9.0f, 9.0f), 0.0f);
    }

    private void Update()
    {
        FireBomb(1.0f);

        if (!randomPointDefined)
        {
            randomPoint = new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-9.0f, 9.0f), 0.0f);

            randomPointDefined = true;
        }

        else if (randomPointDefined)
        {
            EnemyRandomAccelerationLogic(randomPoint);
        }
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

    private void EnemyRandomAccelerationLogic(Vector3 randomVector)
    {
        if (doesEnemyKnowWhenToAccelerate == false && doesEnemyKnowWhenToDecelerate == false)
        {
            accelerateForHowLong = Random.Range(5.0f, 10.0f);

            doesEnemyKnowWhenToAccelerate = true;
        }

        else if (doesEnemyKnowWhenToAccelerate == true && doesEnemyKnowWhenToDecelerate == false)
        {
            accelerateTimer += Time.deltaTime;

            acceleration += (maxSpeed / accelerationTime) * Time.deltaTime;

            if (accelerateTimer > accelerateForHowLong && doesEnemyKnowWhenToDecelerate != true)
            {
                decelerateForHowLong = Random.Range(5.0f, 10.0f);

                accelerateForHowLong = 0.0f;

                accelerateTimer = 0.0f;

                doesEnemyKnowWhenToDecelerate = true;
                doesEnemyKnowWhenToAccelerate = false;
            }
        }

        else if (doesEnemyKnowWhenToDecelerate == true && doesEnemyKnowWhenToAccelerate != true)
        {
            decelerateTimer += Time.deltaTime;

            acceleration -= (maxSpeed / decelerationTime) * Time.deltaTime;

            if (decelerateTimer > decelerateForHowLong)
            {
                decelerateForHowLong = 0.0f;

                decelerateTimer = 0.0f;
                acceleration = 0.0f;

                doesEnemyKnowWhenToDecelerate = false;
                doesEnemyKnowWhenToAccelerate = false;
            }
        }

        if (acceleration <= 0.0f)
        {
            acceleration = 0.0f;
        }

        else if (acceleration >= maxSpeed)
        {
            acceleration = maxSpeed;
        }

        if (Vector2.Distance(transform.position, randomVector) < 0.2f)
        {
            randomPointDefined = false;
        }

        transform.position += (randomVector - transform.position).normalized * acceleration * Time.deltaTime;
    }
}
