using UnityEngine;

public class Damage : MonoBehaviour
{
    public HealthSystem playerHp;
 
  private void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Player"))
    {
        playerHp.TakeDamage(1);
    }
}
}
