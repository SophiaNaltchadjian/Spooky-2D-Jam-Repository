using UnityEngine;

public class UndeadSpawner : MonoBehaviour
{

    private Transform playerLoc;
    [SerializeField] private GameObject[] Undead;
    [SerializeField] private float distanceToSpawn;
    [SerializeField] private float refreshTime = 10;
    [SerializeField] private SpriteRenderer mySprite;
    [SerializeField] private Sprite coffin0;
    [SerializeField] private Sprite coffin1;
    [SerializeField] private Sprite coffin2;
    private float refreshTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLoc = FindAnyObjectByType<Player>().transform;
        if(playerLoc == null)
        {
            Debug.Log("Undead Spawner cant find player, Removed Spawner");
            Destroy(this);
        }
        InvokeRepeating("DistanceCheck", 1, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        refreshTimer -= Time.fixedDeltaTime;
        if(refreshTimer < 0)
        {
            mySprite.sprite = coffin1;
        }
        else
        {
            if (refreshTimer < refreshTime - 1)
            {
                mySprite.sprite = coffin0;
            }
            else
            {
                mySprite.sprite = coffin2;
            }
        }
    }

    private void DistanceCheck()
    {
        if (refreshTimer < 0)
        {
            if (Vector2.Distance(playerLoc.position, transform.position) < distanceToSpawn)
            {
                //spawnzombie
                Instantiate(Undead[Random.Range(0, Undead.Length)], transform.position, transform.rotation);
                if (AudioMaster.AM != null)
                {
                    AudioMaster.AM.score += 1;
                }
                refreshTimer = refreshTime;
                Debug.Log("Spawned Undead");
            }
        }
    }
}
