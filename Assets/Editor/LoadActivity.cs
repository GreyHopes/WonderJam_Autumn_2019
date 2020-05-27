using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(Activity))]
public class LoadActivity : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Activity activity = (Activity)target;
        if (GUILayout.Button("Open Activity"))
        {
            EditorSceneManager.SaveOpenScenes();

            if (!EditorSceneManager.GetSceneByName(R.S.MainScene).isLoaded)
            {
                EditorSceneManager.OpenScene("Assets/Scenes/Main.unity", OpenSceneMode.Additive);
            }

            for (int i = 0; i < EditorSceneManager.loadedSceneCount; i++)
            {
                Scene currentScene = EditorSceneManager.GetSceneAt(i);
                if (currentScene.name != R.S.MainScene)
                {
                    EditorSceneManager.CloseScene(EditorSceneManager.GetSceneAt(i), true);
                    i--;
                }
            }

            foreach (var i in activity.Scenes)
            {
                EditorSceneManager.OpenScene("Assets/Scenes/" + i + ".unity", OpenSceneMode.Additive);
            }

            EditorSceneManager.OpenScene("Assets/Scenes/LoadingScreen.unity", OpenSceneMode.Additive);
        }
    }
}