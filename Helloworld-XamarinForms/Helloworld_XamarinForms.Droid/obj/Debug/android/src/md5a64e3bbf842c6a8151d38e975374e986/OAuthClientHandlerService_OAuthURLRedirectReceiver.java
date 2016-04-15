package md5a64e3bbf842c6a8151d38e975374e986;


public class OAuthClientHandlerService_OAuthURLRedirectReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("FHSDK.Services.OAuthClientHandlerService+OAuthURLRedirectReceiver, FHXamarinAndroidSDK, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", OAuthClientHandlerService_OAuthURLRedirectReceiver.class, __md_methods);
	}


	public OAuthClientHandlerService_OAuthURLRedirectReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == OAuthClientHandlerService_OAuthURLRedirectReceiver.class)
			mono.android.TypeManager.Activate ("FHSDK.Services.OAuthClientHandlerService+OAuthURLRedirectReceiver, FHXamarinAndroidSDK, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

	java.util.ArrayList refList;
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
