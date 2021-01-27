﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Android.Animation;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;

namespace WSTowersOffice.App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_start);
            ImageView logoImageView = FindViewById<ImageView>(Resource.Id.logoImg);
            AnimateLogo(logoImageView, 3000);
        }

        private void AnimateLogo(ImageView imgview,int duration) {
            List<ObjectAnimator> logoAnimators = new List<ObjectAnimator>();
            logoAnimators.AddRange(GetAnimatorScale(imgview, duration, new EventHandler((object sender, EventArgs args) => {
                imgview.LayoutParameters.Width = imgview.LayoutParameters.Width / 20 * 13;
                imgview.LayoutParameters.Height = imgview.LayoutParameters.Height / 20 * 13;
            })));
            logoAnimators.AddRange(GetAnimatorPosition(imgview, duration));
            logoAnimators.Add(GetAnimatorAlpha(imgview, duration));
            foreach (var item in logoAnimators)
            {
                item.Start();
            }
        }
        private ObjectAnimator[] GetAnimatorScale(View @object,int duration,EventHandler animationEnd) {
            ObjectAnimator animatorScaleX = ObjectAnimator.OfFloat(@object, "scaleX", 1f, 0.65f);
            ObjectAnimator animatorScaleY = ObjectAnimator.OfFloat(@object, "scaleY", 1f, 0.65f);
            animatorScaleX.SetDuration(duration);
            animatorScaleY.SetDuration(duration);
            animatorScaleX.AnimationEnd += animationEnd;
            animatorScaleY.AnimationEnd += animationEnd;
            return new ObjectAnimator[] { animatorScaleX, animatorScaleY };
        }
        private ObjectAnimator GetAnimatorAlpha(Java.Lang.Object @object, int duration)
        {
            ObjectAnimator animatorAlpha = ObjectAnimator.OfFloat(@object, "alpha", 0f, 1f);
            animatorAlpha.SetDuration(duration);
            return animatorAlpha;
        }
        private ObjectAnimator[] GetAnimatorPosition(View view, int duration) {
            DisplayMetrics displayMetrics = new DisplayMetrics();
            WindowManager.DefaultDisplay.GetMetrics(displayMetrics);
            int screenWidth;
            screenWidth = displayMetrics.WidthPixels;
            int[] pos = new int[2];
            view.GetLocationOnScreen(pos);
            //ObjectAnimator translateX = ObjectAnimator.OfFloat(view, "translationX", screenHeight / 2f,view.GetX());
            ObjectAnimator translateY = ObjectAnimator.OfFloat(view, "translationY", screenWidth / 2f, view.GetY());
            //translateX.SetDuration(duration);
            translateY.SetDuration(duration);
            return new ObjectAnimator[] { translateY};
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.Menu.menu_main, menu);
        //    return true;
        //}

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    int id = item.ItemId;
        //    if (id == Resource.Id.action_settings)
        //    {
        //        return true;
        //    }

        //    return base.OnOptionsItemSelected(item);
        //}

        //private void FabOnClick(object sender, EventArgs eventArgs)
        //{
        //}

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}