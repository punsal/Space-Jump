using Doozy.Engine;
using UnityEngine;

namespace _Scripts.Controllers.Base_Line
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BaseLineController : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            var rb = other.GetComponent<Rigidbody2D>();
            if (!rb) return;

            Debug.Log("Ball has failed.");
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
            Message.Send("GAME_OVER");
        }
    }
}