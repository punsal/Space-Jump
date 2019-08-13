using UnityEngine;

namespace _Scripts.Controllers.Ball {
    [RequireComponent(typeof(LineRenderer))]
    public class DragController : MonoBehaviour {
        [Header("Main Camera")] public UnityEngine.Camera mainCamera;
        [Header("Throwable Object")] public Rigidbody2D rigidbody2d;

        [Header("Line Renderer")] [Range(2, 32)]
        public int resolution = 16;

        [Header("Force Factor")] [Range(1f, 10f)]
        public float forceFactor = 5f;

        [Header("Test Showcase")] public Vector3 startPosition = Vector3.zero;
        public Vector3 holdPosition = Vector3.zero;

        private LineRenderer m_lineRenderer;

        /// <summary>
        /// Distance between Input.pressed.position and Input.released.position
        /// <para>Input : currently MouseButton(0)</para>
        /// </summary>
        private Vector3 m_inputDistance;

        private void Start() {
            m_lineRenderer = GetComponent<LineRenderer>();
            m_lineRenderer.positionCount = 1;
            m_lineRenderer.SetPosition(0, Vector3.zero);
            m_lineRenderer.enabled = false;
        }

        private void Update() {
            m_lineRenderer.SetPosition(0, rigidbody2d.transform.position);
            if (Input.GetMouseButtonDown(0)) {
                startPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                rigidbody2d.velocity = Vector3.zero;
                rigidbody2d.angularVelocity = Vector3.zero.magnitude;

                m_lineRenderer.positionCount = resolution;
                m_lineRenderer.enabled = true;
            }
            else if (Input.GetMouseButton(0)) {
                holdPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

                m_inputDistance = startPosition - holdPosition;

                var calculatedPoints = CalculateFlyPoints(m_inputDistance.y, m_inputDistance.x);
                for (int i = 0; i < calculatedPoints.Length; i++) {
                    calculatedPoints[i] += m_lineRenderer.GetPosition(0);
                }

                m_lineRenderer.SetPositions(calculatedPoints);
            }
            else if (Input.GetMouseButtonUp(0)) {
                rigidbody2d.AddForce(m_inputDistance * forceFactor, ForceMode2D.Impulse);

                m_lineRenderer.positionCount = 1;
                m_lineRenderer.enabled = false;

                startPosition = Vector3.zero;
                holdPosition = Vector3.zero;
            }
            else {
                Debug.Log("Wait");
            }
        }

        private Vector3[] CalculateFlyPoints(float verticalForce, float horizontalForce) {
            //Time of Maximum Height = VerticalForce / VerticalGravity
            //Height of any Time Given = (VerticalForce * GivenTime) - [(1 / 2) * VerticalGravity * GivenTime ^ 2]
            verticalForce *= forceFactor;
            horizontalForce *= forceFactor;

            //Find time
            var risingTime = verticalForce / Mathf.Abs(Physics.gravity.y);
            var timeDifference = risingTime / (resolution);

            var points = new Vector3[resolution];
            for (var i = 0; i < resolution; i++) {
                points[i].x = horizontalForce * (i * timeDifference);

                points[i].y = verticalForce * (i * timeDifference) -
                              0.5f * Mathf.Abs(Physics.gravity.y) * Mathf.Pow((i * timeDifference), 2);
            }

            return points;
        }
    }
}