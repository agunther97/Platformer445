using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookRatio : MonoBehaviour
{

    public GameObject player;
    public Vector3 grabPosition;
    public float ratio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ratio();
    }

    public void Ratio()
    {
        float scaleX = Vector3.Distance(player.transform.position, grabPosition)/ratio;
        GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(scaleX, 1f);
    }
}
