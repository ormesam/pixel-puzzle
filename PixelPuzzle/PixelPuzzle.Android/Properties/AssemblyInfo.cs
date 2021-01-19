using System.Reflection;
using System.Runtime.InteropServices;
using Android.App;
using PixelPuzzle.Utility;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("PixelPuzzle.Android")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("PixelPuzzle.Android")]
[assembly: AssemblyCopyright("Copyright ©  2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: MetaData("com.google.android.gms.ads.APPLICATION_ID", Value = Constants.AdMobAppId)]

[assembly: Application(
    UsesCleartextTraffic = true,
    Icon = "@mipmap/icon",
#if DEBUG
    Label = "Pixel Puzzle Dev",
#else
    Label = "Pixel Puzzle",
#endif
#if DEBUG
    Debuggable = true
#else
    Debuggable = false
#endif
)]