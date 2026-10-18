using UnityEngine;

public class VolumeButtons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private AudioSource clicksound;
    [SerializeField] private bool volumedown;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        clicksound.Play();
        if (volumedown && AudioMaster.AM.masterVolume > 0)
        {
            Debug.Log("Volume Down");
            AudioMaster.AM.masterVolume -= 1;
        }
        if(!volumedown && AudioMaster.AM.masterVolume < 11)
        {
            Debug.Log("Volume Up");
            AudioMaster.AM.masterVolume += 1;
        }
    }
}
