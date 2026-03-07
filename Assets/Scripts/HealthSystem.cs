using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthSystem : MonoBehaviour
{
    private int health = 3;
    private int maxHealth = 3;
    [SerializeField] public Collider collider;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

        private void Start()
        {

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
            // OnTriggerEnter(collider);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!other.CompareTag("Enemy")) 
                return;
            else
            {
            Debug.Log("enemy tag erkannt");
            if((health -= 1) == 0) SceneManager.LoadScene("Lose Scene");
            health -= 1;
            Debug.Log(health);
            }
        }
}


