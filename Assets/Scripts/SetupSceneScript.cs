using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
   public void Continue()
   {
    SceneManager.LoadScene("Level-1");
   }
}
