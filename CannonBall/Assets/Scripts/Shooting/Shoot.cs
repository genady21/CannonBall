using Cannon;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Projectile yadroAbstr;
    public GameObject startPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(yadroAbstr, startPoint.transform.position, startPoint.transform.rotation).direction = startPoint.transform;
    }
}