using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonobehavior : MonoBehaviour { };
    private static AsyncOperation loadingAsyncOperation;
    public enum Scene
    {
        GameScene,
        LoadingScene,
        MainMenu,
    }

    private static Action onLoaderCallback;
    public static void Load(Scene scene)
    {
        onLoaderCallback = () =>
        {
            //SceneManager.LoadScene(scene.ToString());
            //SceneManager.LoadSceneAsync(scene.ToString());
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonobehavior>().StartCoroutine(LoadSceneAsync(scene));
        };
        SceneManager.LoadScene(Loader.Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()

    {
        if(onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;  //waiting for one frame
        
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        //loadingAsyncOperation.allowSceneActivation = false;
        while(!loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if(loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }

        return 0.0f;
    }

}
