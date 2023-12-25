using Cannon;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private RotateBase rotatebase;

    public void Update()
    {
        rotatebase.Rotate(
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * (Time.deltaTime * rotationSpeed)));
    }
}