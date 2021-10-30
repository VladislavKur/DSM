
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.CAD.DSM;
using DSMGenNHibernate.Enumerated.DSM;

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
                 UsuarioCEN usu1cen = new UsuarioCEN (); UsuarioEN usu1en = new UsuarioEN();
                 UsuarioCEN usu2cen = new UsuarioCEN (); UsuarioEN usu2en = new UsuarioEN();

                SesionCEN sesion1 = new SesionCEN ();
                 SesionCEN sesion2 = new SesionCEN();

                 MatchCEN match1 = new MatchCEN();
                 MatchCEN match2 = new MatchCEN();

                 MensajeCEN mensaje1 = new MensajeCEN();
                 MensajeCEN mensaje2 = new MensajeCEN();
                 MensajeCEN mensaje3 = new MensajeCEN();

                 CompraCEN compra1 = new CompraCEN();

                 NotificacionesCEN notific = new NotificacionesCEN();
                


                usu1cen.New_ ("1234", "heh@gmail.com", "pedro", "sanchez", DateTime.Today, "Hetero", true, "Pedrito", DateTime.Now, 0);
                usu2cen.New_("4321", "heh2@gmail.com", "Pablo", "Echenique", DateTime.Today, "Invalido", false, "El_ruedas", DateTime.Now, 1);

                //sesion1.New_();
                
                // sesion2.New_();
                
                 match1.New_();
                
                 //mensaje1.New_(usu1.get_IUsuarioCAD().ToString(), usu2.ToString(),"enviado", EstadoMensajeEnum.enviado);
                 //mensaje2.New_(usu1.ToString(), usu2.ToString(), "pendiente", EstadoMensajeEnum.pendiente);
                 //mensaje3.New_(usu1.ToString(), usu2.ToString(), "recibido", EstadoMensajeEnum.recibido);
                
                 compra1.New_(5, EstadoCompraEnum.pendiente);



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
