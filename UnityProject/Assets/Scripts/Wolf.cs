using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Wolf : MonoBehaviour
{
	[SerializeField]
	Text mTelop = null;
	[SerializeField]
	Text mTime = null;
	int mEated;
	GameObject mTargetSheep;
	float mTimeCounter;
	void Lock()
	{
		var sheeps = GameObject.FindGameObjectsWithTag("Player");
		float minDist = float.MaxValue;
		foreach(var sheep in sheeps)
		{
			if(sheep == null)
			{
				continue;
			}
			var vec = sheep.transform.position - transform.position;
			float dist = vec.sqrMagnitude;
			if(dist < minDist)
			{
				mTargetSheep = sheep;
				minDist = dist;
			}
		}
	}
	void Update()
	{
		if(mTelop.gameObject.activeSelf)
		{
			if(Input.GetKey(KeyCode.Space))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			return;
		}
		if(mTargetSheep == null)
		{
			Lock();
		}
		if(mTargetSheep == null)
		{
			mTelop.gameObject.SetActive(true);
			return;
		}
		mTimeCounter += Time.deltaTime;
		mTime.text = (int)mTimeCounter + " days";
		var vec = (transform.position - mTargetSheep.transform.position).normalized;
		var euler = transform.localEulerAngles;
		euler.z = -Mathf.Atan2(vec.x, vec.y) * Mathf.Rad2Deg + 270f;
		transform.eulerAngles = euler;
		float speed = (5.0f + (Mathf.Max(1, mEated) / 10) * 0.5f) * Time.deltaTime;
		transform.localPosition += transform.right * speed;
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
