package mono.android.app;

public class ApplicationRegistration {

	public static void registerApplications ()
	{
				// Application and Instrumentation ACWs must be registered first.
		mono.android.Runtime.register ("Caliburn.Micro.CaliburnApplication, Caliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f", crc648c15711fce523d6b.CaliburnApplication.class, crc648c15711fce523d6b.CaliburnApplication.__md_methods);
		
	}
}
