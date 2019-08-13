using UnityEngine;

namespace _Scripts.Controllers.Walls {
    public struct WallData {
        public Vector2 PositionVector;
        public float Thickness;
        public float CeilingFactor;

        public WallData(Vector2 positionVector, float thickness, float ceilingFactor) {
            PositionVector = positionVector;
            Thickness = thickness;
            CeilingFactor = ceilingFactor;
        }
    }
}