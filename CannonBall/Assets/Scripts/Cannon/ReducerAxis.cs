using UnityEngine;

namespace Cannon
{
    public class ReducerAxis :RotateBase
    {
        [SerializeField]
        private RotateBase origin;
        [SerializeField]
        private Vector2 coeff = Vector2.one;
        public override void Rotate(Vector2 vector)
        {
            origin.Rotate(vector*coeff);
        }
    }
}