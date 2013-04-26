using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("FacebookSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true, WeakFrameworks = "Accounts AdSupport Social")]
