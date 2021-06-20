﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using MemoryGame;
using MemoryGame.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(SoftkeyboardDisabledEntry), typeof(SoftkeyboardDisabledEntryRenderer))]
//namespace MemoryGame.Droid
//{
//    [Obsolete]
//    class SoftkeyboardDisabledEntryRenderer : EntryRenderer
//    {
//        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
//        {
//            base.OnElementChanged(e);

//            if (e.NewElement != null)
//            {
//                ((SoftkeyboardDisabledEntry)e.NewElement).PropertyChanging += OnPropertyChanging;
//            }

//            if (e.OldElement != null)
//            {
//                ((SoftkeyboardDisabledEntry)e.OldElement).PropertyChanging -= OnPropertyChanging;
//            }

//            // Disable the Keyboard on Focus
//            this.Control.ShowSoftInputOnFocus = false;
//        }

//        private void OnPropertyChanging(object sender, PropertyChangingEventArgs propertyChangingEventArgs)
//        {
//            // Check if the view is about to get Focus
//            if (propertyChangingEventArgs.PropertyName == VisualElement.IsFocusedProperty.PropertyName)
//            {
//                // incase if the focus was moved from another Entry
//                // Forcefully dismiss the Keyboard 
//                InputMethodManager imm = (InputMethodManager)this.Context.GetSystemService(Context.InputMethodService);
//                imm.HideSoftInputFromWindow(this.Control.WindowToken, 0);
//            }
//        }
//    }
//}