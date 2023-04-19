using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public static LoadingScene Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
    
    public void LoadScene(int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    private IEnumerator LoadSceneAsync(int sceneId)
    {
        var progress = SceneManager.LoadSceneAsync(sceneId);
        while (!progress.isDone)
        {
            yield return null;
        }

        /*var current = SceneManager.GetSceneAt(sceneId);
        SceneManager.MoveGameObjectToScene(gameObject, current);*/
    }
}
