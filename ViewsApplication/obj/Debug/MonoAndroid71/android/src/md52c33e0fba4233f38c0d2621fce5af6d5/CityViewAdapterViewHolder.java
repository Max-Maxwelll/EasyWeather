package md52c33e0fba4233f38c0d2621fce5af6d5;


public class CityViewAdapterViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ViewsApplication.Adapters.CityViewAdapterViewHolder, ViewsApplication", CityViewAdapterViewHolder.class, __md_methods);
	}


	public CityViewAdapterViewHolder ()
	{
		super ();
		if (getClass () == CityViewAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("ViewsApplication.Adapters.CityViewAdapterViewHolder, ViewsApplication", "", this, new java.lang.Object[] {  });
	}

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
