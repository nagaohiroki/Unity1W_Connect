using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Sheep : MonoBehaviour
{
	[SerializeField]
	Rigidbody mRigid = null;
	[SerializeField]
	Transform mCameraHandle = null;
	[SerializeField]
	Text mTelop = null;
	[SerializeField]
	Wolf mWolf = null;
	bool mIsPlayer = true;
	void Shot()
	{
		if(mRigid == null)
		{
			return;
		}
		var vec  = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
		vec.z = 0.0f;
		var player = Instantiate(this, transform.position, Quaternion.identity);
		player.name = "Sheep";
		player.Player();
		NotPlayer();
	}
	void Player()
	{
		var vec  = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
		vec.z = 0.0f;
		mRigid.AddForce(vec.normalized * 10.0f, ForceMode.VelocityChange);
		mIsPlayer = true;
	}
	void NotPlayer()
	{
		mRigid.constraints = RigidbodyConstraints.FreezeAll;
		mIsPlayer = false;
	}
	void Update()
	{
		if(!mIsPlayer)
		{
			return;
		}
		mCameraHandle.position = transform.position;
		if(Input.GetButtonDown("Fire1"))
		{
			Shot();
		}
		if(Input.GetKey(KeyCode.Space))
		{
			if(mTelop.gameObject.activeSelf)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
	void OnTriggerEnter(Collider inColl)
	{
		if(inColl.tag != "Finish")
		{
			return;
		}
		if(mTelop == null)
		{
			return;
		}
		mTelop.gameObject.SetActive(true);
	}
}
