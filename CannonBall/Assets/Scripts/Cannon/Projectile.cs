using Unity.VisualScripting;
using UnityEngine;

namespace Cannon
{
    public class Projectile: MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rb;
        private float sila;
        public Transform direction;
        
        public void Start()
        {
            transform.parent = null;
            sila = Random.Range(1200, 1000);
            rb.AddForce(direction.forward * sila,ForceMode.Force);
        }
    }
}