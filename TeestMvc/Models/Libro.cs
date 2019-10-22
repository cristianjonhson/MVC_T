using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
namespace TeestMvc.Models
{
    public class Libro
    {
        [Required(ErrorMessage="Debe Ingresar el codigo")]
        public int codigo { get; set; }
        [Required(ErrorMessage="No puede quedar vacio")]
        [StringLength(10,MinimumLength=3)]
        public string nombre { get; set; }

        public int precio { get; set; }


        public void grabar()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            
            conn.ConnectionString="Server=PMT_LAB0209;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into libro values (@cod,@nomb,@pre)";
            cmd.Parameters.AddWithValue("@cod",this.codigo);
            cmd.Parameters.AddWithValue("@nomb", this.nombre);
            cmd.Parameters.AddWithValue("@pre", this.precio);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        static public List<Libro> Catologo()
        {
            List<Libro>lista=new List<Libro>();
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader lee;
            conn.ConnectionString = "Server=PMT_LAB0209;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from libro";
            

            conn.Open();
            lee = cmd.ExecuteReader();
            while (lee.Read())
            {
                Libro l = new Libro();
                l.codigo = lee.GetInt32(0);
                l.nombre = lee.GetString(1);
                l.precio = lee.GetInt32(2);
                lista.Add(l);
            }
            conn.Close();
            return lista;

        }

        public void leer()
        {

        
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader lee;
            conn.ConnectionString = "Server=PMT_LAB0209;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from libro where codigo="+this.codigo;


            conn.Open();
            lee = cmd.ExecuteReader();
            if (lee.Read())
            {

                
                this.nombre = lee.GetString(1);
                this.precio = lee.GetInt32(2);
                
            }
            conn.Close();
            



        }

        public void actualizar()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            conn.ConnectionString = "Server=PMT_LAB0209;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update libro set nombre=@nomb,precio=@pre where codigo=@cod";
            cmd.Parameters.AddWithValue("@cod", this.codigo);
            cmd.Parameters.AddWithValue("@nomb", this.nombre);
            cmd.Parameters.AddWithValue("@pre", this.precio);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        public void eliminar()
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader lee;
            conn.ConnectionString = "Server=PMT_LAB0209;Database=biblio;User Id=sa;Password=sql-pto;";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete  from libro where codigo=" + this.codigo;


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
           

        }

    
    }
}