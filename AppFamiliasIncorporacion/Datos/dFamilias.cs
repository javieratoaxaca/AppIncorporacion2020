﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AppFamiliasIncorporacion.Logica; // Cargando la capa de Logica en la de Datos
using System.Windows.Forms;

namespace AppFamiliasIncorporacion.Datos
{
    class dFamilias
    {
        //Creamos la conexion con la base de datos para enviar los datos 
        private SqlCommand cnx = new SqlCommand();

        //Metodo para Insertar Datos en la DB
        public bool insertarDB(lFamIncorporacion dtFamilia) {
            try
            {
                ConexionDB.open();
                cnx = new SqlCommand("Insertar_Familia",ConexionDB.sqlcnx);//aqui cargare los datos a traves de un procedimiento almacenado en la DB
                cnx.CommandType = CommandType.StoredProcedure;
                cnx.Parameters.AddWithValue("@FamiliaId",dtFamilia.familiaId);
                cnx.Parameters.AddWithValue("@FolioEncuesta", dtFamilia.folioEncuesta);
                cnx.Parameters.AddWithValue("@Tutora", dtFamilia.tutora);
                cnx.Parameters.AddWithValue("@TutoraPaterno", dtFamilia.tutoraPaterno);
                cnx.Parameters.AddWithValue("@TutoraMaterno", dtFamilia.tutoraMaterno);
                cnx.Parameters.AddWithValue("@TutoraCurp", dtFamilia.tutoraCurp);
                cnx.Parameters.AddWithValue("@FolioAvisoCobro", dtFamilia.folioAvisoCobro);
                cnx.Parameters.AddWithValue("@ObsCris", dtFamilia.obsCris);
                cnx.Parameters.AddWithValue("@ObsNoti", dtFamilia.obsNoti);
                cnx.Parameters.AddWithValue("@ObsAviso", dtFamilia.obsAviso);

                if (cnx.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionDB.close();
            }
        }

        //Metodo para Visualizar los Datos de la DB
        public DataTable vistaDB()
        {
            try
            {
                ConexionDB.open();
                cnx = new SqlCommand("Vista_Familia", ConexionDB.sqlcnx);
                if (cnx.ExecuteNonQuery() != 0)
                {
                    DataTable dtFamilia = new DataTable();
                    SqlDataAdapter daFamilia = new SqlDataAdapter(cnx);
                    daFamilia.Fill(dtFamilia);
                    return dtFamilia;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                ConexionDB.close();
            }
        }

        //Metodo para Actualizar Datos en la DB
        //Metodo para Eliminar Datos en la DB
        //Metodo para Buscar Datos en la DB
    }
}