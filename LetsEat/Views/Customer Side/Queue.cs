﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LetsEat
{
    [Activity(Label = "Queue")]
    public class Queue : ListActivity
    {
        public static readonly List<string> queueNames = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomerQueueLayout);

            // Create your application here

            ListView queueList = FindViewById<ListView>(Resource.Id.QueueList);
            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.QueueListItem, queueNames);
            queueList.Adapter = ListAdapter;

            Button addToQueueButton = FindViewById<Button>(Resource.Id.AddNameToQueueButton);
            addToQueueButton.Click += (sender, e) =>
            {
                Toast.MakeText(this, "Adding name to queue", ToastLength.Short).Show();
                StartActivity(typeof(QueuePageActivity));
            };


        }
    }
}
