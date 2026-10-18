using UnityEngine;

public class AudioMaster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static AudioMaster AM;
    public int masterVolume = 5;
    public int score;
    public int highscore;

    [SerializeField] private AudioSource baseSong;
    [SerializeField] private AudioSource percussionLayer;

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
        baseSong.volume = 0.9f;
        percussionLayer.volume = 0.01f;
        baseSong.gameObject.SetActive(true);
        percussionLayer.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AudioListener.volume = masterVolume / 11.0f;
        percussionLayer.volume = (score + 1) / 45.0f;
    }

    public void StopMusic()
    {
        baseSong.gameObject.SetActive(false);
        percussionLayer.gameObject.SetActive(false);
    }

    public void StartMusic()
    {
        baseSong.gameObject.SetActive(true);
        percussionLayer.gameObject.SetActive(true);
    }
}