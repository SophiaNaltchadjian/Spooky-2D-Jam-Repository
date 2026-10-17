using UnityEngine;

public class LifeSpan : MonoBehaviour
{

    [SerializeField] private float destroyAfterXSeconds = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, destroyAfterXSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
