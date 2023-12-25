using System.Collections;
using UnityEngine;

namespace Cannon
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] public Rigidbody Rigidbody;
        [SerializeField] public float _lifeTime = 3f;

        private void OnCollisionEnter(Collision other)
        {
            var target = other.gameObject.GetComponent<Target>();
            if (target != null)
            {
                target.GetDamage(Random.Range(50, 100));
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("triger");
        }

        public void Init(Vector3 startPos)
        {
            transform.position = startPos;
            gameObject.SetActive(true);
            StartCoroutine(ReturnToPool());
        }

        private IEnumerator ReturnToPool()
        {
            yield return new WaitForSeconds(_lifeTime);
            gameObject.SetActive(false);
        }
    }
}