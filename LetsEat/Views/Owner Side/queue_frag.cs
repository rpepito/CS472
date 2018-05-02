﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

namespace LetsEat.Views.OwnerSide
{
    public class queue_frag : Android.Support.V4.App.Fragment
    {
        private const string FBURL = "https://fir-database-ec02e.firebaseio.com/";
        EditText queueText;
        EditText amountText;
        Button queuebutton;

        // List<Views.OwnerSide.Queuedb> listQueue = new List<Views.OwnerSide.Queuedb>();

        ListView listView;

        Views.OwnerSide.QueueListViewAdapter adapter;
        List<Views.OwnerSide.Queuedb> listQueue = new List<Views.OwnerSide.Queuedb>();

        string queueHolder = string.Empty;
        string errmesg = "Could not queue.";
        string confirmmsg = "Success!";

        FirebaseUser user;

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

            user = FirebaseAuth.GetInstance(MainActivity.app).CurrentUser;

            await LoadData();
        }

        public static queue_frag NewInstance()
        {
            var frag2 = new queue_frag { Arguments = new Bundle() };
            return frag2;
        }

        private async Task LoadData()
        {
            
            var firebase = new FirebaseClient(FBURL);
            
            var items = await firebase
                .Child("queues")
                .Child(user.Uid)
                .OnceAsync<Queuedb>();
            
            adapter = null;
            foreach (var item in items)
            {
                Console.WriteLine("Loading items...");
                Console.WriteLine(item.Object.name);
                Queuedb queuedb = new Queuedb();
                queuedb.uid = item.Key;
                queuedb.name = item.Object.name;
                listQueue.Add(queuedb);
            }

            Console.WriteLine("Updating adapter...");
            adapter = new Views.OwnerSide.QueueListViewAdapter(this, listQueue);
            adapter.NotifyDataSetChanged();
            listView.Adapter = adapter;
            listView.TextFilterEnabled = true;

           
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.OwnerQueueLayout, null);

            Button removeFromQueueBtn = view.FindViewById<Button>(Resource.Id.removeFromQueueButton);

            removeFromQueueBtn.Click += delegate {
                Toast.MakeText(this.Activity, "Remove from queue", ToastLength.Short).Show();
            };
           
            listView = (ListView)view.FindViewById(Android.Resource.Id.List);
            adapter = new Views.OwnerSide.QueueListViewAdapter(this, listQueue);
            adapter.NotifyDataSetChanged();
            listView.Adapter = adapter;
            listView.TextFilterEnabled = true;

            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }
    }
    
}
