using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DogBase : MonoBehaviour {
    protected Transform playerTransform;
    private int health = 100;
    private float speed = 5f;
    private int damage = 10;

    // ENCAPSULATION
    public int Health {
        get { return health; }
        set {
            health = Mathf.Clamp(value, 0, 100); // Ensure health is within 0-100
            if (health == 0) {
                SelfDestruct(); // Destroy the dog if health reaches zero
            }
        }
    }

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    public int Damage {
        get { return damage; }
        set { damage = value; }
    }

    protected virtual void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("SelfDestruct", .7f);
    }

    protected virtual void SelfDestruct() {
        Destroy(gameObject);
    }

    protected virtual void Update() {
        if (playerTransform != null) {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
    }

    public abstract void OnHitPlayer(); // Abstract method for handling player collision
}