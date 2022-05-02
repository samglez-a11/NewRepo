using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followTarget;
    Vector3 offset;
    public GameObject starPrefab;
    public int numberStars;
    public float skyAltitude;
    public float maxDistance;
    void Start()
    {
        offset = followTarget.transform.position;
        GenerateSky();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GenerateSky()
    {
        Vector3 pos;
        pos.y = skyAltitude;

        for (int i = 0; i < numberStars; i++)
        {
            pos = Random.onUnitSphere * maxDistance;
            if (pos.y < 0)
            {
                pos.y = -pos.y;
            }

            GameObject s = Instantiate(starPrefab, pos, starPrefab.transform.rotation);
            s.transform.parent = transform;
            s.transform.LookAt(followTarget);
     }

    }
}
