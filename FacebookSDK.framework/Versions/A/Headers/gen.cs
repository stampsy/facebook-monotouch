
	[BaseType (typeof (UIView))]
	interface FBLoginView {
		[Export ("permissions")]
		NSArray Permissions { get; set;  }

		[Export ("readPermissions")]
		NSArray ReadPermissions { get; set;  }

		[Export ("publishPermissions")]
		NSArray PublishPermissions { get; set;  }

		[Export ("defaultAudience")]
		FBSessionDefaultAudience DefaultAudience { get; set;  }

		[Export ("id<FBLoginViewDelegate>")]
		IBOutlet Id<FBLoginViewDelegate> { get; set;  }

		[Export ("init")]
		NSObject Init ();

		[Export ("initWithPermissions:__attribute__((deprecated))")]
		NSObject InitWithPermissions__attribute__((deprecated)) (NSArray permissions, (deprecated ));

		[Export ("initWithReadPermissions:")]
		NSObject InitWithReadPermissions (NSArray readPermissions);

		[Export ("initWithPublishPermissions:defaultAudience:")]
		NSObject InitWithPublishPermissionsdefaultAudience (NSArray publishPermissions, FBSessionDefaultAudience defaultAudience);

	}

	[BaseType (typeof ())]
	[Model]
	interface FBLoginViewDelegate {
		[Abstract]
		[Export ("loginViewShowingLoggedInUser:")]
		void LoginViewShowingLoggedInUser (FBLoginView loginView);

		[Abstract]
		[Export ("loginViewFetchedUserInfo:user:")]
		void LoginViewFetchedUserInfouser (FBLoginView loginView, id<FBGraphUser> user);

		[Abstract]
		[Export ("loginViewShowingLoggedOutUser:")]
		void LoginViewShowingLoggedOutUser (FBLoginView loginView);

	}
