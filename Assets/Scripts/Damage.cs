using UnityEngine;

public class Damage : MonoBehaviour
{
    public HealthSystem playerHp;
 
  private void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Player"))
    {
        Debug.Log("Goat found player");
        playerHp.TakeDamage(1);
    }
}
}
