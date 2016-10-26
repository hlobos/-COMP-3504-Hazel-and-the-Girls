package md5bb60802a59fb0f95c9bfbb66ffd35aad;


public class MetricsActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("DogWalkies.MetricsActivity, DogWalkies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MetricsActivity.class, __md_methods);
	}


	public MetricsActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MetricsActivity.class)
			mono.android.TypeManager.Activate ("DogWalkies.MetricsActivity, DogWalkies, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
