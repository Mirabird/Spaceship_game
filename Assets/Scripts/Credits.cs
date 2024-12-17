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
        creditScreen.SetActive(true);
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(0);
    }
}
 