
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ProyectoGenNHibernate.EN.Proyecto;
using ProyectoGenNHibernate.CEN.Proyecto;
using ProyectoGenNHibernate.CAD.Proyecto;
using ProyectoGenNHibernate.CP.Proyecto;
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

                //int idUsu = usuarioCEN.New_ ("1234", "hola@gmail.com", "paqnazco69", "Lucia", "Oliva", new DateTime (1800, 6, 11), OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, new DateTime (2021, 11, 1), 0, @"https://pixnio.com/free-images/2021/09/21/2021-09-21-09-26-06-550x729.jpg");
                int idUsu = usuarioCEN.New_ ("1234", "hola@gmail.com", "paqnazco69", "Lucia", "Oliva", new DateTime (1800, 6, 11), OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, new DateTime (2021, 11, 1), 0);
                usuarioCEN.CalcularEdad (idUsu);
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
                //int idUsu2 = usuarioCEN.New_ ("1234", "tanga@gmail.com", "paqnazco69", "Lucia", "Oliva", new DateTime (2001, 6, 11), OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, new DateTime (2021, 11, 1), 5, @"https://cdn.stocksnap.io/img-thumbs/960w/girl-portrait_OWJB5WGPME.jpg");
                int idUsu2 = usuarioCEN.New_ ("1234", "tanga@gmail.com", "paqnazco69", "Lucia", "Oliva", new DateTime (2001, 6, 11), OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, new DateTime (2021, 11, 1), 5);
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
                        usuarioCEN.EditarPerfil (idUsu, "turbo2000", "Eustaquia", "Arocas", new DateTime (1900, 6, 30), OrientacionSexualEnum.homosexual, GeneroUsuarioEnum.mujer);
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
                        usuarioCEN.EditarPerfil (idUsu, "tristeza123", "Lucia", "Arocas", new DateTime (2011, 6, 11), OrientacionSexualEnum.heterosexual, GeneroUsuarioEnum.hombre);
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

                //MATCH
                Console.WriteLine ("-----------------------");
                Console.WriteLine ("MATCH");
                MatchCP matchCP = new MatchCP ();

                MatchCAD matchCAD = new MatchCAD ();
                MatchCEN matchCEN = new MatchCEN ();
                MatchEN match1 = null;

                //int id = matchCEN.NewProv(EstadoMatchEnum.pendiente, idUsu, idUsu2);
                try {
                        Console.WriteLine ("Se envia la peticion de match");
                        //match1 = matchCP.New_ (EstadoMatchEnum.pendiente, idUsu, idUsu2);
                        match1 = matchCP.New2 (idUsu, idUsu2);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine ("Error controlado: " + e.Message);
                }
                /*Console.WriteLine ("Se acepta la peticion de match");
                 * MatchEN match2 = matchCP.New_ (EstadoMatchEnum.pendiente, idUsu2, idUsu);*/
                MatchCEN matchCEN1 = new MatchCEN ();
                try
                {
                        Console.WriteLine ("Intentamos hacer match con los usuarios cambiados debe dar error");
                        //MatchEN match2 = matchCP2.New_ (EstadoMatchEnum.pendiente, idUsu2, idUsu);
                        MatchEN match2 = matchCP.New2 (idUsu2, idUsu);
                        Console.WriteLine ("Se hace match");
                        //matchCP.HacerMatch (match1.Id, idUsu, idUsu2, EstadoMatchEnum.aceptado);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }
                matchCEN1.GestionarMatch (match1.Id, EstadoMatchEnum.aceptado);
                Console.WriteLine ("Mostramos el estado del match 1 despues de darle a aceptar");
                match1 = matchCEN1.ReadOID (match1.Id);
                Console.WriteLine (match1.Id + "Estado: " + match1.Estado);

                try
                {
                        Console.WriteLine ("Intentamos hacer match con el mismo usuario debe dar error");
                        //MatchEN match3 = matchCP2.New_ (EstadoMatchEnum.pendiente, idUsu, idUsu2);
                        MatchEN match3 = matchCP.New2 (idUsu, idUsu2);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }



                // matchCP.FiltrarPorNombre ("pedro");
                Console.WriteLine ("-----------------------");
                Console.WriteLine ("MENSAJES");
                //MENSAJES
                MensajeCP men1 = new MensajeCP ();
                try
                {
                        MensajeEN idmen1 = men1.New_ (" algo de contenido", EstadoMensajeEnum.enviado, idUsu, idUsu2);

                        MensajeCP men2 = new MensajeCP ();
                        MensajeEN idmen2 = men2.New_ (" a si, que guay ", EstadoMensajeEnum.enviado, idUsu2, idUsu);

                        MensajeEN mensajeEN1 = new MensajeCAD ().ReadOIDDefault (idmen1.Id);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine ("Error controlado: " + e.Message);
                }

                IList<MensajeEN> listamensajes = null;
                MensajeCEN mensaje = new MensajeCEN ();
                listamensajes = mensaje.DameMensajes (idUsu);
                Console.WriteLine ("Mensajes donde el usuario 1 es o el receptor o el emisor");
                foreach (MensajeEN ped in listamensajes) {
                        Console.WriteLine ("Usuario: " + idUsu + "Contenido " + ped.Contenido);
                }


                IList<MensajeEN> listamensajes2 = null;
                MensajeCEN mensaje2 = new MensajeCEN ();
                listamensajes2 = mensaje2.DameMensajesEntreEstos2 (idUsu, idUsu2);
                Console.WriteLine ("Mensajes donde el usuario 1 es o el receptor o el emisor y el usuario 2 el receptor");
                foreach (MensajeEN ped in listamensajes2) {
                        Console.WriteLine ("Contenido " + ped.Contenido);
                }






                // SESION
                SesionCP sesCP = new SesionCP ();
                SesionCAD sesCAD = new SesionCAD ();
                SesionCEN sesCEN = new SesionCEN ();
                DateTime dateNow = DateTime.Now;
                //int idSes = sesCEN.New_ (new DateTime (dateNow.Year, dateNow.Month, dateNow.Day, 4, 5, 6), idUsu, idUsu);
                int idSes = sesCEN.New_ (DateTime.Now, idUsu);


                //sesCP.CerrarSesion()
                SesionEN sesEN = new SesionCAD ().ReadOIDDefault (idSes);

                Console.WriteLine ("hora de inicio antes " + sesEN.Hora_inicio);

                Console.WriteLine ("hora de fin antes " + sesEN.Hora_fin);


                IList<SesionEN> listaSesiones = null;
                SesionCEN sesionCEN = new SesionCEN ();
                listaSesiones = sesionCEN.DameSesionesUsuario (idUsu);
                Console.WriteLine ("LISTA DE SESIONES (ACTIVAS)?");
                foreach (SesionEN ped in listaSesiones) {
                        Console.WriteLine ("Id: " + ped.Id + ", Hora inicio: " + ped.Hora_inicio + ", Hora fin: " + ped.Hora_fin);
                }

                Console.WriteLine ("Creamos otra sesion antes de cerrar la otra");
                int idSes2 = sesCEN.New_ (DateTime.Now, idUsu);

                try
                {
                        Console.WriteLine ("Se ha cerrado la sesion: " + idSes + " - " + idUsu);

                        sesCP.CerrarSesion (idSes, idUsu);
                        sesCP.CerrarSesion (idSes2, idUsu);
                }
                catch (Exception e)
                {
                        System.Console.WriteLine (e.Message);
                }



                sesEN = new SesionCAD ().ReadOIDDefault (idSes);
                Console.WriteLine ("hora de fin despues " + sesEN.Hora_fin);

                Console.WriteLine ("Creamos otra sesion");
                int idSesNot = sesCEN.New_ (DateTime.Now, idUsu);
                //sesCP.CerrarSesion(idSesNot, idUsu);
                listaSesiones = sesionCEN.DameSesionesUsuario (idUsu);
                Console.WriteLine ("LISTA DE SESIONES");
                foreach (SesionEN ped in listaSesiones) {
                        Console.WriteLine ("Id: " + ped.Id + ", Hora inicio: " + ped.Hora_inicio + ", Hora fin: " + ped.Hora_fin);
                }

                listaSesiones = sesionCEN.DameSesionesTerminadasUsuario (idUsu);
                Console.WriteLine ("LISTA DE SESIONES TERMINADAS");
                foreach (SesionEN ped in listaSesiones) {
                        Console.WriteLine ("Id: " + ped.Id + ", Hora inicio: " + ped.Hora_inicio + ", Hora fin: " + ped.Hora_fin);
                }

                listaSesiones = sesionCEN.DameUltimaSesionUsuario (idUsu);
                Console.WriteLine ("ULTIMA SESION USUARIO");
                foreach (SesionEN ped in listaSesiones) {
                        Console.WriteLine ("Id: " + ped.Id + ", Hora inicio: " + ped.Hora_inicio + ", Hora fin: " + ped.Hora_fin);
                }


                PremiumCEN premiumCEN = new PremiumCEN ();
                int idPrem = premiumCEN.New_ (9.99, EstadoCompraEnum.realizado);

                PremiumEN premiumEN = premiumCEN.ReadOID (idPrem);
                usuarioCEN.AsignarPremium (idUsu, idPrem);

                usuEN = new UsuarioCAD ().ReadOIDDefault (idUsu);
                Console.WriteLine ("Valor despues de poner el premium " + usuEN.EsPremium);


                IList<UsuarioEN> listaUsuario = usuarioCEN.DameUsuariosPremium ();


                Console.WriteLine ("Lista de usuarios con premium ");
                foreach (UsuarioEN ped in listaUsuario) {
                        Console.WriteLine ("Usuario " + ped.Email);
                }


                IList<UsuarioEN> listaUsuarioDefecto = null;

                listaUsuarioDefecto = usuarioCEN.FiltroDefecto (OrientacionSexualEnum.bisexual, GeneroUsuarioEnum.mujer, false, 0, -1);



                Console.WriteLine ("\n");
                Console.WriteLine ("Lista de mujeres bisexuales");
                foreach (UsuarioEN ped in listaUsuarioDefecto) {
                        Console.WriteLine ("Usuario " + ped.Orientacion_sexual + ": " + ped.Genero);
                }

                //COMPROBAMOS EDAD CORRECTA
                Console.WriteLine (usuEN.Edad);
                Console.WriteLine (usuEN2.Edad);

                IList<UsuarioEN> listaUsuarioBusqueda = usuarioCEN.FiltroBusqueda (null, null, 2, 18, false);

                Console.WriteLine ("Edad menor que 18");
                Console.WriteLine ("Lista de usuarios mujer con edad entre 19 y 20");
                foreach (UsuarioEN ped in listaUsuarioBusqueda) {
                        Console.WriteLine ("Usuario  " + ped.Email + ": " + ped.Genero + ", " + ped.Edad + ", " + ped.Orientacion_sexual);
                }


                IList<UsuarioEN> listaFiltroNombreMatch = matchCP.FiltrarPorNombre ("lucia");;         //= matchCEN.Filtra


                foreach (UsuarioEN matchen in listaFiltroNombreMatch) {
                        Console.WriteLine ("Usuario " + matchen.Nombre);
                }


                IList<UsuarioEN> listaUsuarioMatchRecibido = null;

                listaUsuarioMatchRecibido = usuarioCEN.DameUsuariosMatchReceptor (idUsu);

                Console.WriteLine ("\n");
                Console.WriteLine ("Lista Receptor Match Usu1");
                foreach (UsuarioEN ped in listaUsuarioMatchRecibido) {
                        Console.WriteLine ("Usuario " + ped.Orientacion_sexual + ": " + ped.Genero + " nose " + ped.Email);
                }
                IList<UsuarioEN> listaUsuarioMatchRecibido2 = null;
                listaUsuarioMatchRecibido2 = usuarioCEN.DameUsuariosMatchReceptor (idUsu2);

                Console.WriteLine ("\n");
                Console.WriteLine ("Lista Receptor Match Usu2");
                foreach (UsuarioEN ped in listaUsuarioMatchRecibido2) {
                        Console.WriteLine ("Usuario " + ped.Orientacion_sexual + ": " + ped.Genero + " nose " + ped.Email);
                }
                IList<UsuarioEN> listaUsuarioMatchEmisor1 = null;
                listaUsuarioMatchEmisor1 = usuarioCEN.DameUsuariosMatchEmisor (idUsu);

                Console.WriteLine ("\n");
                Console.WriteLine ("Lista Emisor Match Usu1");
                foreach (UsuarioEN ped in listaUsuarioMatchEmisor1) {
                        Console.WriteLine ("Usuario " + ped.Orientacion_sexual + ": " + ped.Genero + " nose " + ped.Email);
                }
                IList<UsuarioEN> listaUsuarioMatchEmisor2 = null;
                listaUsuarioMatchEmisor2 = usuarioCEN.DameUsuariosMatchEmisor (idUsu2);

                Console.WriteLine ("\n");
                Console.WriteLine ("Lista Emisor Match Usu2");
                foreach (UsuarioEN ped in listaUsuarioMatchEmisor2) {
                        Console.WriteLine ("Usuario " + ped.Orientacion_sexual + ": " + ped.Genero + " nose " + ped.Email);
                }

                NotificacionCEN notificacionCEN = new NotificacionCEN ();
                int idNotificacion = notificacionCEN.New_ ("Notificacion de Prueba");
                notificacionCEN.AsignarSesion (idNotificacion, idSesNot);
                IList<NotificacionEN> listaNotificaciones = null;
                listaNotificaciones = notificacionCEN.DameNotificacionesUsuario (idUsu);

                Console.WriteLine ("\n");
                Console.WriteLine ("Lista Notificaciones");
                foreach (NotificacionEN ped in listaNotificaciones) {
                        Console.WriteLine ("Usuario: " + idUsu + " Contenido" + ped.Contenido);
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
