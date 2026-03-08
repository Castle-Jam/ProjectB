using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthSystem : MonoBehaviour
{
    public int health;
    private int maxHealth = 3;
    [SerializeField] public new Collider collider;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

        private void Start()
        {
            health = maxHealth;
        }

        void Update()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                hearts[i].sprite = fullHeart;
                }
                else
                {
                hearts[i].sprite = emptyHeart;
                }
                if (i < maxHealth)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            } 
        
        }

        public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0) SceneManager.LoadScene("Lose Scene");
    }

}


