using UnityEngine;
public class DamagingObjects : MonoBehaviour
{
    public int ammountOfDamage = 1;
    private void OnTriggerEnter(Collider collision)
    
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.tag == "Player")
            
        {
            collisionObject.gameObject.GetComponent<Health>().TakeDamage(ammountOfDamage);
        }
    }
}
