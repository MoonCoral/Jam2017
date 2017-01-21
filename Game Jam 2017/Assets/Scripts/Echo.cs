using UnityEngine;
using System.Collections;

public class Echo : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Foreground";
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<ParticleSystem>().Emit(10000);
        }
    }
}
