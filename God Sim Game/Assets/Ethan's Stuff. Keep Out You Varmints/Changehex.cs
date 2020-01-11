using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changehex : MonoBehaviour
{

    public GameObject DestBiome;
    private Vector3 DestPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Changing Biome");
            DestPosition = gameObject.transform.position;
            Instantiate(DestBiome, new Vector3(DestPosition.x, DestPosition.y, DestPosition.z), Quaternion.identity);




        }
    }
}
