using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;

namespace FacebookSDK
{
    delegate void FBSessionStateHandler (FBSession session, FBSessionState status, NSError error);

    delegate void FBSessionReauthorizeResultHandler (FBSession session, NSError error);
    
    [BaseType (typeof (NSObject))]
    interface FBSession {

        [Field ("FBSessionDidSetActiveSessionNotification", "__Internal")]
        NSString DidSetActiveSessionNotificationKey { get; }

        [Field ("FBSessionDidUnsetActiveSessionNotification", "__Internal")]
        NSString DidUnsetActiveSessionNotificationKey { get; }

        [Field ("FBSessionDidBecomeOpenActiveSessionNotification", "__Internal")]
        NSString DidBecomeOpenActiveSessionNotificationKey { get; }

        [Field ("FBSessionDidBecomeClosedActiveSessionNotification", "__Internal")]
        NSString DidBecomeClosedActiveSessionNotificationKey { get; }

        [Export ("isOpen")]
        bool IsOpen { get;  }
        
        [Export ("state")]
        FBSessionState State { get;  }
        
        [Export ("appID")]
        string AppID { get;  }
        
        [Export ("urlSchemeSuffix")]
        string UrlSchemeSuffix { get;  }
        
        [Export ("accessToken")]
        string AccessToken { get;  }
        
        [Export ("expirationDate")]
        NSDate ExpirationDate { get;  }
        
        [Export ("permissions")]
        string[] Permissions { get;  }
        
        [Export ("loginType")]
        FBSessionLoginType LoginType { get;  }
        
        [Export ("initWithPermissions:")]
        IntPtr Constructor (string[] permissions);
        
        [Export ("initWithAppID:permissions:urlSchemeSuffix:tokenCacheStrategy:")]
        IntPtr Constructor (string appID, string[] permissions, [NullAllowed] string urlSchemeSuffix, [NullAllowed] FBSessionTokenCachingStrategy tokenCachingStrategy);
        
        [Export ("initWithAppID:permissions:defaultAudience:urlSchemeSuffix:tokenCacheStrategy:")]
        IntPtr Constructor (string appID, string[] permissions, FBSessionDefaultAudience defaultAudience, [NullAllowed] string urlSchemeSuffix, [NullAllowed] FBSessionTokenCachingStrategy tokenCachingStrategy);
        
        [Export ("openWithCompletionHandler:")]
        void Open (FBSessionStateHandler handler);
        
        [Export ("openWithBehavior:completionHandler:")]
        void Open (FBSessionLoginBehavior behavior, FBSessionStateHandler handler);
        
        [Export ("close")]
        void Close ();
        
        [Export ("closeAndClearTokenInformation")]
        void CloseAndClearTokenInformation ();
        
        [Export ("reauthorizeWithReadPermissions:completionHandler:")]
        void Reauthorize (string[] readPermissions, FBSessionReauthorizeResultHandler handler);
        
        [Export ("reauthorizeWithPublishPermissions:defaultAudience:completionHandler:")]
        void Reauthorize (string[] writePermissions, FBSessionDefaultAudience defaultAudience, FBSessionReauthorizeResultHandler handler);
        
        [Export ("handleOpenURL:")]
        bool HandleOpenUrl (NSUrl url);
        
        [Export ("handleDidBecomeActive")]
        void HandleDidBecomeActive ();
        
        [Static]
        [Export ("openActiveSessionWithAllowLoginUI:")]
        bool OpenActiveSession (bool allowLoginUI);
        
        [Static]
        [Export ("openActiveSessionWithReadPermissions:allowLoginUI:completionHandler:")]
        bool OpenActiveSession (string[] readPermissions, bool allowLoginUI, FBSessionStateHandler handler);
        
        [Static]
        [Export ("openActiveSessionWithPublishPermissions:defaultAudience:allowLoginUI:completionHandler:")]
        bool OpenActiveSession (string[] publishPermissions, FBSessionDefaultAudience defaultAudience, bool allowLoginUI, FBSessionStateHandler handler);
        
        [Static]
        [Export ("openActiveSessionWithPermissions:allowLoginUI:allowSystemAccount:isRead:defaultAudience:completionHandler:")]
        bool OpenActiveSession (string[] permissions, bool allowLoginUI, bool allowSystemAccount, bool isRead, FBSessionDefaultAudience defaultAudience, FBSessionStateHandler handler);

        //Detected properties
        [Static]
        [Export ("activeSession")]
        FBSession ActiveSession { get; set; }
        
        [Static]
        [Export ("defaultAppID")]
        string DefaultAppID { get; set; }
        
    }

    [BaseType (typeof (NSObject))]
    interface FBSessionTokenCachingStrategy {
        [Export ("initWithUserDefaultTokenInformationKeyName:")]
        IntPtr Constructor (string tokenInformationKeyName);
        
        [Export ("cacheTokenInformation:")]
        void CacheTokenInformation (NSDictionary tokenInformation);
        
