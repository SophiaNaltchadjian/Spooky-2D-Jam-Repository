using UnityEngine;

public class Follower : MonoBehaviour
{
      public float speed;
    private Transform target;
    private Animator animator;
    private Vector2 lastDirection = Vector2.down;

    protected virtual void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Vector2 previousPosition = transform.position;

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        Vector2 movement = (Vector2)transform.position - previousPosition;

        if (movement.sqrMagnitude > 0.0001f)
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                lastDirection = new Vector2(Mathf.Sign(movement.x), 0);
            }
            else
            {
                lastDirection = new Vector2(0, Mathf.Sign(movement.y));
            }
        }

        animator.SetFloat("Horizontal", lastDirection.x);
        animator.SetFloat("Vertical", lastDirection.y);
    }
}
