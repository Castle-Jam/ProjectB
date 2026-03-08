using UnityEngine;

public class Damage : MonoBehaviour
{
    public HealthSystem playerHp;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        {
            playerHp.TakeDamage(1);
        }
    }
}
