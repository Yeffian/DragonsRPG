using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

[SuppressMessage("ReSharper", "CheckNamespace")]
public class PathCreatorWindow : EditorWindow
{
    private float speed;
    private Vector3 endPosOffset;

    private GameObject patroller;
    private GameObject traversalObject;

    private EnemyController enemy;
    
    [MenuItem("Window/Enemies")]
    public static void ShowWindow()
    {
        GetWindow<PathCreatorWindow>("Create Enemy Patrol Path");
    }
    
    private void OnGUI()
    {
        GUILayout.Label("This lets you create enemy patrols");
        
        endPosOffset = EditorGUILayout.Vector3Field("End Position", endPosOffset);
        speed = EditorGUILayout.FloatField("Enemy Speed", speed);

        traversalObject = 
#pragma warning disable CS0618
            (GameObject)EditorGUILayout.ObjectField("Point Prefab", traversalObject, typeof(GameObject));

        
        patroller = 
            (GameObject)EditorGUILayout.ObjectField("Enemy Position", patroller, typeof(GameObject));
#pragma warning restore CS0618
        
        // ReSharper disable once InvertIf
        if (GUILayout.Button("Create Path"))
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            enemy = patroller.GetComponent<EnemyController>();

            var originalPos = patroller.transform.position;
            enemy.Speed = speed;
            enemy.Origin = Instantiate(traversalObject, originalPos , Quaternion.identity);
            enemy.FirstPoint = Instantiate(traversalObject, originalPos + endPosOffset, Quaternion.identity);  
            
            EditorUtility.SetDirty(enemy);
            
            Debug.Log("done");
        }
    }
}
