using UnityEngine;
public class Sheep : MonoBehaviour
{
	[SerializeField]
	Rigidbody mRigid = null;
	[SerializeField]
	Transform mCameraHandle = null;
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
		mRigid.AddForce(vec.normalized * 3.5f, ForceMode.VelocityChange);
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
	}
}
