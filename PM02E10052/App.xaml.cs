using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PM02E10052.Controlador;
using Xamarin.Essentials;
using System.IO;
using PM02E10052.Vistas;
using PM02E10052.Models;

namespace PM02E10052
{
    public partial class App : Application
    {
        static BDSite basedatos;
        public static BDSite BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new BDSite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Examen.db3"));
                }
                return basedatos;
            }

        }
        public  App()
        {
            InitializeComponent();
            

            if ((Preferences.Get("Remember", true) == true))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new AgregarSitio());
            }
        }

        protected override void OnStart()
        {
            if ((Preferences.Get("Remember", true) == true))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new AgregarSitio());
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
