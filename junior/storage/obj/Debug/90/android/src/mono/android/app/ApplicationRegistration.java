package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("storage.MainApplication, storage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", crc641a8c84067319b108.MainApplication.class, crc641a8c84067319b108.MainApplication.__md_methods);
		
	}
}
