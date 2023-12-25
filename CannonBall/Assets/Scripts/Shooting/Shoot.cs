using System.Collections.Generic;
using Cannon;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float force = 10f;

    [SerializeField] public Projectile ballPrefab;
    [SerializeField] private Transform _barrel;

    private readonly List<Projectile> ballsPool = new();
    private Vector3 direction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ShootFire();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Target>(out var target))
            gameObject.SetActive(false);
    }


    private Projectile CreateNewBall()
    {
        var ballGameObject = Instantiate(ballPrefab, transform.position, Quaternion.identity, null);

        ballsPool.Add(ballGameObject);

        return ballGameObject;
    }

    public void ShootFire()
    {
        direction = _barrel.forward + transform.forward;

        var currentBall = GetFreeBall();

        if (currentBall == null) currentBall = CreateNewBall();

        currentBall.Init(_barrel.position);

        currentBall.Rigidbody.AddForce(direction * force, ForceMode.VelocityChange);
    }

    private Projectile GetFreeBall()
    {
        foreach (var item in ballsPool)
            if (!item.isActiveAndEnabled)
            {
                item.transform.position = transform.position;
                item.Rigidbody.velocity = Vector3.zero;

                return item;
            }

        return null;
    }
}