using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static AudioMaster AM;
    public int masterVolume = 5;
    public int score;
    public int highscore;

    [SerializeField] private AudioSource baseSong;
    [SerializeField] private AudioSource skeletonLayer;
    [SerializeField] private AudioSource zombieLayer;
    [SerializeField] private AudioSource percussionLayer;
    public bool randomizer = false;
    private bool testsweep = false;

    void Start()
    {
        if (AM == null)
        {
            DontDestroyOnLoad(gameObject);
            AM = this;
        }
        else
        {
            Destroy(gameObject);
        }
        baseSong.volume = 0.95f;
        skeletonLayer.volume = 0.01f;
        zombieLayer.volume = 0.01f;
        percussionLayer.volume = 0.01f;
        baseSong.gameObject.SetActive(true);
        skeletonLayer.gameObject.SetActive(true);
        zombieLayer.gameObject.SetActive(true);
        percussionLayer.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AudioListener.volume = masterVolume / 11.0f;
        if (randomizer)
        {
            if (!testsweep)
            {
                if (zombieLayer.volume < 0.98f)
                {
                    zombieLayer.volume += 0.01f;
                }
                if (zombieLayer.volume > 0.97f)
                {
                    testsweep = true;
                }
            }
            else
            {
                if (zombieLayer.volume > 0.02f)
                {
                    zombieLayer.volume -= 0.01f;
                }
                if (zombieLayer.volume < 0.03f)
                {
                    testsweep = false;
                }
            }
        }
    }
}