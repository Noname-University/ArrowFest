using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NaughtyAttributes;
using Utilities;

#if UNITY_EDITOR
using  UnityEditor;
#endif

public class RoadController : MonoSingleton<RoadController>
{
	#region SerializedFields

	public List<GameObject> roads;
    public GameObject roadPrefab;
    public Transform roadFinish;

	#endregion

	#region Variables

	private float roadLength = 20F;

	#endregion

	#region Props

	public float PlaneSideSize => roadPrefab.transform.localScale.x;

	#endregion

	#region Unity Methods

	#endregion

	#region Methods
    #if UNITY_EDITOR

	[Button()]
    public void Add()
    {
        var road = PrefabUtility.InstantiatePrefab(roadPrefab,transform) as GameObject;
        road.transform.localPosition = Vector3.forward * roadLength * roads.Count;
        roads.Add(road);

        roadFinish.localPosition = road.transform.localPosition + Vector3.forward * roadLength;

    }
    
    [Button()]
    public void Remove()
    {
        if(roads.Count <= 1) return;
        
        var road = roads.Last();

        roads.Remove(road);
        
        DestroyImmediate(road);
        
        var lastRoad = roads.Last();
        roadFinish.localPosition = lastRoad.transform.localPosition + Vector3.forward * roadLength;
    }
    #endif
	#endregion

	#region Callbacks

	#endregion
}