        [Export ("fetchTokenInformation")]
        NSDictionary FetchTokenInformation ();
        
        [Export ("clearToken")]
        void ClearToken ();
        
        [Static]
        [Export ("defaultInstance")]
        FBSessionTokenCachingStrategy DefaultInstance ();
        
        [Static]
        [Export ("isValidTokenInformation:")]
        bool IsValidTokenInformation (NSDictionary tokenInformation);
        
    }


    delegate void FBRequestHandler (FBRequestConnection connection, NSObject result, NSError error);

    [BaseType (typeof (NSObject))]
    interface FBRequestConnection {
        [Field ("FBNonJSONResponseProperty", "__Internal")]
        NSString NonJSONResponsePropertyKey { get; }
        
        [Export ("urlRequest")]
        NSMutableUrlRequest UrlRequest { get; set;  }
        
        [Export ("urlResponse")]
        NSHttpUrlResponse UrlResponse { get;  }
        
        [Export ("initWithTimeout:")]
        IntPtr Constructor (double timeout);
        
        [Export ("addRequest:completionHandler:")]
        void AddRequest (FBRequest request, FBRequestHandler handler);
        
        [Export ("addRequest:completionHandler:batchEntryName:")]
        void AddRequest (FBRequest request, FBRequestHandler handler, [NullAllowed] string name);
        
        [Export ("start")]
        void Start ();
        
        [Export ("cancel")]
        void Cancel ();
        
        [Static]
        [Export ("startForMeWithCompletionHandler:")]
        FBRequestConnection StartForMe (FBRequestHandler handler);
        
        [Static]
        [Export ("startForMyFriendsWithCompletionHandler:")]
        FBRequestConnection StartForMyFriends (FBRequestHandler handler);
        
        [Static]
        [Export ("startForUploadPhoto:completionHandler:")]
        FBRequestConnection StartForUploadPhoto (UIImage photo, FBRequestHandler handler);
        
        [Static]
        [Export ("startForPostStatusUpdate:completionHandler:")]
        FBRequestConnection StartForPostStatusUpdate (string message, FBRequestHandler handler);

        // TODO: NSFastEnumeration tags
        [Static]
        [Export ("startForPostStatusUpdate:place:tags:completionHandler:")]
        FBRequestConnection StartForPostStatusUpdate (string message, NSObject place, NSObject tags, FBRequestHandler handler);
        
        [Static]
        [Export ("startForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:completionHandler:")]
        FBRequestConnection StartForPlacesSearch (CLLocationCoordinate2D coordinate, int radius, int limit, string searchText, FBRequestHandler handler);
        
        [Static]
        [Export ("startWithGraphPath:completionHandler:")]
        FBRequestConnection Start (string graphPath, FBRequestHandler handler);
        
        [Static]
        [Export ("startForPostWithGraphPath:graphObject:completionHandler:")]
        FBRequestConnection StartForPost (string graphPath, FBGraphObject graphObject, FBRequestHandler handler);
        
        [Static]
        [Export ("startWithGraphPath:parameters:HTTPMethod:completionHandler:")]
        FBRequestConnection Start (string graphPath, NSDictionary parameters, string HTTPMethod, FBRequestHandler handler);
        
    }

    
    [BaseType (typeof (NSObject))]
    interface FBRequest {
        [Export ("parameters")]
        NSMutableDictionary Parameters { get;  }
        
        [Export ("session")]
        FBSession Session { get; set;  }
        
        [Export ("graphPath")]
        string GraphPath { get; set;  }
        
        [Export ("restMethod")]
        string RestMethod { get; set;  }
        
        [Export ("HTTPMethod")]
        string HTTPMethod { get; set;  }
        
        [Export ("graphObject")]
        FBGraphObject GraphObject { get; set;  }
        
        [Export ("initWithSession:graphPath:")]
        IntPtr Constructor (FBSession session, string graphPath);

        // TODO: resolve conflict in constructors
        [Export ("initWithSession:graphPath:parameters:HTTPMethod:")]
        IntPtr Constructor (FBSession session, string graphPath, NSDictionary parameters, string HTTPMethod, bool dummyParameter);
        
        [Export ("initForPostWithSession:graphPath:graphObject:")]
        IntPtr Constructor (FBSession session, string graphPath, FBGraphObject graphObject);
        
        [Export ("initWithSession:restMethod:parameters:HTTPMethod:")]
        IntPtr Constructor (FBSession session, string restMethod, NSDictionary parameters, string HTTPMethod);
        
        [Export ("startWithCompletionHandler:")]
        FBRequestConnection Start (FBRequestHandler handler);
        
        [Static]
        [Export ("requestForMe")]
        FBRequest RequestForMe ();
        
        [Static]
        [Export ("requestForMyFriends")]
        FBRequest RequestForMyFriends ();
        
        [Static]
        [Export ("requestForUploadPhoto:")]
        FBRequest RequestForUploadPhoto (UIImage photo);
        
