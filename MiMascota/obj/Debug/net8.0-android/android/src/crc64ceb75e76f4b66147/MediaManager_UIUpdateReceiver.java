package crc64ceb75e76f4b66147;


public class MediaManager_UIUpdateReceiver
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
		mono.android.Runtime.register ("CommunityToolkit.Maui.Core.Views.MediaManager+UIUpdateReceiver, CommunityToolkit.Maui.MediaElement", MediaManager_UIUpdateReceiver.class, __md_methods);
	}


	public MediaManager_UIUpdateReceiver ()
	{
		super ();
		if (getClass () == MediaManager_UIUpdateReceiver.class) {
			mono.android.TypeManager.Activate ("CommunityToolkit.Maui.Core.Views.MediaManager+UIUpdateReceiver, CommunityToolkit.Maui.MediaElement", "", this, new java.lang.Object[] {  });
		}
	}

	public MediaManager_UIUpdateReceiver (com.google.android.exoplayer2.ExoPlayer p0)
	{
		super ();
		if (getClass () == MediaManager_UIUpdateReceiver.class) {
			mono.android.TypeManager.Activate ("CommunityToolkit.Maui.Core.Views.MediaManager+UIUpdateReceiver, CommunityToolkit.Maui.MediaElement", "Com.Google.Android.Exoplayer2.IExoPlayer, ExoPlayer.Core", this, new java.lang.Object[] { p0 });
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
