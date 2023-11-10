using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicControl : MonoBehaviour
{
  public GameObject internal_light;
  public GameObject vision;
  public GameObject cineMachine;
  public GameObject UFO;
  
  public GameObject external_light;
  public GameObject camera1; 


  void Start(){
    Start_first_part();
  }

  void Start_first_part(){
    external_light.SetActive(true);
    internal_light.SetActive(true);
    camera1.SetActive(true);
  }
  
  void finish_first_part(){
    Destroy(external_light);
    Destroy(camera1);
  }

  public void Start_second_part(){
    finish_first_part();
    vision.SetActive(true);
    cineMachine.SetActive(true);
    UFO.SetActive(true);
  }

  public void Load_title_scene(){
    SceneManager.LoadScene("Title scene");
  }

  public void Start_game(){
    SceneManager.LoadScene("Game");
  }


}
