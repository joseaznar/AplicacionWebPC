using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuInicioCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

  //Redirige a la lista de pedidos
  protected void btnListaPedidos_Click(object sender, EventArgs e)
  {
    Response.Redirect("ListaPedidosCliente.aspx");
  }

  //Redirige a la alta de pedidos
  protected void btnAltaPedido_Click(object sender, EventArgs e)
  {
    Response.Redirect("AltaPedidoCliente.aspx");
  }
}