using UnityEngine;
public class FollowPlayer : MonoBehaviour
{ 
    public Transform player;
    public float moveSpeed = 3f;
    public int maxHealth = 30;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);   
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            DestroyBoss();
        }
    }

    private void DestroyBoss()
    {
        Destroy(gameObject);
    }
}
