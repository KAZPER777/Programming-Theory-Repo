using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BouncyDog : DogBase {
    public override void OnHitPlayer() {
        Debug.Log("Boing! Bouncy Dog hit the player.");
    }
}