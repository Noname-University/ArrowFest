using UnityEngine;
using Utilities;

public class ArrowManager : MonoSingleton<ArrowManager>
{
	#region SerializedFields

	[SerializeField]
	private GameObject arrowPrefab;

	[SerializeField]
	private int maxArrowCount;

	#endregion

	#region Variables

	private GameObject[] arrows;

	private int currentArrowCount;

	private int ring;
	private int ringCapacity = 1;

	#endregion

	#region Props

	#endregion

	#region Unity Methods

	private void Start() 
	{
		arrows = new GameObject[maxArrowCount];

		for (int i = 0; i < maxArrowCount; i++)
		{
			var arrow = Instantiate(arrowPrefab, GetArrowPosition(i), Quaternion.identity,PlayerController.Instance.transform);
			arrows[i] = arrow;
		}
	}

	#endregion

	#region Methods

	private Vector3 GetArrowPosition(int i)
    {
        if (i == 0) return Vector3.zero;

        currentArrowCount++;
        if (currentArrowCount > ringCapacity)
        {
            ring++;
            ringCapacity = (int)(Mathf.PI * ring * .075f * 2 / 0.08f);
            currentArrowCount = 0;
        }

        float angle = ((float)currentArrowCount / (float)ringCapacity) * 360f;

        float x = Mathf.Cos(Mathf.Deg2Rad * angle) * ring * .075f;
        float y = Mathf.Sin(Mathf.Deg2Rad * angle) * ring * .075f;

        return new Vector3(x, y, 0);
    }

	#endregion

	#region Callbacks

	#endregion
}