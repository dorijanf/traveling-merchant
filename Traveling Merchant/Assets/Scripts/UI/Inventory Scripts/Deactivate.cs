using UnityEngine;

public class Deactivate : MonoBehaviour
{
    /*
    * Script that deactivates inventory on Start
    */
    void Start()
    {
        gameObject.SetActive(false);
    }
}
