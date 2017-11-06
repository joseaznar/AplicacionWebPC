using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {

  //Atributos de la clase.
  String cadSql;
  GestorBD.GestorBD GestorBD;
  DataSet DsGeneral = new DataSet();

  //Acciones iniciales.
  protected void Page_Load(object sender, EventArgs e) {
    lblFH.Text = DateTime.Now.ToString();
    //IsPostBack - da false la 1a. vez que se carga la página; 
    // true desde la 2a. vez.
    if (!IsPostBack) {
      //Conexión a la BD.
      GestorBD = new GestorBD.GestorBD("MSDAORA", "bd01", "esqose", "oracle.itam.mx");
      Session["GestorBD"] = GestorBD;
      //Response.Write("Conecté");
    }
  }

  //Si usuario y contraseña son correctos, avanza
  protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e) {

    if (valida()) {
      Session["RFC"] = Login1.UserName;
      Session["Tipo"] = getTipo(Session["RFC"].ToString());
      Response.Redirect("AdminUsuarios.aspx");
    }
  }

  //Verifica que usuario y contraseña coincidan
  private bool valida() {
    
    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    cadSql = "select * from PCUsuarios where RFC='" + Login1.UserName +
      "' and Passw='" + Login1.Password + "'";
    GestorBD.consBD(cadSql, "Temp", DsGeneral);
    if (DsGeneral.Tables["Temp"].Rows.Count != 0)
      return true;      //El usuario existe.
    else
      return false;     //El usuario no existe.
  }

  //Ya que se verificó que existe el usuario, se obtiene el tipo el usuario
  private String getTipo(String rfc)
  {
    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    cadSql = "select Tipo from PCUsuarios where RFC='" + Login1.UserName;
    GestorBD.consBD(cadSql, "Tipo", DsGeneral);

    return DsGeneral.Tables["Tipo"].Rows[0]["Tipo"].ToString();
  }

}
