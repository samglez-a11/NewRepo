using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private PlayerController playerController;
    // Start is called before the first frame update
    public virtual void Interact(PlayerController playerController)
    {
        Debug.Log(this.name + " un objeto desconocido interactuo");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
