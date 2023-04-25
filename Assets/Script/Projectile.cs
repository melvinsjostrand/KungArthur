using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction, float speed) {
        rb.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter(Collision collision) {
        // Destroy the projectile on collision with another object
        Destroy(gameObject);
    }
}
