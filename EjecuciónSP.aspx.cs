using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EjecuciónSP : System.Web.UI.Page {

  //Atributos.
  GestorBD.GestorBD GestorBD;
  OleDbConnection cnOracle;       //Para conctarse a Oracle.
  OleDbCommand procAlm;
  OleDbParameter par;

  protected void Page_Load(object sender, EventArgs e) {
    GestorBD= (GestorBD.GestorBD) Session["GestorBD"];
  }

  //Ejemplo de ejecución de un procedimiento almacenado (en Oracle).
  //Procedimiento cantPedidosArt:
  // recibe como parámetro de entrada el nombre de un artículo y regresa como 
  // parámetro de salida la cantidad de pedidos en los que aparece.
  protected void BtnEjecutaProc_Click(object sender, EventArgs e) {
    String nomArt;
    int cant;

    //1- Abrir la conexión a la BD.
    cnOracle = GestorBD.conex;
    cnOracle.Open();
    procAlm = new OleDbCommand();
    procAlm.Connection = cnOracle;
    
    //2- Especificar el llamado al procedimiento  (en general: al subprograma).
    procAlm.CommandText = "cantPedidosArt";
    procAlm.CommandType = CommandType.StoredProcedure;

    //3- Especificar los parámetros:
    //a) primero todos los de entrada:
    nomArt = "Portafolios";
    par = new OleDbParameter("nom", nomArt);
    procAlm.Parameters.Add(par);

    //b) luego todos los de salida (uno en este caso):
    par = new OleDbParameter("cant", OleDbType.Integer,
      4, ParameterDirection.Output, false, 4, 0, "NomArt", DataRowVersion.Current, 0);
    procAlm.Parameters.Add(par);

    //4- Ejecutar el procedimiento (en general: el subprograma).
    try {
      procAlm.ExecuteNonQuery();

      //5- Recuperar el (los) valor(es) regresado(s) por medio del (de los)
      //   parámetro(s) de salida.
      cant = Convert.ToInt16(procAlm.Parameters["cant"].Value);
      Label1.Text= "Cantidad de pedidos: " + cant;
    }
    catch (OleDbException err) {
      Label1.Text = err.Message;
    }

    //6- Cerrar la conexión a la BD.
    cnOracle.Close();
  }

  //Ejemplo de ejecución de una función almacenada (en Oracle).
  //Función cantArtsPedido:
  // recibe como parámetro de entrada el folio de un pedido,
  // y regresa la cantidad de artículos pedidos.
  protected void BtnEjecutaFunc_Click(object sender, EventArgs e) {
    int folioPed, cantArts;
    //1- Abrir la conexión a la BD.
    cnOracle = GestorBD.conex;
    cnOracle.Open();
    procAlm = new OleDbCommand();
    procAlm.Connection = cnOracle;

    //2- Especificar el llamado a la función.
    procAlm.CommandText = "cantArtsPedido";
    procAlm.CommandType = CommandType.StoredProcedure;

    //3- Especificar los parámetros:
    // a) Nota: primero hay que definir el tipo de valor que regresará la función.
    par = new OleDbParameter("RETURN_VALUE", OleDbType.Integer,
      4, ParameterDirection.ReturnValue, false, 4, 0, "cantArts", DataRowVersion.Current, 0);
    procAlm.Parameters.Add(par);

    // b) luego hay que definir los parámetros de entrada (uno en este caso).
    folioPed = 10;
    par = new OleDbParameter("folio", folioPed);
    procAlm.Parameters.Add(par);

    //4- Ejecutar el procedimiento (en general: el subprograma).
    try {
      procAlm.ExecuteNonQuery();

      //5- Recuperar el valor regresado por la función.
      cantArts = Convert.ToInt16(procAlm.Parameters["RETURN_VALUE"].Value);
      Label1.Text = "Cantidad de artículos: " + cantArts;
    }
    catch (OleDbException err) {
      Label1.Text = err.Message;
    }

    //6- Cerrar la conexión a la BD.
    cnOracle.Close();
  }
}

