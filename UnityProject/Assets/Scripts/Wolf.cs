using UnityEngine;
public class Wolf : MonoBehaviour
{
	[SerializeField]
	Sheep mSheep = null;
	int mEated;
	void Update()
	{
		if(mSheep == null)
		{
			return;
		}
		var vec = (transform.position - mSheep.transform.position).normalized;
		var euler = transform.localEulerAngles;
		euler.z = -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg + 270f;
		transform.eulerAngles = euler;
		transform.localPosition += transform.right * Time.deltaTime;
	}
	void OnTriggerEnter(Collider inColl)
	{
		if(inColl.tag != "Player")
		{
			return;
		}
		Destroy(inColl.gameObject);
		++mEated;
	}
}
