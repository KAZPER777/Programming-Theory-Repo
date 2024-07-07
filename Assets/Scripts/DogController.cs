using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {
    public float speed = 5f;
    private Transform playerTransform;

    void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find player
    }

    void Update() {
        if (playerTransform != null) {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    // POLYMORPHSIM
    protected virtual void SelfDestruct() {
        Destroy(gameObject);
    }

}