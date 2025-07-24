package crc64945cd749a3cf0abd;


public class ReceiveUpdates
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("CommunityToolkit.Maui.Media.Services.ReceiveUpdates, CommunityToolkit.Maui.MediaElement", ReceiveUpdates.class, __md_methods);
	}


	public ReceiveUpdates ()
	{
		super ();
		if (getClass () == ReceiveUpdates.class) {
			mono.android.TypeManager.Activate ("CommunityToolkit.Maui.Media.Services.ReceiveUpdates, CommunityToolkit.Maui.MediaElement", "", this, new java.lang.Object[] {  });
		}
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
