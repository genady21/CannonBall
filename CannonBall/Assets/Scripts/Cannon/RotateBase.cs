using UnityEngine;

namespace Cannon
{
    public class RotateBase : RotateAxis
    {
        [SerializeField] private Transform axis;
        [SerializeField] private Vector2 current;

        private void Awake()
        {
            ApplyRotation();
        }

        private void ApplyRotation()
        {
            axis.rotation = Quaternion.Euler(current.y, current.x, 0);
        }

        public override void Rotate(Vector2 vector)
        {
            // current += vector;
            current.x = Mathf.Clamp(current.x + vector.x, -55, 55);
            current.y = Mathf.Clamp(current.y - vector.y, -30, 0);
            ApplyRotation();
        }
    }
}