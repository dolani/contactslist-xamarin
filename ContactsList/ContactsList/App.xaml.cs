using ContactsList.PageModels;
using ContactsList.Services;
using ContactsList.Validator;
using FluentValidation;
using FreshMvvm;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Interface registration with FreshIOC  
            FreshIOC.Container.Register<IContactRepository, ContactRepository>();
            FreshIOC.Container.Register<IValidator, ContactValidator>();

            // The root page of your application
            var mainPage = FreshPageModelResolver.ResolvePageModel<AddContactPageModel>();
            MainPage = new FreshNavigationContainer(mainPage);
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
