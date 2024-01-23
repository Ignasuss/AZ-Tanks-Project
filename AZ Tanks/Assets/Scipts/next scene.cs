using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync("SampleScene");

    }
}
