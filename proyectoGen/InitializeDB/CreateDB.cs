
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.Enumerated.Proyecto;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes

                UsuarioCEN usuarioCEN = new UsuarioCEN ();

                string idUsu = usuarioCEN.New_ ("1234", "hola@gmail.com", "paqnazco69", "Lucia", "Oliva", new DateTime (2001, 6, 11), OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, new DateTime (2021, 11, 1), 0);

                //vamos a decrementar en un usuario que no tiene likes debe saltar error
                Console.WriteLine ("Vamos a decrementar los likes del usuario (debe dar error)");
                UsuarioEN usuEN = new UsuarioCAD ().ReadOIDDefault (idUsu);
                Console.WriteLine ("El usuario ha dado like " + usuEN.Like_counter + " veces");
                try
                {
                        usuarioCEN.DecrementaLikes (idUsu);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }
                usuEN = new UsuarioCAD ().ReadOIDDefault (idUsu);
                Console.WriteLine ("El usuario1 ha dado like " + usuEN.Like_counter + " veces");
                //Ahora decrementa cuando si puede hacerlo
                Console.WriteLine ("Vamos a decrementar los likes del usuario2 (no debe dar error)");
                string idUsu2 = usuarioCEN.New_ ("1234", "tanga@gmail.com", "paqnazco69", "Lucia", "Oliva", new DateTime (2001, 6, 11), OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, new DateTime (2021, 11, 1), 5);
                usuarioCEN.CalcularEdad (idUsu2);
                UsuarioEN usuEN2 = new UsuarioCAD ().ReadOIDDefault (idUsu2);
                Console.WriteLine ("El usuario2 ha dado like " + usuEN2.Like_counter + " veces");
                try
                {
                        usuarioCEN.DecrementaLikes (idUsu2);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }
                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");
                usuEN2 = new UsuarioCAD ().ReadOIDDefault (idUsu2);
                Console.WriteLine ("El usuario2 ha dado like " + usuEN2.Like_counter + " veces");

                //vamos a incrementar likes aqui en principio no hay restricciones
                Console.WriteLine ("Vamos a incrementar los likes del usuario");

                try
                {
                        usuarioCEN.IncrementaLikes (idUsu);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }
                usuEN = new UsuarioCAD ().ReadOIDDefault (idUsu);
                Console.WriteLine ("El usuario ha dado like " + usuEN.Like_counter + " veces");

                //Esto corresponde con la accion de editar perfil
                Console.WriteLine ("Vamos a modificar los datos de usuario relevantes");

                Console.WriteLine ("Primero veamos los datos que tiene el usuario");
                Console.WriteLine ("contrasena: " + usuEN.Pass + ", nickname: " + usuEN.Nickname + ", nombre: " + usuEN.Nombre + ", apellidos: " + usuEN.Apellidos + ", fecha nacimiento: " + usuEN.Fecha_nacimiento + ", orientacion sexual: " + usuEN.Orientacion_sexual + ", genero " + usuEN.Genero);
                Console.WriteLine ("---------------------------------------");
                //modificamos

                try
                {
                        usuarioCEN.EditarPerfil (idUsu, "turbo2000", "Eustaquia", "Arocas", new DateTime (2003, 6, 30), OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.mujer, "4567");
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }


                //volvemos a mostrar
                usuEN = new UsuarioCAD ().ReadOIDDefault (idUsu);
                Console.WriteLine ("Los datos deben cambiar: ");
                Console.WriteLine ("contrasena: " + usuEN.Pass + ", nickname: " + usuEN.Nickname + ", nombre: " + usuEN.Nombre + ", apellidos: " + usuEN.Apellidos + ", fecha nacimiento: " + usuEN.Fecha_nacimiento + ", orientacion sexual: " + usuEN.Orientacion_sexual + ", genero " + usuEN.Genero);
                Console.WriteLine ("---------------------------------------");

                //Ahora introducimos datos incorrectos
                Console.WriteLine ("Ahora introducimos datos incorrectos o vacios");
                //modificamos
                try
                {
                        usuarioCEN.EditarPerfil (idUsu, "", "Lucia", "Arocas", new DateTime (), OrientacionSexualEnum.heterosexual, GeneroUsuarioEnum.hombre, "1234");
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }


                //volvemos a mostrar
                usuEN = new UsuarioCAD ().ReadOIDDefault (idUsu);
                Console.WriteLine ("Debe salir error y no cambiarse los datos");
                Console.WriteLine ("contrasena: " + usuEN.Pass + ", nickname: " + usuEN.Nickname + ", nombre: " + usuEN.Nombre + ", apellidos: " + usuEN.Apellidos + ", fecha nacimiento: " + usuEN.Fecha_nacimiento + ", orientacion sexual: " + usuEN.Orientacion_sexual + ", genero " + usuEN.Genero + ", esPremium: " + usuEN.EsPremium);
                Console.WriteLine ("---------------------------------------");

                Console.WriteLine ("Vamos a calcular la edad y asignarla en el campo");
                Console.WriteLine ("Edad sin asignar " + usuEN.Edad);
                usuarioCEN.CalcularEdad (idUsu);

                usuEN = new UsuarioCAD ().ReadOIDDefault (idUsu);
                Console.WriteLine ("Edad despues de asignar " + usuEN.Edad);

                SesionCEN sesCEN = new SesionCEN ();
                DateTime dateNow = DateTime.Now;
                //int idSes = sesCEN.New_ (new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 4, 5, 6), idUsu, idUsu);
                int idSes = sesCEN.New_(DateTime.Now, idUsu, idUsu);
                SesionEN sesEN = new SesionCAD ().ReadOIDDefault (idSes);
                Console.WriteLine ("hora de fin antes " + sesEN.Hora_fin);

                try
                {
                        sesCEN.CerrarSesion (idSes);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }


                sesEN = new SesionCAD ().ReadOIDDefault (idSes);
                Console.WriteLine ("hora de fin despues " + sesEN.Hora_fin);
                PremiumCEN premiumCEN = new PremiumCEN ();
                int idPrem = premiumCEN.New_ (9.99, EstadoCompraEnum.realizado, DateTime.Now, new DateTime (2021, 12, 11));


                usuarioCEN.AsignarPremium (idUsu, idPrem);

                usuEN = new UsuarioCAD ().ReadOIDDefault (idUsu);
                Console.WriteLine ("Valor despues de poner el premium " + usuEN.EsPremium);


                IList<UsuarioEN> listaUsuario = usuarioCEN.DameUsuariosPremium ();


                Console.WriteLine ("Lista de usuarios con premium ");
                foreach (UsuarioEN ped in listaUsuario) {
                        Console.WriteLine ("Usuario " + ped.Email);
                }

                IList<UsuarioEN> listaUsuarioEdad = usuarioCEN.DamePorEdad (10, 20);


                Console.WriteLine ("Lista de usuarios con edad entre 10 y 20");
                foreach (UsuarioEN ped in listaUsuarioEdad) {
                        Console.WriteLine ("Usuario " + ped.Email + ": " + ped.Edad);
                }

                IList<UsuarioEN> listaUsuarioGenero = usuarioCEN.DamePorGenero (GeneroUsuarioEnum.mujer);


                Console.WriteLine ("Lista de usuarios con genero mujer");
                foreach (UsuarioEN ped in listaUsuarioGenero) {
                        Console.WriteLine ("Usuario " + ped.Email + ": " + ped.Genero);
                }

                IList<UsuarioEN> listaUsuarioOrientacion = usuarioCEN.DamePorOrientacion (OrientacionSexualEnum.bisexual);


                Console.WriteLine ("Lista de usuarios con orientacion sexual bisexual");
                foreach (UsuarioEN ped in listaUsuarioOrientacion) {
                        Console.WriteLine ("Usuario " + ped.Email + ": " + ped.Orientacion_sexual);
                }

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
