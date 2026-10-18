using UnityEngine;

public class Undead : MonoBehaviour
{
    public float speed;
    private Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        
          target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
