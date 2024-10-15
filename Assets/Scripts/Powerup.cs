using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Powerup : MonoBehaviour
    {
        public GameObject powerupIndicator;
            
        private bool _isPowerupEnabled;
        public bool HasPowerup
        {
            get { return _isPowerupEnabled; }
            set
            {
                powerupIndicator.SetActive(value);
                _isPowerupEnabled = value;
            }
        }
        public float powerupStrength = 15.0f;

        public void Update()
        {
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Powerup"))
            {
                HasPowerup = true;
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountdownRoutine());
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            bool isEnemyCollision = collision.gameObject.CompareTag("Enemy");
            if (isEnemyCollision && HasPowerup) CollisionWithEnemyHandler(collision);
        }

        private void CollisionWithEnemyHandler(Collision enemy)
        {
            Rigidbody enemyRigidBody = enemy.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (enemy.gameObject.transform.position - transform.position).normalized;
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }

        private IEnumerator PowerupCountdownRoutine()
        {
            yield return new WaitForSeconds(7);
            HasPowerup = false;
        }
    }
}