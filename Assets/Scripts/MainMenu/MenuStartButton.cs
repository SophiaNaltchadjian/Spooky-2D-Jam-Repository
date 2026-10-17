using UnityEngine;


public class MenuStartButton : MonoBehaviour
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
            Application.LoadLevel(1);
            Debug.Log("LoadingScene1");
        }
    }

    private void OnMouseDown()
    {
        Application.LoadLevel(1);
        Debug.Log("LoadingScene1");
    }
}
