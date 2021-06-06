using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAwan : MonoBehaviour
{
    public GameObject Prefab;
    public float waktuMinimal, waktuMaximal;
    float spawnTime;

    Vector2 screenHalfSizeWorldUnits;

    // Use this for initialization
    void Start () {
        screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update () {

        if (Time.time > spawnTime) {
            spawnTime = Time.time + Random.Range(waktuMinimal, waktuMaximal);

            Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizeWorldUnits.x + -2f, screenHalfSizeWorldUnits.x + -10f), screenHalfSizeWorldUnits.y + -3f);
            Instantiate (Prefab, spawnPosition, Quaternion.identity);
        }

    }
}
