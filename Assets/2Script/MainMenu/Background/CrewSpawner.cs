using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewSpawner : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private GameObject crewPrefab;

    [SerializeField] private Transform topRight;
    [SerializeField] private Transform bottomLeft;

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
}
