using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePopUpHeart : MonoBehaviour
{
    public GameObject prefab;
    public int size;

    public void CreatePopUp()
    {
        int rand_size = Random.Range(1, size);
        for(int i = 0; i < rand_size; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 2f), 10f);
            var pop_up = Instantiate(prefab, pos, prefab.transform.rotation);
            pop_up.transform.Rotate(new Vector3(0, Random.Range(-30f, 30f), 0));
            Destroy(pop_up, 1f);
        }
    }
}
