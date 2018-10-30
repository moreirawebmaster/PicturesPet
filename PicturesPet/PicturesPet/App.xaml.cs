using System.Diagnostics;
using DLToolkit.Forms.Controls;
using PicturesPet.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PicturesPet
{
    public partial class App : Application
    {
        public const string HttpCat = "https://api.thecatapi.com";
        public const string HttpDog = "https://api.thedogapi.com";
        public App()
        {
            InitializeComponent();
            FlowListView.Init();

            if (Debugger.IsAttached)
                LiveReload.Init();

            var tabbNavigation = new FreshMvvm.FreshTabbedFONavigationContainer("Pictures Pet", "baseNavigation");

            tabbNavigation.AddTab<PetPageModel>("Cat", "cat", TypePet.Cat);
            tabbNavigation.AddTab<PetPageModel>("Dog", "dog", TypePet.Dog);

            MainPage = tabbNavigation;
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

        public enum TypePet
        {
            Cat,
            Dog
        }
    }
}
