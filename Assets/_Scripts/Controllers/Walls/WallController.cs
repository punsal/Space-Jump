using System;
using UnityEngine;

namespace _Scripts.Controllers.Walls {
    public class WallController : MonoBehaviour {
        public WallType wallType = WallType.Left;

        private void OnEnable() {
            WallManager.OnCreateEvent += Create;
        }

        private void OnDisable() {
            WallManager.OnCreateEvent -= Create;
        }

        private void Create() {
            var wallTransform = transform;
            switch (wallType) {
                case WallType.Left:
                    wallTransform.localScale = new Vector3(
                        WallManager.Data.Thickness,
                        WallManager.Data.PositionVector.y * 2f * (1f + WallManager.Data.CeilingFactor * 0.1f),
                        1f);
                    wallTransform.position = new Vector3(
                        -1 * (WallManager.Data.Thickness * 0.5f + WallManager.Data.PositionVector.x),
                        WallManager.Data.CeilingFactor * 0.1f);
                    break;
                case WallType.Up:
                    wallTransform.gameObject.SetActive(false);
                    break;
                case WallType.Right:
                    wallTransform.localScale = new Vector3(
                        WallManager.Data.Thickness,
                        WallManager.Data.PositionVector.y * 2f * (1f + WallManager.Data.CeilingFactor * 0.1f),
                        1f);
                    wallTransform.position = new Vector3(
                        WallManager.Data.Thickness * 0.5f + WallManager.Data.PositionVector.x,
                        WallManager.Data.CeilingFactor * 0.1f);
                    break;
                case WallType.Down:
                    wallTransform.localScale = new Vector3(
                        WallManager.Data.PositionVector.x * 2f + 1f,
                        WallManager.Data.Thickness,
                        1f);
                    wallTransform.position = new Vector3(
                        0f,
                        -1 * WallManager.Data.PositionVector.y - WallManager.Data.Thickness * 0.5f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}