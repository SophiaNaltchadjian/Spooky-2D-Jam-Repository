using UnityEngine;
using System.Collections;
public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject copPrefab;
    [SerializeField] private float spawnCopsAfterXTime;
    [SerializeField] private float spawnCopseveryX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnCops",spawnCopsAfterXTime,spawnCopseveryX);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnCops()
    {
        Instantiate(copPrefab, transform.position, Quaternion.identity);
    }
}
