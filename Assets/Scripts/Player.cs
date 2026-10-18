using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public AudioSource stepsAudioSource;
    private Animator anim;
    private Transform tombstoneTransform;
    private bool isSummoning = false;
    private float lastHorizontal = 0f;
    private float lastVertical = -1f;
    [SerializeField] GameObject undeadPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0f);
        transform.position += movement * speed * Time.deltaTime;
      
       bool isMoving = movement.magnitude > 0;

    if (isMoving)
    {
        lastHorizontal = movement.x;
        lastVertical = movement.y;
    }

    anim.SetFloat("Horizontal", lastHorizontal);
    anim.SetFloat("Vertical", lastVertical);
    anim.SetBool("Walk", isMoving);

    if (stepsAudioSource != null)
    {
        if (isMoving && !stepsAudioSource.isPlaying)
            stepsAudioSource.Play();
        else if (!isMoving && stepsAudioSource.isPlaying)
            stepsAudioSource.Stop();
    }

}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tombstone")
        {
          
            tombstoneTransform = other.gameObject.GetComponent<Transform>();
            if (isSummoning != true)
            {
                StartCoroutine(SummonUndead());   
                  isSummoning=true;
            }
        }
    }
    IEnumerator SummonUndead()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(undeadPrefab, tombstoneTransform.position, Quaternion.identity);  
        yield return new WaitForSeconds(3f);
          isSummoning=false; 
    }
}