using _Scripts.Managers;
using UnityEngine;

namespace _Scripts.Controllers.Platform {
    public class HoopInsideController : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            var rb = other.GetComponent<Rigidbody2D>();
            if (!rb) return;

            Debug.Log("Ball has entered.");
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            GetComponent<Collider2D>().enabled = false;

            GameManager.AddScore();
        }
    }
}