using System;


namespace FacebookSDK
{
    public enum FBSessionState {
        /*! One of two initial states indicating that no valid cached token was found */
        Created                   = 0,
        /*! One of two initial session states indicating that a cached token was loaded;
     when a session is in this state, a call to open* will result in an open session,
     without UX or app-switching*/
        CreatedTokenLoaded        = 1,
        /*! One of three pre-open session states indicating that an attempt to open the session
     is underway*/
        CreatedOpening            = 2,
        
        /*! Open session state indicating user has logged in or a cached token is available */
        Open                      = 1 | (1 << 9),
        /*! Open session state indicating token has been extended */
        OpenTokenExtended         = 2 | (1 << 9),
        
        /*! Closed session state indicating that a login attempt failed */
        ClosedLoginFailed         = 1 | (1 << 8), // NSError obj w/more info
        /*! Closed session state indicating that the session was closed, but the users token 
        remains cached on the device for later use */
        Closed                    = 2 | (1 << 8), // "
    }

    public enum FBSessionLoginBehavior {
        /*! Attempt Facebook Login, ask user for credentials if necessary */
        WithFallbackToWebView      = 0,
        /*! Attempt Facebook Login, no direct request for credentials will be made */
        WithNoFallbackToWebView    = 1,
        /*! Only attempt WebView Login; ask user for credentials */
        ForcingWebView             = 2,
        /*! Attempt Facebook Login, prefering system account and falling back to fast app switch if necessary */
        UseSystemAccountIfPresent  = 3,
    }

    public enum FBSessionDefaultAudience {
        /*! No audience needed; this value is useful for cases where data will only be read from Facebook */
        None                = 0,
        /*! Indicates that only the user is able to see posts made by the application */
        OnlyMe              = 10,
        /*! Indicates that the user's friends are able to see posts made by the application */
        Friends             = 20,
        /*! Indicates that all Facebook users are able to see posts made by the application */
        Everyone            = 30,
    }

    public enum FBSessionLoginType {
        /*! A login type has not yet been established */
        None                      = 0,
        /*! A system integrated account was used to log the user into the application */
        SystemAccount             = 1,
        /*! The Facebook native application was used to log the user into the application */
        FacebookApplication       = 2,
        /*! Safari was used to log the user into the application */
        FacebookViaSafari         = 3,
        /*! A web view was used to log the user into the application */
        WebView                   = 4,
        /*! A test user was used to create an open session */
        TestUser                  = 5,
    }

}

