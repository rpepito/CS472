package md54d6069665a4ee24d63f2a17d1f9bbbb0;


public class menu_config_frag_User_ValueEventListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.firebase.database.ValueEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCancelled:(Lcom/google/firebase/database/DatabaseError;)V:GetOnCancelled_Lcom_google_firebase_database_DatabaseError_Handler:Firebase.Database.IValueEventListenerInvoker, Xamarin.Firebase.Database\n" +
			"n_onDataChange:(Lcom/google/firebase/database/DataSnapshot;)V:GetOnDataChange_Lcom_google_firebase_database_DataSnapshot_Handler:Firebase.Database.IValueEventListenerInvoker, Xamarin.Firebase.Database\n" +
			"";
		mono.android.Runtime.register ("LetsEat.Views.OwnerSide.menu_config_frag+User_ValueEventListener, LetsEat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", menu_config_frag_User_ValueEventListener.class, __md_methods);
	}


	public menu_config_frag_User_ValueEventListener ()
	{
		super ();
		if (getClass () == menu_config_frag_User_ValueEventListener.class)
			mono.android.TypeManager.Activate ("LetsEat.Views.OwnerSide.menu_config_frag+User_ValueEventListener, LetsEat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCancelled (com.google.firebase.database.DatabaseError p0)
	{
		n_onCancelled (p0);
	}

	private native void n_onCancelled (com.google.firebase.database.DatabaseError p0);


	public void onDataChange (com.google.firebase.database.DataSnapshot p0)
	{
		n_onDataChange (p0);
	}

	private native void n_onDataChange (com.google.firebase.database.DataSnapshot p0);

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
