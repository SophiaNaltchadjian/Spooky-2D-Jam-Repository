using UnityEngine;

public class UndeadSpawner : MonoBehaviour
{

    private Transform playerLoc;
    [SerializeField] private GameObject Undead;
    [SerializeField] private float distanceToSpawn;
    [SerializeField] private float refreshTime = 10;
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
    }

    private void DistanceCheck()
    {
        if (refreshTimer < 0)
        {
            if (Vector2.Distance(playerLoc.position, transform.position) < distanceToSpawn)
            {
                //spawnzombie
                Instantiate(Undead, transform.position.normalized, transform.rotation);
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