        [Static]
        [Export ("requestForPostStatusUpdate:")]
        FBRequest RequestForPostStatusUpdate (string message);

        // TODO: NSFastEnumeration tags
        [Static]
        [Export ("requestForPostStatusUpdate:place:tags:")]
        FBRequest RequestForPostStatusUpdate (string message, NSObject place, NSObject tags);
        
        [Static]
        [Export ("requestForPlacesSearchAtCoordinate:radiusInMeters:resultsLimit:searchText:")]
        FBRequest RequestForPlacesSearchAtCoordinate (CLLocationCoordinate2D coordinate, int radius, int limit, string searchText);
        
        [Static]
        [Export ("requestForGraphPath:")]
        FBRequest RequestForGraphPath (string graphPath);
        
        [Static]
        [Export ("requestForPostWithGraphPath:graphObject:")]
        FBRequest RequestForPost (string graphPath, FBGraphObject graphObject);
        
        [Static]
        [Export ("requestWithGraphPath:parameters:HTTPMethod:")]
        FBRequest Request (string graphPath, NSDictionary parameters, string HTTPMethod);
        
    }

    [BaseType (typeof (NSMutableDictionary))]
    interface FBGraphObject {
        [Static]
        [Export ("graphObject")]
        FBGraphObject GraphObject ();
        
        [Static]
        [Export ("graphObjectWrappingDictionary:")]
        FBGraphObject GraphObjectWrappingDictionary (NSDictionary jsonDictionary);
        
        [Static]
        [Export ("isGraphObjectID:sameAs:")]
        bool IsEquals (FBGraphObject anObject, FBGraphObject anotherObject);
        
    }

    [BaseType (typeof (FBGraphObject))]
    interface FBGraphUser {
        [Export ("id")]
        string Id { get; set;  }
        
        [Export ("name")]
        string Name { get; set;  }
        
        [Export ("first_name")]
        string FirstName { get; set;  }
        
        [Export ("middle_name")]
        string MiddleName { get; set;  }
        
        [Export ("last_name")]
        string LastName { get; set;  }
        
        [Export ("link")]
        string Link { get; set;  }
        
        [Export ("username")]
        string Username { get; set;  }
        
        [Export ("birthday")]
        string Birthday { get; set;  }
        
        [Export ("location")]
        FBGraphPlace Location { get; set;  }
    }

    [BaseType (typeof (FBGraphObject))]
    interface FBGraphPlace {
        [Export ("id")]
        string Id { get; set;  }
        
        [Export ("name")]
        string Name { get; set;  }
        
        [Export ("category")]
        string Category { get; set;  }
        
        [Export ("location")]
        FBGraphLocation Location { get; set;  }
    }

    [BaseType (typeof (FBGraphObject))]
    interface FBGraphLocation {
        [Export ("street")]
        string Street { get; set;  }
        
        [Export ("city")]
        string City { get; set;  }
        
        [Export ("state")]
        string State { get; set;  }
        
        [Export ("country")]
        string Country { get; set;  }
        
        [Export ("zip")]
        string Zip { get; set;  }
        
        [Export ("latitude")]
        NSNumber Latitude { get; set;  }
        
        [Export ("longitude")]
        NSNumber Longitude { get; set;  }
    }

    [BaseType (typeof (UIView),
        Delegates=new string [] {"WeakDelegate"},
        Events=new Type [] { typeof (FBLoginViewDelegate)})]
    interface FBLoginView {
        [Export ("permissions")]
        string[] Permissions { get; set;  }
        
        [Export ("readPermissions")]
        string[] ReadPermissions { get; set;  }
        
        [Export ("publishPermissions")]
        string[] PublishPermissions { get; set;  }
        
        [Export ("defaultAudience")]
        FBSessionDefaultAudience DefaultAudience { get; set;  }
        
        [Wrap ("WeakDelegate")]
        FBLoginViewDelegate Delegate { get; set; }
        
        [Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
        NSObject WeakDelegate { get; set; }

        [Export ("initWithReadPermissions:")]
        IntPtr Constructor (string[] readPermissions);
        
        [Export ("initWithPublishPermissions:defaultAudience:")]
        IntPtr Constructor (string[] publishPermissions, FBSessionDefaultAudience defaultAudience);
        
    }
    
    [BaseType (typeof (NSObject))]
    [Model]
    interface FBLoginViewDelegate {
        [Abstract]
        [Export ("loginViewShowingLoggedInUser:")]
        void LoginViewShowingLoggedInUser (FBLoginView loginView);
        
        [Abstract]
        [Export ("loginViewFetchedUserInfo:user:"), EventArgs ("FBLoginViewFetchedUserInfo")]
        void LoginViewFetchedUserInfo (FBLoginView loginView, FBGraphUser user);
        
        [Abstract]
        [Export ("loginViewShowingLoggedOutUser:")]
        void LoginViewShowingLoggedOutUser (FBLoginView loginView);
        
    }
}

