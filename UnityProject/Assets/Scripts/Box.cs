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
		if(mRigid == null)
		{
			return;
		}
		if(Input.GetButtonDown("Fire1"))
		{
			var player = Instantiate(this, transform.position + Vector3.up * 0.5f, Quaternion.identity);
			player.mIsPlayer = true;
			mIsPlayer = false;
			mRigid.constraints = RigidbodyConstraints.FreezeAll;
		}
	}
}
