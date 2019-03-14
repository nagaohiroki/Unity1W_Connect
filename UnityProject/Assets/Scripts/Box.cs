using UnityEngine;
public class Box : MonoBehaviour
{
	[SerializeField]
	Rigidbody mRigid = null;
	[SerializeField]
	Transform mCameraHandle = null;
	bool mIsPlayer = true;
	void Update()
	{
		if(!mIsPlayer)
		{
			return;
		}
		mCameraHandle.position = transform.position;
		Shot();
	}
	void Shot()
	{
		if(!Input.GetButtonDown("Fire1"))
		{
			return;
		}
		if(mRigid == null)
		{
			return;
		}
		var vec  = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
		vec.z = 0.0f;
		var player = Instantiate(this, transform.position, Quaternion.identity);
		player.Player();
		NotPlayer();
	}
	void Player()
	{
		var vec  = (Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position));
		vec.z = 0.0f;
		mRigid.AddForce(vec.normalized, ForceMode.VelocityChange);
		mIsPlayer = true;
	}
	void NotPlayer()
	{
		mRigid.constraints = RigidbodyConstraints.FreezeAll;
		mIsPlayer = false;
	}
}
