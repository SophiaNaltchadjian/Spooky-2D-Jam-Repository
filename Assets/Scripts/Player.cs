using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public AudioSource stepsAudioSource;
    private Transform tombstoneTransform;
    private bool isSummoning= false;
    [SerializeField] GameObject undeadPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
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
        if (movement.magnitude > 0)
        {
            if(stepsAudioSource != null && !stepsAudioSource.isPlaying)
            {
                stepsAudioSource.Play();
            }
          
         }
          if (movement.magnitude == 0)
        {
            if(stepsAudioSource != null && stepsAudioSource.isPlaying)
            {
                stepsAudioSource.Stop();
            }
          
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