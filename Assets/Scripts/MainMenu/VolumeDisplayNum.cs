using UnityEngine;

public class VolumeDisplayNum : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private TextMesh myTextMesh;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myTextMesh.text = AudioMaster.AM.masterVolume + "";
    }
}
