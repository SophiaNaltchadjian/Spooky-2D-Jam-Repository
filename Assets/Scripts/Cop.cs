using UnityEngine;

public class Cop : MonoBehaviour
{
    public float speed;
    private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //maybe add health later
            Debug.Log("Cop got player, GAMEOVER!");
            Application.LoadLevel(2);
        }
        if (collision.gameObject.CompareTag("Undead"))
        {
            AudioMaster.AM.score += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //spawn a death effect for cop meets zombie
        }
    }
}
