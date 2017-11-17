﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.CommonCore;

/*

Android MainActivity must implement
    Forms.SetFlags("FastRenderers_Experimental");

 - and -

    Nuget version of Xamarin.Forms 2.5 and above

Reduce native views created - Performance
Cut down on backing native views created for Xamarin.Forms, as noted by Miguel in #42948.

Layout Compression - Performance
LayoutCompression allows multiple layers of Xamarin.Forms layouts to be packed into a single native one.
https://blog.xamarin.com/3-big-things-explore-xamarin-forms-2-5-0-pre-release/
*/
namespace referenceguide
{
    /// <summary>
    /// LayoutCompression allows multiple layers of Xamarin.Forms layouts to be packed into a single native one. 
    /// Not for UI rendered panels.
    /// </summary>
    public class CompressedStackLayout : StackLayout
    {
        public CompressedStackLayout()
        {
            if(CoreSettings.OS== DeviceOS.ANDROID)
                this.SetValue(CompressedLayout.IsHeadlessProperty, true);
        }
    }

    /// <summary>
    /// LayoutCompression allows multiple layers of Xamarin.Forms layouts to be packed into a single native one. 
    /// Not for UI rendered panels.
    /// </summary>
    public class CompressedAbsoluteLayout : AbsoluteLayout
    {
        public CompressedAbsoluteLayout()
        {
            if (CoreSettings.OS == DeviceOS.ANDROID)
                this.SetValue(CompressedLayout.IsHeadlessProperty, true);
        }
    }
    /// <summary>
    /// LayoutCompression allows multiple layers of Xamarin.Forms layouts to be packed into a single native one. 
    /// Not for UI rendered panels.
    /// </summary>
    public class CompressedGrid : Grid
    {
        public CompressedGrid()
        {
            if (CoreSettings.OS == DeviceOS.ANDROID)
                this.SetValue(CompressedLayout.IsHeadlessProperty, true);
        }
    }
    /// <summary>
    /// LayoutCompression allows multiple layers of Xamarin.Forms layouts to be packed into a single native one. 
    /// Not for UI rendered panels.
    /// </summary>
    public class CompressedRelativeLayout : RelativeLayout
    {
        public CompressedRelativeLayout()
        {
            if (CoreSettings.OS == DeviceOS.ANDROID)
                this.SetValue(CompressedLayout.IsHeadlessProperty, true);
        }
    }

}
