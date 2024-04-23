using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePopUpHeart : MonoBehaviour
{
    public GameObject prefab;
    public int size;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePopUp()
    {
        int rand_size = Random.Range(1, size);
        for(int i = 0; i < rand_size; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-0.4f, 0.4f), Random.Range(0.8f, 1.2f), 10f);
            var pop_up = Instantiate(prefab, pos, prefab.transform.rotation);
            pop_up.transform.Rotate(new Vector3(0, Random.Range(30f, 150f), 0));
            Destroy(pop_up, 1f);
        }
    }
}
