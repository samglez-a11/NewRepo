using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : Interactable
{
    int ptsRandom=0;
    public override void Interact(PlayerController playerController)
    {   
        System.Random rnd = new System.Random();
        ptsRandom = rnd.Next(1,10);
        if (playerController.ContFragmentos == 0) { 
            playerController.AudioSource.Play();
        }
        playerController.ContFragmentos++;
        playerController.UpdatePuntaje(ptsRandom);
        Destroy(gameObject);
        if(playerController.ContFragmentos >3)
        {
            Scene_Manager sceneManager = new Scene_Manager();
            sceneManager.LoadMainMenu();
        }
    }
}
