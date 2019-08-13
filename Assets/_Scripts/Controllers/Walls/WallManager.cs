using System;
using _Scripts.State_Machine.States;
using UnityEngine;

namespace _Scripts.Controllers.Walls {
    public class WallManager : MonoBehaviour {
        #region Camera

        [Header("Scene Camera")] public UnityEngine.Camera mainCamera;

        #endregion

        #region Walls

        [Header("Wall Properties")] [Range(0.1f, 0.5f)]
        public float thickness = 0.25f;

        [Range(1f, 50f)] public float ceilingFactor = 20f;

        #endregion

        #region Events

        public delegate void Create();

        public static event Create OnCreateEvent;

        #endregion

        public Vector2 cameraWorldVector;

        public static WallData Data;

        private void OnEnable() {
            IdleState.OnEnterIdleEvent += Prepare;
        }

        private void OnDisable() {
            IdleState.OnEnterIdleEvent -= Prepare;
        }

        private void Prepare() {
            cameraWorldVector.x = Vector2.Distance(
                mainCamera.ScreenToWorldPoint(Vector3.zero),
                mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f))) * 0.5f;
            cameraWorldVector.y = Vector2.Distance(
                mainCamera.ScreenToWorldPoint(Vector3.zero),
                mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height))) * 0.5f;

            Data = new WallData(cameraWorldVector, thickness, ceilingFactor);

            try {
                if (OnCreateEvent != null)
                    OnCreateEvent.Invoke();
                else
                    EventExtension.ThrowMessage(nameof(OnCreateEvent));
            }
            catch (Exception e) {
                EventExtension.PrintError(e);
            }
        }
    }
}