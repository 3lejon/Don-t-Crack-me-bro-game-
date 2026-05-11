using UnityEngine;
public class FollowPlayer : MonoBehaviour
{ 
    public Transform player;
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;
    public float stopDistance = 2f;

    public int maxHealth = 30;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);   
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
