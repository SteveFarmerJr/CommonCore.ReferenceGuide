using System;
using FFImageLoading.Forms;
using Xamarin.Forms;
using Xamarin.Forms.CommonCore;

namespace referenceguide
{
    public class PictureView: ContentView
    {
        private CachedImage img;
        public PictureView()
        {
			img = new CachedImage()
			{
                HeightRequest = 300,
				RetryCount = 0,
                Aspect = Aspect.AspectFill,
				RetryDelay = 250,
				LoadingPlaceholder = "placeholder.png",
				CacheDuration = TimeSpan.FromDays(10),
			};
            img.SetBinding(CachedImage.SourceProperty,"ImageUrl");

            Content = new StackContainer(true)
            {
                Children = { img }
            };
        }

    }
}
