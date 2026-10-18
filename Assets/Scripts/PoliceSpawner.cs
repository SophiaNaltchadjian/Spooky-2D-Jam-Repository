using UnityEngine;
using System.Collections;
public class PoliceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject copPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCops());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnCops()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(copPrefab, transform.position, Quaternion.identity);
    }
}
