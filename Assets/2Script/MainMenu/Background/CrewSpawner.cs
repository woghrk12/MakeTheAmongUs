using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewSpawner : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private GameObject crewPrefab;

    [SerializeField] private Transform topRight;
    [SerializeField] private Transform bottomLeft;

    private float timer = 1f;
    private float distance = 9f;

    private bool[] isSpawn = new bool[(int)EPlayerColor.End];

    private void Start()
    {
        for (int i = 0; i < (int)EPlayerColor.End; i++)
        {
            SpawnFloatingCrew((EPlayerColor)i, distance);
            isSpawn[i] = true;
        }
    }

    private void Update()
    {
        TimeChecking();
    }

    private void TimeChecking()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnChecking(Random.Range(0, (int)EPlayerColor.End));
            timer = 0.5f;
        }
    }

    private void SpawnChecking(int value)
    {
        if (isSpawn[value]) return;

        SpawnFloatingCrew((EPlayerColor)value, distance);
        isSpawn[value] = true;
    }

    private void SpawnFloatingCrew(EPlayerColor color, float dist)
    {
        int angle = Random.Range(0, 360);

        Vector3 spawnPos = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f) * dist;
        Vector3 direction = (new Vector3(
                Random.Range(topRight.position.x, bottomLeft.position.x),
                Random.Range(topRight.position.y, bottomLeft.position.y),
                0f
                ) - spawnPos).normalized;
        float floatingSpeed = Random.Range(1f, 3f);
        float rotateSpeed = Random.Range(-1.5f, 1.5f);

        var crew = Instantiate(crewPrefab, spawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
        crew.SetFloatingCrew(
            sprites[Random.Range(0, sprites.Length)],
            direction,
            floatingSpeed,
            rotateSpeed,
            Random.Range(0.8f, 1f),
            color
            );
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var crew = collision.GetComponent<FloatingCrew>();
        if (crew)
        {
            isSpawn[(int)crew.color] = false;
            Destroy(crew.gameObject);
        }
    }
}
