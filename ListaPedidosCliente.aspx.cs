using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaPedidos : System.Web.UI.Page {
  //Atributos de la clase.
  String cadSql, rfc;
  GestorBD.GestorBD GestorBD;
  DataSet DsGeneral = new DataSet(), DsPedidos= new DataSet();
  DataSet DsArtículos = new DataSet(), DsPagos = new DataSet();
  DataRow fila;
  Comunes comunes = new Comunes();

  //Acciones iniciales.
  protected void Page_Load(object sender, EventArgs e) {
    if (!IsPostBack) {
      //Recupera los objetos de sesión.
      rfc = Session["RFC"].ToString();
      GestorBD= (GestorBD.GestorBD)Session["GestorBD"];

      //Lee los datos del usuario.
      cadSql = "select * from PCUsuarios u, PCClientes c where u.RFC='" + rfc +
        "' and u.RFC=c.RFC";
      GestorBD.consBD(cadSql, "Usuario", DsGeneral);
      fila = DsGeneral.Tables["Usuario"].Rows[0];

      //Asigna los valores de fila en la tabla.
      tblUsuario.Rows[1].Cells[0].Text = rfc;
      tblUsuario.Rows[1].Cells[1].Text = fila["Nombre"].ToString();
      tblUsuario.Rows[1].Cells[2].Text = fila["Domicilio"].ToString();

      //Carga los folios de los pedidos del cliente elegido.
      cadSql = "select * from PCPedidos where RFCC='"+rfc+"'";
      GestorBD.consBD(cadSql, "Pedidos", DsPedidos);
      comunes.cargaDDL(DDLPedidos, DsPedidos, "Pedidos", "FolioP");
      Session["DsPedidos"] = DsPedidos;
    }
  }

  //Muestra los datos del pedidos elegido en el DDL.
  protected void DDLPedidos_SelectedIndexChanged(object sender, EventArgs e) {
    DataRow[] filas;

    GestorBD = (GestorBD.GestorBD)Session["GestorBD"];
    DsPedidos = (DataSet)Session["DsPedidos"];

    //Primera alternativa: consultando de nuevo a la BD (puede ser costoso, aunque con 
    //datos actuales).
    //rfc = Session["RFC"].ToString();
    //cadSql = "select * from PCPedidos where RFCC='" + rfc + "' and FolioP=" + DDLPedidos.Text;
    //GestorBD.consBD(cadSql, "Pedidos", DsPedidos);
    //fila = DsPedidos.Tables["Pedidos"].Rows[0];

    //Segunda alternativa: usando la información que ya está en el DataSet (más eficiente,
    //pero puede tener datos desactualizados).
    filas = (DataRow[])DsPedidos.Tables["Pedidos"].Select("FolioP=" + DDLPedidos.Text);
    fila = filas[0];

    tblPedido.Rows[1].Cells[0].Text = fila["FolioP"].ToString();
    tblPedido.Rows[1].Cells[1].Text = fila["FechaPed"].ToString();
    tblPedido.Rows[1].Cells[2].Text = fila["Monto"].ToString();
    tblPedido.Rows[1].Cells[3].Text = fila["SaldoCli"].ToString();
    tblPedido.Rows[1].Cells[4].Text = fila["SaldoFacs"].ToString();

    //Lee y muestra los artículos del pedido elegido.
    cadSql = "select Nombre, CantPed, CantEnt from PCArtículos a, PCDetalle d " +
      "where FolioP=" + DDLPedidos.Text + " and a.IdArt=d.IdArt";
    GestorBD.consBD(cadSql, "Artículos", DsArtículos);
    grdArtículos.DataSource = DsArtículos.Tables["Artículos"];
    grdArtículos.DataBind();

    //Lee y muestra los pagos del pedido elegido.
    cadSql = "select IdPago, Fecha, Monto from PCPagos " +
      "where FolioP=" + DDLPedidos.Text;
    GestorBD.consBD(cadSql, "Pagos", DsPagos);
    grdPagos.DataSource = DsPagos.Tables["Pagos"];
    grdPagos.DataBind();
  }
}