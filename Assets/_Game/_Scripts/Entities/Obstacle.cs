using UnityEngine;

public class Obstacle : MonoBehaviour
{
	#region SerializedFields

	[SerializeField]
	private int damage;

	[SerializeField]
	private int score;

	private Rigidbody rb;

	#endregion

	#region Variables

	#endregion

	#region Props

	private int Score => score;
	private int Damage => damage;

	#endregion

	#region Unity Methods

	private void Start() 
	{
		rb= GetComponent<Rigidbody>();
	}

	#endregion

	#region Methods

	private void OnTriggerEnter(Collider rb) 
	{
		TakeDamage(damage);
	}

	private void Kill()
	{
		var kill= CurrentScore + score;
	}

	public void TakeDamage(int arrowCount)
	{
		arrowCount -= damage;
		if(arrowCount<=0)
		{
			Invoke?=Fail;
		}
	}
	#endregion

	#region Callbacks

	#endregion
}