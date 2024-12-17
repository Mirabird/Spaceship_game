using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    public GameObject creditScreen;
    void Start()
    {
        StartCoroutine(CreditsRun());
    }
    IEnumerator  CreditsRun()
    {
        yield return new WaitForSeconds(0.5f);
        
        if (creditScreen != null)
        {
            creditScreen.SetActive(true);
        }
        
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("MainMenu");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
 