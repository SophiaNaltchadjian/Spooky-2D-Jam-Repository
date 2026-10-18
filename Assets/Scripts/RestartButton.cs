using UnityEngine;

public class RestartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
    }

    private void OnMouseDown()
    {
        Restart();
    }

    private void Restart()
    {
        AudioMaster.AM.StartMusic();
        AudioMaster.AM.score = 0;
        Application.LoadLevel(0);
        Debug.Log("Restarting Game");
    }
}
