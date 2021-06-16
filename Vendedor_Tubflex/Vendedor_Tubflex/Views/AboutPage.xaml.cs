using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using Dapper;
using EntityFramework.Firebird;


namespace Vendedor_Tubflex.Views
{
    public partial class AboutPage : ContentPage
    {
        public string Source { get; set; }
        public AboutPage()
        {
            InitializeComponent();
            // var Imagen = ImageSource.FromResource(Source, typeof());
            var image = new Image { Source = "img/TubFlexAca.png" };
        }

        public void Conectar()
        {
            try
            {
                string connectionString = "user = SYSDBA;"
                    + "password = FJ23qw67po;" +
                    "database=BDA_TUBFLEX.FDB;" +
                    "DataSource = localhost;" +
                    "Port = 3050;" +
                    "Dialect = 3;" +
                    "Charset = NONE;" +
                    "Role = ;" +
                    "Connection lifetime = 15;" +
                    "Pooling = true;" +
                    "Packet Size = 8192;" +
                    "ServerType = 0";
                FbConnection conector = new FbConnection(connectionString);
                FbTransaction myTransection = conector.BeginTransaction();
                FbCommand sql = new FbCommand();
                sql.CommandText = "Select * from clientes";
                sql.Connection = conector;
                sql.Transaction = myTransection;

                myTransection.Commit();
                sql.Dispose();


                Correo.Text = "Conectado Correctamente";

                conector.Close();
            }
            catch(Exception)
            {
                Correo.Text = "No se pudo Conectar";
            }
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            var usuario = Convert.ToString(user.Text);
            var Contraseña = Convert.ToString(password.Text);

            Correo.Text = usuario;
            pass.Text = Contraseña;
            /*var Result = usuario + " - " + Contraseña;
            DisplayAlert("Datos", Result, "Ok");*/

            //await Shell.Current.GoToAsync("//Menu");
            //InitializeComponent();
            //this.BindingContext = new Menu();
            //Conectar();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            string ip_addres = ip_Address.Text;
            int Port = Convert.ToInt32(Tb_Port.Text);
            string Result = "";
            try
            {
                FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
                csb.DataSource = ip_addres;
                csb.Port = Port;
                csb.Database = @"C:\BDA_TUBFLEX.FDB";
                csb.UserID = "SYSDBA";
                csb.Password = "FJ23qw67po";
                csb.ServerType = FbServerType.Default;
                csb.Dialect = 3;

                FbConnection con = new FbConnection(csb.ToString());
                con.Open();

                FbCommand sql = new FbCommand("select nombre from clientes",con);
                
                String nombreCliente = con.Query<String>("select nombre from clientes ").Single();

                Result = "Conectado Correctamente Con El Servidor";
                DisplayAlert("Estado de Conexión", Result + nombreCliente, "Ok");
            }
            catch(Exception ex)
            {
                Result = "No Se Pudo Conectar con el Servidor";
                DisplayAlert("Estado de Conexión" ,Result + " - " + ex.Message, "Ok");
                ip.Text = ip_addres;
                puerto.Text = Convert.ToString( Port );
            }
            

        }
    }
}