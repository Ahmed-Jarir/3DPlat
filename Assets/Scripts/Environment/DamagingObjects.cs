using UnityEngine;
public class DamagingObjects : MonoBehaviour
{
    public int ammountOfDamage = 1;
    private void OnTriggerEnter(Collider collision)
    
    {
        GameObject collisionObject = collision.gameObject;
        Health playerHealth = collisionObject.gameObject.GetComponent<Health>();
        if (collisionObject.tag == "Player")
        {
            //for later use
            //playerHealth.TakeDamage(ammountOfDamage);
            playerHealth.TakeDamage(playerHealth.currentHealth);
        }
    }
}
