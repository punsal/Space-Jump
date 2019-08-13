using System;
using UnityEngine;

namespace _Scripts.Controllers.Camera {
    public class CameraController : MonoBehaviour {
        public UnityEngine.Camera mainCamera;
        public Transform ball;

        [Range(0f, 0.5f)] public float yAxisThreshold;

        private Vector2 m_cameraWorldPosition;

        private Vector2 CalculateCameraPosition() {
            return new Vector2(
                Vector2.Distance(
                    mainCamera.ScreenToWorldPoint(Vector3.zero),
                    mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f))) * 0.5f,
                Vector2.Distance(
                    mainCamera.ScreenToWorldPoint(Vector3.zero),
                    mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height))) * 0.5f);
        }

        // Start is called before the first frame update
        private void Start() { }

        // Update is called once per frame
        private void Update() { }
    }
}