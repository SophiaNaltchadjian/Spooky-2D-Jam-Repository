using UnityEngine;

public class FinalScore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private TextMesh myTextMesh;
    [SerializeField] private bool highScore;

    void Start()
    {
        if (AudioMaster.AM.score > AudioMaster.AM.highscore)
        {
            AudioMaster.AM.highscore = AudioMaster.AM.score;
        }
        if (highScore)
        {
            myTextMesh.text = AudioMaster.AM.highscore + "";
        }
        else
        {
            myTextMesh.text = AudioMaster.AM.score + "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
