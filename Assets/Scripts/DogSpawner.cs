using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpawner : MonoBehaviour {
    public GameObject dogPrefab;
    public float spawnInterval = 34f;
    public float spawnDistance = 10f;

    private Transform playerTransform;

    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnDog", 0f, spawnInterval); // Start spawning rocks
    }

    void SpawnDog() {
        if (playerTransform != null) {
            // Calculate spawn position behind the player
            Vector3 spawnPosition = playerTransform.position - playerTransform.forward * spawnDistance;
            spawnPosition.y = 7;
            Instantiate(dogPrefab, spawnPosition, Quaternion.identity);
        }
    }
}